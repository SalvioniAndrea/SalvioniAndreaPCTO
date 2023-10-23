using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgettoPtco.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ProgettoPtco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetectionController : ControllerBase
    {
        private readonly ILogger<DetectionController> _logger;
        private readonly TemperatureDBContext _ctx;

        public DetectionController(ILogger<DetectionController> logger, TemperatureDBContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Detection> dt = _ctx.detections.ToList();
            return Ok(dt);
        }

        [HttpGet]
        [Route("{id}")]
        // /api/Tutor/1
        public IActionResult Get(int id)
        {
            Detection? d = _ctx.detections.SingleOrDefault(x => x.id == id);
            if (d == null)
            {
                return NotFound($"Tutor not found with id: {id}");
            }

            return Ok(d);
        }

        [HttpGet]
        [Route("filter")]
        // /api/Tutor/1
        public IActionResult GetFiltred(DateTime dstart, DateTime dfinish, int viewSlice, int page)
        {
            if (page <= 0)
                return BadRequest("There are no pages with an index below 1");
            int viewPage = viewSlice * (page - 1);
            List<Detection>? d = _ctx.detections.Where(x=>x.timeStamp>=dstart && x.timeStamp <= dfinish).ToList();
            List<Detection> dt = d.Skip(viewPage).Take(viewSlice).ToList();
            return Ok(dt);
        }

        [HttpGet]
        [Route("Paged")]
        public IActionResult GetAllPaged(int viewSlice, int page)
        {
            if(page<=0)
                return BadRequest("There are no pages with an index below 1");
            int viewPage = viewSlice * (page-1);
            List<Detection> dt = _ctx.detections.Skip(viewPage).Take(viewSlice).ToList();
            return Ok(dt);
        }
    }
}
