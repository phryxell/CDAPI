using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDAPI.Models
{
    public class CD
    {
        public int ID { get; init; } // Use of init - get/set ID and dont allow future manipulation of it

        public string Artist { get; set; }

        public string Title { get; set; }

        public int Length { get; set; }

        public string Category { get; set; }

    }
}
