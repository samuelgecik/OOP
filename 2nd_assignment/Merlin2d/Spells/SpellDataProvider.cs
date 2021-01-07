using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Merlin2d.Spells
{
    public class SpellDataProvider : ISpellDataProvider
    {
        private static SpellDataProvider instance = null;

        private Dictionary<string, int> spellEffects;
        private Dictionary<string, SpellInfo> spellInfo;


        public SpellDataProvider()
        {
        }

        public static SpellDataProvider GetInstance()
        {
            if (instance == null)
            {
                instance = new SpellDataProvider();
            }

            return instance;
        }

        public Dictionary<string, int> GetSpellEffects()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, SpellInfo> GetSpellInfo()
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, SpellInfo> LoadSpellInfo()
        {
            List<string> lines = File.ReadAllLines("resources/spells.csv").Skip(1).ToList();
            Dictionary<string, SpellInfo> dictionary = new Dictionary<string, SpellInfo>();

            foreach(string line in lines)
            {
                try
                {
                    SpellInfo spellInfo = line;
                }
                catch (ArgumentException e)
                {

                }
            }
        }

        private Dictionary<string, int> LoadSpellEffects()
        {
            string json = File.ReadAllText("resources/efgects.json");
            List<SpellEffect> effects = JsonConvert.DeserializeObject<List<SpellEffect>>(json);
            return effects;
        }

        private class SpellEffect
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("cost")]
            public int Cost { get; set; }
        }
    }
}
