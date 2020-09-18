using AutoMapper;
using BigGameSurvey.Api.Contexts;
using BigGameSurvey.Api.DTO;
using BigGameSurvey.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Paging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BigGameSurvey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public RecordsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Records
        [HttpGet]
        public async Task<ActionResult<PagedResult<RecordDTO>>> GetRecords()
        {
            var pi = PagingInfo.FromRequest(Request);

            var rec = await Task.FromResult(
                _context.Records
                .Include(r => r.Game)
                    .ThenInclude(g => g.Genre)
                .AsQueryable()
                .ToPagedResult<RecordEntity>(pi, Request));

            var ret = _mapper.Map<PagedResult<RecordDTO>>(rec);

            return ret;
        }

        // GET: api/Records/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecordEntity>> GetRecord(int id)
        {
            var record = await _context.Records.FindAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            return record;
        }

        // PUT: api/Records/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecord(int id, RecordEntity record)
        {
            if (id != record.Id)
            {
                return BadRequest();
            }

            _context.Entry(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Records
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RecordEntity>> PostRecord(RecordEntity record)
        {
            _context.Records.Add(record);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecord", new { id = record.Id }, record);
        }

        // DELETE: api/Records/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RecordEntity>> DeleteRecord(int id)
        {
            var record = await _context.Records.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _context.Records.Remove(record);
            await _context.SaveChangesAsync();

            return record;
        }

        private bool RecordExists(int id)
        {
            return _context.Records.Any(e => e.Id == id);
        }
    }
}
