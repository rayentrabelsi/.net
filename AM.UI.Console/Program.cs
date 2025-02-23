// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

//Plane plane = new Plane();

//plane.planeType = PlaneType.Airbus;
//plane.Capacity = 100;
//plane.ManufactureDate = new DateTime(2002, 6, 6);


//Plane plane2 = new Plane(100, DateTime.Now, PlaneType.Boing);

Plane plane3 = new Plane { planeType = PlaneType.Airbus, Capacity = 100 };

Console.WriteLine();

Console.WriteLine("************************************ Testing Signature Polymorphisme ****************************** ");

Passenger p1 = new Passenger { FirstName = "steave", LastName = "jobs", EmailAddress = "steeve.jobs@gmail.com", BirthDate = new DateTime(1955, 01, 01) };

Console.WriteLine("la méthode Checkpassenger");

Console.WriteLine(p1.CheckProfile("steave", "jobs"));

Console.WriteLine(p1.CheckProfile("steave", "jobs", "steeve.jobs@gmail.com"));



Console.WriteLine("************************************ Testing Inheritance Polymorphisme ****************************** ");

Staff s1 = new Staff { FirstName = "Bill", LastName = "Gates", EmailAddress = "Bill.gates@gmail.com", BirthDate = new DateTime(1945, 01, 01), EmployementDate = new DateTime(1990, 01, 01), Salary = 99999 };

Traveller t1 = new Traveller { FirstName = "Mark", LastName = "Zuckerburg", EmailAddress = "Mark.Zuckerburg@gmail.com", BirthDate = new DateTime(1980, 01, 01), HealthInformation = "Some troubles", Nationality = "American" };

p1.PassengerType();

s1.PassengerType();

t1.PassengerType();

//Question 5 tp2
FlightMethods fm = new FlightMethods();
fm.Flights = TestData.listFlights;

Console.WriteLine("****services****");
Console.WriteLine("get filght dates");
foreach (var f in fm.GetFlightDates("Madrid"))
    Console.WriteLine(f);

Console.WriteLine("-------------------");
Console.WriteLine("Show Flight Details");
fm.ShowFlightDetails(TestData.Airbusplane);

Console.WriteLine("------------------------------------------");
Console.WriteLine("Number of programmed flights in 31/01/2022");
Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2022, 01, 31)));

Console.WriteLine("------------------------------");
Console.WriteLine("flight duration average: " + fm.DurationAverage("Madrid"));

Console.WriteLine("--------------");
Console.WriteLine("Liste des vols");
foreach (Flight f in fm.OrderedDurationFlights())
    Console.WriteLine(f);

Console.WriteLine("-------------------------");
Console.WriteLine("3 passagers les plus agés");
foreach (Traveller t in fm.SeniorTravellers(TestData.flight1))
    Console.WriteLine(t);

Console.WriteLine("--------------------------------");
Console.WriteLine("les vols groupés par destination");
fm.DestinationGroupedFlights();

