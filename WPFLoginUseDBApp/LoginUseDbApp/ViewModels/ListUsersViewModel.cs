using LoginUseDbApp.Models;
using LoginUseDbApp.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;

namespace LoginUseDbApp.ViewModels
{
    public class ListUsersViewModel : ViewModelBase
    {
        private string _username;
        private string _name;
        private string _lastName;
        private string _email;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private ObservableCollection<UserModel> ListUser;


        private IUserRepository userRepository;

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public ObservableCollection<UserModel> ListUser1 { get => ListUser; set => ListUser = value; }

        public ObservableCollection<UserModel> userModels = new ObservableCollection<UserModel>();

        public ListUsersViewModel()
        {
            userRepository = new UserRepository();
            ListUser1 = new ObservableCollection<UserModel>();
            foreach (var item in userRepository.GetByAll())
            {
                ListUser1.Add(item);
            }
        }

        public void load()
        {
            var user = userRepository.GetByAll().ToList();
        }
    }
}
