using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        //Rol və icazə idarəsi (rol əlavə etmək, silmək, istifadəçiyə rol təyin etmək və s.).

        //POST /api/roles/{roleId}/assign – Bir istifadəçiyə rol təyin etmək.

        //GET /api/roles/{roleId}/permissions – Bir rolun icazələrini əldə etmək.

        //POST /api/permissions/assign – İstifadəçiyə xüsusi bir icazə təyin etmək.

        //DELETE /api/permissions/revoke – İstifadəçinin icazəsini ləğv etmək.
    }
}
