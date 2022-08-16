using BaseUsuarios.Models;
using System.Collections.Generic;

namespace BaseUsuarios.Repositorios
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);
        UsuarioModel BuscarPorEmaileLogin(string email, string login);
    }
}
