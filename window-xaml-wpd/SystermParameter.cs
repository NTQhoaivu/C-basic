using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace window_xaml_wpd
{
    internal class SystermParameter
    {
    }
    public class TagInfo
    {
        public TagInfo(string id, string description)
        {
            this.id = id;
            this.name = description;
        }

        public string id { get; set; }
        public string name { get; set; }
    }
    public class Property
    {
        public Property(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; private set; }
        public object Value { get; set; }
    }

    public class Record
    {
        private readonly ObservableCollection<Property> properties = new ObservableCollection<Property>();

        public Record(params Property[] properties)
        {
            foreach (var property in properties)
                Properties.Add(property);
        }

        public ObservableCollection<Property> Properties
        {
            get { return properties; }
        }
    }
}
