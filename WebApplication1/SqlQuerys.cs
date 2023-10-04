using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class SqlQuerys
    {
        string strConexion = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        public bool InsertarCuenta(string descripcion)
        {
            SqlConnection con = new SqlConnection(strConexion);

            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("Insert into Cuentas values(@descripcion)", con);

                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                int result = cmd.ExecuteNonQuery(); 
                if(result > 0) return true; else return false;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
            finally { con.Close(); }    

            
        }

        public bool EditarCuenta(int id, string descripcion)
        {
            SqlConnection con = new SqlConnection(strConexion);

            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("update Cuentas set descripcion = @descripcion where idCuenta = @idCuenta", con);

                cmd.Parameters.AddWithValue("@idCuenta", id);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                   cmd.ExecuteNonQuery();
                return true;
          

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
             
            }
            finally { con.Close(); }


        }
        public bool EliminarCuenta(int id)
        {
            SqlConnection con = new SqlConnection(strConexion);

            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("delete from Cuentas where idCuenta = @idCuenta", con);

                cmd.Parameters.AddWithValue("@idCuenta", id);
                cmd.ExecuteNonQuery();
                return true;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;

            }
            finally { con.Close(); }


        }
        public bool ExistsCuenta(string nombreCuenta)
        {
            SqlConnection con = new SqlConnection(strConexion);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(@"select count(idCuenta) result from Cuentas where
 descripcion like @cuenta", con);

                cmd.Parameters.AddWithValue("@cuenta", nombreCuenta);

                int result = Convert.ToInt32(cmd.ExecuteScalar());

                if (result > 0) return true; else  return false; 

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return true;
            }
            finally { con.Close(); }
        }


       public DataTable ListarCuentas()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(strConexion);

            con.Open();
            try
            {

                SqlCommand cmd = new SqlCommand("Select * from Cuentas", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
            finally { con.Close(); }
        }

        internal bool InsertarRegistroContable(int idCuenta,  double monto, int Tipo)
        {
            SqlConnection con = new SqlConnection(strConexion);

            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("Insert into RegistrosContables values(@idCuenta, @monto, @tipo)", con);

                cmd.Parameters.AddWithValue("@idCuenta", idCuenta);
                cmd.Parameters.AddWithValue("@monto", monto);
                cmd.Parameters.AddWithValue("@tipo", Tipo);
                int result = cmd.ExecuteNonQuery();
                if (result > 0) return true; else return false;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
            finally { con.Close(); }
        }

        public RegistroContableModel ObtenerRegistroContablePorId(int id)
        {
            SqlConnection con = new SqlConnection(strConexion);
            RegistroContableModel result = new RegistroContableModel();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(@"select id, idCuenta, monto, tipo from RegistrosContables
   where id = @id ", con);

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = cmd.ExecuteReader(); 
                if (dr != null) {
                    dr.Read();
                    result.idCuenta = Convert.ToInt32(dr["idCuenta"]);
                    result.monto = Convert.ToDouble(dr["monto"]);
                    result.tipo = Convert.ToInt32(dr["tipo"]);
                }
                dr.Close();
                return result;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
            finally { con.Close(); }
        }

       

        public bool EliminarRegistroContable(int id)
        {
            SqlConnection con = new SqlConnection(strConexion);

            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("delete from RegistrosContables where id = @id", con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;

            }
            finally { con.Close(); }
        }

        internal bool ActualizarRegistroContable(RegistroContableModel model)
        {
            SqlConnection con = new SqlConnection(strConexion);

            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(@"update RegistrosContables set idCuenta = @idCuenta, tipo = @tipo, 
monto = @monto where id = @id", con);

                cmd.Parameters.AddWithValue("@id", model.id);
                cmd.Parameters.AddWithValue("@idCuenta", model.idCuenta);
                cmd.Parameters.AddWithValue("@tipo", model.tipo);
                cmd.Parameters.AddWithValue("@monto", model.monto);

                cmd.ExecuteNonQuery();
                return true;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;

            }
            finally { con.Close(); }
        }
    }
}