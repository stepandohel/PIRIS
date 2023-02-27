using AutoMapper;
using Lb1.DB;
using Lb1.DB.Entites.Bank;
using Lb1.Modeles.Deposite.DepositPlane;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lb1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepositPlaneController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public DepositPlaneController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var item = await _appDbContext.DepositPlanes.ToListAsync();
            var itemsView = _mapper.Map<List<DepositPlaneViewModel>>(item);
            return Ok(itemsView);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var item = await _appDbContext.DepositPlanes.FirstOrDefaultAsync(x => x.Id == id);
            var itemView = _mapper.Map<DepositPlaneViewModel>(item);
            return Ok(itemView);
        }

        [HttpPost]
        public async Task<ActionResult> Post(DepositPlanePostModel depositPlanePostModel)
        {
            if (depositPlanePostModel is not null)
            {
                var item = _mapper.Map<DepositPlane>(depositPlanePostModel);
                await _appDbContext.Set<DepositPlane>().AddAsync(item);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(DepositPlanePutModel depositPlanePutModel)
        {
            if (depositPlanePutModel is not null)
            {
                var item = _mapper.Map<DepositPlane>(depositPlanePutModel);
                _appDbContext.Set<DepositPlane>().Update(item);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _appDbContext.DepositPlanes.FindAsync(id);
            if (item is not null)
            {
                _appDbContext.Set<DepositPlane>().Remove(item);
                await _appDbContext.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
