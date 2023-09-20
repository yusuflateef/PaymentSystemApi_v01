using Microsoft.AspNetCore.Mvc;
using PaymentSystemApi_v01.Contracts;
using PaymentSystemApi_v01.DTO;

namespace PaymentSystemApi_v01.Controllers
{
    
        [ApiController]
        [Route("api/Marchant")]
        public class MarchantsController : ControllerBase
        {
            public IMarchantService _marchantProvider { get; }
            public MarchantsController(IMarchantService marchantsProvider)
            {
                 _marchantProvider = marchantsProvider;
            }

            [HttpPost]
            public ActionResult<IEnumerable<MarchantDto>> Marchants(MarchantDto input)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var response = _marchantProvider.Marchant(input);

                return Ok(response);
            }

            [HttpGet]
            public ActionResult<IEnumerable<MarchantDto>> Marchants()
            {
                var marchants = _marchantProvider.Marchants().Result.marchants;

                return Ok(marchants);
            }
            [HttpGet("{id}")]
            public async Task<ActionResult<MarchantDto>> MarchantById(string id)
            {
                var marchant = await _marchantProvider.MarchantById(id);

                return Ok(marchant.marchants);
            }
        }

    }

