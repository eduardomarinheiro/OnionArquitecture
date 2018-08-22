using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Xml;


namespace OnionArchitecture.Class
{
    public class StructureCreation
    {

        const string XML_INFORMATION_FILE = "Information.xml";


        XmlDocument xmlDoc = new XmlDocument();



        public bool Created { get; set; }
        public string XmlInformationFile { get; set; }
        public Layer Structure { get; set; }



        public StructureCreation()
        {
            this.ReadConfiguration();
        }


        private void ReadConfiguration()
        {
            try
            {
                if (this.ValidateXmlInformationFile())
                {
                    this.CreateStructure();

                }


            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        private bool ValidateXmlInformationFile()
        {
            bool xmlInformation = false;

            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);

            string path = Uri.UnescapeDataString(uri.Path);

            if (System.IO.Directory.Exists(Path.GetDirectoryName(path)))
            {
                if (System.IO.File.Exists(Path.GetDirectoryName(path) + "\\Resources\\" + XML_INFORMATION_FILE))
                {
                    this.XmlInformationFile = Path.GetDirectoryName(path) + "\\Resources\\" + XML_INFORMATION_FILE;
                }

            }

            try
            {
                xmlDoc.Load(this.XmlInformationFile);
                xmlInformation = true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }

            return xmlInformation;


        }

        private void CreateStructure()
        {
            XmlElement root = xmlDoc.DocumentElement;
            Layer _layer = new Layer();
            List<Layer> _structure = new List<Layer>();

            foreach (XmlNode item in root)
            {
                _layer = this.ExtractNodes(item);
                _structure.Add(_layer);
            }


        }

        private Layer ExtractNodes(XmlNode node)
        {
            if (node.Name == "Item")
            {
                Layer _node = new Layer();

                if (node.Attributes.Count > 0)
                {
                    _node.Description = node.Attributes["description"].Value;
                    _node.Abreviation = node.Attributes["abreviation"].Value;
                }

                if (node.HasChildNodes)
                {
                    _node.Layers.Add(this.ExtractNodes(node.ChildNodes.Item(0)));
                }

                return _node;
            }
            else
            {
                return null;
            }


            

        }



    }

}

