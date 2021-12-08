using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeRoom.POCO;
using Escape.Repository;

namespace Escape.UI
{
    class ProgramUI
    {
        private RoomRepo _roomRepo = new RoomRepo();

        private PlayerRepo _playerRepo = new PlayerRepo();

        

        internal void Run()
        {
            RunApplication();
        }

        public void Menu()
        {
            Console.WriteLine("Welcome to the Escape Room: Wombat Edition! We recommend reading the game rules before you start. Good luck!\n" +
                "1. Enter Escape Room\n" +
                "2. Game Rules\n" +
                "3. Prelude\n" +
                "4. Exit Application");
        }
        private void RunApplication()
        {
            EnterEscapeRoom();
        }

        public void EnterEscapeRoom()
        {
            bool isEscaping = true;
            Console.WriteLine("You enter the escape room...");
            Console.ReadKey();
            Console.WriteLine("It looks like your typical kitchen but there is a strong smell of sulfer in the air...");
            Console.ReadKey();
            LookAround();
            while (isEscaping)
            {
                Console.WriteLine("\n");
                Console.WriteLine("What would you like to do?");
                string userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "look around":
                        LookAround();
                        continue;
                    case "look at counter":
                        _playerRepo.StandByCounter(_roomRepo._room);
                        continue;
                    case "look at table":
                        _playerRepo.StandByTable();
                        continue;
                    case "look at refrigerator":
                        _playerRepo.StandByRefrigerator();
                        continue;
                    case "look at northeast corner":
                    case "look northeast":
                    case "look at northeastern corner":
                        _playerRepo.StandByCornerWithX(_roomRepo._room);
                        continue;
                    case "look at southeast corner":
                    case "look southeast":
                    case "look at southeastern corner":
                        _playerRepo.StandByAxe(_roomRepo._room);
                        continue;
                    case "pick up knife":
                        _playerRepo.PickUpKnife();
                        continue;
                    case "pick up milk":
                        _playerRepo.PickUpMilk();
                        continue;
                    case "pick up axe":
                        _playerRepo.PickUpAxe();
                        continue;
                    case "pick up book":
                    case "pick up old book":
                        _playerRepo.PickUpOldBook(_roomRepo._room);
                        continue;
                    case "pick up safe":
                        _playerRepo.PickUpSafe(_roomRepo._room);
                        continue;
                    case "look at door":
                        int x = StandByDoor();
                        if (x == 1)
                            isEscaping = false;
                        else if (x == 2)
                            isEscaping = false;
                        else if (x == 3)
                            isEscaping = true;
                        continue;
                    default:
                        Console.WriteLine("Action not recognized...");
                        continue;
                }
            }
            Console.ReadLine();
        }

        private void LookAround()
        {
            Console.Clear();
            Console.WriteLine("There is a counter that runs across the western wall of the kitchen.\n" +
            "There is a table in the center of the room that seems to have some objects on it.\n" +
            "There is a refrigerator on the northern wall next to the exit door.\n" +
            "There is an empty corner to the northeast.\n" +
            "There is a corner with an Axe standing up in it to the southeast.\n" +
            "There is a door with an exit sign.\n");
        }

        public int StandByDoor()
        {
            _playerRepo._player.IsByCounter = false;
            _playerRepo._player.IsByAxe = false;
            _playerRepo._player.IsByTable = false;
            _playerRepo._player.IsByRefrigerator = false;
            _playerRepo._player.IsByX = false;
            _playerRepo._player.IsByDoor = true;
            if (_roomRepo._room.FlippedSwitch)
            {
                Console.WriteLine("You fell through a trap door.. be careful with the decisions you make..");
                return 2;
            }
            else if (_playerRepo._playerInventory.HasKeyFromSafe)
            {
                Console.WriteLine("Congrats you did it! You smell the air and it's fresh..");
                return 1;
            }
            else if (_playerRepo._playerInventory.HasAxe)
            {
                Console.WriteLine("The door is made of solid steel.. Don't even think about..");
                return 3;
            }
            else 
            {
                Console.WriteLine("This door appears to be locked..");
                return 3;
            }
        }
    }
}
