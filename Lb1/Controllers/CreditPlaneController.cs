using AutoMapper;
using Lb1.DB;
using Lb1.DB.Entites.BankE.CreditE;
using Lb1.Modeles.Credit.CreditPlane;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lb1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditPlaneController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public CreditPlaneController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var item = await _appDbContext.CreditPlanes.ToListAsync();
            var itemsView = _mapper.Map<List<CreditPlaneViewModel>>(item);
            return Ok(itemsView);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var item = await _appDbContext.CreditPlanes.FirstOrDefaultAsync(x => x.Id == id);
            var itemView = _mapper.Map<CreditPlaneViewModel>(item);
            return Ok(itemView);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreditPlanePostModel creditPlanePostModel)
        {
            if (creditPlanePostModel is not null)
            {
                var item = _mapper.Map<CreditPlane>(creditPlanePostModel);
                await _appDbContext.Set<CreditPlane>().AddAsync(item);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(CreditPlanePutModel creditPlanePutModel)
        {
            if (creditPlanePutModel is not null)
            {
                var item = _mapper.Map<CreditPlane>(creditPlanePutModel);
                _appDbContext.Set<CreditPlane>().Update(item);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _appDbContext.CreditPlanes.FindAsync(id);
            if (item is not null)
            {
                _appDbContext.Set<CreditPlane>().Remove(item);
                await _appDbContext.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
