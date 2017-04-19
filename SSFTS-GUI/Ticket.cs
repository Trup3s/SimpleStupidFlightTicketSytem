using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSFTS_GUI {
    class Ticket {
        private List<Flight> ticketlist;
        public int getTicketCount() => ticketlist.Count;
        public List<Flight> getTicketlist() => ticketlist;
    }
}
