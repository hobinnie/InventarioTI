
using InventarioTI.Models;

//interfaz


namespace InventarioTI.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string Nombre_usuario, string contraseña); //devolver un usuario a traves de un nombre de usuario y una clave

        Task<Usuario> SaveUsuario(Usuario modelo);
    }
}
