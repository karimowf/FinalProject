using MediatR;
using Project.BLL.CQRS.BaseResponse;
using Project.BLL.CQRS.Command.Request;
using Project.DAL.UnitOfWorkModel;
using Project.Domain.Entities;
using Project.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.CQRS.Handler.Category
{
    public class CreateCategoryCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<CreateCategoryRequest, GenericApiResponse<BaseResponse.BaseResponse>>
    {
        public async Task<GenericApiResponse<BaseResponse.BaseResponse>> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            bool isExists = await unitOfWork.CategoryRepository.ExistsAsync(c => c.Name == request.Name);
            if (isExists)
                return GenericApiResponse<BaseResponse.BaseResponse>.Fail("A category with the same name already exists!");


            if (request.ParentCategoryId.HasValue)
            {
                bool parentExists = await unitOfWork.CategoryRepository.ExistsAsync(c => c.Id == request.ParentCategoryId.Value);
                if (!parentExists)
                    return GenericApiResponse<BaseResponse.BaseResponse>.Fail("Parent category not found!");
            }

            var newCategory = new Domain.Entities.Category()
            {
                Name = request.Name,
                ParentCategoryId = request.ParentCategoryId
            };

            await unitOfWork.CategoryRepository.AddAsync(newCategory);

            if(await unitOfWork.CommitAsync() <0)
                return GenericApiResponse<BaseResponse.BaseResponse>.Fail("failed to create category",HttpStatusCode.BadRequest.GetHashCode());

            return GenericApiResponse<BaseResponse.BaseResponse>.Success(new BaseResponse.BaseResponse(true, "Category created successfully."), HttpStatusCode.OK.GetHashCode());
        }

    }
}
