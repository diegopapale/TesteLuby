using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteLuby.Models;
using Xamarin.Forms;
using System.Data;

namespace TesteLuby.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Nome = "First item", Telefone="(14)997613668", Email="first@email.com.br", Senha="123", Aniversario="18/01" },
                new Item { Id = Guid.NewGuid().ToString(), Nome = "Second item", Telefone="(14)997623670",Email="second@email.com.br", Senha="321", Aniversario="18/02" },
                new Item { Id = Guid.NewGuid().ToString(), Nome = "Third item", Telefone="(14)997633644",Email="third@email.com.br", Senha="111", Aniversario="18/02" },
                new Item { Id = Guid.NewGuid().ToString(), Nome = "Fourth item", Telefone="(14)997653555",Email="fourth@email.com.br", Senha="222", Aniversario="18/02" }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<Acesso> GetAcessoAsync(string id)
        {
            await Task.Run(() =>
            {
                return ((App)Application.Current).Conexao.Query<Acesso>("select * from acesso").FirstOrDefault();
            });

            return null;
        }

        public async Task<bool> AddAcessoAsync(Acesso item)
        {
            await Task.Run(() =>
            {
                string query = string.Format("insert into acesso (login) " +
                    "values ( '{0}' )", item.Login);

                ((App)Application.Current).Conexao.Execute(query);

                return true;
            });

            return false;
        }
    }
}