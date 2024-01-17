using ExoAPI.DTOs;
using ExoAPI.Models;

namespace ExoAPI.Repositories
{
    public interface IClientRepository
    {
        Task<Client> CreateClientAsync(Client client);

        /// <summary>
        /// Get All client
        /// </summary>
        /// <returns></returns>
        Task<List<GetAllClientDTO>> GetAllAsync();

        //Task<List<Client>> GetAllAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task<Client> UpdateClientAsync(Client client);
        Task <bool>DeleteClientAsync(int id);
        Task<List<Client>> SearchByNameAsync(string name);
    }
}
