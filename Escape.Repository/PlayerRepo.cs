using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeRoom.POCO;

namespace Escape.Repository
{
    public class PlayerRepo
    {
        public Player _player = new Player();

        public Inventory _playerInventory = new Inventory();

        public bool StandByCounter(Room room)
        {
            _player.IsByCounter = true;
            _player.IsByAxe = false;
            _player.IsByTable = false;
            _player.IsByRefrigerator = false;
            _player.IsByX = false;
            _player.IsByDoor = false;
            Console.Clear();
            if (room.PictureReferenceMade)
            {
                Console.WriteLine("You notice the picture on the counter has the same girl from the picture from the book so you take a closer look\n" +
                    "and find that there is a box behind the picture frame.. you open it and find a note that says, X marks the spot.\n");
            }
            else
            {
                Console.WriteLine("You walk over to the counter and notice a picture frame.. The picture itself doesnt seem to hold any meaning yet..");
            }
            return true;
        }

        public bool StandByRefrigerator()
        {
            _player.IsByCounter = false;
            _player.IsByAxe = false;
            _player.IsByTable = false;
            _player.IsByRefrigerator = true;
            _player.IsByX = false;
            _player.IsByDoor = false;
            Console.Clear();
            Console.WriteLine("You walk over to the refrigerator and open the door.. Nothing but spoiled milk.. gross..");
            return true;
        }

        public bool StandByCornerWithX(Room room)
        {
            _player.IsByCounter = false;
            _player.IsByAxe = false;
            _player.IsByTable = false;
            _player.IsByRefrigerator = false;
            _player.IsByX = true;
            _player.IsByDoor = false;
            Console.Clear();
            Console.WriteLine("You walk to the northeastern corner.. you see an X carved into the ground..");
            if (_playerInventory.HasAxe)
            {
                Console.WriteLine("Would you like to use the axe on the floor? (yes/no)");
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "yes")
                {
                    UseAxe(room);
                }
            }
            return true;
        }

        public bool StandByAxe(Room room)
        {
            _player.IsByCounter = false;
            _player.IsByAxe = true;
            _player.IsByTable = false;
            _player.IsByRefrigerator = false;
            _player.IsByX = false;
            _player.IsByDoor = false;
            Console.Clear();
            Console.WriteLine("You walk over to the southeastern corner and notice the Axe sitting there along with an ominous switch\n" +
                "on the wall next to it. Do you flip it? (yes/no)\n");
            string userInput = Console.ReadLine();
            if (userInput == "yes")
            {
                room.FlippedSwitch = true;
                Console.WriteLine("You flipped the switch and hear some mechanisms turning under the floor..");
            }
            else
            {
                room.FlippedSwitch = false;
                Console.WriteLine("You stop thinking about the switch..");
            }
            return true;
        }

        public bool StandByTable()
        {
            _player.IsByCounter = false;
            _player.IsByAxe = false;
            _player.IsByTable = true;
            _player.IsByRefrigerator = false;
            _player.IsByX = false;
            _player.IsByDoor = false;
            Console.Clear();
            Console.WriteLine("You walk over to the table and notice a knife sitting on top of an old book entitled, The Curse of the Holy Wombat");
            return true;
        }

        public bool PickUpRoomKey(Room room)
        {
            if (room.SafeUnearthed)
            {
                _playerInventory.HasKeyFromSafe = true;
                Console.WriteLine("You picked up the Key!");
                return true;
            }
            else
            {
                Console.WriteLine("Wait... you don't even know where the key is..");
                return false;
            }
        }

        public bool PickUpMilk()
        {
            if (_player.IsByRefrigerator)
            {
                _playerInventory.GotMilk = true;
                Console.WriteLine("Got milk? Of course you do..");
                return true;
            }
            else
            {
                Console.WriteLine("You are too far away to pick that up..");
                return false;
            }

        }

        public bool PickUpKnife()
        {
            if (_player.IsByTable)
            {
                _playerInventory.HasKnife = true;
                Console.WriteLine("You picked up the knife!");
                return true;
            }
            else
            {
                Console.WriteLine("You are too far away to pick that up..");
                return false;
            }
        }

        public bool PickUpAxe()
        {
            if (_player.IsByAxe)
            {
                _playerInventory.HasAxe = true;
                Console.WriteLine("You picked up the Axe!");
                return true;
            }
            else
            {
                Console.WriteLine("You are too far away to pick that up..");
                return false;
            }
        }

        public bool PickUpOldBook(Room room)
        {
            if (_player.IsByTable)
            {
                _playerInventory.HasOldBook = true;
                Console.WriteLine("You picked up the Old Book! Do you want to open it? (yes/no)");
                string userInput = Console.ReadLine();
                if (userInput == "yes")
                {
                    Console.WriteLine("You notice a picture with a little girl on it.. it seems to have some relation to the picture on the counter..");
                    TakePictureFromBook(room);
                }
                return true;
            }
            else
            {
                Console.WriteLine("You are too far away to pick that up..");
                return false;
            }
        }

        public bool TakePictureFromBook(Room room)
        {
            _playerInventory.HasBookPicture = true;
            Console.WriteLine("You take the picture from the book! You notice numbers on the back that resemble a combination..");
            room.PictureReferenceMade = true;
            _playerInventory.HasCombination = true;
            if (room.SafeUnearthed)
            {
                Console.WriteLine("Would you like to use it on the safe you found? (yes/no)");
                string userInput = Console.ReadLine();
                if (userInput == "yes")
                {
                    Console.WriteLine("You open the safe with the combination from the picture and discover a key.");
                    PickUpRoomKey(room);
                }
            }
            return true;
        }

        public bool UseAxe(Room room)
        {
            Console.WriteLine("You break through the floor and find a safe down below.");
            room.SafeUnearthed = true;
            return true;
        }

        public bool PickUpSafe(Room room)
        {
            if (room.SafeUnearthed)
            {
                Console.WriteLine("You pick it up and place it on the main floor by yourself.");
                if (_playerInventory.HasCombination)
                {
                    Console.WriteLine("You open the safe with the combination from the picture and discover a key.");
                    PickUpRoomKey(room);
                }
                else
                {
                    Console.WriteLine("If only you knew the combination..");
                }
                return true;
            }
            else
            {
                Console.WriteLine("You don't know if there's a safe...");
                return false;
            }
        }
    }
}
