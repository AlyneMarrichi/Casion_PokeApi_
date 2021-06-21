using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
//using System.Web.Configuration;
//using System.Web.Mvc;
//using System.Web.Script.Serialization;
using Casion_PokeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casion_PokeApi.Controllers
{
    public class PokemonsController : Controller 
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Casion Pokedex";
            ViewBag.Message = "";

            List<Pokemons> listaPokemons = new List<Pokemons>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("aplication/json"));
                string url = $"https://davilson.github.io/casion-tech-goodies-tests/casion-test-full-stack-dot-net/poke_api.json";

                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    string content = await response.Content.ReadAsStringAsync();
                    listaPokemons = JsonConvert.DeserializeObject<List<Pokemons>>(content);
                    ViewBag.Contador = listaPokemons.Count();
                }
                else
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
            }           
            
            return View(listaPokemons);

        }                     
    }
}