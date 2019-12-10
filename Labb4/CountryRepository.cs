using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Labb4.Repository
{
    public class CountryRepository
    {
        public List<Country> Countries { get; set; }

        public void GetJson()
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{"rawData.json"}");

            using (StreamReader r = new StreamReader(stream))
            {
                var CountryCollection = JsonConvert.DeserializeObject<CountryRepository>(r.ReadToEnd());
                Countries = CountryCollection.Countries;
            }
                
        }

        public List<Country> GetCountries()
        {
            GetJson();
            return Countries;
        }

    }

}
