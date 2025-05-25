using MediatR;
using Microsoft.Extensions.Logging;
using Project.BLL.Patterns.CQRS.Command.Request.Categories;
using Project.DAL.UnitOfWorkModel;
using Project.Shared;
using System.Net;

namespace Project.BLL.Patterns.CQRS.Handler.Category.CommandHandler
{
    public class CreateCategoryCommandHandler(
    IUnitOfWork unitOfWork, ILogger<CreateCategoryCommandHandler> logger) : IRequestHandler<CreateCategoryRequest, GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public async Task<GenericApiResponse<BaseResponse.BaseResponse>> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            bool isExists = await unitOfWork.CategoryRepository.ExistsAsync(c => c.Name == request.Name);
            if (isExists) return GenericApiResponse<BaseResponse.BaseResponse>.Fail("A category with the same name already exists!");

            if (request.ParentCategoryId.HasValue)
            {
                bool parentExists = await unitOfWork.CategoryRepository.ExistsAsync(c => c.Id == request.ParentCategoryId.Value); if (!parentExists)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail("Parent category not found!");
            }
            var newCategory = new Domain.Entities.Category()
            {
                Name = request.Name,
                ParentCategoryId = request.ParentCategoryId
            };
            await unitOfWork.CategoryRepository.AddAsync(newCategory);
            if (await unitOfWork.CommitAsync() < 0)
                return GenericApiResponse<BaseResponse.BaseResponse>.Fail("failed to create category", HttpStatusCode.BadRequest.GetHashCode());
            return GenericApiResponse<BaseResponse.BaseResponse>.Success(new BaseResponse.BaseResponse(true, "Category created successfully."), HttpStatusCode.OK.GetHashCode());
        }
    }
}
