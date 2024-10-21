using Minimalapi.Dominio.Entidades;
using Minimalapi.Dominio.Interfaces;
using Minimalapi.DTOs;

namespace Test.Mocks
{
    public class AdministradorServicoMock : IAdministradorServico
    {
        private static List<Administrador> Administradores = new List<Administrador>(){
            new Administrador{
                Id = 1,
                Email = "adm@teste.com",
                Senha = "123456",
                Perfil = "Adm"
            },
             new Administrador{
                Id = 2,
                Email = "editor@teste.com",
                Senha = "123456",
                Perfil = "Editor"
            }
        };

        public Administrador? BuscarPorId(int id)
        {
            return Administradores.Find(a => a.Id == id);
        }

        public Administrador Incluir(Administrador administrador)
        {
            administrador.Id = Administradores.Count() + 1;
            Administradores.Add(administrador);

            return administrador;
        }

        public Administrador? Login(LoginDTO loginDTO)
        {
            return Administradores.Find(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha);
        }

        public List<Administrador> Todos(int? pagina)
        {
            return Administradores;
        }
    }
}
