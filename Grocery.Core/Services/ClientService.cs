using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        
        public Client? Get(string email) =>_clientRepository.Get(email);

        public Client? Get(int id) => _clientRepository.Get(id);

        public List<Client> GetAll() => _clientRepository.GetAll();
        
        public bool ExistsByEmail(string email) => _clientRepository.ExistsByEmail(email);
        public Client Add(Client client) => _clientRepository.Add(client);
    }
}
