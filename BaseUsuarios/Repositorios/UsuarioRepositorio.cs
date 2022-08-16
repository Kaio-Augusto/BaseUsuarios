using BaseUsuarios.Data;
using BaseUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseUsuarios.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoDados _bancoDados;
        public UsuarioRepositorio(BancoDados bancoDados) 
        { 
            _bancoDados = bancoDados;
        }
        public UsuarioModel ListarPorId(int id)
        {
            return _bancoDados.Usuarios.FirstOrDefault(x=> x.Id == id);
        }
        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoDados.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscarPorEmaileLogin(string email, string login)
        {
            return _bancoDados.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoDados.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            // gravar no banco de dados
            usuario.DataDeCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _bancoDados.Usuarios.Add(usuario);
            _bancoDados.SaveChanges();
             
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = ListarPorId(usuario.Id);

            if (usuarioDb == null) throw new System.Exception("Houve um erro na alteração do usuário!");
            
            usuarioDb.Nome = usuario.Nome;
            usuarioDb.CPF = usuario.CPF;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Email = usuario.Email;
            usuarioDb.NomeDaMae = usuario.NomeDaMae;
            usuarioDb.Senha = usuario.Senha;
            usuarioDb.DataDeNascimento = usuario.DataDeNascimento;
            usuarioDb.DataAlteracao = DateTime.Now;

            _bancoDados.Update(usuarioDb);
            _bancoDados.SaveChanges();
            
            return usuarioDb;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDb = ListarPorId(id);
            
            if (usuarioDb == null) throw new System.Exception("Houve um erro na remoção do usuário!");
            
            _bancoDados.Usuarios.Remove(usuarioDb);
            _bancoDados.SaveChanges();

            return true;                
        }


    }
}
