using Project.Domain.Entities;
using Project.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Abstract
{
    public interface IFavoritesService
    {
        Task<GenericApiResponse<Favorites>> AddFavoriteAsync(Favorites favorite);
        Task<GenericApiResponse<Favorites>> DeleteFavoriteAsync(int userId, int productId);
        Task<GenericApiResponse<List<Favorites>>> GetFavoritesByUserIdAsync(int userId);
        Task<GenericApiResponse<Favorites>> GetByUserAndProductIdAsync(int userId, int productId);
    }
}
