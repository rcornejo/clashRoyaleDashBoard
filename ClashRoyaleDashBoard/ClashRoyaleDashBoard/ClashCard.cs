using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleDashBoard
{
    class ClashCard
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxLevel { get; set; }
        public int Count { get; set; }
        public string[] IconUrls { get; set; }
    }
}
