using Microsoft.EntityFrameworkCore;
using Minimalapi.Dominio.Entidades;
using Minimalapi.Dominio.Interfaces;
using Minimalapi.DTOs;
using Minimalapi.Infraestrutura.Db;

namespace Minimalapi.Dominio.Servicos;

public class VeiculoServico : IVeiculoServico
{
    private readonly DbContexto _contexto;
    public VeiculoServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public void Apagar(Veiculo Veiculo)
    {
        _contexto.veiculos.Remove(Veiculo);
        _contexto.SaveChanges();
    }

    public void Atualizar(Veiculo Veiculo)
    {
        _contexto.veiculos.Update(Veiculo);
        _contexto.SaveChanges();
    }

    public Veiculo? BuscaPorId(int id)
    {
        return _contexto.veiculos.Where(v => v.Id == id).FirstOrDefault();
    }

    public void Incluir(Veiculo Veiculo)
    {
        _contexto.veiculos.Add(Veiculo);
        _contexto.SaveChanges();
    }

    public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
    {
       var query = _contexto.veiculos.AsQueryable();
       if(!string.IsNullOrEmpty(nome))
       {
        query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{nome}%"));
       }
       int itensPorPagina = 10;
       
       if(pagina != null)
       {
       query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
        }
       return query.ToList();
    }
}