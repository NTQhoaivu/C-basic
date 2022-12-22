using LoginUseDbApp.Models;
using LoginUseDbApp.Repositories;
using LoginUseDbApp.ViewModels;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
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
using static System.Net.Mime.MediaTypeNames;

namespace LoginUseDbApp.Views
{

    public partial class ListUsersView : UserControl
    {
        private UserModel _ItemSelected;
        private IUserRepository userRepository;

        public ListUsersView()
        {
            userRepository = new UserRepository();
            InitializeComponent();
            //load();
        }
        //public void load()
        //{
        //    var users = userRepository.GetByAll().ToList();
        //    listUser.ItemsSource = users;
        //}

        //private void btn_clickDelete(object sender, RoutedEventArgs e)
        //{


        //    userRepository.Remove(_ItemSelected.Id);
        //    load();
        //}

        //private void btn_Click_Chose(object sender, RoutedEventArgs e)
        //{
        //    var dataGrid = sender as DataGrid;
        //    if (dataGrid != null)
        //    {
        //        var index = dataGrid.SelectedIndex;
        //        //dostuff with index
        //    }
        //}

        //private void listUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var dataGrid = sender as DataGrid;
        //    _ItemSelected = dataGrid.SelectedItem as UserModel;
        //    if (_ItemSelected != null)
        //    {
        //        txtUsername.Text = _ItemSelected.Username;
        //        txtPassword.Text = _ItemSelected.Password;
        //        txtName.Text = _ItemSelected.Name;
        //        txtLastName.Text = _ItemSelected.LastName;
        //        txtEmail.Text = _ItemSelected.Email;
        //    }

        //}

        //private void btn_add_click(object sender, RoutedEventArgs e)
        //{
        //    userRepository.Insert(txtUsername.Text, txtPassword.Text, txtName.Text, txtLastName.Text, txtEmail.Text);
        //    load();
        //}

        //private void btn_update_click(object sender, RoutedEventArgs e)
        //{
        //    userRepository.Edit(_ItemSelected.Id, txtUsername.Text, txtPassword.Text, txtName.Text, txtLastName.Text, txtEmail.Text);
        //    load();

        //}
    }
}
