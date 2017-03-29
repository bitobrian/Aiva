﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoxBot.Auction.Models
{
    public class InitModel
    {
        public string Name { get; set; }
        public string Command { get; set; }
        public bool WithTickets { get; set; }
        public int Tickets { get; set; }
        
        public bool WriteStartInChat { get; set; }
        public string StartChatMessage { get; set; }

        public string StartChatMessageTicket { get; set; }
    }
}
