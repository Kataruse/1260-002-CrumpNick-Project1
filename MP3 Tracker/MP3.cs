/**
*--------------------------------------------------------------------
* File name: MP3.cs
* Project name: 1260-002-CrumpNick-Project3
*--------------------------------------------------------------------
* Author’s name and email: Nick Crump, CRUMPNA@ETSU.EDU
* Course-Section: CSCI 1260-002
* Creation Date: 2/6/2023
* -------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MP3_Tracker
{
    public class MP3
    {
        //attributes of MP3's
        private string _title;
        private string _artist;
        private string _date;
        private double _minute;
        private Genre _genre;
        private decimal _cost;
        private double _size;
        private string _path;

        //getters & setters
        public string GetTitle()
        {
            return _title;
        }
        public string GetArtist()
        {
            return _artist;
        }
        public string GetDate()
        {
            return _date;
        }
        public double GetMinute()
        {
            return _minute;
        }
        public Genre GetGenre()
        {
            return _genre;
        }
        public decimal GetCost()
        {
            return _cost;
        }
        public double GetSize()
        {
            return _size;
        }
        public string GetPath()
        {
            return _path;
        }
        public void SetTitle(string title)
        {
            _title = title;
        }
        public void SetArtist(string artist)
        {
            _artist = artist;
        }
        public void SetDate(string date)
        {
            _date = date;
        }
        public void SetMinute(double minute)
        {
            _minute = minute;
        }
        public void SetGenre(Genre genre)
        {
            _genre = genre;
        }
        public void SetCost(decimal cost)
        {
            _cost = cost;
        }
        public void SetSize(double size)
        {
            _size = size;
        }
        public void SetPath(string path)
        {
            _path = path;
        }

        //constructors
        public MP3()
        {
            _title = "Frolic";
            _artist = "Luciano Michelini";
            _date = "2006";
            _minute = 3.33;
            _genre = Genre.classical;
            _cost = 1;
            _size = 4.1;
            _path = "Frolic.jpg";
            
        }

        public MP3(string title, string artist, string date, double minute, decimal cost, double size, string path, Genre genre)
        {
            _title = title;
            _artist = artist;
            _date = date;
            _minute = minute;
            _genre = genre;
            _cost = cost;
            _size = size;
            _path = path;
        }

        public MP3(MP3 another)
        {
            _title = another._title;
            _artist = another._artist;
            _date = another._date;
            _minute = another._minute;
            _genre = another._genre;
            _cost = another._cost;
            _size = another._size;
            _path = another._path;
        }

        //methods
        public string ToString()
        {
            return $"MP3 Title: {_title}\nArtist: {_artist}\nRelease Date: {_date}\nGenre: {_genre}\nDownload Cost: ${_cost}\nFile Size: {_size} MBs\nSong Playtime: {_minute} minutes\nAlbum Photo: {_path}";
        }


    }
}
