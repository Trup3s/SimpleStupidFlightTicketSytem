using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace SSFTS_GUI {
    class PythonHandler {

        [Serializable]
        public class ExitCodeException : Exception {
            public ExitCodeException() { }
            public ExitCodeException(string file, int code) : base(file + " returned " + code.ToString()) { }
            protected ExitCodeException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }


        private static String PythonExecutable = "python.exe";

        public static String GetPythonOutput(String script, List<String> args) {
            args.Insert(0, script);
            if (!File.Exists(script)) {
                throw new FileNotFoundException("Python Script does not exist", script);
            }
            /*if (!File.Exists(PythonExecutable)) {
                throw new FileNotFoundException("PythonExecutable does not exist", PythonExecutable);
            }*/
            Process pythonProcess = new Process() {
                StartInfo = new ProcessStartInfo() {
                    FileName = PythonExecutable,
                    Arguments = String.Join(" ", args),
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                }
            };

            Debug.Print("Calling \"{0} {1}\"", PythonExecutable, String.Join(" ", args));

            pythonProcess.Start();

            String result = pythonProcess.StandardOutput.ReadLine();
            Debug.Print(pythonProcess.StandardError.ReadToEnd());

            pythonProcess.WaitForExit(30 * 1000);


            if (!pythonProcess.HasExited) {
                pythonProcess.Kill();
                Debug.Print("Script is not responding, force closing");
            }

            if (pythonProcess.ExitCode != 0) {
                throw new ExitCodeException(script, pythonProcess.ExitCode);
            }

            return result;
        }

        private static T FlightInfo<T>(List<String> args) {
            String output = GetPythonOutput(Path.GetFullPath("flightinfo.py"), args);
            try {
                return  JsonConvert.DeserializeObject<T>(output);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static List<Country> GetCountries() => FlightInfo<List<Country>>(new List<String> { "--countries" });
        public static List<Airline> GetAirlines() => FlightInfo<List<Airline>>(new List<String> { "--airlines" });
        public static List<Airport> GetAirports(Country country) => FlightInfo<List<Airport>>(new List<String> { "--airports", '"' + country.Name + '"' });
        public static List<Airplane> GetFleet(Airline airline) => FlightInfo<List<Airplane>>(new List<String> { "--fleet", '"' + airline.AirlineCode + '"' });
        public static List<Flight> GetFlights(Airline airline) => FlightInfo<List<Flight>>(new List<String> { "--flights", '"' + airline.AirlineCode + '"' });
        public static Dictionary<String, String> GetHistoryByFlight(Flight flight) => FlightInfo<Dictionary<String, String>>(new List<String> { "--history-by-flight", '"' + flight.FlightNumber + '"' });
        public static Dictionary<String, String> GetHistoryByTail(Airplane airplane) => FlightInfo<Dictionary<String, String>>(new List<String> { "--history-by-tail", '"' + airplane.Code + '"' });
        public static Dictionary<String, String> GetInfoByTail(Airplane airplane) => FlightInfo<Dictionary<String, String>>(new List<String> { "--info", '"' + airplane.Code + '"' });
    }
}
