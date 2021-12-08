using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.POCO
{

    public class Inventory
    {
        public bool HasBox { get; set; }
        public bool HasKnife { get; set; }
        public bool HasAxe { get; set; }
        public bool HasOldBook { get; set; }
        public bool HasBookPicture { get; set; }
        public bool HasKeyFromSafe { get; set; }
        public bool HasCombination { get; set; }
        public bool GotMilk { get; set; }


        public Inventory()
        {

        }
    }
}
