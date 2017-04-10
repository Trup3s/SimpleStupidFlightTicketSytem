using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SSFTS_GUI {
    class Airline {
        private String airline_code;
        private String callsign;
        private String title;
        private List<Airplane> fleet;
        private Uri img;

        [JsonProperty("airline-code")]
        public String AirlineCode { get => this.airline_code; set => this.airline_code = value; }
        [JsonProperty("callsign")]
        public String Callsign { get => this.callsign; set => this.callsign = value; }
        [JsonProperty("title")]
        public String Title { get => this.title; set => this.title = value; }
        [JsonProperty("img")]
        public Uri Image { get => this.img; set => this.img = value; }
        public List<Airplane> Fleet { get => this.fleet; set => this.fleet = value; }

        //public Airline(String airline_code, String callsign, String title, List<Airplane> fleet, Uri img) {
        //    this.airline_code = airline_code;
        //    this.callsign = callsign;
        //    this.title = title;
        //    this.fleet = fleet;
        //    this.img = img;
        //}
    }
}
