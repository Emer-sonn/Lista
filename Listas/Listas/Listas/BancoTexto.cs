using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Listas.Models;
using SQLite;

namespace Listas
{
    public class BancoTexto
    {
        readonly SQLiteAsyncConnection _bancotexto;
        public BancoTexto(string Path)
        {
            _bancotexto = new SQLiteAsyncConnection(Path);
            _bancotexto.CreateTableAsync<Models.Texto>().Wait();
        }

        public Task<List<Texto>>Listar()
        {
            return _bancotexto.Table<Texto>().ToListAsync();
        }
        public Task<Texto> Listar(int id)
        {
            return _bancotexto.Table<Texto>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> Adicionar (Texto t)
        {
            return _bancotexto.InsertAsync(t);
        }
        public Task<int> Deletar (Texto t)
        {
            return _bancotexto.DeleteAsync(t);
        }
    }

   
}
