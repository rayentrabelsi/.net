﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        public Plane plane { get; set; }
        public string AirlineLogo { get; set; }
        public ICollection<Passenger> Passengers { get; set; }

        public override string? ToString()
        {
            return "Destination:" + Destination + "Departure:" + Departure + "FlightDate:" + FlightDate + "EffectiveArrival:" + EffectiveArrival + "EstimatedDuration" + EstimatedDuration;
        }
    }
}
