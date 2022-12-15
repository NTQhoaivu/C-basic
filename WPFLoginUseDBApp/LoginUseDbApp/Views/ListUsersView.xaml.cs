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
        }
        public void load()
        {
            var users = userRepository.GetByAll().ToList();
            listUser.ItemsSource = users;
        }

        private void btn_clickDelete(object sender, RoutedEventArgs e)
        {
            userRepository.Remove(3);

        }

        private void btn_Click_Chose(object sender, RoutedEventArgs e)
        {
            var row = sender as DataGrid;
            var user= row.DataContext as UserModel;
            MessageBox.Show("check box");
        }

        private void listUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
