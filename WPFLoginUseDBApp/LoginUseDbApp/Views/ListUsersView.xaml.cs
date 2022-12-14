using LoginUseDbApp.Models;
using LoginUseDbApp.Repositories;
using LoginUseDbApp.ViewModels;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginUseDbApp.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class ListUsersView : UserControl
    {
        private IUserRepository userRepository;

        public ListUsersView()
        {
            userRepository = new UserRepository();
            InitializeComponent();
            load();
            DataContext = new ListUsersViewModel();
            //listUser.ItemsSource.

        }
        public void load()
        {
            var users = userRepository.GetByAll().ToList();
            listUser.ItemsSource = users;
        }

    }
}
