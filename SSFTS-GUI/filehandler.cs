using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SSFTS_GUI
{
    class filehandler {
        private string path = @"\Savedflights.txt";
        public void save() {            
            if (!File.Exists(path)) {
                FileStream fs = File.Create(path);
            }
            else {
                using (FileStream fs = File.OpenWrite(path)) {
                    //do stuff                    
                }
            }
        }

        public void read() {
            if (!File.Exists(path)) {
                //File does not exists or cant be opened
                return;
            }
            else {
                using (FileStream fs = File.OpenRead(path)) {
                    //do stuff
                }
            }
        }

        public void write(FileStream fs, string text) {
            byte[] msg = new UTF8Encoding(true).GetBytes(text);
            fs.Write(msg, 0, msg.Length);
        }

        public filehandler() { }
    }
}
