using ExoAPI.Models;

namespace ExoAPI.Repositories
{
    public interface IClientRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        Task<Client> CreateClientAsync(Client client);
        Task<List<Client>> GetAllAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task<Client> UpdateClientAsync(Client client);
        Task <bool>DeleteClientAsync(int id);
        Task<List<Client>> SearchByNameAsync(string name);
    }
}
