using BaseUsuarios.Models;

namespace BaseUsuarios.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usario);
        void RemoverSessaoDoUsuario();
        UsuarioModel BuscarSessaoDoUsuario();
    }
}
