using RegistroUsiariosJOBOAPI.Models;

namespace RegistroUsiariosJOBOAPI.Servicios
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetAll();
        Usuario? GetById(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
    }
}
