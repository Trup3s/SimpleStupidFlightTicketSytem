using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* --Ticket Design--
 * 
 * --Airport(source)--
 * sName:
 * sIATA:
 * 
 * --Airport(destination)--
 * dName:
 * dIATA:
 * 
 * --Airplane--
 * Age:
 * Type:
 * Code:
 * Serialnumber:
 * Typecode:
 *  
 * Flightnumber:
 * Aircrafttype:
 */

namespace SSFTS_GUI
{
    class filehandler {
        private string path = @"\Savedflights.txt";
        private List<Flight> ticketlist;
        private string msg, bfr, age, type, code, serialnumber, typecode, flightnumber, aircrafttype, sname, siata, dname, diata;
        private Flight flight;
        private Airport sAirport, dAirport;
        private Airplane airplane;

        public List<Flight> TicketList { get => this.ticketlist; }

        public void save() {            
            if (!File.Exists(path)) {
                FileStream fs = File.Create(path);
            }
            else {
                using (FileStream fs = File.OpenWrite(path)) {
                    foreach (Flight flight in ticketlist) {
                        sAirport = flight.From;
                        dAirport = flight.To;
                        airplane = flight.Airplane;
                        flightnumber = flight.FlightNumber;
                        aircrafttype = flight.AircraftType;

                        write(fs, "\nsName: " + sAirport.Name + "\nsIATA: " + sAirport.IATA + "\ndName: " + dAirport.Name + "\ndIATA: " + dAirport.IATA + "\nAge: " + airplane.Age + 
                            "\nType: " + airplane.Type + "\nCode: " + airplane.Code + "\nSerialnumber: " + airplane.Serialnumber + "\nTypecode: " + airplane.TypeCode + 
                            "\nFlightnumber: " + flight.FlightNumber + "\nAircrafttype: " + flight.AircraftType + "\n---");
                    }
                }
            }
        }

        public bool load() {
            if (!File.Exists(path)) {
                //File does not exists or cant be opened
                return false;
            }
            else {
                using (FileStream fs = File.OpenRead(path)) {
                    int length = (int)fs.Length;
                    byte [] buffer = new byte[length];
                    int count, sum = 0;
                    while((count = fs.Read(buffer, sum, length - sum)) > 0) {
                        sum += count;
                    }
                    msg = System.Text.Encoding.Default.GetString(buffer);
                }                
                for (int x = 0; x >= msg.Length; x++) {
                    bfr += msg[x];
                    if (msg[x] == ':') {
                        x++;
                        switch (bfr) {
                            case "\nsName:":
                                bfr = "";
                                for (; msg[x] != '\n'; x++) {
                                    bfr += msg[x];
                                }
                                sname = bfr;
                                break;
                            case "siata:":
                                bfr = "";
                                for (; msg[x] != '\n'; x++) {
                                    bfr += msg[x];
                                }
                                siata = bfr;
                                break;
                            case "dName:":
                                bfr = "";
                                for (; msg[x] != '\n'; x++) {
                                    bfr += msg[x];
                                }
                                dname = bfr;
                                break;
                            case "diata:":
                                bfr = "";
                                for (; msg[x] != '\n'; x++) {
                                    bfr += msg[x];
                                }
                                diata = bfr;
                                break;
                            case "Age:":
                                bfr = "";
                                for (; msg[x] != '\n'; x++) {
                                    bfr += msg[x];
                                }
                                age = bfr;
                                break;
                            case "Type:":
                                bfr = "";
                                for (; msg[x] != '\n'; x++) {
                                    bfr += msg[x];
                                }
                                type = bfr;
                                break;
                            case "Code:":
                                bfr = "";
                                for (; msg[x] != '\n'; x++) {
                                    bfr += msg[x];
                                }
                                code = bfr;
                                break;
                            case "Serialnumber:":
                                bfr = "";
                                for (; msg[x] != '\n'; x++) {
                                    bfr += msg[x];
                                }
                                serialnumber = bfr;
                                break;
                            case "Typecode:":
                                bfr = "";
                                for (; msg[x] != '\n'; x++) {
                                    bfr += msg[x];
                                }
                                typecode = bfr;
                                break;
                            case "Flightnumber:":
                                bfr = "";
                                for (; msg[x] != '\n'; x++) {
                                    bfr += msg[x];
                                }
                                flightnumber = bfr;
                                break;
                            case "Aircrafttype:":
                                bfr = "";
                                for (; msg[x] != '\n'; x++) {
                                    bfr += msg[x];
                                }
                                aircrafttype = bfr;
                                break;
                            case "---":
                                sAirport = new Airport(siata, 0, 0, sname);
                                dAirport = new Airport(diata, 0, 0, dname);
                                airplane = new Airplane(age, type, code, null, null, serialnumber, typecode);
                                flight = new Flight(airplane, aircrafttype, flightnumber, sAirport, dAirport);
                                ticketlist.Add(flight);
                                break;
                        }                                   
                    }
                }
            }
            return true;
        }

        public void write(FileStream fs, string text) {
            byte[] msg = new UTF8Encoding(true).GetBytes(text);
            fs.Write(msg, 0, msg.Length);
        }
    }
}
