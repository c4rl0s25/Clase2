using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace EjercicioADOConexion.DAL
{
    public class ServicioDeUsuarios
    {
        public void crearUsuario(NuevoUsuario usuario)
        {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("CreaUsuario",conection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@name",usuario.Name));
            comando.Parameters.Add(new SqlParameter("@clave", usuario.Clave));
            comando.Parameters.Add(new SqlParameter("@habilitar", usuario.Habilitar));
            conection.Open();
            comando.ExecuteNonQuery();
            conection.Close();
        }
        public void BorrarUsuario(int id)
        {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("BorrarUsuario", conection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Id", id));
            conection.Open();
            comando.ExecuteNonQuery();
            conection.Close();
        }
        public List<UsuarioGenerico> ListaTodosLosUsuarios()
        {
            SqlConnection conection = this.iniciarConexion();
            SqlCommand comando = new SqlCommand("ListarUsuarios",conection);
            comando.CommandType = CommandType.StoredProcedure;
            conection.Open();
            SqlDataReader lectorDeDatos = comando.ExecuteReader();
            List<UsuarioGenerico> usuarios = new List<UsuarioGenerico>();

            while (lectorDeDatos.Read())
            {
                UsuarioGenerico usuario = new UsuarioGenerico();
                usuario.Id = (int)lectorDeDatos.GetInt32(0);
                usuario.Name = lectorDeDatos.GetString(1);
                usuario.Clave = lectorDeDatos.GetString(2);
                usuario.Habilitar = lectorDeDatos.GetBoolean(3);
                usuarios.Add(usuario);
            }
            conection.Close();
            return usuarios;
        }
        private SqlConnection iniciarConexion()
        {
            SqlConnection conection = new SqlConnection();
            conection.ConnectionString = ConfigurationManager.ConnectionStrings["Tarea"].ConnectionString;
            return conection;
        }
    }
}
