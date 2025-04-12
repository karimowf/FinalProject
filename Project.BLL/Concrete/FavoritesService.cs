using Microsoft.AspNetCore.Http;
using Project.BLL.Abstract;
using Project.BLL.Exceptions;
using Project.DAL.Abstract;
using Project.DAL.Exceptions;
using Project.DAL.UnitOfWorkModel;
using Project.Domain.Entities;
using Project.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Concrete
{
    public class FavoritesService : IFavoritesService
    {
        private readonly IUnitOfWork unitOfWork;

        public FavoritesService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GenericApiResponse<Favorites>> GetByUserAndProductIdAsync(int userId, int productId)
        {
            try
            {
                var favorite = await unitOfWork.FavoritesRepository.GetByUserAndProductIdAsync(userId, productId);
                if (favorite == null)
                {
                    return GenericApiResponse<Favorites>.FailResponse("Favorite not found.", HttpStatusCode.NotFound.GetHashCode());
                }
                return GenericApiResponse<Favorites>.SuccessResponse(favorite);
            }
            catch (Exception ex)
            {
                return GenericApiResponse<Favorites>.FailResponse("Error occurred while retrieving the favorite.", HttpStatusCode.InternalServerError.GetHashCode());
            }
        }

        public async Task<GenericApiResponse<List<Favorites>>> GetFavoritesByUserIdAsync(int userId)
        {
            try
            {
                var favorites = await unitOfWork.GetFavoritesByUserIdAsync(userId);
                if (favorites == null || favorites.Count == 0)
                {
                    return GenericApiResponse<List<Favorites>>.FailResponse("No favorites found for this user.", HttpStatusCode.NotFound.GetHashCode());
                }
                return GenericApiResponse<List<Favorites>>.SuccessResponse(favorites);
            }
            catch (Exception ex)
            {
                return GenericApiResponse<List<Favorites>>.FailResponse("Error occurred while retrieving the favorites.", HttpStatusCode.InternalServerError.GetHashCode());
            }
        }

        public async Task<GenericApiResponse<Favorites>> AddFavoriteAsync(Favorites favorite)
        {
            try
            {
                await _favoritesRepository.Create(favorite);
                await _favoritesRepository.SaveAsync();
                return GenericApiResponse<Favorites>.SuccessResponse(favorite, HttpStatusCode.Created.GetHashCode());
            }
            catch (Exception ex)
            {
                return GenericApiResponse<Favorites>.FailResponse("Error occurred while adding the favorite.", HttpStatusCode.InternalServerError.GetHashCode());
            }
        }

        public async Task<GenericApiResponse<Favorites>> DeleteFavoriteAsync(int userId, int productId)
        {
            try
            {
                var favorite = await _favoritesRepository.GetByUserAndProductIdAsync(userId, productId);
                if (favorite == null)
                {
                    return GenericApiResponse<Favorites>.FailResponse("Favorite not found.", HttpStatusCode.NotFound.GetHashCode());
                }

                await _favoritesRepository.Delete(favorite);
                await _favoritesRepository.SaveAsync();
                return GenericApiResponse<Favorites>.SuccessResponse(favorite, HttpStatusCode.OK.GetHashCode());
            }
            catch (Exception ex)
            {
                return GenericApiResponse<Favorites>.FailResponse("Error occurred while deleting the favorite.", HttpStatusCode.InternalServerError.GetHashCode());
            }
        }
    }
