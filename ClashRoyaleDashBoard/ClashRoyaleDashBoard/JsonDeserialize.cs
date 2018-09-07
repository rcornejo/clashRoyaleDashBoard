using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleDashBoard
{
    class JsonDeserialize
    {
        public List<ClashWar> items { get; set; }
        public Paging paging { get; set; }

    }
    
    public class Paging
    {
        public Cursors cursors { get; set; }
        public string next { get; set; }
    }
    public class Cursors
    {
        public string before { get; set; }
        public string after { get; set; }
    }
}
