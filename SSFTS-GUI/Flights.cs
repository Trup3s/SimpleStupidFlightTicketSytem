using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSFTS_GUI {
    class Flight {

    }
    class Airline {
        String airline_code;
        String callsign;
        int fleet_size;
        String title;
        String img;
        List<Airplane> fleet;

        String AirlineCode => this.airline_code;
        String Callsign => this.callsign;
        int FleetSize => this.fleet_size;
        String Title => this.title;
        String Image => this.img;
        List<Airplane> Fleet => this.fleet;

        Airline(String airline_code, String callsign, int fleet_size, String title, String img) {
            this.airline_code = airline_code;
            this.callsign = callsign;
            this.fleet_size = fleet_size;
            this.title = title;
            this.img = img;
        }
        Airline(String airline_code, String callsign, int fleet_size, String title) {
            this.airline_code = airline_code;
            this.callsign = callsign;
            this.fleet_size = fleet_size;
            this.title = title;
        }
    }
    class Airport {
        String iata;
        Double lat;
        Double lon;
        String name;

        String IATA => this.iata;
        Double Latitude => this.lat;
        Double Longitude => this.lon;
        String Name => this.name;

        Airport(String iata, Double lat, Double lon, String name) {
            this.iata = iata;
            this.lat = lat;
            this.lon = lon;
            this.name = name;
        }
    }
    class Country {
        List<Airport> airports;

        List<Airport> Airports => this.airports;

        Country(List<Airport> airports) {
            this.airports = new List<Airport>(airports);
        }
    }
    class Airplane {

    }
}
