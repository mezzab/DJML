using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;



namespace AerolineaFrba
{
    public class Query
    {
        private enum TipoQuery
        {
            Obtener, Ejecutar
        }

        string CadenaConexion = AerolineaFrba.Properties.Settings.Default.CadenaDeConexion;
        public string pComando { get; set; }
        public List<SqlParameter> pParametros = new List<SqlParameter>();
        public int pTimeOut = 0;
        public CommandType? pTipoComando;


        public Query(string _Comando)
        {
            this.pComando = _Comando;
        }



        public DataTable ObtenerDataTable()
        {
            SqlConnection sqlConnection = new SqlConnection();
            DataTable dataTable = new DataTable();
            try
            {
                sqlConnection.ConnectionString = this.CadenaConexion;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = this.GetCommandType(Query.TipoQuery.Obtener);
                sqlCommand.CommandText = this.pComando;
                SqlCommand selectCommand = sqlCommand;
                selectCommand.CommandTimeout = this.pTimeOut;
                if (this.pParametros != null)
                {
                    foreach (SqlParameter sqlParameter in this.pParametros)
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                    }
                }
                sqlConnection.Open();
                new SqlDataAdapter(selectCommand).Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return dataTable;
        }

        public object ObtenerUnicoCampo()
        {
            SqlConnection sqlConnection = new SqlConnection();
            object obj;
            try
            {
                sqlConnection.ConnectionString = this.CadenaConexion;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = this.GetCommandType(Query.TipoQuery.Obtener);
                sqlCommand.CommandText = this.pComando;
                sqlCommand.CommandTimeout = this.pTimeOut;
                if (this.pParametros != null)
                {
                    foreach (SqlParameter sqlParameter in this.pParametros)
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                    }
                }
                sqlConnection.Open();
                obj = sqlCommand.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + Environment.NewLine + pComando);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return obj;
        }

        public bool Ejecutar()
        {
            int num = 1;
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = this.CadenaConexion;
                SqlCommand sqlCommand = new SqlCommand(this.pComando, connection);
                if (this.pParametros != null)
                {
                    foreach (SqlParameter sqlParameter in this.pParametros)
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                    }
                }
                sqlCommand.CommandTimeout = this.pTimeOut;
                sqlCommand.CommandType = this.GetCommandType(Query.TipoQuery.Ejecutar);
                connection.Open();
                num = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return (num == 1);
        }

        private CommandType GetCommandType(Query.TipoQuery _TipoQuery)
        {
            if (this.pTipoComando.HasValue)
                return this.pTipoComando.Value;
            if (this.pComando.TrimStart(new char[1] { ' ' }).StartsWith("exec ", StringComparison.InvariantCultureIgnoreCase))
            {
                this.pComando = this.pComando.Remove(0, 5);
                return CommandType.StoredProcedure;
            }
            else
            {
                switch (_TipoQuery)
                {
                    case Query.TipoQuery.Ejecutar:
                        return this.pComando.ToLowerInvariant().Contains("update ") || this.pComando.ToLowerInvariant().Contains("insert ")
                            || this.pComando.ToLowerInvariant().Contains("delete ") ? CommandType.Text : CommandType.StoredProcedure;
                    default:
                        return this.pComando.ToLowerInvariant().Contains("select ") ? CommandType.Text : CommandType.StoredProcedure;
                }
            }
        }
    }
}