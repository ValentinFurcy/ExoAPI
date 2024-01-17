using ExoAPI.Models;
using ExoAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        IClientRepository clientRepository;

        public ClientController(IClientRepository IClientRepository)
        {
            clientRepository = IClientRepository;
        }

        /// <summary>
        /// Get All Client
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetAll()
        {
            return Ok(await clientRepository.GetAllAsync());
        }

        [HttpGet("GetClientById/{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            return Ok(await clientRepository.GetClientByIdAsync(id));
        }
        [HttpGet("SearchByName/{name}")]
        public async Task<IActionResult> SearchByName(string name)
        {
            List<Client> clients = await clientRepository.SearchByNameAsync(name);
           if(!clients.Any()) 
            {
                return NoContent();
            }
            else { return Ok(clients); }              
        }
        [HttpPost()]
        public async Task<IActionResult> CreateClient(Client client)
        {
            if (client != null)
            {
                return Ok(await clientRepository.CreateClientAsync(client));
            } else { return BadRequest("Echec de la création du client"); }
                                
        }
        [HttpPut()]
        public async Task<IActionResult> UpdateClient(Client client)
        {
            return Ok(await clientRepository.UpdateClientAsync(client));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            bool success = await clientRepository.DeleteClientAsync(id);
            if (success)
            {
                return Ok();
            }
            else return BadRequest("Echec de la suppression");
        }

    }
}
