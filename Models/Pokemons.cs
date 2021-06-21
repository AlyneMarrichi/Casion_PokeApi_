using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Casion_PokeApi.Models
{
    public class Pokemons
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public Sprites Sprites { get; set; }

        public List<Types> Types { get; set; }

        public Pokemons() {}

        public Pokemons(int id, string name)
        {
            Id = id;
            Name = name;
        }        
    }
}