using System.Configuration;

namespace Controlador
{

    /// <summary>
    /// Nombre de SP
    /// </summary>
    public enum ProcedimientosAlmacenados
    {
        /// <summary>
        /// consulta de datos para clientes
        /// </summary>
        sps_datos_cliente_por_identificacion,

        /// <summary>
        /// consulta de datos para prestamos
        /// </summary>
        sps_datos_prestamos_por_identificacion,

        /// <summary>
        /// inserta el conocimiento modelo en la base de datos
        /// </summary>
        spi_model_knowledge,

        /// <summary>
        /// elimina el conocimiento posterior del modelo y deja por defecto
        /// </summary>
        spd_model_knowledge,

        /// <summary>
        /// selecciona el conocimiento del modelo actual
        /// </summary>
        sps_model_knowledge,

        /// <summary>
        /// Actualiza el valor del incumplimiento
        /// </summary>
        spu_incumplimiento,

        /// <summary>
        /// elimina los datos de datos cliente vars
        /// </summary>
        spd_vars,

        /// <summary>
        /// elimina los datos de 
        /// </summary>
        spd_vals,

        /// <summary>
        /// Consulta datos de clientes con sus variables agrupadas
        /// </summary>
        sps_datos_clientes_and_vars,

        /// <summary>
        /// Consulta los valores clave del ajuste de tasas de interes
        /// </summary>
        sps_vals
    }

    /// <summary>
    /// Clase para referenciar valores constantes
    /// </summary>
    public static class Constantes {
        /// <summary>
        /// Tipos basicos de graficos
        /// </summary>
        public static string[] TipoGragicosBasicos = new string [] { "Column", "Bar", "Pie"};

    }

    /// <summary>
    /// Codigo Python de refencia para interoperabilidad
    /// </summary>
    public static class CodeRef {

        /// <summary>
        /// Codigo de referencia para el calcuilo de estaidsitcas
        /// </summary>
        /// <returns></returns>
        public static string calculateVarsTrain()
        {
            return $@"
import pandas
import pyodbc
import numpy

STRING_CONNECTION = '{new AppSettingsReader().GetValue("PythonConnectionString", string.Empty.GetType())}'

def insert_dataframe(df, table_name):
    cnxn = pyodbc.connect(STRING_CONNECTION)
    cursor = cnxn.cursor()
    columns = ', '.join(df.columns)
    placeholders = ', '.join('?' * len(df.columns))
    insert_sql = 'INSERT INTO ' + table_name + ' (' + columns + ') VALUES (' + placeholders + ')'
    for _, row in df.iterrows():
        cursor.execute(insert_sql, row.tolist())
    cnxn.commit()
    cnxn.close()

def indicatriz_default(mora, cartera) -> int:
    return int(mora > 60 and cartera > 100)

def agrupacion_variables(datos_u:pandas.DataFrame, datos_p:pandas.DataFrame, item= '',
        operaciones=['media', 'std', 'var', 'area']):
    if not operaciones is None:
        datos_p_util = datos_p.groupby(['identificacion'])['incumplimiento'].max()
        datos_p_util =  pandas.concat([datos_p_util, datos_p.groupby([
            'identificacion'])[item].mean().rename(item + '_' + operaciones[0])], axis=1)
        datos_p_util =  pandas.concat([datos_p_util, datos_p.groupby([
            'identificacion'])[item].std().rename(item + '_' + operaciones[1])], axis=1)
        datos_p_util =  pandas.concat([datos_p_util, datos_p.groupby([
            'identificacion'])[item].var().rename(item + '_' + operaciones[2])], axis=1)
        for idt in datos_p_util.index:
            vector = numpy.array(datos_p[item])
            datos_p_util.at[idt, item + '_' + operaciones[3]] = numpy.trapz(vector)
        datos_p_util.reset_index()
        if 'incumplimiento' in datos_u.columns:
            datos_p_util.drop(columns=['incumplimiento'], inplace=True)
        datos_u = pandas.merge(datos_u, datos_p_util, on='identificacion', how='left') 
    else:
        datos_u =  pandas.concat([datos_u, datos_p.groupby(
            ['identificacion'])[item].max().reset_index()], axis=1)
        if 'incumplimiento.1' in datos_u.columns:
            datos_u.drop(columns=['incumplimiento.1'], inplace=True)
    return datos_u

def acumulacion_mora(mora) -> int:
    return int (mora > 60/2 )

def calculate(df_unicos:pandas.DataFrame, df_prestamos:pandas.DataFrame):
    df_prestamos = df_prestamos[df_prestamos['cartera_total'] > 100]
    df_unicos = df_unicos[df_unicos['ingreso_mensual'] >= 400]
    df_unicos_f = df_unicos[['identificacion']].dropna().drop_duplicates()
    df_prestamos_f = df_prestamos[['identificacion']].dropna().drop_duplicates()
    df_interseccion = pandas.merge(df_unicos_f, df_prestamos_f, how='inner', on='identificacion')
    df_unicos=df_unicos[df_unicos['identificacion'].apply(
        lambda x: x in list(df_interseccion['identificacion']))]
    df_prestamos = df_prestamos[df_prestamos['identificacion'].apply(
        lambda x: x in list(df_interseccion['identificacion']))]
    df_prestamos['acumulacion_mora'] = df_prestamos.apply(
            lambda row : acumulacion_mora(row['dias_mora']), axis=1)
    df_prestamos['incumplimiento'] = df_prestamos.apply(lambda row : indicatriz_default(row['dias_mora'],
        row['saldo_por_vencer'] + row['saldo_vencido'] + row['saldo_no_devenga']), axis=1)
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'saldo_por_vencer')
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'saldo_vencido')
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'saldo_no_devenga')
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'cartera_total')
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'cartera_en_riesgo')
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'saldo_mora')
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'dias_mora')
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'vida_prestamo', None)
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'monto_prestamo', None)
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'plazo', None)
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'acumulacion_mora', None)
    return df_unicos

conn = pyodbc.connect(STRING_CONNECTION)
df_unicos = pandas.read_sql('select* from datos_cliente', conn)
df_prestamos = pandas.read_sql('select * from datos_prestamos', conn)
cursor = conn.cursor()
result = calculate(df_unicos, df_prestamos)[['identificacion', 'saldo_por_vencer_media', 'saldo_por_vencer_std',
       'saldo_por_vencer_var', 'saldo_por_vencer_area', 'saldo_vencido_media',
       'saldo_vencido_std', 'saldo_vencido_var', 'saldo_vencido_area',
       'saldo_no_devenga_media', 'saldo_no_devenga_std',
       'saldo_no_devenga_var', 'saldo_no_devenga_area', 'cartera_total_media',
       'cartera_total_std', 'cartera_total_var', 'cartera_total_area',
       'cartera_en_riesgo_media', 'cartera_en_riesgo_std',
       'cartera_en_riesgo_var', 'cartera_en_riesgo_area', 'saldo_mora_media',
       'saldo_mora_std', 'saldo_mora_var', 'saldo_mora_area',
       'dias_mora_media', 'dias_mora_std', 'dias_mora_var', 'dias_mora_area',
       'vida_prestamo', 'monto_prestamo', 'plazo', 'acumulacion_mora']]
result = result.T.drop_duplicates().T
result['incumplimiento'] = result['dias_mora_media'].apply(lambda x: int(x > 60))
conn = pyodbc.connect(STRING_CONNECTION)
cursor = conn.cursor()
cursor.execute('spd_vars_train')
conn.commit()
conn.close()
insert_dataframe(result, 'datos_cliente_vars_train')
";
        }

        /// <summary>
        /// Codigo de referencia para el calcuilo de estaidsitcas
        /// </summary>
        /// <returns></returns>
        public static string calculateVars() {
            return $@"
import pandas
import pyodbc
import numpy

STRING_CONNECTION = '{new AppSettingsReader().GetValue("PythonConnectionString", string.Empty.GetType())}'

def insert_dataframe(df, table_name):
    cnxn = pyodbc.connect(STRING_CONNECTION)
    cursor = cnxn.cursor()
    columns = ', '.join(df.columns)
    placeholders = ', '.join('?' * len(df.columns))
    insert_sql = 'INSERT INTO ' + table_name + ' (' + columns + ') VALUES (' + placeholders + ')'
    for _, row in df.iterrows():
        cursor.execute(insert_sql, row.tolist())
    cnxn.commit()
    cnxn.close()

def indicatriz_default(mora, cartera) -> int:
    return int(mora > 60 and cartera > 100)

def agrupacion_variables(datos_u:pandas.DataFrame, datos_p:pandas.DataFrame, item= '',
        operaciones=['media', 'std', 'var', 'area']):
    if not operaciones is None:
        datos_p_util = datos_p.groupby(['identificacion'])['incumplimiento'].max()
        datos_p_util =  pandas.concat([datos_p_util, datos_p.groupby([
            'identificacion'])[item].mean().rename(item + '_' + operaciones[0])], axis=1)
        datos_p_util =  pandas.concat([datos_p_util, datos_p.groupby([
            'identificacion'])[item].std().rename(item + '_' + operaciones[1])], axis=1)
        datos_p_util =  pandas.concat([datos_p_util, datos_p.groupby([
            'identificacion'])[item].var().rename(item + '_' + operaciones[2])], axis=1)
        for idt in datos_p_util.index:
            vector = numpy.array(datos_p[item])
            datos_p_util.at[idt, item + '_' + operaciones[3]] = numpy.trapz(vector)
        datos_p_util.reset_index()
        if 'incumplimiento' in datos_u.columns:
            datos_p_util.drop(columns=['incumplimiento'], inplace=True)
        datos_u = pandas.merge(datos_u, datos_p_util, on='identificacion', how='left') 
    else:
        datos_u =  pandas.concat([datos_u, datos_p.groupby(
            ['identificacion'])[item].max().reset_index()], axis=1)
        if 'incumplimiento.1' in datos_u.columns:
            datos_u.drop(columns=['incumplimiento.1'], inplace=True)
    return datos_u

def acumulacion_mora(mora) -> int:
    return int (mora > 60/2 )

def calculate(df_unicos:pandas.DataFrame, df_prestamos:pandas.DataFrame):
    df_prestamos = df_prestamos[df_prestamos['cartera_total'] > 100]
    df_unicos = df_unicos[df_unicos['ingreso_mensual'] >= 400]
    df_unicos_f = df_unicos[['identificacion']].dropna().drop_duplicates()
    df_prestamos_f = df_prestamos[['identificacion']].dropna().drop_duplicates()
    df_interseccion = pandas.merge(df_unicos_f, df_prestamos_f, how='inner', on='identificacion')
    df_unicos=df_unicos[df_unicos['identificacion'].apply(
        lambda x: x in list(df_interseccion['identificacion']))]
    df_prestamos = df_prestamos[df_prestamos['identificacion'].apply(
        lambda x: x in list(df_interseccion['identificacion']))]
    df_prestamos['acumulacion_mora'] = df_prestamos.apply(
            lambda row : acumulacion_mora(row['dias_mora']), axis=1)
    df_prestamos['incumplimiento'] = df_prestamos.apply(lambda row : indicatriz_default(row['dias_mora'],
        row['saldo_por_vencer'] + row['saldo_vencido'] + row['saldo_no_devenga']), axis=1)
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'saldo_por_vencer')
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'saldo_vencido')
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'saldo_no_devenga')
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'cartera_total')
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'cartera_en_riesgo')
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'saldo_mora')
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'dias_mora')
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'vida_prestamo', None)
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'monto_prestamo', None)
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'plazo', None)
    df_unicos = agrupacion_variables(df_unicos, df_prestamos, 'acumulacion_mora', None)
    return df_unicos

conn = pyodbc.connect(STRING_CONNECTION)
df_unicos = pandas.read_sql('select* from datos_cliente', conn)
df_prestamos = pandas.read_sql('select * from datos_prestamos', conn)
cursor = conn.cursor()
result = calculate(df_unicos, df_prestamos)[['identificacion', 'saldo_por_vencer_media', 'saldo_por_vencer_std',
       'saldo_por_vencer_var', 'saldo_por_vencer_area', 'saldo_vencido_media',
       'saldo_vencido_std', 'saldo_vencido_var', 'saldo_vencido_area',
       'saldo_no_devenga_media', 'saldo_no_devenga_std',
       'saldo_no_devenga_var', 'saldo_no_devenga_area', 'cartera_total_media',
       'cartera_total_std', 'cartera_total_var', 'cartera_total_area',
       'cartera_en_riesgo_media', 'cartera_en_riesgo_std',
       'cartera_en_riesgo_var', 'cartera_en_riesgo_area', 'saldo_mora_media',
       'saldo_mora_std', 'saldo_mora_var', 'saldo_mora_area',
       'dias_mora_media', 'dias_mora_std', 'dias_mora_var', 'dias_mora_area',
       'vida_prestamo', 'monto_prestamo', 'plazo', 'acumulacion_mora']]
result = result.T.drop_duplicates().T
result['incumplimiento'] = result['dias_mora_media'].apply(lambda x: int(x > 60))
conn = pyodbc.connect(STRING_CONNECTION)
cursor = conn.cursor()
cursor.execute('spd_vars')
conn.commit()
conn.close()
insert_dataframe(result, 'datos_cliente_vars')
";
        }

        /// <summary>
        /// Codigo de referencia para ajustar variables de la aplicacion estadistica
        /// </summary>
        /// <param name="umbral"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <param name="raroc"></param>
        /// <returns></returns>
        public static string ajust(int umbral, decimal max, decimal min, decimal raroc) {
            return $@"
import pyodbc

STRING_CONNECTION='{new AppSettingsReader().GetValue("PythonConnectionString", string.Empty.GetType())}'
MAX_TASA_INTERES={max.ToString(System.Globalization.CultureInfo.InvariantCulture)}
MIN_TASA_INTERES={min.ToString(System.Globalization.CultureInfo.InvariantCulture)}
UMBRAL_DEFAULT={umbral.ToString(System.Globalization.CultureInfo.InvariantCulture)}
RAROCFACTOR={raroc.ToString(System.Globalization.CultureInfo.InvariantCulture)}
MINIMA_CARTERA=100

conn = pyodbc.connect(STRING_CONNECTION)
cursor = conn.cursor()
insert_query = 'spi_model_knowledge @umbral=?,@tasamax=?,@tasamin=?,@raroc=?,@data=NULL'
params = (UMBRAL_DEFAULT, MAX_TASA_INTERES ,MIN_TASA_INTERES, RAROCFACTOR)
cursor.execute(insert_query, params)
conn.commit()
conn.close()
";
        }

        /// <summary>
        /// Entrena la regresion para el calculo de la probabilidad de incumplimiento
        /// </summary>
        /// <returns></returns>
        public static string train() {
            return $@"
import io
import joblib
import pyodbc
import pandas
from scipy.stats import norm
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LogisticRegression
from sklearn.preprocessing import LabelEncoder

STRING_CONNECTION = '{new AppSettingsReader().GetValue("PythonConnectionString", string.Empty.GetType())}'

def save_model_to_database(model, connection_string):
    output = io.BytesIO()
    joblib.dump(model, output, compress=True)
    model_data = output.getvalue()
    conn = pyodbc.connect(connection_string)
    cursor = conn.cursor()
    insert_query = 'spi_model_knowledge @data=?'
    params = (model_data)
    cursor.execute(insert_query, params)
    conn.commit()
    conn.close()

conn = pyodbc.connect(STRING_CONNECTION)
cursor = conn.cursor()
cursor.execute('exec sps_datos_clientes_and_vars_train')
results = cursor.fetchall()
df_unicos = pandas.DataFrame.from_records(results, columns=[column[0] for column in cursor.description])
df_prestamos = pandas.read_sql('select * from datos_prestamos_train', conn)
conn.close()
del results

categorical_columns = ['fecha_nacimiento', 'estado_civil', 'sexo', 'nivel_academico',
                       'origen_ingresos', 'situacion_laboral']
for col in categorical_columns:
    label_encoder = LabelEncoder()
    df_unicos[col] = label_encoder.fit_transform(df_unicos[col])

X = df_unicos.drop(['incumplimiento','identificacion'], axis=1)
y = df_unicos['incumplimiento']

model = LogisticRegression()
model.fit(X, y)

save_model_to_database(model, STRING_CONNECTION)

output=''
coeficientes = model.coef_[0]
for feature, coef in zip(X.columns, coeficientes):
    output += feature+'\t'+str(coef)+'\n'

";
        }

        /// <summary>
        /// Calcula los valores clave del ajuste de tasas de interes
        /// </summary>
        /// <returns></returns>
        public static string predict() {
            return $@"
import io
import math
import joblib
import pyodbc
import pandas
from sklearn.preprocessing import LabelEncoder

STRING_CONNECTION = '{new AppSettingsReader().GetValue("PythonConnectionString", string.Empty.GetType())}'
MINIMA_CARTERA=100
conn = pyodbc.connect(STRING_CONNECTION)
cursor = conn.cursor()
cursor.execute('sps_model_knowledge')
paramslist = cursor.fetchone()
UMBRAL_DEFAULT=paramslist[0]
MAX_TASA_INTERES=paramslist[1]
MIN_TASA_INTERES=paramslist[2]
RAROCFACTOR=paramslist[3]
binary_data = paramslist[-1]
binary_stream = io.BytesIO(binary_data)
model = joblib.load(binary_stream)
cursor.execute('exec sps_datos_clientes_and_vars')
results = cursor.fetchall()
df_unicos = pandas.DataFrame.from_records(results, columns=[column[0] for column in cursor.description])
conn.close()
del results

def insert_dataframe(df, table_name):
    cnxn = pyodbc.connect(STRING_CONNECTION)
    cursor = cnxn.cursor()
    columns = ', '.join(df.columns)
    placeholders = ', '.join('?' * len(df.columns))
    insert_sql = 'INSERT INTO ' + table_name + ' (' + columns + ') VALUES (' + placeholders + ')'
    for _, row in df.iterrows():
        cursor.execute(insert_sql, row.tolist())
    cnxn.commit()
    cnxn.close()

def calc_ead(value:float) -> float:
    return value*( 1/(1 + math.exp(-3*UMBRAL_DEFAULT/2)) )

def calc_lgd(value, monto):
    return 1-(monto-value)/monto

def acumulacion_mora(mora, cartera) -> int:
    return int(mora > UMBRAL_DEFAULT/2 )

def indicatriz_default(mora, cartera) -> int:
    return int(mora > UMBRAL_DEFAULT and cartera > MINIMA_CARTERA)

def calc_perdida_inesperada(pd, ead, lgd):
    return ead*math.sqrt( pd*lgd*(1-lgd) + (lgd**2)*pd*(1-pd) )

def asignar_tasa(value:float ):
    return (2*(MAX_TASA_INTERES - MIN_TASA_INTERES))/(1+math.exp(-(MAX_TASA_INTERES - MIN_TASA_INTERES)*value/RAROCFACTOR))+(2*MIN_TASA_INTERES-MAX_TASA_INTERES)

categorical_columns = ['fecha_nacimiento', 'estado_civil', 'sexo', 'nivel_academico','origen_ingresos', 'situacion_laboral']
for col in categorical_columns:
    label_encoder = LabelEncoder()
    df_unicos[col] = label_encoder.fit_transform(df_unicos[col])

X = df_unicos.drop(['incumplimiento','identificacion'], axis=1)
probabilidad_default = model.predict_proba(X)
df_unicos['PD'] = probabilidad_default[:,1]
df_unicos['EAD'] = df_unicos.apply(lambda row :calc_ead(row['cartera_total_media']), axis=1 ) 
df_unicos['LGD'] = df_unicos.apply(lambda row:calc_lgd(row['cartera_total_media'], row['monto_prestamo']), axis=1)
df_unicos['LGD'] = df_unicos['LGD'].apply(lambda x: x if x <= 1 else 1)
df_unicos['PE'] = df_unicos['PD']*df_unicos['EAD']*df_unicos['LGD']
df_unicos['PE']=df_unicos.apply(lambda row : row['monto_prestamo'] if row['PE'] > row['monto_prestamo'] else row['PE'], axis=1)
df_unicos['PI']=df_unicos.apply(lambda row: calc_perdida_inesperada( row['PD'], row['EAD'], row['LGD']), axis=1)
df_unicos['tasa_ajustada'] = df_unicos.apply( lambda row : (row['PE'] + row['PI'])/(row['monto_prestamo'] ), axis=1 )
df_unicos['tasa_ajustada'] = df_unicos['tasa_ajustada'].apply( lambda x: asignar_tasa(x))
df_unicos = df_unicos[['identificacion','PD', 'EAD', 'LGD', 'PE', 'PI', 'tasa_ajustada']]
conn = pyodbc.connect(STRING_CONNECTION)
cursor = conn.cursor()
cursor.execute('spd_vals')
conn.commit()
conn.close()
insert_dataframe(df_unicos, 'datos_cliente_values')

";
        }

        /// <summary>
        /// Guarda un dataFrame recuperado de un sp a un excel
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string saveExcel(string filepath)
        {
            return $@"
import pyodbc
import pandas as pd

conn = pyodbc.connect('{new AppSettingsReader().GetValue("PythonConnectionString", string.Empty.GetType())}')
cursor = conn.cursor()
cursor.execute('sps_results')

# Extraer los datos
data = cursor.fetchall()
column_names = [column[0] for column in cursor.description]
df = pd.DataFrame.from_records(data, columns=column_names)
df.to_excel(r'{filepath}', index=False)
cursor.close()
conn.close()
";
        }

    }

}
