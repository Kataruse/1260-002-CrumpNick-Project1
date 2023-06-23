/**
*--------------------------------------------------------------------
* File name: Program.cs
* Project name: 1260-002-CrumpNick-Project1
*--------------------------------------------------------------------
* Author’s name and email: Nick Crump, CRUMPNA@ETSU.EDU
* Course-Section: CSCI 1260-002
* Creation Date: 2/6/2023
* -------------------------------------------------------------------
*/

namespace MP3_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Welcoming message
            Console.WriteLine("---Welcome to MP3 Display Program---");
            Console.WriteLine("By: Nicholas Crump");
            Console.WriteLine("This program will display any MP3 created in it!\n");
            Console.Write("Please enter a username: ");
            string username = Console.ReadLine();

            //Method that displays the menu
            void DisplayMenu()
            {
                Console.Clear();
                Console.WriteLine($"Make a selection {username}.");
                Console.WriteLine("[1] Create a MP3");
                Console.WriteLine("[2] Display the MP3");
                Console.WriteLine("[0] Shutdown");
            }


            //All variables needed for menu navigation
            int uInput = 3;
            MP3 UMP3 = null;
            string uGenre = "";
            bool intCheck = false;
            //loops menu till user enters a integer <= 0
            do
            {
                intCheck = false;
                uInput = 3;
                DisplayMenu();
                //checks if the user's input was able to be converted to an integer
                try
                {
                    uInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("---ERROR: Not a integer---");
                    Console.ReadLine();
                    intCheck = true;
                }

                switch (uInput)
                {
                    //case 1 creates MP3's
                    case 1:
                        UMP3 = new MP3();
                        Console.Clear();
                        Console.Write("Enter in the Title: ");
                        UMP3.SetTitle(Console.ReadLine());
                        Console.Clear();
                        Console.Write("Enter in the Artist: ");
                        UMP3.SetArtist(Console.ReadLine());
                        Console.Clear();
                        Console.Write("Enter in the Date: ");
                        UMP3.SetDate(Console.ReadLine());
                        Console.Clear();
                        do
                        {
                            try
                            {
                                Console.Write("Enter in the Length of the Song in Minutes: ");
                                UMP3.SetMinute(Convert.ToDouble(Console.ReadLine()));
                                break;
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("---Error: Input was not a double---");
                            }
                        }
                        while (true);
                        Console.Clear();
                        do
                        {
                            try
                            {
                                Console.Write("Enter in the Genre (Rock, Pop, Jazz, Country, Classical, or Other): ");
                                UMP3.SetGenre((Genre)Enum.Parse(typeof(Genre), Console.ReadLine().ToLower()));
                                break;
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("---Error: Input was not a Genre---");
                            }
                        }
                        while (true);
                        Console.Clear();
                        do
                        {
                            try
                            {
                                Console.Write("Enter in the Download Cost: ");
                                UMP3.SetCost(Convert.ToDecimal(Console.ReadLine()));
                                break;
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("---Error: Input was not a decimal---");
                            }
                        }
                        while (true);
                        Console.Clear();
                        do
                        {
                            try
                            {
                                Console.Write("Enter in the Size (MBs): ");
                                UMP3.SetSize(Convert.ToDouble(Console.ReadLine()));
                                break;
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("---Error: Input was not a double---");
                            }
                        }
                        while (true);
                        Console.Clear();
                        Console.Write("Enter in the File Name: ");
                        UMP3.SetPath(Console.ReadLine());
                        break;
                    //case 2 displays MP3's and checks if the user has created a MP3
                    case 2:
                        if(UMP3 == null) { 
                            Console.Clear();
                            Console.WriteLine("---ERROR: No MP3 has been created---");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(UMP3.ToString());
                            Console.ReadLine();
                        }
                        break;
                    //default case displays a error message since the user's input was not valid
                    default:
                        if (intCheck != true)
                        {
                            if (uInput != 0)
                            {
                                Console.Clear();
                                Console.WriteLine("---ERROR: Not a valid menu selection---");
                                Console.ReadLine();
                            }
                        }
                        break;
                }
            } while (uInput != 0);
            //displays a goodbye message with the username
            Console.Clear();
            Console.WriteLine($"Have a great day {username}! <3");
        }
    }
}
