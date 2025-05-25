using MediatR;
using Project.BLL.Patterns.CQRS.BaseResponse;
using Project.BLL.Patterns.CQRS.Command.Request.Categories;
using Project.DAL.UnitOfWorkModel;
using Project.Domain.Models.ResponseModels;
using Project.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Patterns.CQRS.Handler.Category.CommandHandler
{
    public class DeleteCategoryHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryRequest, GenericApiResponse<BaseResponse>>
    {
        public async Task<GenericApiResponse<BaseResponse>> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.CategoryRepository.GetCategoryByIdAsync(request.CategoryId); if (category == null)
            {
                return GenericApiResponse<BaseResponse>.Fail("category not found", HttpStatusCode.BadRequest.GetHashCode());
            }
            unitOfWork.CategoryRepository.DeleteAsync(category); if (await unitOfWork.CommitAsync() < 0)
                return GenericApiResponse<BaseResponse>.Fail("failed to delete category", HttpStatusCode.BadRequest.GetHashCode());
            return GenericApiResponse<BaseResponse>.Success(new BaseResponse(isSuccess: true, message: "Successfully deleted"), HttpStatusCode.OK.GetHashCode());
        }
    }
}
