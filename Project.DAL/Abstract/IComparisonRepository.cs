using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Abstract
{
    public interface IComparisonRepository
    {
        Task AddToComparisonAsync(Comparison comparison);
        Task<List<Comparison>> GetComparisonsByUserIdAsync(int userId);
        void RemoveFromComparisonAsync(Comparison comparison);
        Task<Comparison?> GetComparisonByIdAsync(int id);
    }
}
