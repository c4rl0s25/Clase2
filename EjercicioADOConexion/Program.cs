using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjercicioADOConexion.DAL;
namespace EjercicioADOConexion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Insertar Usuarios
            ServicioDeUsuarios servicioUsuario = new ServicioDeUsuarios();
            /*NuevoUsuario nuevoUsuario = new NuevoUsuario();
            nuevoUsuario.Name = "pepito";
            nuevoUsuario.Clave = "axasd";
            nuevoUsuario.Habilitar = true;
            
            nuevoUsuario.Name = "Marco";
            nuevoUsuario.Clave = "aada";
            nuevoUsuario.Habilitar = true;
            servicioUsuario.crearUsuario(nuevoUsuario);*/

            //Eliminar Usuario
            servicioUsuario.BorrarUsuario(10);

            //Listar usuarios
            servicioUsuario.ListaTodosLosUsuarios().ForEach(usuario =>Console.WriteLine(usuario.Name));

           
            Console.ReadKey();
        }
    }
}
