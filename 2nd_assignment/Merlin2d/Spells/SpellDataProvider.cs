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
            if (spellEffects == null)
            {
                spellEffects = LoadSpellEffects();
            }

            return spellEffects;
        }

        public Dictionary<string, SpellInfo> GetSpellInfo()
        {
            if (spellInfo == null)
            {
                spellInfo = LoadSpellInfo();
            }

            return spellInfo;
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
                    dictionary[spellInfo.Name] = spellInfo;
                }
                catch (ArgumentException e)
                {
                    throw e;
                }
            }

            return dictionary;
        }

        private Dictionary<string, int> LoadSpellEffects()
        {
            string json = File.ReadAllText("resources/efgects.json");
            List<SpellEffect> effects = JsonConvert.DeserializeObject<List<SpellEffect>>(json);
            Dictionary<string, int> nameCost = new Dictionary<string, int>();
            effects.ForEach(e => nameCost[e.Name] = e.Cost);
            return nameCost;
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
