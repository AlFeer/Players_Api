using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoungWolves.Models;

namespace YoungWolves.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Warrior>>> FindAll()
        {
            return null;
        }
    }
}
