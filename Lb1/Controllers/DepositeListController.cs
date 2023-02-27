using AutoMapper;
using Lb1.DB;
using Lb1.DB.Entites.Bank;
using Lb1.Modeles.Deposite.DepositList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lb1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepositeListController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public DepositeListController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var item = await _appDbContext.DepositLists
                .Include(x => x.Client)
                .Include(x => x.DepositPlane)
                .ToListAsync();
            var itemsView = _mapper.Map<List<DepositListViewModel>>(item);
            return Ok(itemsView);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var item = await _appDbContext.DepositLists
                .Include(x => x.Client)
                .Include(x => x.DepositPlane)
                .FirstOrDefaultAsync(x => x.Id == id);
            var itemView = _mapper.Map<DepositListViewModel>(item);
            return Ok(itemView);
        }

        [HttpPost]
        public async Task<ActionResult> Post(DepositListPostModel depositListPostModel)
        {
            if (depositListPostModel is not null)
            {
                var item = _mapper.Map<DepositList>(depositListPostModel);
                await _appDbContext.Set<DepositList>().AddAsync(item);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(DepositListPutModel depositListPutModel)
        {
            if (depositListPutModel is not null)
            {
                var item = _mapper.Map<DepositList>(depositListPutModel);
                _appDbContext.Set<DepositList>().Update(item);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _appDbContext.DepositLists.FindAsync(id);
            if (item is not null)
            {
                _appDbContext.Set<DepositList>().Remove(item);
                await _appDbContext.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
