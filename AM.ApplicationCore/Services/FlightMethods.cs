using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>() { };

        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            IEnumerable<DateTime> result = new List<DateTime>();
            /*for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].Destination.Equals(destination))
                    result.Add(Flights[i].FlightDate);
            }*/
            /*foreach (Flight f in Flights)
            {
                if (f.Destination.Equals(destination))
                    result.Add(f.FlightDate);
            }*/
            /* result = from f in Flights
                       where f.Destination.Equals(destination)
                       select f;*/

              //Expression lamda
              result = Flights.Where(f => f.Destination.Equals(destination))
                              .Select(f => f.FlightDate);
            return result;
        }

        public void ShowFlightDetails(Plane plane)
        {
            var req = from f in Flights
                      where f.plane == plane
                      select new { f.Destination, f.FlightDate };
            foreach (var f in req)
            {
                Console.WriteLine(f);
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var req = from f in Flights
                      where DateTime.Compare(startDate, f.FlightDate) < 0 && (f.FlightDate - startDate).TotalDays < 8
                      select f;
            return req.Count();
        }

        public double DurationAverage(string destination)
        {
            var req = from f in Flights
                      where f.Destination.Equals(destination)
                      select f.EstimatedDuration;
            return req.Average();
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var req = from f in Flights
                      orderby f.EstimatedDuration descending
                      select f;
            return req;
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            var req = from t in flight.Passengers.OfType<Traveller>()
                      orderby t.BirthDate
                      select t;
            return req.Take(3);
            //skip(3) ignorer les 3 premiers
        }
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights() // string is the type of destination 
        {
            var req = from f in Flights
                      group f by f.Destination;
           
            foreach(var g in req)
            {
                Console.WriteLine("Destination: " + g.Key);
                foreach(Flight f  in g)
                    Console.WriteLine(f);
            }
            return req;
        }
    }
}