
using CloudWorkSpace.DAL.DTO;
using CloudWorkSpace.DAL.ViewModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CloudWorkSpace.DAL.Repositories
{
    public class ClientRepository : GenericRepository<Client> 
    {
        public ClientRepository(DALDbContext context) : base(context) { }

        public IEnumerable<ClientViewModel> GetClientViewModelList()
        {
            // Get Clients turn into ClientViewModel
            List<Client> clients = this.context.Clients.ToList();
            List<ClientViewModel> cvmList = new List<ClientViewModel>();
            ClientViewModel cvm = new ClientViewModel();
            foreach (Client item in clients)
            {                
                cvm.Name = item.Name;

                cvmList.Add(cvm);
            }

            return cvmList;
        }
    }
}
