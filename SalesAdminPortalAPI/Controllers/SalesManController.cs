using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAdminPortalAPI.Data;

namespace SalesAdminPortalAPI.Controllers
{
    //localhost:xxxx/api/salesman
    [Route("api/[controller]")]
    [ApiController]
    public class SalesManController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public SalesManController(ApplicationDbContext dbContext)
        {
             this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllSalesmans()
        {
            var AllSalesmans = dbContext.Salesmans.ToList();
            return Ok(AllSalesmans);

            //return Ok(dbContext.Salesmans.ToList());
        }
    }
}
