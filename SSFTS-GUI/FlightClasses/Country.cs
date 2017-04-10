using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SSFTS_GUI {
    class Country {
        private String name;
        private Uri img;
        private List<Airport> airports;

        public String Name { get => this.name; }
        public Uri Image { get => this.img; }
        internal List<Airport> Airports { get => this.airports; set => this.airports = value; }

        public Country(String country, Uri img, List<Airport> airports) {
            this.name = country;
            this.img = img;
            this.airports = airports;
        }
        [JsonConstructor]
        public Country(String country, Uri img) {
            this.name = country;
            this.img = img;
        }
    }
}
