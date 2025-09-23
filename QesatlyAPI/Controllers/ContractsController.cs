using Microsoft.AspNetCore.Mvc;
using Qesatly.Infrastructure.Abstracts;
using Qesatly.Service.DTO;

namespace QesatlyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IContractRepository _productRepository;

        public ContractsController(IClientRepository clientRepository, IContractRepository productRepository)
        {
            _clientRepository = clientRepository;
            _productRepository = productRepository;
        }
        [HttpPost("add-client")]
        public async Task<IActionResult> AddClient([FromForm] AddClientDto client)
        {
            var result = await _clientRepository.AddAsync(client);
            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDto product)
        {
            var result = await _productRepository.AddAsync(product);
            return StatusCode((int)result.StatusCode, result);
        }

    }
}
