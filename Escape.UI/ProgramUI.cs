using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeRoom.POCO;
using Escape.Repository;
using EscapeRoom;

namespace Escape.UI
{
    class ProgramUI
    {
        private RoomRepo _roomRepo = new RoomRepo();
        private StarDesign _design = new StarDesign();
        
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
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Menu();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        EnterEscapeRoom();
                        break;
                    case "2":
                        GameRules();
                        break;
                    case "3":
                        Prelude();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void Prelude()
        {
            Console.Clear();
            Console.WriteLine("After traveling several miles in a remote area in Northern California on a cold, wintery night,\n" +
                "you arrive at the Tinker Street Inn in search of a warm place to stay...");
            Console.ReadKey();
            Console.WriteLine("Annabelle, an older woman with graying hair and a black dress, greets you as you come stumbling in.");
            Console.ReadKey();
            Console.WriteLine("\"Welcome to Tinker Street Inn, my dear! You'll find plenty of accomodations here during your stay.\n" +
                "Your room is 13. Don't forget, supper is at 6.\"");
            Console.ReadKey();
            Console.WriteLine("You head up to your room and begin to unpack. The warm air begins to hug your skin, and you lay down\n" +
                "for some rest, but end up falling asleep...");
            Console.ReadKey();
            Console.WriteLine("\"BAM!!\" Startled, you wake up in a state of confusion from a loud crash from the hallway.\n" +
                "You forget about supper and quickly head down in hopes to fill your stomach...");
            Console.ReadKey();
            Console.WriteLine("As you enter the kitchen, you find that it's been left a mess... The door closes behind you and locks...");
            Console.ReadKey();
            Console.WriteLine("You frantically attempt to open the door but there's no hope. In order to survive, you have one option. In order to escape, you must find clues to unlocking the door.");
        }

        private void GameRules()
        {
            Console.Clear();
            Console.WriteLine("There are three commands to utilize in the Escape Room.\n" +
                "1. Look At: prompting \"Look At\" will allow your player to move to designated areas.\n" +
                "2. Pick Up: prompting \"Pick Up\" will allow your player to pick up items.\n" +
                "3. Look Around: players may prompt \"Look Around\" option to explore the room.\n" +
                "4. When prompted \"yes/no\", enter it exactly as it is shown.");
            Console.ReadKey();
        }

        

        public void EnterEscapeRoom()
        {
            bool isEscaping = true;
            _design.WriteAt("*", 5, 5);
            _design.WriteAt("*", 4, 6);
            _design.WriteAt("*", 8, 12);
            _design.WriteAt("*", 1, 7);
            _design.WriteAt("*", 11, 19);
            _design.WriteAt("*", 20, 25);
            //_design.WriteAt("*", 9, 3);
            _design.WriteAt("*", 27, 11);
            _design.WriteAt("*", 35, 15);
            _design.WriteAt("*", 32, 21);
            _design.WriteAt("*", 30, 10);
            Console.SetCursorPosition(12, 12);
            Console.WriteLine("You enter the escape room...");
            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(14, 15);
            Console.WriteLine("It looks like your typical kitchen but there is a strong smell of sulfur in the air...");
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
                    case "look at center table":
                        _playerRepo.StandByTable();
                        continue;
                    case "look at refrigerator":
                    case "look at fridge":
                    case "look at northern wall":
                        _playerRepo.StandByRefrigerator();
                        continue;
                    case "look at northeast corner":
                    case "look northeast":
                    case "look at northeastern corner":
                    case "look at empty corner":
                    case "look at empty corner northeast":
                    case "look at northeast empty corner":
                        _playerRepo.StandByCornerWithX(_roomRepo._room);
                        continue;
                    case "look at southeast corner":
                    case "look southeast":
                    case "look at southeastern corner":
                    case "look at corner with axe":
                    case "look at southeast corner with axe":
                    case "look at southeast corner with an axe":
                    case "look at corner with an axe":
                        _playerRepo.StandByAxe(_roomRepo._room);
                        continue;
                    case "pick up knife":
                        _playerRepo.PickUpKnife();
                        continue;
                    case "pick up milk":
                    case "pick up spoiled milk":
                        _playerRepo.PickUpMilk();
                        continue;
                    case "pick up axe":
                        _playerRepo.PickUpAxe();
                        continue;
                    case "pick up book":
                    case "pick up old book":
                    case "pick up wombat book":
                    case "pick up cursed book":
                    case "pick up cursed wombat book":
                        _playerRepo.PickUpOldBook(_roomRepo._room);
                        continue;
                    case "pick up safe":
                        _playerRepo.PickUpSafe(_roomRepo._room);
                        continue;
                    case "look at door":
                    case "look at exit door":
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
