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
        
        
        public ChampionSimple GetChamp(int id)
        {
            HttpClient client = new HttpClient();
            var token = "RGAPI-0B059AC1-A838-48C1-8A88-F2569F4E184B";
            client.BaseAddress = new Uri("https://global.api.riotgames.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/lol/static-data/LAN/v1.2/champion/" + id + "?api_key=" + token).Result;


            if (response.IsSuccessStatusCode)
            {
                var champion = response.Content.ReadAsStringAsync().Result;
                ChampionSimple championsimple = JsonConvert.DeserializeObject<ChampionSimple>(champion);

                return championsimple;
            }
            else
            {
                ChampionSimple championsimple = new ChampionSimple
                {
                    id = 0,
                    key = "No funciono",
                    name = "402",
                    title = "No funciono"
                };

                return championsimple;
            }
        }

        public void SaveChampion(ChampionSimple champion)
        {
            if (champion.name == "402")
            {
                Console.WriteLine("Ese no parece un id que se pueda guardar");
            }
            else
            {
                using (Entities db = new Entities())
                {
                    var query = new ChampionTips
                    {
                        IdInGame = champion.id,
                        Name = champion.name,
                        Title = champion.title
                    };
                    db.ChampionTips.Add(query);

                    db.SaveChanges();
                    Console.WriteLine("Se guardo: " + champion.name);
                }
            }
            
        }

        public void CallQuery(int id)
        {
            Program pg = new Program();
            ChampionSimple test = pg.GetChamp(id);
            pg.SaveChampion(test);
        }

        static void Main(string[] args)
        {
            Program pg = new Program();
            var contador = 1;

            while (contador <= 498)
            {
                pg.CallQuery(contador);
                contador += 1;
            }

            Console.WriteLine("Se termino la consulta");    

        }
    }
}
