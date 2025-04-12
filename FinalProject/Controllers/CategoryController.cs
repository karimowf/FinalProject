using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.CQRS.Command.Request;

namespace Project.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryRequest request)
            => Ok(await mediator.Send(request));

        [HttpPut]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryRequest request)
            =>Ok(await mediator.Send(request));

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryAsync(DeleteCategoryRequest request)
            =>Ok(await mediator.Send(request));
    }
}
