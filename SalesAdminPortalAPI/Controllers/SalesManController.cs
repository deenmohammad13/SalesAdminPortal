using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesAdminPortalAPI.Data;
using SalesAdminPortalAPI.Models;
using SalesAdminPortalAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

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

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetSalemanbyId(Guid id)
        {
            var salesman = dbContext.Salesmans.Find(id);

            if (salesman == null)
            {
                return NotFound();
            }
            return Ok(salesman);
        }

        [HttpPost]
        public IActionResult AddSalesman(AddSalesmanDto addSalesmanDto)
        {
            var salesmanEntity = new Salesman()
            {
                Name = addSalesmanDto.Name,
                Email = addSalesmanDto.Email,
                Phone = addSalesmanDto.Phone,
                Salary = addSalesmanDto.Salary,
            };

            dbContext.Salesmans.Add(salesmanEntity);
            dbContext.SaveChanges();

            return Ok(salesmanEntity);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateSalesman(Guid id, UpdateSalesmanDto updateSalesmanDto)
        {
            var salesman = dbContext.Salesmans.Find(id);
            if (salesman == null)
            {
                return NotFound();
            }
            salesman.Name = updateSalesmanDto.Name;
            salesman.Email = updateSalesmanDto.Email;
            salesman.Phone = updateSalesmanDto.Phone;
            salesman.Salary = updateSalesmanDto.Salary;

            dbContext.SaveChanges();
            return Ok(salesman);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteSalesman(Guid id)
        {
            var salesman = dbContext.Salesmans.Find(id);
            if ( salesman == null)
            {
                return NotFound();
            }
            dbContext.Salesmans.Remove(salesman);
            dbContext.SaveChanges();
            return Ok();    
            
        }
    }

}
