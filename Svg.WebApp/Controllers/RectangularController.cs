using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Svg.DataAccess;
using Svg.DataAccess.Response;
using Svg.Service;

namespace Svg.WebApp.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RectangularController : ControllerBase
    {
        private readonly IRectangularRepo? _repo;

        public RectangularController(IRectangularRepo? repo)
        {
            _repo = repo;
        }


        [HttpPost]
        public IActionResult AddRectangular([FromBody] Rectangular rectangular)
        {
            try
            {
                if (rectangular == null)
                {
                    return BadRequest(new ApiResponse(true, "Rectangular object is null", null));
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(true, "Invalid model object", null));

                }
                else
                {
                    _repo.AddRectangular(rectangular);
                }
                return Ok(new ApiResponse(true, "Data Saved", _repo));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }


        }


        [HttpGet]
        public IActionResult getAllRectangular()
        {

            try
            {
                var response = _repo?.GetAllRectangular();
                return Ok(new ApiResponse(true, "Rectangular data load successfully", response));

            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(true, "Rectangular data load failed", null));
            }
        }

    }
}
