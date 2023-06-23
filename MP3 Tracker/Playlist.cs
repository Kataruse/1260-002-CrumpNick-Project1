/**
*--------------------------------------------------------------------
* File name: Playlist.cs
* Project name: 1260-002-CrumpNick-Project3
*--------------------------------------------------------------------
* Author’s name and email: Nick Crump, CRUMPNA@ETSU.ED
* Course-Section: CSCI 1260-002
* Creation Date: 3/9/2023
* -------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP3_Tracker
{
    internal class Playlist
    {

        //attributes

        List<MP3> _mp3s;
        string _name;
        string _creator;
        string _date;
        bool _saveNeeded;

        //constructors
        public Playlist()
        {
            _mp3s = new List<MP3>();
            _name = "Favorites";
            _creator = "Nicholas Crump";
            _date = "3/9/2023";
            _saveNeeded = true;
        }
        public Playlist(string name, string creator, string date)
        {
            _mp3s = new List<MP3>();
            SetName(name);
            SetCreator(creator);
            SetDate(date);  
            _saveNeeded = true;
        }

        public Playlist(Playlist other)
        {
            SetMP3s(other._mp3s);
            SetName(other._name);
            SetCreator(other._creator);
            SetDate(other._date);
            SetSaveNeeded(other._saveNeeded);
        }

        //getters & setters
        public List<MP3> GetMP3s()
        {
            return _mp3s;
        }
        public string GetName()
        {
            return _name;
        }
        public string GetCreator()
        {
            return _creator;
        }
        public string GetDate()
        {
            return _date;
        }
        public bool GetSaveNeeded()
        {
            return _saveNeeded;
        }
        public void SetMP3s(List<MP3> mp3s)
        {
            _mp3s = mp3s;
        }
        public void SetName(string name)
        {
            _name = name;
        }
        public void SetCreator(string creator)
        {
            _creator = creator;
        }
        public void SetDate(string date)
        {
            _date = date;
        }
        public void SetSaveNeeded(bool saveNeeded)
        {
            _saveNeeded = saveNeeded;
        }

        public void AddMP3(MP3 mp3)
        {
            _mp3s.Add(mp3);
        }

        public void RemoveMP3(MP3 mp3)
        {
            _mp3s.Remove(mp3);
        }

        //methods
        public string ToString()
        {
            return "";
        }

        public MP3 CreateMP3()
        {
            string month;
            string day;
            string year;
            string date;
            MP3 UMP3 = new MP3();
            
            Console.Write("Enter in the Title: ");
            UMP3.SetTitle(Console.ReadLine());
            
            Console.Write("Enter in the Artist: ");
            UMP3.SetArtist(Console.ReadLine());
            
            //User enters a year beyond 0
            do
            {
                try
                {
                    Console.Write("Enter in the Release Year: ");
                    year = Console.ReadLine();
                    if (Convert.ToInt32(year) > 0 && Convert.ToInt32(year) < 10000)
                    {
                        break;
                    }
                    else
                    {
                        
                        Console.WriteLine("Year entered was invalid.");
                    }
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            while (true);

            if (Convert.ToInt32(year) < 10)
            {
                year = "000" + year;
            }
            else if (Convert.ToInt32(year) < 100)
            {
                year = "00" + year;
            }
            else if (Convert.ToInt32(year) < 1000)
            {
                year = "0" + year;
            }

            //user enters a month 1 - 12
            do
            {
                try
                {
                    Console.Write("Enter in the Release Month: ");
                    month = Console.ReadLine();
                    if (Convert.ToInt32(month) > 0 && Convert.ToInt32(month) < 13)
                    {
                        if (Convert.ToInt32(month) < 10)
                        {
                            month = "0" + month;
                        }
                        break;
                    }
                    else
                    {
                        
                        Console.WriteLine("Month entered was invalid.");
                    }
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            while (true);
            
            //user enters a day corresponding within each months range and if its a leap year for Febraury
            do
            {
                try
                {
                    Console.Write("Enter in the Release Day: ");
                    day = Console.ReadLine();
                    //checks for months with 31 day being January, March, May, July, August, October,& December 
                    if (Convert.ToInt32(month) == 1 || Convert.ToInt32(month) == 3 || Convert.ToInt32(month) == 5 || Convert.ToInt32(month) == 7 || Convert.ToInt32(month) == 8 || Convert.ToInt32(month) == 10 || Convert.ToInt32(month) == 12)
                    {
                        if (Convert.ToInt32(day) > 0 && Convert.ToInt32(day) < 32)
                        {
                            if (Convert.ToInt32(day) < 10)
                            {
                                day = "0" + day;
                            }
                            break;
                        }
                        else
                        {
                            
                            Console.WriteLine("Day entered was invalid.");
                        }
                    }
                    //checks for months with 30 days being April, June, September, & November
                    else if (Convert.ToInt32(month) == 4 || Convert.ToInt32(month) == 6 || Convert.ToInt32(month) == 9 || Convert.ToInt32(month) == 11)
                    {
                        if (Convert.ToInt32(day) > 0 && Convert.ToInt32(day) < 31)
                        {
                            if (Convert.ToInt32(day) < 10)
                            {
                                day = "0" + day;
                            }
                            break;
                        }
                        else
                        {
                            
                            Console.WriteLine("Day entered was invalid.");
                        }
                    }
                    //checks for leap years to determine if Febraury dates are between 1 - 29 or 1 - 28
                    else if (DateTime.IsLeapYear(Convert.ToInt32(year)))
                    {
                        if (Convert.ToInt32(day) > 0 && Convert.ToInt32(day) < 30)
                        {
                            if (Convert.ToInt32(day) < 10)
                            {
                                day = "0" + day;
                            }
                            break;
                        }
                        else
                        {
                            
                            Console.WriteLine("Day entered was invalid.");
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(day) > 0 && Convert.ToInt32(day) < 29)
                        {
                            if (Convert.ToInt32(day) < 10)
                            {
                                day = "0" + day;
                            }
                            break;
                        }
                        else
                        {
                            
                            Console.WriteLine("Day entered was invalid.");
                        }
                    }
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            while (true);
            date = month + "/" + day + "/" + year;
            UMP3.SetDate(date);
            
            do
            {
                try
                {
                    Console.Write("Enter in the Length of the Song in Minutes: ");
                    UMP3.SetMinute(Convert.ToDouble(Console.ReadLine()));
                    break;
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            while (true);
            
            do
            {
                try
                {
                    Console.Write("Enter in the Genre (Rock, Pop, Jazz, Country, Classical, or Other): ");
                    UMP3.SetGenre((Genre)Enum.Parse(typeof(Genre), Console.ReadLine().ToLower()));
                    break;
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            while (true);
            
            do
            {
                try
                {
                    Console.Write("Enter in the Download Cost: ");
                    UMP3.SetCost(Convert.ToDecimal(Console.ReadLine()));
                    break;
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            while (true);
            
            do
            {
                try
                {
                    Console.Write("Enter in the Size (MBs): ");
                    UMP3.SetSize(Convert.ToDouble(Console.ReadLine()));
                    break;
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            while (true);
            
            Console.Write("Enter in the File Name: ");
            UMP3.SetPath(Console.ReadLine());
            return UMP3;
        }

        public bool CheckForMP3(string mp3Title)
        {
            bool check = false;
            string mp3;
            foreach (MP3 n in _mp3s)
            {
                if (mp3Title.ToLower() == n.GetTitle().ToLower())
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        public MP3 EditMP3(MP3 UMP3)
        {
            string month;
            string day;
            string year;
            string date;
            
            Console.Write("Enter in the Title: ");
            UMP3.SetTitle(Console.ReadLine());
            
            Console.Write("Enter in the Artist: ");
            UMP3.SetArtist(Console.ReadLine());
            
            //User enters a year beyond 0
            do
            {
                try
                {
                    Console.Write("Enter in the Release Year: ");
                    year = Console.ReadLine();
                    if (Convert.ToInt32(year) > 0)
                    {
                        break;
                    }
                    else
                    {
                        
                        Console.WriteLine("Year entered was invalid.");
                    }
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            while (true);
            
            //user enters a month 1 - 12
            do
            {
                try
                {
                    Console.Write("Enter in the Release Month: ");
                    month = Console.ReadLine();
                    if (Convert.ToInt32(month) > 0 && Convert.ToInt32(month) < 13)
                    {
                        break;
                    }
                    else
                    {
                        
                        Console.WriteLine("Month entered was invalid.");
                    }
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            while (true);
            
            //user enters a day corresponding within each months range and if its a leap year for Febraury
            do
            {
                try
                {
                    Console.Write("Enter in the Release Day: ");
                    day = Console.ReadLine();
                    //checks for months with 31 day being January, March, May, July, August, October,& December 
                    if (Convert.ToInt32(month) == 1 || Convert.ToInt32(month) == 3 || Convert.ToInt32(month) == 5 || Convert.ToInt32(month) == 7 || Convert.ToInt32(month) == 8 || Convert.ToInt32(month) == 10 || Convert.ToInt32(month) == 12)
                    {
                        if (Convert.ToInt32(day) > 0 && Convert.ToInt32(day) < 32)
                        {
                            break;
                        }
                        else
                        {
                            
                            Console.WriteLine("Day entered was invalid.");
                        }
                    }
                    //checks for months with 30 days being April, June, September, & November
                    else if (Convert.ToInt32(month) == 4 || Convert.ToInt32(month) == 6 || Convert.ToInt32(month) == 9 || Convert.ToInt32(month) == 11)
                    {
                        if (Convert.ToInt32(day) > 0 && Convert.ToInt32(day) < 31)
                        {
                            break;
                        }
                        else
                        {
                            
                            Console.WriteLine("Day entered was invalid.");
                        }
                    }
                    //checks for leap years to determine if Febraury dates are between 1 - 29 or 1 - 28
                    else if (DateTime.IsLeapYear(Convert.ToInt32(year)))
                    {
                        if (Convert.ToInt32(day) > 0 && Convert.ToInt32(day) < 30)
                        {
                            break;
                        }
                        else
                        {
                            
                            Console.WriteLine("Day entered was invalid.");
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(day) > 0 && Convert.ToInt32(day) < 29)
                        {
                            break;
                        }
                        else
                        {
                            
                            Console.WriteLine("Day entered was invalid.");
                        }
                    }
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            while (true);
            date = day + "/" + month + "/" + year;
            UMP3.SetDate(date);
            
            do
            {
                try
                {
                    Console.Write("Enter in the Length of the Song in Minutes: ");
                    UMP3.SetMinute(Convert.ToDouble(Console.ReadLine()));
                    break;
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            while (true);
            
            do
            {
                try
                {
                    Console.Write("Enter in the Genre (Rock, Pop, Jazz, Country, Classical, or Other): ");
                    UMP3.SetGenre((Genre)Enum.Parse(typeof(Genre), Console.ReadLine().ToLower()));
                    break;
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            while (true);
            
            do
            {
                try
                {
                    Console.Write("Enter in the Download Cost: ");
                    UMP3.SetCost(Convert.ToDecimal(Console.ReadLine()));
                    break;
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            while (true);
            
            do
            {
                try
                {
                    Console.Write("Enter in the Size (MBs): ");
                    UMP3.SetSize(Convert.ToDouble(Console.ReadLine()));
                    break;
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            while (true);
            
            Console.Write("Enter in the File Name: ");
            UMP3.SetPath(Console.ReadLine());
            return UMP3;
        }

        public MP3 FindByTitle(string mp3Title)
        {
            MP3 mp3 = null;
            foreach (MP3 n in _mp3s)
            {
                if (mp3Title.ToLower() == n.GetTitle().ToLower())
                {
                    mp3 = n;
                }
            }
            return mp3;
        }

        public string DisplayPlaylist()
        {
            string playlist = "";
            foreach (MP3 item in GetMP3s())
            {
                playlist = playlist + item.ToString() + "\n\n";
            }
            return playlist;
        }

        public string displayGenre(Genre genre)
        {
            string mp3s = "\n";
            foreach (MP3 n in _mp3s)
            {
                if (genre == n.GetGenre())
                {
                    mp3s = mp3s + n.ToString() + "\n";
                }
            }
            if (mp3s == "\n")
            {
                return $"\nNo MP3 in playlist has the {genre} genre.\n";
            }
            return mp3s;
        }

        public string displayArtist(string artist)
        {
            string mp3s = "\n";
            foreach (MP3 n in _mp3s)
            {
                if (artist.ToLower() == n.GetArtist().ToLower())
                {
                    mp3s = mp3s + n.ToString() + "\n";
                }
            }
            if (mp3s == "\n")
            {
                return $"\nNo MP3 in playlist has the artist {artist}.\n";
            }
            return mp3s;
        }

        public void SortTitle()
        {
            _mp3s.Sort((x, y) => string.Compare(x.GetTitle(), y.GetTitle()));
        }
        public void SortDate()
        {
            for (int i = _mp3s.Count; i > 1; i--)
            {
                int largestPos = FindCurrentPos(i);

                if (largestPos != i - 1) 
                {
                    MP3 temp = _mp3s[largestPos];
                    _mp3s[largestPos] = _mp3s[i - 1];
                    _mp3s[i - 1] = temp;
                }
            }
        }
        public int FindCurrentPos(int pos)
        {
            int current = 0;
        
            for (int i = 0; i < pos; i++)
            {
                char[] currentDateArray = _mp3s[current].GetDate().ToCharArray();

                char[] iArray = _mp3s[i].GetDate().ToCharArray();

                int currentYear = Convert.ToInt32(Convert.ToString(currentDateArray[6]) + Convert.ToString(currentDateArray[7]) + Convert.ToString(currentDateArray[8]) + Convert.ToString(currentDateArray[9]));

                int iYear = Convert.ToInt32(Convert.ToString(iArray[6]) + Convert.ToString(iArray[7]) + Convert.ToString(iArray[8]) + Convert.ToString(iArray[9]));

                if (currentYear < iYear)
                {
                    current = i;
                }
                else if (currentYear == iYear)
                {
                    int currentMonth = Convert.ToInt32(Convert.ToString(currentDateArray[0]) + Convert.ToString(currentDateArray[1]));

                    int iMonth = Convert.ToInt32(Convert.ToString(iArray[0]) + Convert.ToString(iArray[1]));

                    if (currentMonth < iMonth)
                    {
                        current = i;
                    }
                    else if (currentMonth == iMonth)
                    {
                        int currentDay = Convert.ToInt32(Convert.ToString(currentDateArray[3]) + Convert.ToString(currentDateArray[4]));

                        int iDay = Convert.ToInt32(Convert.ToString(iArray[3]) + Convert.ToString(iArray[4]));

                        if (currentDay < iDay)
                        {
                            current = i;
                        }
                    }
                }
            }
            return current;
        }

        public void FillFromFile(string filePath)
        {
            bool check = false;

            try
            {
                StreamReader rdr = new StreamReader($@"..\..\..\PlaylistData\{filePath}.txt");

                
                SetMP3s(new List<MP3>());

                while (rdr.Peek() != -1)
                {

                    string nextLine = rdr.ReadLine();

                    string[] playlistData = nextLine.Split("|");

                    if (check == false)
                    {
                        SetName(playlistData[0]);
                        SetCreator(playlistData[1]);
                        SetDate(playlistData[2]);
                        check = true;
                    }
                    else
                    {
                        MP3 mp3 = new MP3();
                        mp3.SetTitle(playlistData[0]);
                        mp3.SetArtist(playlistData[1]);
                        mp3.SetDate(playlistData[2]);
                        mp3.SetMinute(Convert.ToDouble(playlistData[3]));
                        mp3.SetGenre((Genre)Enum.Parse(typeof(Genre), playlistData[4]));
                        mp3.SetCost(Convert.ToDecimal(playlistData[5]));
                        mp3.SetSize(Convert.ToDouble(playlistData[6]));
                        mp3.SetPath(playlistData[7]);

                        GetMP3s().Add(mp3);
                    }
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SaveToFile(string filePath)
        {
            try
            {

                StreamWriter rwr = new StreamWriter($@"..\..\..\PlaylistData\{filePath}.txt");

                rwr.WriteLine(GetName() + "|" + GetCreator() + "|" + GetDate());

                for (int i = 0; i < GetMP3s().Count(); i++)
                {
                    if (i < GetMP3s().Count() - 1)
                    {
                        rwr.WriteLine(GetMP3s()[i].GetTitle() + "|" + GetMP3s()[i].GetArtist() + "|" + GetMP3s()[i].GetDate() + "|" + GetMP3s()[i].GetMinute() + "|" + GetMP3s()[i].GetGenre() + "|" + GetMP3s()[i].GetCost() + "|" + GetMP3s()[i].GetSize() + "|" + GetMP3s()[i].GetPath());
                    }
                    else
                    {
                        rwr.Write(GetMP3s()[i].GetTitle() + "|" + GetMP3s()[i].GetArtist() + "|" + GetMP3s()[i].GetDate() + "|" + GetMP3s()[i].GetMinute() + "|" + GetMP3s()[i].GetGenre() + "|" + GetMP3s()[i].GetCost() + "|" + GetMP3s()[i].GetSize() + "|" + GetMP3s()[i].GetPath());
                    }
                }

                rwr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
