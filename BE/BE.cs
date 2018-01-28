using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    #region Entities
    public class Nanny : IEquatable<Nanny>
    {
        private uint id;
        public uint Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        private DateTime birthDate;
        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = new DateTime(value.Year, value.Month, value.Day);
            }
        }

        private string telephonNumber;
        public string TelephonNumber
        {
            get
            {
                return telephonNumber;
            }
            set
            {
                telephonNumber = value;
            }
        }

        private string adress;
        public string Adress
        {
            get
            {
                return adress;
            }
            set
            {
                adress = value;
            }
        }

        private bool isThereElevator;
        public bool IsThereElevator
        {
            get
            {
                return isThereElevator;
            }
            set
            {
                isThereElevator = value;
            }
        }

        private int floor;
        public int Floor
        {
            get
            {
                return floor;
            }
            set
            {
                floor = value;
            }
        }

        private int yersOfExperiance;
        public int YersOfExperiance
        {
            get
            {
                return yersOfExperiance;
            }
            set
            {
                yersOfExperiance = value;
            }
        }

        private int maxChildren;
        public int MaxChildren
        {
            get
            {
                return maxChildren;
            }
            set
            {
                maxChildren = value;
            }
        }

        private int numberOfChildren = 0;
        public int NumberOfChildren
        {
            get
            {
                return numberOfChildren;
            }
            set
            {
                numberOfChildren = value;
            }
        }

        private int maxAge;
        public int MaxAge
        {
            get
            {
                return maxAge;
            }
            set
            {
                maxAge = value;
            }
        }

        private int minAge;
        public int MinAge
        {
            get
            {
                return minAge;
            }
            set
            {
                minAge = value;
            }
        }

        private bool allowsSalaryPerHour;
        public bool AllowsSalaryPerHour
        {
            get
            {
                return allowsSalaryPerHour;
            }
            set
            {
                allowsSalaryPerHour = value;
            }
        }

        private double salareyPerHour;
        public double SalareyPerHour
        {
            get
            {
                return salareyPerHour;
            }
            set
            {
                salareyPerHour = value;
            }
        }

        private double salareyPerMonth;
        public double SalareyPerMonth
        {
            get
            {
                return salareyPerMonth;
            }
            set
            {
                salareyPerMonth = value;
            }
        }

        private bool[] daysOfWork = new bool[7];
        public bool[] DaysOfWork
        {
            get
            {
                return daysOfWork;
            }
            set
            {
                for (int i = 0; i < 7; i++)
                    daysOfWork[i] = value[i];
            }
        }

        private Dictionary<int, HoursRange> workingHours = new Dictionary<int, HoursRange>(7);
        public Dictionary<int, HoursRange> WorkingHours
        {
            get
            {
                return workingHours;
            }
            set
            {
                for (int i = 0; i < 7; i++)
                {
                    workingHours[i].BeginingTime = value[i].BeginingTime;
                    workingHours[i].EndTime = value[i].EndTime;
                }
            }
        }

        private bool vacationDays; //0-education 1-tamat
        public bool VacationDays
        {
            get
            {
                return vacationDays;
            }
            set
            {
                vacationDays = value;
            }
        }

        private string recommendations;
        public string Recommendations
        {
            get
            {
                return recommendations;
            }
            set
            {
                recommendations = value;
            }
        }

        public Nanny(uint id, string lastName, string firstName, DateTime birthDate,
            string telephonNumber, string adress, bool isThereElevator, int floor,
            int yersOfExperiance, int maxChildren, int maxAge, int minAge,
            bool allowsSalaryPerHour, double salareyPerHour, double salareyPerMonth,
            bool[] daysOfWork, bool vacationDays, string recommendations,
            Dictionary<int, HoursRange> workingHours)
        {
            this.id = id;
            this.lastName = lastName;
            this.firstName = firstName;
            this.birthDate = birthDate;
            this.telephonNumber = telephonNumber;
            this.adress = adress;
            this.isThereElevator = isThereElevator;
            this.floor = floor;
            this.yersOfExperiance = yersOfExperiance;
            this.maxChildren = maxChildren;
            this.maxAge = maxAge;
            this.minAge = minAge;
            this.allowsSalaryPerHour = allowsSalaryPerHour;
            this.salareyPerHour = salareyPerHour;
            this.salareyPerMonth = salareyPerMonth;
            this.daysOfWork = daysOfWork;
            this.workingHours = workingHours;
            this.vacationDays = vacationDays;
            this.recommendations = recommendations;
        }

        public Nanny()
        {
            for (int i = 0; i < 7; i++)
                workingHours[i] = new HoursRange(new DateTime(), new DateTime());
        }

        // returns a string that describes the mother.
        public override string ToString()
        {
            return firstName + " " + lastName + " id: " + id +
                   "offers services in the area of " +
                   adress;
        }
        // returns whether the nanny objects are equal based on their id.
        // useful for the function List.remove
        public bool Equals(Nanny nanny)
        {
            return this.Id == nanny.Id;
        }
    }

    public class Mother : IEquatable<Mother>
    {
        private uint id;
        public uint Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        private string addressForNanny;
        public string AddressForNanny
        {
            get
            {
                if (addressForNanny == null)
                    return address;
                else
                    return addressForNanny;
            }
            set
            {
                addressForNanny = value;
            }
        }

        private bool wantsSalaryPerHour;
        public bool WantsSalaryPerHour
        {
            get
            {
                return wantsSalaryPerHour;
            }
            set
            {
                wantsSalaryPerHour = value;
            }
        }

        private bool[] requiredDays = new bool[7];
        public bool[] RequiredDays
        {
            get
            {
                return requiredDays;
            }
            set
            {
                for (int i = 0; i < 7; i++)
                    requiredDays[i] = value[i];
            }
        }

        private Dictionary<int, HoursRange> requiredHours = new Dictionary<int, HoursRange>(7);
        public Dictionary<int, HoursRange> RequiredHours
        {
            get
            {
                return requiredHours;
            }
            set
            {
                for (int i = 0; i < 7; i++)
                {
                    requiredHours[i].BeginingTime = value[i].BeginingTime;
                    requiredHours[i].EndTime = value[i].EndTime;
                }
            }
        }

        private string comments;
        public string Comments
        {
            get
            {
                return comments;
            }
            set
            {
                comments = value;
            }
        }

        private int maxDistane;
        public int MaxDistance
        {
            get { return maxDistane; }
            set { maxDistane = value; }
        }

        public Mother(uint id, string lastName, string firstName, string phoneNumber,
            string address, string addressForNanny, bool wantsSalaryPerHour,
            bool[] requiredDays, Dictionary<int, HoursRange> requiredHours,
            string comments, int maxDistane)
        {
            this.id = id;
            this.lastName = lastName;
            this.firstName = firstName;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.addressForNanny = addressForNanny;
            this.wantsSalaryPerHour = wantsSalaryPerHour;
            this.requiredDays = requiredDays;
            this.requiredHours = requiredHours;
            this.comments = comments;
            this.maxDistane = maxDistane;
        }

        public Mother()
        {
        }

        // returns a string that describes the mother.
        public override string ToString()
        {
            return LastName + " " + FirstName +
                " looking for Nanny arround " +
                AddressForNanny + "./nPhone number: " +
                PhoneNumber;
        }
        // returns whether two mother objects are equal based on their ID
        // useful for the function List.remove
        public bool Equals(Mother mother)
        {
            return this.Id == mother.Id;
        }
    }

    public class Child : IEquatable<Child>
    {
        private uint id;
        public uint Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private uint motherId;
        public uint MotherId
        {
            get
            {
                return motherId;
            }
            set
            {
                motherId = value;
            }
        }

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        private DateTime birthDay;
        public DateTime BirthDay
        {
            get
            {
                return birthDay;
            }
            set
            {
                birthDay = new DateTime(value.Year, value.Month, value.Day);
            }
        }

        private bool isThereSpecialNeeds;
        public bool IsThereSpecialNeeds
        {
            get
            {
                return isThereSpecialNeeds;
            }
            set
            {
                isThereSpecialNeeds = value;
            }
        }

        private string specialNeeds;
        public string SpecialNeeds
        {
            get
            {
                return specialNeeds;
            }
            set
            {
                specialNeeds = value;
            }
        }

        public Child(uint id, uint motherId, string firstName, DateTime birthDay, bool isThereSpecialNeeds, string specialNeeds)
        {
            this.id = id;
            this.motherId = motherId;
            this.firstName = firstName;
            this.birthDay = birthDay;
            this.isThereSpecialNeeds = isThereSpecialNeeds;
            this.specialNeeds = specialNeeds;
        }

        public Child()
        {
        }

        // returns a string that describes the child.
        public override string ToString()
        {
            return "Child name: " + FirstName + "/nId: " + Id;
        }
        // returns whether the child objects are equal based on their id.
        // useful for the function List.remove
        public bool Equals(Child child)
        {
            return this.Id == child.Id;
        }
    }

    public class Contract : IEquatable<Contract>
    {
        private static uint contractNumber = 9999999;
        public uint ContructNumber
        {
            get
            {
                return contractNumber;
            }
            set
            {
                contractNumber = value;
            }
        }

        private Child child;
        public Child Child
        {
            get
            {
                return child;
            }
            set
            {
                child = value;
            }
        }
        public string ChildFirstName { get { return child.FirstName; } }

        private Mother mother;
        public Mother Mother
        {
            get
            {
                return mother;
            }
            set
            {
                mother = value;
            }
        }

        private Nanny nanny;
        public Nanny Nanny
        {
            get
            {
                return nanny;
            }
            set
            {
                nanny = value;
            }
        }
        public string NannyFirstName { get { return nanny.FirstName; } }

        private bool wasMeating;
        public bool WasMeating
        {
            get
            {
                return wasMeating;
            }
            set
            {
                wasMeating = value;
            }
        }

        private bool isSigned;
        public bool IsSigned
        {
            get
            {
                return isSigned;
            }
            set
            {
                isSigned = value;
            }
        }

        private double salaryPerHour;
        public double SalaryPerHour
        {
            get
            {
                return salaryPerHour;
            }
            set
            {
                salaryPerHour = value;
            }
        }

        private double salaryPerMonth;
        public double SalaryPerMonth
        {
            get
            {
                return salaryPerMonth;
            }
            set
            {
                salaryPerMonth = value;
            }
        }

        private bool perMonthOrHour; //0-month 1-hour
        public bool PerMonthOrHour
        {
            get
            {
                return perMonthOrHour;
            }
            set
            {
                perMonthOrHour = value;
            }
        }

        private DateTime beginingDate;
        public DateTime BeginingDate
        {
            get
            {
                return beginingDate;
            }
            set
            {
                beginingDate = new DateTime(value.Year, value.Month, value.Day);
            }
        }

        private DateTime endingDate;
        public DateTime EndingDate
        {
            get
            {
                return endingDate;
            }
            set
            {
                endingDate = new DateTime(value.Year, value.Month, value.Day);
            }
        }

        public Contract(Child child, Mother mother, Nanny nanny, bool wasMeating,
            bool isSigned, DateTime endingDate)
        {
            this.child = child;
            this.mother = mother;
            this.nanny = nanny;
            this.wasMeating = wasMeating;
            this.isSigned = isSigned;
            this.endingDate = endingDate;
        }

        public Contract()
        {
        }

        // returns whether the contract objects are equal based on their contract number field.
        // useful for the function List.remove
        public bool Equals(Contract y)
        {
            return this.ContructNumber == y.ContructNumber;
        }
        // returns a string that describes the contract.
        public override string ToString()
        {
            return "contract between mother: " + Mother.Id + "and nanny: " + Nanny.Id +
                    "for child: " + Child.Id;
        }

    }
    #endregion

    public class HoursRange// to describe a range of hours in a day.
    {
        private DateTime beginingTime;
        public DateTime BeginingTime
        {
            get
            {
                return beginingTime;
            }
            set
            {
                beginingTime = beginingTime.AddSeconds(value.Second);
                beginingTime = beginingTime.AddMinutes(value.Minute);
                beginingTime = beginingTime.AddHours(value.Hour);
            }
        }

        private DateTime endTime;
        public DateTime EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = endTime.AddSeconds(value.Second);
                endTime = endTime.AddMinutes(value.Minute);
                endTime = endTime.AddHours(value.Hour);
            }
        }

        public HoursRange(DateTime beginningTime, DateTime endTime)
        {
            this.beginingTime = beginningTime;
            this.endTime = endTime;
        }
    }

    public delegate bool Condition(Contract contract);

    #region Exceptions
    public class IdException : Exception
    {
        public new string Message;
    }

    public class AgeException : Exception
    {
        public new string Message;
    }

    public class IncompatibleParametersException : Exception
    {
        public new string Message;
    }

    public class WrongTypeException : Exception
    {
        public new string Message;
    }

    #endregion
}