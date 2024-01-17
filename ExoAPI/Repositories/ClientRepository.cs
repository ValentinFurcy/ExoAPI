using ExoAPI.Context;
using ExoAPI.DTOs;
using ExoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoAPI.Repositories
{
    public class ClientRepository : IClientRepository
    {
        ExoAPIContext context;
        public ClientRepository(ExoAPIContext exoAPIContext ) 
        {
            context = exoAPIContext;
        }

        public async Task<Client> CreateClientAsync(Client client)
        {            
            context.Clients.Add( client );
            await context.SaveChangesAsync();
            return client;
        }
        
        public async Task<List<GetAllClientDTO>> GetAllAsync()
        {
            return await context.Clients.Select(c => new GetAllClientDTO { Name = c.Name , Age = c.Age}).ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await context.Clients.Include(c => c.Orders).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            var clientUpdate = context.Clients.FirstOrDefault(c => c.Id == client.Id);

            clientUpdate.Name = client.Name;
            clientUpdate.Age = client.Age;
            await context.SaveChangesAsync();

            return client;
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            try
            {
                var clientToDelete = context.Clients.FirstOrDefault(c => c.Id == id);
                context.Clients.Remove(clientToDelete);
                await context.SaveChangesAsync();
                return true;
            }catch (Exception ex) 
            {
                return false;
            }
        }

        public async Task<List<Client>> SearchByNameAsync(string name)
        {
            return await context.Clients.Where(c => c.Name.Contains(name)).ToListAsync();
        }
    }
}
