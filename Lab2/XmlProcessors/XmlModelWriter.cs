using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Application.Properties;

namespace Application.XmlProcessors
{
    public class XmlModelWriter
    {
        public void AddElement<T>(T item, string filePath)
        {
            var xElement = CreateXElement(item);

            var xDocument = XmlModelLoader.LoadXDocument(filePath);

            if(xDocument != null)
            {
                if (!xDocument.Root.Name.LocalName.Equals($"{item.GetType().Name}s"))
                    throw new InvalidCastException(ExceptionsMessages.IncorrectRootElement);

                xDocument.Root.Add(xElement);
            }
            else
            {
                xDocument = new XDocument(
                    new XElement($"{item.GetType().Name}s", xElement)
                );
            }

            xDocument.Save(filePath);
        }

        private XElement CreateXElement<T>(T item)
        {
            var type = item.GetType();
            var properties = type.GetProperties();
            var list = new List<XElement>();

            foreach (var property in properties)
                list.Add(new XElement(property.Name, property.GetValue(item))); 

            return new XElement(type.Name, list.ToArray());
        }
    }
}
