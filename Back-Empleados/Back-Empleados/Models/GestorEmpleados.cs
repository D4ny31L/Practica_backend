using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Back_Empleados.Models
{
    public class GestorEmpleados
    {
        public List<Empleados> GetEmpleados()
        {
            List<Empleados> lista = new List<Empleados>();
            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Trabajadores_select";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string sexh;
                    int id = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    string apellidop = dr.GetString(2).Trim();
                    string apellidom = dr.GetString(3).Trim();
                    string telefono = dr.GetString(4).Trim();
                    bool sexo = dr.GetBoolean(5);
                    if (sexo == true)
                    {
                        sexh = "hombre";
                    }
                    else {sexh = "mujer"; }
                    DateTime nacimiento = dr.GetDateTime(6);
                    string nacimientos = nacimiento.ToString("MM/dd/yyyy");

                    Empleados empleados = new Empleados(id, nombre, apellidop, apellidom, telefono, sexh, nacimientos);
                    lista.Add(empleados);
                }
                dr.Close();
                conn.Close();
            }

            return lista;
        }
        public bool Addempleado(Empleados empleados)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                if (empleados.Sexo == "hombre")
                {
                    se = true;
                }
                else { se = false; }
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Trabajadores_Agregar";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", empleados.Nombre);
                cmd.Parameters.AddWithValue("@apellidoP", empleados.Apellidop);
                cmd.Parameters.AddWithValue("@apellidoM", empleados.Apellidom);
                cmd.Parameters.AddWithValue("@telefono", empleados.Telefono);
                cmd.Parameters.AddWithValue("@sexo", se);
                cmd.Parameters.AddWithValue("@fec_nacimiento", empleados.Nacimiento);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }
                return res;

            }
        }
        public bool se;

        public bool Updateempleado(int id, Empleados empleados)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                
                if(empleados.Sexo == "hombre")
                {
                    se = true;
                }
                else { se = false; }
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Trabajadores_Modif";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", empleados.ID_empleado);
                cmd.Parameters.AddWithValue("@nombre", empleados.Nombre);
                cmd.Parameters.AddWithValue("@apellidoP", empleados.Apellidop);
                cmd.Parameters.AddWithValue("@apellidoM", empleados.Apellidom);
                cmd.Parameters.AddWithValue("@telefono", empleados.Telefono);
                cmd.Parameters.AddWithValue("@sexo", se);
                cmd.Parameters.AddWithValue("@fec_nacimiento", empleados.Nacimiento);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }
                return res;

            }
        }
        public bool Deleteempleado(int id)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Trabajadores_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }
                return res;

            }
        }
        public List<Empleados> GetOne(int id)
        {
            List<Empleados> lista = new List<Empleados>();
            string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Trabajadores_SelectOne";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string sexh;
                    id = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    string apellidop = dr.GetString(2).Trim();
                    string apellidom = dr.GetString(3).Trim();
                    string telefono = dr.GetString(4).Trim();
                    bool sexo = dr.GetBoolean(5);
                    if (sexo == true)
                    {
                        sexh = "hombre";
                    }
                    else { sexh = "mujer"; }
                    DateTime nacimiento = dr.GetDateTime(6);
                    string nacimientos = nacimiento.ToString("MM/dd/yyyy");

                    Empleados empleados = new Empleados(id, nombre, apellidop, apellidom, telefono, sexh, nacimientos);
                    lista.Add(empleados);
                }
                dr.Close();
                conn.Close();
            }

            return lista;
        }
    }
}