using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Amiibo : IComparable<Amiibo>
    {
        /// <summary>
        /// matched all of these properties with what was listed on the website api
        /// </summary>
        public string amiiboSeries { get; set; }
        public string character { get; set; }
        public string gameSeries { get; set; }
        public string head { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public Json? release { get; set; }
        public string tail { get; set; }
        public string type { get; set; }


        //using string.compare for easier sorting of results
        public int CompareTo(Amiibo other) => string.Compare(name, other.name);
    }
}
