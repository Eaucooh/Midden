using System;
using System.Collections.Generic;
using System.Xml;

namespace RemoveAtTag
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string node = Console.ReadLine();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(path);
            List<XmlNode> nodes = GetAllNode(xmldoc);
            foreach (XmlNode item in nodes)
            {
                if (item.Name.Equals(node))
                {
                    item.RemoveAll();
                }
            }
            xmldoc.Save(path);
        }

        private static List<XmlNode> GetAllNode(XmlDocument doc)
        {
            List<XmlNode> nodes = new List<XmlNode>();
            foreach (XmlNode item in doc.ChildNodes)
            {
                nodes.Add(item);
                if (item.HasChildNodes)
                {
                    AddAllNode(item, nodes);
                }
            }
            return nodes;
        }

        private static void AddAllNode(XmlNode item, List<XmlNode> xns)
        {
            xns.Add(item);
            if (item.HasChildNodes)
            {
                foreach (XmlNode node in item.ChildNodes)
                {
                    AddAllNode(node, xns);
                }
            }
        }
    }
}
