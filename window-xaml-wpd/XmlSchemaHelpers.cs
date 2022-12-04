using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace window_xaml_wpd
{
    public sealed class XmlSchemaHelpers
    {
        private XmlSchemaHelpers() { }
        public static List<string> GetElementChildNames(XmlSchemaElement element, ICollection<string> exclude = null)
        {
            XmlSchemaComplexType complexType = element.ElementSchemaType as XmlSchemaComplexType;
            List<string> elementNames = new List<string>();
            // Get the sequence particle of the complex type.
            XmlSchemaSequence sequence = complexType.ContentTypeParticle as XmlSchemaSequence;

            if (sequence != null)
            {
                // Iterate over each XmlSchemaElement in the Items collection.
                foreach (XmlSchemaElement childElement in sequence.Items)
                {
                    if (exclude == null || !exclude.Contains(childElement.Name) || childElement.MaxOccurs > 1)
                    {
                        elementNames.Add(childElement.Name);
                    }
                }
            }
            return elementNames;
        }
        public static XmlSchemaElement GetChildElementByName(XmlSchemaElement element, string elementName)
        {
            XmlSchemaComplexType complexType = element.ElementSchemaType as XmlSchemaComplexType;
            XmlSchemaSequence sequence = complexType.ContentTypeParticle as XmlSchemaSequence;

            if (sequence != null)
            {
                // Iterate over each XmlSchemaElement in the Items collection.
                foreach (XmlSchemaElement childElement in sequence.Items)
                {
                    if (elementName.Equals(childElement.Name))
                    {
                        return childElement;
                    }
                }
            }
            return null;
        }
        public static XmlSchemaObjectCollection GetChildElements(XmlSchemaElement element)
        {
            XmlSchemaComplexType complexType = element.ElementSchemaType as XmlSchemaComplexType;
            XmlSchemaSequence sequence = complexType.ContentTypeParticle as XmlSchemaSequence;

            if (sequence != null)
            {
                return sequence.Items;
            }
            return null;
        }
        public static List<string> GetAttributeNames(XmlSchemaElement element)
        {
            XmlSchemaComplexType complexType = element.ElementSchemaType as XmlSchemaComplexType;
            List<string> attributeNames = new List<string>();

            // If the complex type has any attributes, get an enumerator
            // and write each attribute name to the console.
            if (complexType.AttributeUses.Count > 0)
            {
                IDictionaryEnumerator enumerator =
                    complexType.AttributeUses.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    XmlSchemaAttribute attribute =
                        (XmlSchemaAttribute)enumerator.Value;

                    attributeNames.Add(attribute.Name);
                }
            }
            return attributeNames;
        }
        public static List<XmlSchemaAttribute> GetAttributes(XmlSchemaElement element)
        {
            XmlSchemaComplexType complexType = element.ElementSchemaType as XmlSchemaComplexType;
            List<XmlSchemaAttribute> attributes = new List<XmlSchemaAttribute>();

            // If the complex type has any attributes, get an enumerator
            // and write each attribute name to the console.
            if (complexType.AttributeUses.Count > 0)
            {
                IDictionaryEnumerator enumerator =
                    complexType.AttributeUses.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    XmlSchemaAttribute attribute =
                        (XmlSchemaAttribute)enumerator.Value;

                    attributes.Add(attribute);
                }
            }
            return attributes;
        }
    }
}
