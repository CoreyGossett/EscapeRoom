using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.POCO
{
    public class Room
    {
        public bool FlippedSwitch { get; set; }
        public bool ExitDoorUnlocked { get; set; }
        public bool SafeUnearthed { get; set; }
        public bool PictureReferenceMade { get; set; }

        public Room()
        {

        }
    }
}
