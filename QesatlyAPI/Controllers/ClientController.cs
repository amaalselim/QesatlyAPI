using Microsoft.AspNetCore.Mvc;
using Qesatly.Infrastructure.Abstracts;
using Qesatly.Service.DTO;

namespace QesatlyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        [HttpPost("AddClient")]
        public async Task<IActionResult> AddClient([FromForm] AddClientDto client)
        {
            var result = await _clientRepository.AddAsync(client);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
