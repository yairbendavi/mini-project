using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;

namespace BL
{
    public interface IBL
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

        IEnumerable<Nanny> GetTamatNannys();
        IEnumerable<Nanny> GetCompatibleNannys(Mother mother);
        IEnumerable<Nanny> GetCompatibleNannysByDistance(Mother mother);
        IEnumerable<Child> GetChildrenWithoutNanny();
        IEnumerable<Contract> GetContractsByCondition(Condition condition);
        IEnumerable<IGrouping<int, Nanny>> GetNannysGroupedByChildrenAge(bool maxAge, bool toSort = false);
        IEnumerable<IGrouping<int, Contract>> GetContractsGroupedByDistance(bool toSort = false);

        int GetNumberOfContractsByCondition(Condition condition);
        int GetNumberOfBrothersWithSameNanny(uint nannyId, uint motherId);

        double GetSalary(Contract contract);

        List<Contract> GetAllContractsByType(int id, string type);
        void AddObject<T>(T obj);
        void AddObjects<T>(List<T> objects);
        void DeleteObject<T>(T obj);
        void DeleteObjects<T>(List<T> objects);
        void UpdateObject<T>(T obj);
        void UptateObjects<T>(List<T> objects);
    }

    public class BL_imp : IBL
    {
        private DAL_imp DAL = new DAL_imp();
        /// return whether the nanny works at the hours that the mother needs.
        private bool Fit(Nanny nanny, Mother mother)
        {
            for (int i = 0; i < 7; i++)
                if (mother.RequiredDays[i] && !nanny.DaysOfWork[i])
                    return false;

            for (int i = 0; i < 7; i++)
                if (mother.RequiredDays[i] == true)
                {
                    if (DateTime.Compare(nanny.WorkingHours[i].BeginingTime,
                        mother.RequiredHours[i].BeginingTime) > 0)
                        return false;
                    if (DateTime.Compare(nanny.WorkingHours[i].EndTime,
                        mother.RequiredHours[i].EndTime) < 0)
                        return false;
                }

            return true;
        }
        /// return the offset betwenn the mother's needed hours, to the nanny's offer hours.
        private int FitNanny(Nanny nanny, Mother mother)
        {
            int sum = 0;
            if (!Fit(nanny, mother))
            {
                for (int i = 0; i < 7; i++)
                {
                    if (mother.RequiredDays[i])
                    {
                        if (!nanny.DaysOfWork[i])
                            sum += (int)(mother.RequiredHours[i].EndTime - mother.RequiredHours[i].BeginingTime).TotalMinutes;

                        else
                        {
                            if (DateTime.Compare(mother.RequiredHours[i].BeginingTime, nanny.WorkingHours[i].BeginingTime) < 0)
                                sum += (int)(nanny.WorkingHours[i].BeginingTime - mother.RequiredHours[i].BeginingTime).TotalMinutes;
                            if (DateTime.Compare(mother.RequiredHours[i].EndTime, nanny.WorkingHours[i].EndTime) > 0)
                                sum += (int)(mother.RequiredHours[i].EndTime - nanny.WorkingHours[i].EndTime).TotalMinutes;
                        }
                    }
                }
            }
            return sum;
        }
        /// to intialize the values of the DS
        public void Initialization()
        {
            Nanny Ayala_Zehavi = new Nanny
            (123456782, "zehavi", "Ayala", new DateTime(1980, 5, 19), "0523433333", "Beit Ha-Defus St 21,Jerusalem,israel", true, 2, 3, 5, 120, 12, true, 30, 5000, new bool[] { true, true, true, true, true, false, false }, true, " ",
            new Dictionary<int, HoursRange>
            {
                    {0, new HoursRange(new DateTime(0, 0, 0, 7, 30, 0, 0), new DateTime(0, 0, 0, 10, 0, 0, 0))},
                    {1, new HoursRange(new DateTime(0, 0, 0, 9, 30, 0, 0), new DateTime(0, 0, 0, 14, 45, 0, 0))},
                    {2, new HoursRange(new DateTime(0, 0, 0, 15, 30, 0, 0), new DateTime(0, 0, 0, 19, 0, 0, 0))},
                    {3, new HoursRange(new DateTime(0, 0, 0, 16, 30, 0, 0), new DateTime(0, 0, 0, 22, 15, 0, 0))},
                    {4, new HoursRange(new DateTime(0, 0, 0, 18, 30, 0, 0), new DateTime(0, 0, 0, 23, 45, 0, 0))},
                    {5, new HoursRange(new DateTime(0, 0, 0, 0, 0, 0, 0), new DateTime(0, 0, 0, 0, 0, 0, 0))},
                    {6, new HoursRange(new DateTime(0, 0, 0, 0, 0, 0, 0), new DateTime(0, 0, 0, 0, 0, 0, 0))},
            });

            Nanny Moria_Schneider = new Nanny
            (198345394, "Schneider", "Moria", new DateTime(1974, 12, 23), "0523433598", "Givati St 21,Ashkelon,israel", false, 1, 2, 9, 60, 6, true, 25.0, 4250.0, new bool[] { false, true, true, true, true, true, false }, false, " ",
            new Dictionary<int, HoursRange>
            {
                    {0, new HoursRange(new DateTime(0, 0, 0, 0, 0, 0, 0), new DateTime(0, 0, 0, 0, 0, 0, 0))},
                    {1, new HoursRange(new DateTime(0, 0, 0, 15, 15, 0, 0), new DateTime(0, 0, 0, 19, 20, 0, 0))},
                    {2, new HoursRange(new DateTime(0, 0, 0, 12, 30, 0, 0), new DateTime(0, 0, 0, 14, 0, 0, 0))},
                    {3, new HoursRange(new DateTime(0, 0, 0, 13, 30, 0, 0), new DateTime(0, 0, 0, 19, 15, 0, 0))},
                    {4, new HoursRange(new DateTime(0, 0, 0, 18, 30, 0, 0), new DateTime(0, 0, 0, 23, 45, 0, 0))},
                    {5, new HoursRange(new DateTime(0, 0, 0, 7, 0, 0, 0), new DateTime(0, 0, 0, 11, 0, 0, 0))},
                    {6, new HoursRange(new DateTime(0, 0, 0, 0, 0, 0, 0), new DateTime(0, 0, 0, 0, 0, 0, 0))},
            });
            AddNanny(Ayala_Zehavi);
            AddNanny(Moria_Schneider);
            Mother Ayelt_Shaked = new Mother
            (666666666, "Ayelt", "Shaked", "0521234566", "Shakhal St 23,Jerusalem,isreal", "Shakhal St 23,Jerusalem,isreal", true, new bool[] { true, true, true, true, true, false },
            new Dictionary<int, HoursRange>
            {
                    {0, new HoursRange(new DateTime(0, 0, 0, 0, 0, 0, 0), new DateTime(0, 0, 0, 0, 0, 0, 0))},
                    {1, new HoursRange(new DateTime(0, 0, 0, 15, 15, 0, 0), new DateTime(0, 0, 0, 19, 20, 0, 0))},
                    {2, new HoursRange(new DateTime(0, 0, 0, 12, 30, 0, 0), new DateTime(0, 0, 0, 14, 0, 0, 0))},
                    {3, new HoursRange(new DateTime(0, 0, 0, 13, 30, 0, 0), new DateTime(0, 0, 0, 19, 15, 0, 0))},
                    {4, new HoursRange(new DateTime(0, 0, 0, 18, 30, 0, 0), new DateTime(0, 0, 0, 23, 45, 0, 0))},
                    {5, new HoursRange(new DateTime(0, 0, 0, 7, 0, 0, 0), new DateTime(0, 0, 0, 11, 0, 0, 0))},
                    {6, new HoursRange(new DateTime(0, 0, 0, 0, 0, 0, 0), new DateTime(0, 0, 0, 0, 0, 0, 0))},
            }, " ", 20);
            Mother Gilat_Bennet = new Mother
            (113542872, "Bennet", "Gilat", "0522567566", "Givati St 7,Ashkelon,isreal", "Rosh Pina St 3,Ashdod,israel", true, new bool[] { true, true, true, true, true, false },
            new Dictionary<int, HoursRange>
            {
                    {0, new HoursRange(new DateTime(0, 0, 0, 0, 0, 0, 0), new DateTime(0, 0, 0, 0, 0, 0, 0))},
                    {1, new HoursRange(new DateTime(0, 0, 0, 15, 15, 0, 0), new DateTime(0, 0, 0, 19, 20, 0, 0))},
                    {2, new HoursRange(new DateTime(0, 0, 0, 12, 30, 0, 0), new DateTime(0, 0, 0, 14, 0, 0, 0))},
                    {3, new HoursRange(new DateTime(0, 0, 0, 13, 30, 0, 0), new DateTime(0, 0, 0, 19, 15, 0, 0))},
                    {4, new HoursRange(new DateTime(0, 0, 0, 18, 30, 0, 0), new DateTime(0, 0, 0, 23, 45, 0, 0))},
                    {5, new HoursRange(new DateTime(0, 0, 0, 7, 0, 0, 0), new DateTime(0, 0, 0, 11, 0, 0, 0))},
                    {6, new HoursRange(new DateTime(0, 0, 0, 0, 0, 0, 0), new DateTime(0, 0, 0, 0, 0, 0, 0))},
            }, " ", 20);
            AddMother(Ayelt_Shaked);
            AddMother(Gilat_Bennet);
            Child Yair = new Child(322690124, 666666666, "Yair", new DateTime(2013, 2, 12), false, "the smartest boy in the world");
            Child Dror = new Child(302302039, 113542872, "Dror", new DateTime(2015, 3, 29), true, "Is STUPID");
            AddChild(Yair);
            AddChild(Dror);
            Contract contract1 = new Contract(Dror, Ayelt_Shaked, Ayala_Zehavi, true, true, new DateTime(2019, 12, 20));
            Contract contract2 = new Contract(Yair, Gilat_Bennet, Moria_Schneider, false, false, new DateTime(2021, 4, 13));
            AddContract(contract1);
            AddContract(contract2);
        }

        // adds a nanny to DS
        public void AddNanny(Nanny nanny)
        {
            if (DateTime.Now.Year - nanny.BirthDate.Year < 18)
            {
                AgeException E = new AgeException
                {
                    Message = "A nanny cannot be under 18!!!"
                };
                throw E;
            }
            else
                DAL.AddNanny(nanny);
        }
        // deletes a nanny from the DS accroding to id no.
        public void DeleteNanny(uint nannyId)
        {
            DeleteObjects<Contract>(GetContractsByCondition(x => x.Nanny.Id == nannyId).ToList<Contract>());
            DAL.DeleteNanny(nannyId);
        }
        // by giving a new nanny, the function updates a nanny.
        public void UpdateNanny(Nanny nanny)
        {
            DAL.UpdateNanny(nanny);
        }

        // adds a new mother to the DS
        public void AddMother(Mother mother)
        {
            DAL.AddMother(mother);
        }
        // Deletes a specific mother from the DS
        public void DeleteMother(uint motherId)

        {
            DeleteObjects<Contract>(GetContractsByCondition(x => x.Mother.Id == motherId).ToList<Contract>());
            DAL.DeleteMother(motherId);
        }
        // updates a specific mother in the DS
        public void UpdateMother(Mother mother)
        {
            DAL.UpdateMother(mother);
        }

        // adds a child to DS
        public void AddChild(Child child)
        {
            DAL.AddChild(child);
        }
        // deletes a specific child from the DS
        public void DeleteChild(uint childId)
        {
            DeleteObjects<Contract>(GetContractsByCondition(x => x.Child.Id == childId).ToList<Contract>());
            DAL.DeleteNanny(childId);
        }
        // updates a specific child in the DS
        public void UpdateChild(Child child)
        {
            DAL.UpdateChild(child);
        }

        // adds a new contract to the DS
        public void AddContract(Contract contract)
        {
            if (contract.Nanny.NumberOfChildren >= contract.Nanny.MaxChildren)
            {
                IncompatibleParametersException E = new IncompatibleParametersException
                {
                    Message = "This nanny cannot take anymore children"
                };
                throw E;
            }
            if (DateTime.Now.Year == contract.Child.BirthDay.Year)
            {
                if (DateTime.Now.Month - contract.Child.BirthDay.Month < 3)
                {
                    AgeException E = new AgeException
                    {
                        Message = "Cannot sign a contract with a child under 3 months."
                    };
                    throw E;
                }
            }


            int brothersWithNanny = GetNumberOfBrothersWithSameNanny
                (contract.Mother.Id, contract.Nanny.Id);

            if (contract.Nanny.AllowsSalaryPerHour)
                contract.SalaryPerHour = contract.Nanny.SalareyPerHour * (1 - 0.02 * brothersWithNanny);
            else
                contract.SalaryPerMonth = contract.Nanny.SalareyPerMonth * (1 - 0.02 * brothersWithNanny);

            contract.PerMonthOrHour = contract.Nanny.AllowsSalaryPerHour && contract.Mother.WantsSalaryPerHour;

            DAL.AddContract(contract);
        }
        // deletes a specific contracts from the DS
        public void DeleteContract(uint contractNumber)
        {
            DAL.DeleteContract(contractNumber);
        }
        // updates a specifc contract
        public void UpdateContract(Contract contract)
        {
            DAL.UpdateContract(contract);
        }

        // returns a List which includes all the nannies
        public List<Nanny> GetAllNannys()
        {
            return DAL.GetAllNannys();
        }
        // returns a List which includes all the mothers
        public List<Mother> GetAllMothers()
        {
            return DAL.GetAllMothers();
        }
        // returns a List which includes all the children
        public List<Child> GetAllChildren()
        {
            return DAL.GetAllChildren();
        }
        // returns a List which includes all the children from the same mother
        public List<Child> GetAllChildrenByMother(uint motherId)
        {
            return DAL.GetAllChildrenByMother(motherId);
        }
        // returns a List which includes all the contracts.
        public List<Contract> GetAllContracts()
        {
            return DAL.GetAllContracts();
        }

        // returns a linq of all the Tamat nannies
        public IEnumerable<Nanny> GetTamatNannys()
        {
            var tamatNannys = from Nanny nanny in DAL.GetAllNannys()
                              where nanny.VacationDays == true
                              select nanny;

            //List<Nanny> tamatNannys = new List<Nanny>();
            foreach (Nanny nanny in tamatNannys)
                yield return nanny;

            //return tamatNannys;
        }
        /* returns a linq of all the nannies that works on the convinient hours 
        of that mother demands. If no nanny fits, the function will return the best
        5 nannies.
        */
        public IEnumerable<Nanny> GetCompatibleNannys(Mother mother)
        {
            var linq1 = from Nanny item in GetAllNannys()
                        where Fit(item, mother) == true
                        select item;
            var linq2 = from Nanny item in GetAllNannys()
                        orderby FitNanny(item, mother)
                        select item;

            if (linq1 == null)
                for (int i = 0; i < 5; i++)
                    yield return linq2.ToArray()[i];
            else
                foreach (Nanny nanny in linq1)
                    yield return nanny;
        }
        // just like the first function, with a distance condition.         
        public IEnumerable<Nanny> GetCompatibleNannysByDistance(Mother mother)
        {
            //List<Nanny> list = new List<Nanny>();

            var linq = from Nanny item in GetAllNannys()
                       where CalculateDistance(item.Adress, mother.AddressForNanny) <= mother.MaxDistance
                       select item;

            foreach (Nanny item in linq)
                yield return item;
            //return list;
        }
        // returns a linq of all the children without nanny
        public IEnumerable<Child> GetChildrenWithoutNanny()
        {
            foreach (Child child in DAL.GetAllChildren())
                if (DAL.GetAllContracts().Find(x => x.Child.Id == child.Id).Child == null)
                    yield return child;
        }
        // returns a linq of all the contracts that fit a condition
        // which given by the user.
        public IEnumerable<Contract> GetContractsByCondition(Condition condition)
        {
            var contractsByCondition = from Contract contract in DAL.GetAllContracts()
                                       where condition(contract) == true
                                       select contract;

            foreach (Contract contract in contractsByCondition)
                yield return contract;
        }
        // returns a linq of all the nannies grouped by children.
        public IEnumerable<IGrouping<int, Nanny>> GetNannysGroupedByChildrenAge(bool maxAge, bool toSort = false)
        {
            IEnumerable<IGrouping<int, Nanny>> linq;
            if (maxAge && toSort)
            {
                linq = from item in GetAllNannys()
                       orderby item.Id
                       group item by (item.MaxAge / 3);
            }
            else if (maxAge && !toSort)
            {
                linq = from item in GetAllNannys()
                       group item by (item.MaxAge / 3);
            }
            else if (!maxAge && toSort)
            {
                linq = from item in GetAllNannys()
                       orderby item.Id
                       group item by (item.MinAge / 3);
            }
            else
            {
                linq = from item in GetAllNannys()
                       group item by (item.MinAge / 3);
            }

            return linq;
        }
        // returns a linq of all the contracts grouped by distance.
        public IEnumerable<IGrouping<int, Contract>> GetContractsGroupedByDistance(bool toSort = false)
        {
            IEnumerable<IGrouping<int, Contract>> linq;
            if (toSort)
            {
                linq = from item in GetAllContracts()
                       orderby item.ContructNumber
                       group item by CalculateDistance(item.Mother.AddressForNanny, item.Nanny.Adress);
            }
            else
            {
                linq = from item in GetAllContracts()
                       group item by CalculateDistance(item.Mother.AddressForNanny, item.Nanny.Adress);
            }

            return linq;
        }

        // returns the number of all the contracts that fit to specific condition.
        public int GetNumberOfContractsByCondition(Condition condition)
        {
            return GetContractsByCondition(condition).ToList<Contract>().Count;
        }
        // returns the number of brothers who belong to same nanny.
        public int GetNumberOfBrothersWithSameNanny(uint nannyId, uint motherId)
        {
            int brothersWithNanny = 0;
            foreach (Contract contract1 in DAL.GetAllContracts())
                if (contract1.Nanny.Id == nannyId)
                    if (contract1.Mother.Id == motherId)
                        brothersWithNanny++;

            return brothersWithNanny;
        }
        // return the distance between to addresses the the function is given.
        public static int CalculateDistance(string source, string dest)
        {
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }

        // returns the salary of a specific contract
        public double GetSalary(Contract contract)
        {
            if (contract.Nanny.AllowsSalaryPerHour && contract.Mother.WantsSalaryPerHour)
            {
                int hoursOfWorkPerWeek = 0;
                for (int i = 0; i < 7; i++)
                    if (contract.Mother.RequiredDays[i])
                    {
                        int begining = contract.Mother.RequiredHours[i].BeginingTime.Hour;
                        int end = contract.Mother.RequiredHours[i].EndTime.Hour;

                        int timeSpan = end - begining + 1;

                        hoursOfWorkPerWeek += timeSpan;
                    }

                return hoursOfWorkPerWeek * contract.SalaryPerHour * 4;
            }
            else
            {
                return contract.SalaryPerMonth;
            }
        }

        // returns a list of all the contracts that belong to one entity.
        public List<Contract> GetAllContractsByType(int id, string type)
        {
            switch (type)
            {
                case "Mother":
                case "mother":
                    return GetAllContracts().FindAll(x => x.Mother.Id == id);
                case "Nanny":
                case "nanny":
                    return GetAllContracts().FindAll(x => x.Nanny.Id == id);
                case "Child":
                case "child":
                    return GetAllContracts().FindAll(x => x.Child.Id == id);

                default:
                    throw new WrongTypeException { Message = "This tipe is wrong" };
            }
        }
        // generic function to add any entity type you want.
        public void AddObject<T>(T obj)
        {
            if (obj is Mother)
                AddMother(obj as Mother);
            else if (obj is Nanny)
                AddNanny(obj as Nanny);
            else if (obj is Child)
                AddChild(obj as Child);
            else if (obj is Contract)
                AddContract(obj as Contract);
            else
                throw new WrongTypeException
                {
                    Message = "this type is not valid in this content"
                };
        }
        // gets a list of objects and add them into the DS.
        public void AddObjects<T>(List<T> objects)
        {
            if (objects is List<Mother>)
                foreach (T item in objects)
                    AddObject(item);
            else if (objects is List<Nanny>)
                foreach (T item in objects)
                    AddObject(item);
            else if (objects is List<Child>)
                foreach (T item in objects)
                    AddObject(item);
            else if (objects is List<Mother>)
                foreach (T item in objects)
                    AddObject(item);
            else
                throw new WrongTypeException
                {
                    Message = "this type is not valid in this content"
                };
        }
        // generic function to delete any object you want.
        public void DeleteObject<T>(T obj)
        {
            if (obj is Mother)
                DeleteMother((obj as Mother).Id);
            else if (obj is Nanny)
                DeleteNanny((obj as Nanny).Id);
            else if (obj is Child)
                DeleteChild((obj as Child).Id);
            else if (obj is Contract)
                DeleteContract((obj as Contract).ContructNumber);
            else
                throw new WrongTypeException
                {
                    Message = "this type is not valid in this content"
                };
        }
        // to delete a numeric entities on one time.
        public void DeleteObjects<T>(List<T> objects)
        {
            if (objects is List<Mother> || objects is List<Nanny> ||
                objects is List<Child> || objects is List<Contract>)
                foreach (T item in objects)
                    DeleteObject<T>(item);
            else
                throw new WrongTypeException
                {
                    Message = "this type is not valid in this content"
                };
        }
        // to update any object that you want
        public void UpdateObject<T>(T obj)
        {
            if (obj is Mother)
                UpdateMother(obj as Mother);
            else if (obj is Nanny)
                UpdateNanny(obj as Nanny);
            else if (obj is Child)
                UpdateChild(obj as Child);
            else if (obj is Contract)
                UpdateContract(obj as Contract);
            else
                throw new WrongTypeException
                {
                    Message = "this type is not valid in this content"
                };
        }
        // to update a number of objects at once.
        public void UptateObjects<T>(List<T> objects)
        {
            if (objects is List<Mother> || objects is List<Nanny> ||
                objects is List<Child> || objects is List<Contract>)
                foreach (T item in objects)
                    UpdateObject<T>(item);
            else
                throw new WrongTypeException
                {
                    Message = "this type is not valid in this content"
                };
        }
    }
}
