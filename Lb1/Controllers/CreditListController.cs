using AutoMapper;
using Lb1.DB;
using Lb1.DB.Entites.ATM;
using Lb1.DB.Entites.BankE.CreditE;
using Lb1.Modeles.Credit.CreditList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lb1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditListController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public CreditListController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var item = await _appDbContext.CreditLists
                .Include(x => x.Client)
                .Include(x => x.CreditPlane)
                .ToListAsync();
            var itemsView = _mapper.Map<List<CreditListViewModel>>(item);
            return Ok(itemsView);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var item = await _appDbContext.CreditLists
                .Include(x => x.Client)
                .Include(x => x.CreditPlane)
                .FirstOrDefaultAsync(x => x.Id == id);
            var itemView = _mapper.Map<CreditListViewModel>(item);
            return Ok(itemView);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreditListPostModel creditListPostModel)
        {
            if (creditListPostModel is not null)
            {
                var item = _mapper.Map<CreditList>(creditListPostModel);

                var creditCard = new CreditCard()
                {
                    Number = RandomString(16),
                    Pin = RandomString(3)
                };

                await _appDbContext.Set<CreditCard>().AddAsync(creditCard);
                //var creditCardEntity = await _appDbContext.Set<CreditCard>().OrderBy(x=>x.Id).LastAsync();

                //item.CreditCardId = creditCardEntity.Id;
                item.CreditCard = creditCard;
                await _appDbContext.Set<CreditList>().AddAsync(item);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(CreditListPutModel creditListPutModel)
        {
            if (creditListPutModel is not null)
            {
                var item = _mapper.Map<CreditList>(creditListPutModel);
                _appDbContext.Set<CreditList>().Update(item);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _appDbContext.CreditLists.FindAsync(id);
            if (item is not null)
            {
                _appDbContext.Set<CreditList>().Remove(item);
                await _appDbContext.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
