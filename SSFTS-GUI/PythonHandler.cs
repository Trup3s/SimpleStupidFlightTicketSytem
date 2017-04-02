using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace SSFTS_GUI {
    class PythonHandler {
        private const String PythonExecutable = "Python\\python.exe";

        public static String GetPythonOutput(String pythonScript, String[] args) {
            if (!File.Exists(pythonScript)) {
                throw new FileNotFoundException("Python Script does not exist", pythonScript);
            }
            if (!File.Exists(PythonExecutable)) {
                throw new FileNotFoundException("PythonExecutable does not exist", PythonExecutable);
            }
            List<String> result = new List<String>();
            Process pythonProcess = new Process();
            pythonProcess.StartInfo.FileName = pythonScript;
            pythonProcess.StartInfo.Arguments = String.Join(" ", args);
            pythonProcess.StartInfo.CreateNoWindow = true;
            pythonProcess.StartInfo.RedirectStandardOutput = true;

            pythonProcess.Start();
            pythonProcess.WaitForExit();

            return pythonProcess.StandardOutput.ReadLine();
        }

        private static T FlightInfo<T>(String[] args) => JsonConvert.DeserializeObject<T>(GetPythonOutput("flightinfo.py", args));

        public static List<Country> GetCountries() => FlightInfo<List<Country>>(new String[] { "--countries" });
        public static List<Airline> GetAirlines() => FlightInfo<List<Airline>>(new String[] { "--airlines" });
        public static List<Airport> GetAirports(Country country) => FlightInfo<List<Airport>>(new String[] { "--airports", country.Name });
        public static List<Airplane> GetFleet(Airline airline) => FlightInfo<List<Airplane>>(new String[] { "--fleet", airline.AirlineCode });
        public static List<Flight> GetFlights(Airline airline) => FlightInfo<List<Flight>>(new String[] { "--flights", airline.AirlineCode });
        public static Dictionary<String, String> GetHistoryByFlight(Flight flight) => FlightInfo<Dictionary<String, String>>(new String[] { "--history-by-flight", flight.FlightNumber });
        public static Dictionary<String, String> GetHistoryByTail(Airplane airplane) => FlightInfo<Dictionary<String, String>>(new String[] { "--history-by-tail", airplane.Code});
        public static Dictionary<String, String> GetInfoByTail(Airplane airplane) => FlightInfo<Dictionary<String, String>>(new String[] { "--info", airplane.Code});
    }
}
