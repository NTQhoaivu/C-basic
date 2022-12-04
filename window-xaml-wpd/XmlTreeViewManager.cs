using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Schema;
using System.Xml;
using System.Windows;

namespace window_xaml_wpd
{
    class XmlTreeViewManager
    {
        XmlSchema _schema;
        XmlDocument document;
        TreeView treeView;
        private int maxLevel;
        private string nodeNameAttribute;
        private Dictionary<Object, Object> mapping = new Dictionary<object, object>();
        HashSet<string> hiddenAttributes = new HashSet<string>();

        public XmlTreeViewManager(string xsdFile, string xmlFile, TreeView tvScms, int maxLevel = 10, string nodeNameAttribute = "name", string[] hiddenAttributes = null)
        {
            this.treeView = tvScms;
            this.maxLevel = maxLevel;
            this.nodeNameAttribute = nodeNameAttribute;
            if (hiddenAttributes != null)
            {
                foreach (var t in hiddenAttributes)
                {
                    this.hiddenAttributes.Add(t);
                }
            }
            //XmlReaderSettings settings = GetReaderSettings();
            //settings.ValidationEventHandler += new ValidationEventHandler(OnValidationEvent);
            _schema = XmlDocumentHelper.LoadSchema(xsdFile);

            document = XmlDocumentHelper.LoadXML(xmlFile, xsdFile);

            XmlNodeData xmlNodeData = new XmlNodeData();
            BuildTree(_schema.Elements.Values.Cast<XmlSchemaElement>().ToDictionary(t => t.Name, t => t),
                tvScms.Items, document.ChildNodes, 1, xmlNodeData);

        }
        private void BuildTree(
            Dictionary<string, XmlSchemaElement> schemaItems,
            ItemCollection tvItems,
            XmlNodeList childNodes,
            int level,
            XmlNodeData xmlNodeData)
        {
            for (int i = 0; i < childNodes.Count; i++)
            {
                XmlNode childNode = childNodes[i];
                if (schemaItems.ContainsKey(childNode.Name))
                {

                    var att = childNode.Attributes.GetNamedItem(nodeNameAttribute);

                    var scheType = schemaItems[childNode.Name];

                    var newNodeData = new XmlNodeData { schema = scheType, xmlNode = childNode };

                    TreeViewItem tvNode = null;
                    if (level > maxLevel)
                    {
                        //tvNode.IsEnabled = false;
                        //node.Visibility = Visibility.Hidden;
                        //if (node.Parent != null)
                        //{
                        //    ((TreeViewItem)node.Parent).IsEnabled = false;
                        //}
                    }
                    else
                    {
                        tvNode = new TreeViewItem();
                        tvNode.Header = childNode.Name;
                        if (att != null)
                        {
                            if (att.Value != null && att.Value.Length > 0)
                            {
                                tvNode.Header = att.Value;
                            }
                        }
                        tvNode.Tag = newNodeData;
                    }


                    xmlNodeData.childNodeData.Add(newNodeData);

                    if (childNode.ChildNodes.Count > 0 && scheType != null)
                    {
                        XmlSchemaComplexType complexType = ((XmlSchemaElement)scheType).ElementSchemaType as XmlSchemaComplexType;
                        XmlSchemaSequence sequence = complexType.ContentTypeParticle as XmlSchemaSequence;
                        BuildTree(sequence.Items.Cast<XmlSchemaElement>().ToDictionary(t => t.Name, t => t),
                            tvNode?.Items, childNode.ChildNodes, level + 1, newNodeData);
                    }
                    if (tvNode != null)
                        tvItems?.Add(tvNode);
                }
            }
        }
        internal void Save(string filename)
        {
            XmlDocumentHelper.Save(document, filename);
        }

        internal void EditNode(Grid dynamicGrid)
        {
            mapping.Clear();

            dynamicGrid.Children.Clear();

            dynamicGrid.RowDefinitions.Clear();

            var node = treeView.SelectedItem as TreeViewItem;

            EditNode(dynamicGrid, node, 10, node.Tag as XmlNodeData);
        }
        internal void EditNode(Grid dynamicGrid, TreeViewItem selected, int level, XmlNodeData xmlNodeData)
        {

            AddAttributeControls(dynamicGrid, xmlNodeData, selected);

            if (level == 0)
            {
                return;
            }

            var childSchemas = XmlSchemaHelpers.GetChildElements(xmlNodeData.schema);

            if (childSchemas != null && childSchemas.Count > 0)
            {
                if (childSchemas.Count == 1 && childSchemas[0] is XmlSchemaElement)
                {
                    var schema = childSchemas[0] as XmlSchemaElement;

                    var attSchemas = XmlSchemaHelpers.GetAttributes(schema);

                    if (schema.MaxOccurs > 100 && attSchemas.Count == 2 && attSchemas[0].Name == "_id" && attSchemas[1].Name == "name")
                    {
                        AddListElement2(dynamicGrid, selected?.Items, childSchemas[0] as XmlSchemaElement);
                        return;
                    }
                }
                AddTabElement(dynamicGrid, selected, level, xmlNodeData);
            }
        }
        private void AddListElement2(Grid dynamicGrid, ItemCollection items, XmlSchemaElement xmlSchemaElement)
        {
            if (items == null)
            {
                return;
            }
            DataGrid gridView = new DataGrid();

            List<TagInfo> records = new List<TagInfo>();
            Grid.SetRow(gridView, 1);


            gridView.Margin = new Thickness(5);

            gridView.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;


            dynamicGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100, GridUnitType.Star) });
            dynamicGrid.Children.Add(gridView);

            //var firstItem = items[0] as TreeViewItem;
            //var schema = (firstItem.Tag as XmlNodeData).schema;
            //var attSchemas = XmlSchemaHelpers.GetAttributes(schema);


            //var records = new ObservableCollection<Record>();

            foreach (TreeViewItem item in items)
            {
                var node = (item.Tag as XmlNodeData).xmlNode;
                var record = new TagInfo(node.Attributes["id"]?.Value, node.Attributes["name"]?.Value);
                records.Add(record);
            }

            gridView.ItemsSource = records;


        }
        private void AddTabElement(Grid dynamicGrid, TreeViewItem selected, int level, XmlNodeData xmlNodeData)
        {
            TabControl tab = new TabControl();
            Grid.SetRow(tab, 1);
            tab.Margin = new Thickness(5);
            dynamicGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100, GridUnitType.Auto) });
            dynamicGrid.Children.Add(tab);


            foreach (var treeViewItem in xmlNodeData.childNodeData)
            {
                TabItem ti = new TabItem();
                ti.Header = treeViewItem.schema.Name;
                var tabGrid = new Grid();
                ti.Content = tabGrid;
                tabGrid.MinHeight = 100;

                tab.Items.Add(ti);

                EditNode(tabGrid, null, level - 1, treeViewItem);
            }
        }
        private void AddAttributeControls(Grid dynamicGrid, XmlNodeData xmlNodeData, TreeViewItem selected)
        {
            var attSchema = XmlSchemaHelpers.GetAttributes(xmlNodeData.schema);

            if (attSchema != null && attSchema.Count > 0)
            {
                dynamicGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(attSchema.Count * 30 + 15) });
                Grid attGrid = new Grid();
                attGrid.Margin = new Thickness(10);
                attGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(100, GridUnitType.Pixel) });
                attGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(200, GridUnitType.Pixel) });
                Grid.SetColumn(attGrid, 0);
                dynamicGrid.Children.Add(attGrid);
                int row = 0;
                foreach (var schema in attSchema)
                {
                    if (!hiddenAttributes.Contains(schema.Name))
                    {
                        AddGridItem(xmlNodeData.xmlNode, attGrid, schema, row++, selected);
                    }
                }
            }
            else
            {
                dynamicGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(15) });
            }
        }
        private void AddGridItem(XmlNode xmlNode, Grid dynamicGrid, XmlSchemaAttribute schema, int row, TreeViewItem selected)
        {
            var att = xmlNode.Attributes.GetNamedItem(schema.Name);

            Label lb = new Label();
            lb.Content = schema.Name;
            Grid.SetRow(lb, row);
            dynamicGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(25) });
            dynamicGrid.Children.Add(lb);
            var attType = schema.AttributeSchemaType.Datatype.ValueType.Name;
            var typeContent = schema.AttributeSchemaType.Content;
            if (typeContent is XmlSchemaSimpleTypeRestriction)
            {
                Control tb = null;
                List<string> enumValues = new List<string>();
                int min = int.MinValue, max = int.MaxValue;
                string pattern = null;
                var g = typeContent as XmlSchemaSimpleTypeRestriction;
                foreach (var a in g.Facets)
                {
                    if (a is XmlSchemaEnumerationFacet)
                    {
                        enumValues.Add(((XmlSchemaEnumerationFacet)a).Value);
                        attType = "Enum";
                    }
                    else if (a is XmlSchemaMinInclusiveFacet)
                    {
                        min = int.Parse(((XmlSchemaMinInclusiveFacet)a).Value);
                    }
                    else if (a is XmlSchemaMaxInclusiveFacet)
                    {
                        max = int.Parse(((XmlSchemaMaxInclusiveFacet)a).Value);
                    }
                    else if (a is XmlSchemaPatternFacet)
                    {
                        pattern = ((XmlSchemaPatternFacet)a).Value;
                    }
                }

                switch (attType)
                {
                    case "Boolean":
                        var a = new CheckBox();
                        a.Checked += OnChecked;
                        tb = a;
                        break;
                    case "Enum":
                        var c = new ComboBox();
                        foreach (var x in enumValues)
                        {
                            c.Items.Add(x);
                        }
                        tb = c;
                        break;
                    default:

                        TextBox b = new TextBox();

                        tb = b;
                        if (att != null)
                        {
                            b.Text = att.Value;
                        }
                        b.TextChanged += OnTextChanged;
                        break;
                }
                if (att != null)
                {
                    //tb.Text = att.Value;
                    mapping.Add(tb, att);
                    if (att.Name == this.nodeNameAttribute && selected != null)
                        mapping[att] = selected;
                }
                else
                {
                    var att2 = document.CreateAttribute(schema.Name);
                    xmlNode.Attributes.Append(att2);
                    mapping.Add(tb, att2);
                    if (att2.Name == this.nodeNameAttribute && selected != null)
                        mapping[att2] = selected;
                }
                tb.Margin = new Thickness(2);
                Grid.SetRow(tb, row);
                Grid.SetColumn(tb, 1);
                dynamicGrid.Children.Add(tb);
            }


        }
        private void OnChecked(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            object att = null;
            mapping.TryGetValue(sender, out att);
            if (att is XmlNode)
            {
                ((XmlNode)att).Value = ((TextBox)sender).Text;
                object att2 = null;
                mapping.TryGetValue(att, out att2);
                if (att2 is TreeViewItem)
                {
                    ((TreeViewItem)att2).Header = ((TextBox)sender).Text;
                }
            }
        }

        internal void Insert()
        {
            InsertChild(treeView.SelectedItem as TreeViewItem);
        }

        internal void InsertChild(TreeViewItem selected)
        {
            XmlNodeData xmlNodeData = selected.Tag as XmlNodeData;

            var childSchemas = XmlSchemaHelpers.GetChildElements(xmlNodeData.schema);

            if (childSchemas != null)
            {
                foreach (var schema in childSchemas)
                {
                    if (schema is XmlSchemaElement)
                    {
                        TreeViewItem newNode = InsertNode(schema as XmlSchemaElement, xmlNodeData.xmlNode, selected);
                        InsertChild(newNode);
                    }
                }
            }
        }

        private TreeViewItem InsertNode(XmlSchemaElement schema, XmlNode xmlNode, TreeViewItem selected)
        {
            TreeViewItem node = new TreeViewItem();
            node.Header = schema.Name;
            XmlNode x = document.CreateElement(schema.Name);
            xmlNode.InsertAfter(x, xmlNode.LastChild);
            node.Tag = new XmlNodeData { schema = schema, xmlNode = x };
            selected.Items.Add(node);
            return node;
        }

    }
}
