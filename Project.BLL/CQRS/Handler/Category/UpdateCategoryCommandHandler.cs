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
    public class UpdateCategoryCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCategoryRequest, GenericApiResponse<BaseResponse.BaseResponse>>
    {

        public async Task<GenericApiResponse<BaseResponse.BaseResponse>> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.CategoryRepository.GetCategoryByIdAsync(request.Id);

            if (category == null)
            {
                return GenericApiResponse<BaseResponse.BaseResponse>.Fail("category not found", HttpStatusCode.BadRequest.GetHashCode());
               
            }

            category.Name = request.Name;
            category.ParentCategoryId = request.ParentCategoryId;

            unitOfWork.CategoryRepository.UpdateAsync(category);
            if(await unitOfWork.CommitAsync() < 0)
                return GenericApiResponse<BaseResponse.BaseResponse>.Fail("failed to update category", HttpStatusCode.BadRequest.GetHashCode());

           return GenericApiResponse<BaseResponse.BaseResponse>.Success(new BaseResponse.BaseResponse(isSuccess:true, message:"Successfully updated"), HttpStatusCode.OK.GetHashCode());
        }
    }

}
