using MediatR;
using Project.BLL.Patterns.CQRS.BaseResponse;
using Project.BLL.Patterns.CQRS.Command.Request.Categories;
using Project.DAL.UnitOfWorkModel;
using Project.Shared;
using System.Net;

namespace Project.BLL.Patterns.CQRS.Handler.Category.CommandHandler
{
    public class UpdateCategoryCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCategoryRequest, GenericApiResponse<BaseResponse>>
    {
        public async Task<GenericApiResponse<BaseResponse>> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.CategoryRepository.GetCategoryByIdAsync(request.Id);
            if (category == null)
            {
                return GenericApiResponse<BaseResponse>.Fail("category not found", HttpStatusCode.BadRequest.GetHashCode());
            }
            category.Name = request.Name; category.ParentCategoryId = request.ParentCategoryId;
            unitOfWork.CategoryRepository.UpdateAsync(category);
            if (await unitOfWork.CommitAsync() < 0) return GenericApiResponse<BaseResponse>.Fail("failed to update category", HttpStatusCode.BadRequest.GetHashCode());
            return GenericApiResponse<BaseResponse>.Success(new BaseResponse(isSuccess: true, message: "Successfully updated"), HttpStatusCode.OK.GetHashCode());
        }
    }

}
