using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ConsumeWebApi.Models;
using Newtonsoft.Json;


namespace ConsumeWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            TutorialEntityFrameworks getTip = new TutorialEntityFrameworks();

            Console.WriteLine(getTip.GetTipById(1));
            Console.ReadLine();
        }
    }
}
