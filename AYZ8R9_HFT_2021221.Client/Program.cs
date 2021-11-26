using AYZ8R9_HFT_2021221.Models;
using System;
using System.Linq;
using System.Threading;

namespace AYZ8R9_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(5000); //wait for 5 second
            RestService rest = new RestService("http://localhost:49978"); //gives the url to the RestService class
        }
    }
}
