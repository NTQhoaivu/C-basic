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

namespace WpfConfigTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private XmlTreeViewManager tvMain;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            tvMain = new XmlTreeViewManager("default.xsd", "save.xml", tvScms, 5, "name", "_id".Split('|'));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            tvMain.Insert();
        }

        private void btnEditNode_Click(object sender, RoutedEventArgs e)
        {
            tvMain.EditNode(dynamicGrid);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            tvMain.Save("save.xml");
        }

        private void tvScms_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            tvMain.EditNode(dynamicGrid);
        }
    }
}
