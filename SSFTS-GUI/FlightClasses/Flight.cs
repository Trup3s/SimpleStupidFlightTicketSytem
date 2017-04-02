using System;

namespace SSFTS_GUI {
    class Flight {
        private Airplane airplane;
        private String aircraft_type;
        private String flight;
        private Airport from;
        private Airport to;

        public Airplane Airplane { get => this.airplane; }
        public String AircraftType { get => this.aircraft_type; }
        public String FlightNumber { get => this.flight; }
        public Airport From { get => this.from; }
        public Airport To { get => this.to; }

        public Flight(Airplane airplane, String aircraft_type, String flight, Airport from, Airport to) {
            this.airplane = airplane;
            this.aircraft_type = aircraft_type;
            this.flight = flight;
            this.from = from;
            this.to = to;
        }

    }
}
