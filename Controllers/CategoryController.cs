using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Patterns.CQRS.Command.Request.Categories;

namespace Project.UI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryRequest request)
            => Ok(await mediator.Send(request));

        [HttpPut]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryRequest request)
            => Ok(await mediator.Send(request));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] int id)
            => Ok(await mediator.Send(new DeleteCategoryRequest { CategoryId = id }));
    }
}