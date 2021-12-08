using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeRoom.POCO;

namespace Escape.Repository
{
    public class RoomRepo
    {
        public Room _room = new Room();
        public bool UnlockExitDoor()
        {
            _room.ExitDoorUnlocked = true;
            Console.WriteLine("You unlocked the exit! You are finally free to leave!");
            Console.ReadLine();
            return true;
        }

        public bool UnearthSafe()
        {
            _room.SafeUnearthed = true;
            Console.WriteLine("You pull the safe out from under the floor!");
            Console.ReadLine();
            return true;
        }
    }
}
