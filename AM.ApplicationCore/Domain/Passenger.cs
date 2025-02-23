using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string PasseportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TelNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public bool CheckProfile (string firstname, string lastname )
        {
            return FirstName == firstname && LastName == lastname;
        }

        public bool CheckProfile (string firstname, string lastname, string emailAddress) 
        { 
            return LastName == lastname && FirstName == firstname && EmailAddress == emailAddress;
        }

        public bool CheckProfile1(string firstname, string lastname, string email = null)
        {
            if(email!= null)
                return LastName == lastname && FirstName == firstname && EmailAddress == email;
            else
                return FirstName == firstname &&  LastName == lastname; 

        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a Passenger");
        }

        public override string? ToString()
        {
            return "FirstName: " + FirstName + "  LastName: " + LastName + "  BirthDate: " + BirthDate ;
        }
    }
}
