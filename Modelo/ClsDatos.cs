﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class ClsDatos
    {

        #region Declaración de variables
        SqlConnection cnnConexion = null;
        SqlCommand cmdComando = null;
        SqlDataAdapter daAdaptador = null;
        DataTable Dtt = null;
        String strCadenaConexion = string.Empty;
        #endregion

        #region Constructor
        public ClsDatos()
        {
            strCadenaConexion = @"Data Source=DESKTOP-P6IASP1\SQLEXPRESS;Initial Catalog=Empresa;Integrated Security=True";
        }
        #endregion

        #region Métodos a ejecutar

        public void EjecutarSP(SqlParameter[] parParametros, string pasSPName)
        {
            try
            {
                cnnConexion = new SqlConnection(strCadenaConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cnnConexion.Open();
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = pasSPName;
                cmdComando.Parameters.AddRange(parParametros);
                cmdComando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

                
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
            }
        }


        public DataTable RetornaTabla(SqlParameter[] parParametros, string parTSQL)
        {
            Dtt = null;
            try
            {
                Dtt = new DataTable();
                cnnConexion = new SqlConnection(strCadenaConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = parTSQL;
                cmdComando.Parameters.AddRange(parParametros);

                daAdaptador = new SqlDataAdapter(cmdComando);
                daAdaptador.Fill(Dtt);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
                daAdaptador.Dispose();
            }

            return Dtt;

        }

        #endregion

    }

}
