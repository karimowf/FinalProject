using MediatR;
using Project.BLL.CQRS.Command.Request;
using Project.DAL.Abstract;
using Project.DAL.UnitOfWorkModel;
using Project.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.CQRS.Handler.Category
{
    public class DeleteCategoryHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryRequest, GenericApiResponse<BaseResponse.BaseResponse>>
    {

        public async Task<GenericApiResponse<BaseResponse.BaseResponse>> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.CategoryRepository.GetCategoryByIdAsync(request.CategoryId);
            if (category == null)
            {
               return GenericApiResponse<BaseResponse.BaseResponse>.Fail("category not found", HttpStatusCode.BadRequest.GetHashCode());
            }

            unitOfWork.CategoryRepository.DeleteAsync(category);
            if (await unitOfWork.CommitAsync() < 0)
                return GenericApiResponse<BaseResponse.BaseResponse>.Fail("failed to delete category", HttpStatusCode.BadRequest.GetHashCode());

            return GenericApiResponse<BaseResponse.BaseResponse>.Success(new BaseResponse.BaseResponse(isSuccess: true, message:"Successfully deleted"), HttpStatusCode.OK.GetHashCode());
        }
    }

}
