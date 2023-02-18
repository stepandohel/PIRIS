using AutoMapper;
using Lb1.DB;
using Lb1.DB.Entites;
using Lb1.Modeles.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lb1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public ClientsController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var item = await _appDbContext.Clients.Include(x => x.Town)
                .Include(x => x.Citizenship)
                .Include(x => x.MaritalStatus)
                .ToListAsync();
            var itemsView = _mapper.Map<List<ClientViewModel>>(item);
            return Ok(itemsView);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var item = await _appDbContext.Clients
                .Include(x => x.Town)
                .Include(x => x.Citizenship)
                .Include(x => x.MaritalStatus)
                .FirstOrDefaultAsync(x => x.Id == id);
            var itemView = _mapper.Map<ClientViewModel>(item);
            return Ok(itemView);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ClientPostModel clientPostModel)
        {
            if (clientPostModel is not null)
            {
                var item = _mapper.Map<Client>(clientPostModel);
                await _appDbContext.Set<Client>().AddAsync(item);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(ClientPutModel clientPutModel)
        {
            if (clientPutModel is not null)
            {
                var item = _mapper.Map<Client>(clientPutModel);
                _appDbContext.Set<Client>().Update(item);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _appDbContext.Clients.FindAsync(id);
            if (item is not null)
            {
                _appDbContext.Set<Client>().Remove(item);
                await _appDbContext.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
