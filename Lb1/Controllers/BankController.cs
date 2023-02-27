using Lb1.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lb1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public BankController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var items = await _appDbContext.DepositLists
                .Include(x=>x.DepositPlane)
                .ToListAsync();

            foreach (var item in items)
            {
                item.PercentAmount += item.StartAmount * (item.DepositPlane.Percent / 100.0);
            }

            var itemsCredit = await _appDbContext.CreditLists
                .Include(x => x.CreditPlane)
                .ToListAsync();

            foreach (var item in itemsCredit)
            {
                item.PercentAmount += item.StartAmount * (item.CreditPlane.Percent / 100.0);
            }
            await _appDbContext.SaveChangesAsync();           
            return Ok();
        }
    }
}