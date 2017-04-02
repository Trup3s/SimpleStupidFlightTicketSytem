using System;
using System.Collections.Generic;

namespace SSFTS_GUI {
    class Country {
        private String name;
        private Uri img;
        private List<Airport> airports;

        public Uri Image { get => this.img; }
        public String Name { get => this.name; }
        public List<Airport> Airports { get => this.airports; }

        public Country(String name, Uri img, List<Airport> airports) {
            this.name = name;
            this.img = img;
            this.airports = airports;
        }
    }
}
