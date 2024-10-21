using Minimalapi.Dominio.Entidades;
using Minimalapi.DTOs;

namespace Minimalapi.Dominio.Interfaces;

public interface IVeiculoServico
{
    List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null);
    Veiculo? BuscaPorId(int id);
    void Incluir(Veiculo Veiculo);
    void Atualizar(Veiculo Veiculo);
    void Apagar(Veiculo Veiculo);

}