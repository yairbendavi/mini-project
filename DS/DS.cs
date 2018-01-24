using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
                Root = new XElement("ChildrenFile");
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
                Root = new XElement("ChildrenFile");
                Root.Save(Path);
            }
            else
                Root = XElement.Load(Path);
        }
    }
    public class ChildrenFile
    {
        public XElement Root;
        public string Path = @"ChildrenFileXml.xml";

        public ChildrenFile()
        {
            if (!File.Exists(Path))
            {
                Root = new XElement("ChildrenFile");
                Root.Save(Path);
            }
            else
                Root = XElement.Load(Path);
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
                Root = new XElement("ChildrenFile");
                Root.Save(Path);
            }
            else
                Root = XElement.Load(Path);
        }
    }
}
