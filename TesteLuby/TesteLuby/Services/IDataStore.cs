﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteLuby.Models;

namespace TesteLuby.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        Task<bool> AddAcessoAsync(Acesso item);
        Task<Acesso> GetAcessoAsync(string id);
    }
}
