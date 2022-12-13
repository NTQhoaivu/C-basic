using FontAwesome.Sharp;
using LoginUseDbApp.Models;
using LoginUseDbApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace LoginUseDbApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        private IUserRepository userRepository;
        //properties
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }
        //--> Commands
        public ICommand ShowListUsersViewCommand { get; }
        public ICommand ShowListRolesViewCommand { get; }
        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            //Initialize commands
            ShowListUsersViewCommand = new ViewModelCommand(ExecuteListUsersViewCommand);
            ShowListRolesViewCommand = new ViewModelCommand(ExecuteListRolesViewCommand);
            //Default view
            ExecuteListUsersViewCommand(null);
            //LoadCurrentUserData();
        }
        private void ExecuteListUsersViewCommand(object obj)
        {
            CurrentChildView = new ListUsersViewModel();
            Caption = "List Users";
            Icon = IconChar.Home;
        }
        private void ExecuteListRolesViewCommand(object obj)
        {
            CurrentChildView = new ListRolesViewModel();
            Caption = "List Roles";
            Icon = IconChar.UserGroup;
        }
       
    }
}
