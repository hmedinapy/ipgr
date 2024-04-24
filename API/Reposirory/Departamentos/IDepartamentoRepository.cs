﻿using API.Models;

namespace API.Reposirory.Departamentos
{
    public interface IDepartamentoRepository
    {
        public Task<List<Departamento>> GetAllAsync();
        public Task<Departamento?> GetOneAsync(int id);
        public Task<Departamento> AddRowAsync(Departamento document);
        public Task<Departamento> UpdateAsync(Departamento document);
        public Task<Departamento> RemoveAsync(Departamento document);
    }
}
