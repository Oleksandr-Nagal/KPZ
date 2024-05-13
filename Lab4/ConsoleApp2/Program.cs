using System;
using System.Collections.Generic;

namespace DesignPatterns.Mediator
{
    class CommandCentre
    {
        private List<Runway> _runways = new List<Runway>();
        private List<Aircraft> _aircrafts = new List<Aircraft>();

        public CommandCentre()
        {
        }

        public void AddRunway(Runway runway)
        {
            _runways.Add(runway);
        }

        public void AddAircraft(Aircraft aircraft)
        {
            _aircrafts.Add(aircraft);
        }

        public void RequestLanding(Aircraft aircraft)
        {
            foreach (var runway in _runways)
            {
                if (!runway.CheckIsActive())
                {
                    aircraft.Land(runway);
                    return;
                }
            }
            Console.WriteLine($"All runways are busy. {aircraft.Name} cannot land at the moment.");
        }

        public void RequestTakeoff(Aircraft aircraft)
        {
            foreach (var runway in _runways)
            {
                if (runway.IsBusyWithAircraft == aircraft)
                {
                    aircraft.TakeOff(runway);
                    return;
                }
            }
            Console.WriteLine($"{aircraft.Name} cannot take off. It is not on any runway.");
        }
    }

    class Runway
    {
        public readonly Guid Id = Guid.NewGuid();
        public Aircraft? IsBusyWithAircraft;

        public bool CheckIsActive()
        {
            return IsBusyWithAircraft == null;
        }

        public void HighLightRed()
        {
            Console.WriteLine($"Runway {Id} is busy!");
        }

        public void HighLightGreen()
        {
            Console.WriteLine($"Runway {Id} is free!");
        }
    }

    class Aircraft
    {
        public string Name { get; }

        public Aircraft(string name)
        {
            Name = name;
        }

        public void Land(Runway runway)
        {
            Console.WriteLine($"Aircraft {Name} is landing.");
            Console.WriteLine($"Checking runway.");
            if (runway.IsBusyWithAircraft == null)
            {
                Console.WriteLine($"Aircraft {Name} has landed.");
                runway.IsBusyWithAircraft = this;
                runway.HighLightRed();
            }
            else
            {
                Console.WriteLine($"Could not land, the runway is busy.");
            }
        }

        public void TakeOff(Runway runway)
        {
            Console.WriteLine($"Aircraft {Name} is taking off.");
            runway.IsBusyWithAircraft = null;
            runway.HighLightGreen();
            Console.WriteLine($"Aircraft {Name} has taken off.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CommandCentre commandCentre = new CommandCentre();

            Runway runway1 = new Runway();
            Runway runway2 = new Runway();
            Runway runway3 = new Runway();

            commandCentre.AddRunway(runway1);
            commandCentre.AddRunway(runway2);
            commandCentre.AddRunway(runway3);

            Aircraft aircraft1 = new Aircraft("Boeing 747");
            Aircraft aircraft2 = new Aircraft("Airbus A320");

            commandCentre.AddAircraft(aircraft1);
            commandCentre.AddAircraft(aircraft2);

            commandCentre.RequestLanding(aircraft1);
            commandCentre.RequestLanding(aircraft2);

            commandCentre.RequestTakeoff(aircraft1);
            commandCentre.RequestTakeoff(aircraft2);
        }
    }
}
