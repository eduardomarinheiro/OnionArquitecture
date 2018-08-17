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
            catch (Exception ex)
            {
                throw ex;
            }

            return xmlInformation;


        }

        private void CreateStructure()
        {
            XmlElement root = xmlDoc.DocumentElement;
            Layer structure = new Layer();

            foreach (XmlNode item in root)
            {
                if (item.Attributes.Count > 0)
                {
                    foreach (XmlNode attribute in item.Attributes)
                    {
                        if (attribute.Value == "description")
                        {
                            structure.Description = attribute.Value;
                        }
                        if (attribute.Value == "abreviation")
                        {
                            structure.Abreviation = attribute.Value;
                        }
                    }

                }

                if (item.HasChildNodes)
                {
                    foreach (XmlElement child in item.ChildNodes)
                    {

                    }

                }



            }


        }
    }
}
