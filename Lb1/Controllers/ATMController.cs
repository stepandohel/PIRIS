using Lb1.DB;
using Lb1.DB.Entites.ATM;
using Lb1.DB.Entites.BankE.CreditE;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lb1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ATMController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public ATMController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get(string number)
        {
            var item = await _appDbContext.Set<CreditCard>().FirstOrDefaultAsync(x => x.Number == number);
            var returnedItem = await _appDbContext.Set<CreditList>().FirstOrDefaultAsync(x => x.CreditCardId == item.Id);
            return Ok(returnedItem.StartAmount);
        }

        [HttpGet("{number}")]
        public async Task<ActionResult> Get(string number, int count)
        {
            var item = await _appDbContext.Set<CreditCard>().FirstOrDefaultAsync(x => x.Number == number);
            var returnedItem = await _appDbContext.Set<CreditList>().FirstOrDefaultAsync(x => x.CreditCardId == item.Id);
            returnedItem.StartAmount-=count;
            await _appDbContext.SaveChangesAsync();
            return Ok(returnedItem.StartAmount);
        }

        [HttpPost]
        public async Task<ActionResult> Post(string Number, string Pin)
        {
            var item = await  _appDbContext.Set<CreditCard>().FirstOrDefaultAsync(x=>x.Number==Number);          
            if (item is not null)
            {
                if(item.Pin==Pin)
                return Ok();
            }
            return BadRequest();
        }       
    }
}