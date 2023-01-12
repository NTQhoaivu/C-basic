using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<TagInfo> listTagData = new ObservableCollection<TagInfo>() { new TagInfo("1", "1", "1", "1"), new TagInfo("2", "2", "2", "2"), new TagInfo("3", "3", "3", "3"), new TagInfo("4", "4", "4", "4") };
        public MainWindow()
        {
            InitializeComponent();
            list.ItemsSource = listTagData;
        }
    }
    public class TagInfo
    {
        public string tagid;
        public string tagType;
        public string tagValue;
        public string tagQuality;
        public TagInfo(string tagid, string tagType, string tagValue, string tagQuality)
        {
            this.tagid = tagid;
            this.tagType = tagType;
            this.tagValue = tagValue;
            this.tagQuality = tagQuality;
        }

        //public string Tagid { get => tagid; set => tagid = value; }
        //public string TagType { get => tagType; set => tagType = value; }
        //public string TagValue { get => tagValue; set => tagValue = value; }
        //public string TagQuality { get => tagQuality; set => tagQuality = value; }
    }
}
