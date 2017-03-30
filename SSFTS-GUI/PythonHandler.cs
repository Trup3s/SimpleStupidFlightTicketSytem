using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace SSFTS_GUI {
    class PythonHandler {
         const String PythonExecutable = "Python\\python.exe";

        static String GetPythonOutput(String pythonScript, String[] args) {
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


        static String GetCountries() {
            return GetPythonOutput("flightinfo.py", new String[] { "--countries" });
        }

        static String  GetAirports(String country) {
            return GetPythonOutput("flightinfo.py", new String[] { "--airports", country });
        }
    }
}
