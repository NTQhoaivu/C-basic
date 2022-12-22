using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoginUseDbApp.Models
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Edit(string id, string userName, string password, string name, string lastName, string email);
        void Remove(String id);
        void Insert(string userName, string password, string name, string lastName, string email);
        UserModel GetById(int id);
        UserModel GetByUsername(string username);
        ObservableCollection<UserModel> GetByAll();
    }
}
