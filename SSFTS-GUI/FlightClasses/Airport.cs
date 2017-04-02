using System;

namespace SSFTS_GUI {
    class Airport {
        private String iata;
        private Double lat;
        private Double lon;
        private String name;

        public String IATA { get => this.iata; }
        public Double Latitude { get => this.lat; }
        public Double Longitude { get => this.lon; }
        public String Name { get => this.name; }

        public Airport(String iata, Double lat, Double lon, String name) {
            this.iata = iata;
            this.lat = lat;
            this.lon = lon;
            this.name = name;
        }
    }
}
