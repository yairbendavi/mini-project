using BE;
using DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DAL
{
    public interface IDAL
    {
        void AddNanny(Nanny nanny);
        void DeleteNanny(uint nannyId);
        void UpdateNanny(Nanny nanny);

        void AddMother(Mother mother);
        void DeleteMother(uint motherId);
        void UpdateMother(Mother mother);

        void AddChild(Child child);
        void DeleteChild(uint childId);
        void UpdateChild(Child child);

        void AddContract(Contract contract);
        void DeleteContract(uint contractNumber);
        void UpdateContract(Contract contract);

        List<Nanny> GetAllNannys();
        List<Mother> GetAllMothers();
        List<Child> GetAllChildren();
        List<Child> GetAllChildrenByMother(uint motherId);
        List<Contract> GetAllContracts();

    }

    public class DAL_imp : IDAL
    {
        // adds nanny to the DS
        public void AddNanny(Nanny nanny)
        {
            if (DataSource.Nannys.Exists(x => x.Id == nanny.Id))
            {
                IdException E = new IdException
                {
                    Message = "A nanny with the same id already exists," +
                              "please change the id number."
                };
                throw E;
            }

            DataSource.Nannys.Add(nanny);
        }
        // deletes nanny from the DS
        public void DeleteNanny(uint nannyId)
        {
            if (DataSource.Nannys.Exists(x => x.Id == nannyId))
                DataSource.Nannys.Remove(DataSource.Nannys.Find(x => x.Id == nannyId));
            else
            {
                IdException E = new IdException
                {
                    Message = "A nanny with this id does not exist," +
                                  "please change the id number."
                };
                throw E;
            }
        }
        // updates a specific nanny in the DS
        public void UpdateNanny(Nanny nanny)
        {
            DeleteNanny(nanny.Id);
            AddNanny(nanny);
        }

        // adds mother to the DS
        public void AddMother(Mother mother)
        {
            if (DataSource.Mothers.Exists(x => x.Id == mother.Id))
            {
                IdException E = new IdException
                {
                    Message = "A mother with the same id already exists," +
                              "please change the id number."
                };
                throw E;
            }

            DataSource.Mothers.Add(mother);
        }
        // deletes mother from the DS
        public void DeleteMother(uint motherId)
        {
            if (DataSource.Mothers.Exists(x => x.Id == motherId))
                DataSource.Mothers.Remove(DataSource.Mothers.Find(x => x.Id == motherId));
            else
            {
                IdException E = new IdException
                {
                    Message = "A mother with this id does not exist," +
                          "please change the id number."

                };
                throw E;
            }
        }
        // updates a specific mother in the DS
        public void UpdateMother(Mother mother)
        {
            DeleteMother(mother.Id);
            AddMother(mother);
        }

        // adds a child to DS
        public void AddChild(Child child)
        {
            if (DataSource.Children.Exists(x => x.Id == child.Id))
            {
                IdException E = new IdException
                {
                    Message = "A child with the same id already exists," +
                              "please change the id number."
                };
                throw E;
            }

            DataSource.Children.Add(child);
        }
        // deletes a child from the ds
        public void DeleteChild(uint childId)
        {
            if (DataSource.Children.Exists(x => x.Id == childId))
                DataSource.Children.Remove(DataSource.Children.Find(x => x.Id == childId));
            else
            {
                IdException E = new IdException
                {
                    Message = "A child with this id does not exist," +
                          "please change the id number."

                };
                throw E;
            }
        }
        //updates a specific child in the ds
        public void UpdateChild(Child child)
        {
            DeleteChild(child.Id);
            AddChild(child);
        }

        //adds a contract to the ds
        public void AddContract(Contract contract)
        {
            if (!DataSource.Nannys.Exists(x => x.Id == contract.Nanny.Id))
            {
                IdException E = new IdException
                {
                    Message = "A nanny with this id does not exist," +
                                 "please change the id number."

                };
                throw E;
            }
            if (!DataSource.Mothers.Exists(x => x.Id == contract.Mother.Id))
            {
                IdException E = new IdException
                {
                    Message = "A mother with this id does not exist," +
                     "please change the id number."

                };
                throw E;
            }
            if (!DataSource.Children.Exists(x => x.Id == contract.Child.Id))
            {
                IdException E = new IdException
                {
                    Message = "A child with this id does not exist," +
                     "please change the id number."

                };
                throw E;
            }

            contract.ContructNumber++;
            contract.Nanny.NumberOfChildren++;
            DataSource.Contracts.Add(contract);
        }
        //Deletes a contract from the ds
        public void DeleteContract(uint contractNumber)
        {
            if (DataSource.Contracts.Exists(x => x.ContructNumber == contractNumber))
                DataSource.Contracts.Remove(DataSource.Contracts.Find(x => x.ContructNumber == contractNumber));

            IdException E = new IdException
            {
                Message = "A contract with this number does not exist," +
                      "please change the number."

            };
            throw E;
        }
        //updates a specific contract in the ds
        public void UpdateContract(Contract contract)
        {
            DeleteContract(contract.ContructNumber);
            AddContract(contract);
        }

        //returns a lis t of all the nannys in the ds
        public List<Nanny> GetAllNannys()
        {
            var linq = from Nanny item in DataSource.Nannys
                       select item;
            return linq.ToList<Nanny>();

        }
        //returns a lis t of all the mothers in the ds
        public List<Mother> GetAllMothers()
        {
            var linq = from Mother item in DataSource.Mothers
                       select item;
            return linq.ToList<Mother>();
        }
        //returns a lis t of all the ChildrenFile in the ds
        public List<Child> GetAllChildren()
        {
            var linq = from Child item in DataSource.Children
                       select item;
            return linq.ToList<Child>();
        }
        //returns a lis t of all the ChildrenFile in the ds according to aq specific mother
        public List<Child> GetAllChildrenByMother(uint motherId)
        {
            var linq = from child in GetAllChildren()
                       where child.MotherId == motherId
                       select child;

            return linq.ToList<Child>();
        }
        //returns a lis t of all the contracts in the ds
        public List<Contract> GetAllContracts()
        {
            var linq = from Contract item in DataSource.Contracts
                       select item;
            return linq.ToList<Contract>();
        }
    }

    public class Xml_DAL_imp : IDAL
    {
        private string ChildrenPath = XmlDataSource.ChildrenFile.Path;
        private XElement ContractsFile = XmlDataSource.ContractsFile.Root;
        private string ContractsPath = XmlDataSource.ContractsFile.Path;
        private XElement MothersFile = XmlDataSource.MothersFile.Root;
        private string MothersPath = XmlDataSource.MothersFile.Path;
        private XElement NannysFile = XmlDataSource.NannysFile.Root;
        private string NannysPath = XmlDataSource.NannysFile.Path;

        private XElement ConvertToXElement<T>(T t)
        {
            XElement TElement = new XElement(typeof(T).ToString().Remove(0, 3));

            foreach (PropertyInfo item in typeof(T).GetProperties())
                TElement.Add(new XElement(item.Name, item.GetValue(t, null).ToString()));

            return TElement;
        }
        private Nanny XElementToNanny(XElement nanny)
        {
            Nanny nanny1 = new Nanny
            {
                Id = uint.Parse(nanny.Element("Id").Value)

            };

            return nanny1;
        }
        private Mother XElementToMother(XElement mother)
        {
            throw new NotImplementedException();
        }
        private Contract XElementToContract(XElement contract)
        {
            throw new NotImplementedException();
        }

        public void AddChild(Child child)
        {
            FileStream file = new FileStream(ChildrenPath, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Child>));
            List<Child> list1 = new List<Child>();

            try
            {
                list1 = (List<Child>)xmlSerializer.Deserialize(file);
                list1.Add(child);
            }
            catch
            {
                list1 = new List<Child>()
                {
                    child
                };
            }
            file.Close();
            XmlDataSource.ChildrenFile.SaveToXML(list1);
        }
        public void AddContract(Contract contract)
        {
            foreach (XElement element in ContractsFile.Elements())
                if (uint.Parse(element.Element("ContructNumber").Value) == contract.ContructNumber)
                    throw new IdException
                    {
                        Message = "A contract with this number allredy exists."
                    };

            ContractsFile.Add(ConvertToXElement<Contract>(contract));
            ContractsFile.Save(ContractsPath);
        }
        public void AddMother(Mother mother)
        {
            foreach (XElement element in MothersFile.Elements())
                if (uint.Parse(element.Element("Id").Value) == mother.Id)
                    throw new IdException
                    {
                        Message = "A mother with this id allredy exists."
                    };

            MothersFile.Add(ConvertToXElement<Mother>(mother));
            MothersFile.Save(MothersPath);
        }
        public void AddNanny(Nanny nanny)
        {
            foreach (XElement element in NannysFile.Elements())
                if (uint.Parse(element.Element("Id").Value) == nanny.Id)
                    throw new IdException
                    {
                        Message = "A nanny with this id allredy exists."
                    };

            NannysFile.Add(ConvertToXElement<Nanny>(nanny));
            NannysFile.Save(ContractsPath);
        }

        public void DeleteChild(uint childId)
        {
            FileStream file1 = new FileStream(ChildrenPath, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Child>));
            List<Child> list = (List<Child>)serializer.Deserialize(file1);

            list.Remove(list.Find(x => x.Id == childId));
            serializer.Serialize(file1, list);

            file1.Close();
        }
        public void DeleteContract(uint contractNumber)
        {
            XElement ContractElement;
            ContractElement = (from item in ContractsFile.Elements()
                               where uint.Parse(item.Element("ContractNumber").Value) == contractNumber
                               select item).FirstOrDefault();

            if (ContractElement == null)
                throw new IdException
                {
                    Message = "A contract with this id does not exist in the system."
                };

            ContractElement.Remove();
            ContractsFile.Save(ContractsPath);
        }
        public void DeleteMother(uint motherId)
        {
            XElement MotherElement;
            MotherElement = (from item in MothersFile.Elements()
                             where uint.Parse(item.Element("Id").Value) == motherId
                             select item).FirstOrDefault();

            if (MotherElement == null)
                throw new IdException
                {
                    Message = "A mother with this id does not exist in the system."
                };

            MotherElement.Remove();
            MothersFile.Save(MothersPath);
        }
        public void DeleteNanny(uint nannyId)
        {
            XElement NannyElement;
            NannyElement = (from item in NannysFile.Elements()
                            where uint.Parse(item.Element("Id").Value) == nannyId
                            select item).FirstOrDefault();

            if (NannyElement == null)
                throw new IdException
                {
                    Message = "A nanny with this id does not exist in the system."
                };

            NannyElement.Remove();
            NannysFile.Save(NannysPath);
        }

        public void UpdateChild(Child child)
        {
            DeleteChild(child.Id);
            AddChild(child);
        }
        public void UpdateContract(Contract contract)
        {
            DeleteContract(contract.ContructNumber);
            AddContract(contract);
        }
        public void UpdateMother(Mother mother)
        {
            DeleteMother(mother.Id);
            AddMother(mother);
        }
        public void UpdateNanny(Nanny nanny)
        {
            DeleteNanny(nanny.Id);
            AddNanny(nanny);
        }

        public List<Child> GetAllChildren()
        {
            throw new NotImplementedException();
        }
        public List<Child> GetAllChildrenByMother(uint motherId)
        {
            throw new NotImplementedException();
        }
        public List<Contract> GetAllContracts()
        {
            List<Contract> list = new List<Contract>();

            foreach (XElement element in ContractsFile.Elements())
                list.Add(XElementToContract(element));

            return list;
        }
        public List<Mother> GetAllMothers()
        {
            List<Mother> list = new List<Mother>();

            foreach (XElement element in MothersFile.Elements())
                list.Add(XElementToMother(element));

            return list;
        }
        public List<Nanny> GetAllNannys()
        {
            List<Nanny> list = new List<Nanny>();

            foreach (XElement element in NannysFile.Elements())
                list.Add(XElementToNanny(element));

            return list;
        }
    }
}