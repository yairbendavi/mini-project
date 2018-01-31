using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace DS
{
    // this class includes lists which contain the objects for this project.
    public class DataSource
    {
        public static List<Nanny> Nannys = new List<Nanny>();
        public static List<Mother> Mothers = new List<Mother>();
        public static List<Child> Children = new List<Child>();
        public static List<Contract> Contracts = new List<Contract>();
    }

    public class XmlDataSource
    {
        public static NannysFile NannysFile = new NannysFile();
        public static MothersFile MothersFile = new MothersFile();
        public static ChildrenFile ChildrenFile = new ChildrenFile();
        public static ContractsFile ContractsFile = new ContractsFile();
    }

    public class NannysFile
    {
        public XElement Root;
        public string Path = @"NannysXml.xml";

        public NannysFile()
        {
            if (!File.Exists(Path))
            {
                Root = new XElement("NannysFile");
                Root.Save(Path);
            }
            else
                Root = XElement.Load(Path);
        }
    }
    public class MothersFile
    {
        public XElement Root;
        public string Path = @"MothersXml.xml";

        public MothersFile()
        {
            if (!File.Exists(Path))
            {
                Root = new XElement("MothersFile");
                Root.Save(Path);
            }
            else
                Root = XElement.Load(Path);
        }
    }
    public class ChildrenFile
    {
        public string Path = @"ChildrenFile.xml";

        public ChildrenFile()
        {
            if (!File.Exists(Path))
            {
                CreateFiles();
            }
        }

        private void CreateFiles()
        {
            FileStream file = new FileStream(Path, FileMode.Create);
            file.Close();
        }

        public void SaveToXML(List<Child> list)
        {
            FileStream file = new FileStream(Path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(list.GetType());
            xmlSerializer.Serialize(file, list);
            file.Close();
        }
    }
    public class ContractsFile
    {
        public XElement Root;
        public string Path = @"ContractsXml.xml";

        public ContractsFile()
        {
            if (!File.Exists(Path))
            {
                Root = new XElement("ContractsFile");
                Root.Save(Path);
            }
            else
                Root = XElement.Load(Path);
        }
    }
}
