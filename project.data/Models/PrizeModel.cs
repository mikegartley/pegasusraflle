using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.data.Models
{
    public class PrizeModel
    {
        public class Prizes_Load 
        {
            public int Prize_ID { get; set; }
            public string Prize_Name { get; set; }
            public string Prize_Description { get; set; }
            public DateTime Prize_Added { get; set; }
            public string Prize_Winner_Email { get; set; }
            public DateTime? Prize_Winner_DateTime { get; set; }
            public string Prize_Winner_EntryNumber { get; set; }

        }
        public class Entries_LoadAll
        {
            public int Entry_ID { get; set; }
            public string Entry_EmailAddress { get; set; }
            public string Entry_TicketNumber { get; set; }
            public DateTime Entry_DateTime { get; set; }
            public int Entry_WonPrize { get; set; }
            public string Prize_Name { get; set; }

        }

    }
}
