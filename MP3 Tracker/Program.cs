

using Microsoft.VisualBasic;
using System.Dynamic;
/**
*--------------------------------------------------------------------
* File name: Program.cs
* Project name: 1260-002-CrumpNick-Project3
*--------------------------------------------------------------------
* Author’s name and email: Nick Crump, CRUMPNA@ETSU.EDU
* Course-Section: CSCI 1260-002
* Creation Date: 3/9/2023
* -------------------------------------------------------------------
*/
namespace MP3_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool check = true;
            Console.Write("Enter your name: ");
            string uName = Console.ReadLine();
            string filePath = "";
            Console.WriteLine("------------------------------------");

            Playlist playlist = null;
            string uInput;
            MP3 UMP3 = null;
            while (check)
            {
                Console.WriteLine($"Welcome {uName} to MP3 Tracker");
                Console.WriteLine("[1] Create a new Playlist for MP3 Tracker");
                Console.WriteLine("[2] Create a new MP3 object and add it to the playlist");
                Console.WriteLine("[3] Edit an existing MP3 from the playlist");
                Console.WriteLine("[4] Drop an MP3 from the playlist");
                Console.WriteLine("[5] Display all MP3s in the playlist");
                Console.WriteLine("[6] Find and display an MP3 by song title");
                Console.WriteLine("[7] Display all MP3s on the tracker of a given genre");
                Console.WriteLine("[8] Display all MP3s on the tracker with a given artist");
                Console.WriteLine("[9] Sort the MP3s by song title length");
                Console.WriteLine("[10] Sort the MP3s by song release date");
                Console.WriteLine("[11] Populating a Playlist object from a file");
                Console.WriteLine("[12] Saving a Playlist object to a file");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("------------------------------------");


                try
                {
                    Console.Write("Enter a menu selection: ");
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        //Creates a Playlist
                        case 1:
                            Console.WriteLine("------------------------------------");
                            if (playlist != null)
                            {
                                if (playlist.GetSaveNeeded() == true)
                                {
                                    Console.Write("\nEnter the file name from PlaylistData you'd like to save to: ");
                                    filePath = Console.ReadLine();
                                    playlist.SaveToFile(filePath);
                                    playlist.SetSaveNeeded(false);
                                }
                            }
                            Console.Write("Enter a name for your playlist: ");
                            string pName = Console.ReadLine();
                            playlist = new Playlist(pName, uName, DateTime.Now.ToString("MM/dd/yyyy"));
                            Console.WriteLine("------------------------------------");
                            break;
                        //Creates a MP3 if Playlist has been created
                        case 2:
                            Console.WriteLine("------------------------------------");
                            if (playlist == null)
                            {
                                Console.WriteLine("Please create a playlist before creating a MP3 to add.");
                                Console.WriteLine("------------------------------------");
                                break;
                            }
                            UMP3 = playlist.CreateMP3();
                            playlist.AddMP3(UMP3);
                            playlist.SetSaveNeeded(true);
                            Console.WriteLine("------------------------------------");
                            break;
                        //Edits an existing MP3 from the playlist
                        case 3:
                            Console.WriteLine("------------------------------------");
                            if (playlist == null)
                            {
                                Console.WriteLine("Please create a playlist before editing an MP3.");
                                Console.WriteLine("------------------------------------");
                                break;
                            }
                            Console.Write("Enter the title of an existing MP3: ");
                            uInput = Console.ReadLine();
                            
                            if (playlist.CheckForMP3(uInput))
                            {
                                UMP3 = playlist.FindByTitle(uInput);
                                playlist.EditMP3(UMP3);
                                playlist.SetSaveNeeded(true);
                            }
                            else
                            {

                                Console.WriteLine("Not a valid MP3 in playlist.");
                            }
                            Console.WriteLine("------------------------------------");
                            break;
                        //Removes an existing MP3 from the playlist
                        case 4:
                            Console.WriteLine("------------------------------------");
                            if (playlist == null)
                            {
                                Console.WriteLine("Please create a playlist before removing an MP3.");
                                Console.WriteLine("------------------------------------");
                                break;
                            }
                            Console.Write("Enter the title of the MP3 you want to remove: ");
                            uInput = Console.ReadLine();
                            
                            if (playlist.CheckForMP3(uInput))
                            {
                                UMP3 = playlist.FindByTitle(uInput);
                                playlist.RemoveMP3(UMP3);
                                Console.WriteLine($"Removed {uInput} from {playlist.GetName()}.");
                                playlist.SetSaveNeeded(true);
                            }
                            else
                            {

                                Console.WriteLine("Not a valid MP3 in playlist.");
                            }
                            Console.WriteLine("------------------------------------");
                            break;
                        //Displays all MP3's in playlist
                        case 5:
                            Console.WriteLine("------------------------------------");
                            if (playlist == null)
                            {
                                Console.WriteLine("Please create a playlist before displaying all MP3's.");
                                Console.WriteLine("------------------------------------");
                                break;
                            }
                            Console.WriteLine($"Playlist: {playlist.GetName()}\n");
                            Console.WriteLine($"Creator: {playlist.GetCreator()}\n");
                            Console.WriteLine($"Date: {playlist.GetDate()}\n");
                            Console.WriteLine(playlist.DisplayPlaylist());
                            Console.WriteLine("------------------------------------");
                            break;
                        //Find and display a single MP3 by title
                        case 6:
                            Console.WriteLine("------------------------------------");
                            if (playlist == null)
                            {
                                Console.WriteLine("Please create a playlist before displaying an MP3.");
                                Console.WriteLine("------------------------------------");
                                break;
                            }
                            Console.Write("Enter the title of an existing MP3: ");
                            uInput = Console.ReadLine();
                            
                            if (playlist.CheckForMP3(uInput))
                            {
                                Console.WriteLine(playlist.FindByTitle(uInput).ToString());
                            }
                            else
                            {

                                Console.WriteLine("Not a valid MP3 in playlist.");
                            }
                            Console.WriteLine("------------------------------------");
                            break;
                        //displays all MP3's in a given genre
                        case 7:
                            Console.WriteLine("------------------------------------");
                            if (playlist == null)
                            {
                                Console.WriteLine("Please create a playlist before displaying an MP3 by genre.");
                                Console.WriteLine("------------------------------------");
                                break;
                            }
                            try
                            {
                                Console.Write("Enter in a Genre (Rock, Pop, Jazz, Country, Classical, or Other): ");
                                Console.WriteLine($"{playlist.displayGenre((Genre)Enum.Parse(typeof(Genre), Console.ReadLine().ToLower()))}");
                            }
                            catch (Exception e)
                            {
                                
                                Console.WriteLine(e.Message);
                            }
                            Console.WriteLine("------------------------------------");
                            break;
                        //displays all MP3's by a given artist
                        case 8:
                            Console.WriteLine("------------------------------------");
                            if (playlist == null)
                            {
                                Console.WriteLine("Please create a playlist before displaying an MP3 by artist.");
                                Console.WriteLine("------------------------------------");
                                break;
                            }
                            try
                            {
                                Console.Write("Enter in an Artist: ");
                                Console.WriteLine($"{playlist.displayArtist(Console.ReadLine())}");
                            }
                            catch (Exception e)
                            {
                                
                                Console.WriteLine(e.Message);
                            }
                            Console.WriteLine("------------------------------------");
                            break;
                        //sorts the MP3's by song title
                        case 9:
                            Console.WriteLine("------------------------------------");
                            if (playlist == null)
                            {
                                Console.WriteLine("Please create a playlist before sorting an MP3 by title.");
                                Console.WriteLine("------------------------------------");
                                break;
                            }
                            playlist.SortTitle();
                            playlist.SetSaveNeeded(true);
                            Console.WriteLine("Playlist storted by song title.");
                            Console.WriteLine("------------------------------------");
                            break;
                        //sorts the MP3's by release date
                        case 10:
                            Console.WriteLine("------------------------------------");
                            if (playlist == null)
                            {
                                Console.WriteLine("Please create a playlist before sorting an MP3 by date.");
                                Console.WriteLine("------------------------------------");
                                break;
                            }
                            playlist.SortDate();
                            playlist.SetSaveNeeded(true);
                            Console.WriteLine("Playlist sorted by release date.");
                            Console.WriteLine("------------------------------------");
                            break;
                        case 11:
                            Console.WriteLine("------------------------------------");

                            if (playlist == null)
                            {
                                Console.WriteLine("Please create a playlist before reading data from a file.");
                                Console.WriteLine("------------------------------------");
                                break;
                            }
                            else if (playlist.GetSaveNeeded() == true)
                            {
                                Console.Write("\nEnter the file name from PlaylistData you'd like to save to: ");
                                filePath = Console.ReadLine();
                                playlist.SaveToFile(filePath);
                                playlist.SetSaveNeeded(false);
                            }
                            Console.Write("Enter the file name from PlaylistData you'd like to read from: ");
                            filePath = Console.ReadLine();
                            Console.WriteLine($"Populating Playlist from {filePath}.");
                            try
                            {
                                playlist.FillFromFile(filePath);
                            }
                            catch (Exception ex) 
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.WriteLine("------------------------------------");
                            break;
                        case 12:
                            Console.WriteLine("------------------------------------");
                            if (playlist == null)
                            {
                                Console.WriteLine("Please create a playlist before saving it.");
                                Console.WriteLine("------------------------------------");
                                break;
                                
                            }
                            Console.Write("Enter the file name from PlaylistData you'd like to save to: ");
                            filePath = Console.ReadLine();
                            Console.WriteLine($"Saving a {playlist.GetName()} to {filePath}");
                            playlist.SaveToFile(filePath);
                            playlist.SetSaveNeeded(false);
                            Console.WriteLine("------------------------------------");
                            break;
                        //exits the program
                        case 0:
                            check = false;
                            if (playlist != null)
                            {
                                if (playlist.GetSaveNeeded() == true)
                                {

                                    Console.Write("\nEnter the file name from PlaylistData you'd like to save to: ");
                                    filePath = Console.ReadLine();
                                    playlist.SaveToFile(filePath);
                                    playlist.SetSaveNeeded(false);
                                }
                            }
                            break;
                        default:
                            
                            Console.WriteLine("Input integer was out of the selection of the menu.");
                            Console.WriteLine("------------------------------------");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine(ex.Message);
                }
                
            }
            Console.WriteLine("Shutting down...");
        }
    }
}
