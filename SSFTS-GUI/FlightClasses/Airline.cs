using System;
using System.Collections.Generic;

namespace SSFTS_GUI {
    class Airline {
        private String airline_code;
        private String callsign;
        private String title;
        private List<Airplane> fleet;

        public String AirlineCode { get => this.airline_code; }
        public String Callsign { get => this.callsign; }
        public String Title { get => this.title; }
        public List<Airplane> Fleet { get => this.fleet; }

        public Airline(String airline_code, String callsign, String title, List<Airplane> fleet) {
            this.airline_code = airline_code;
            this.callsign = callsign;
            this.title = title;
            this.fleet = fleet;
        }
    }
}
