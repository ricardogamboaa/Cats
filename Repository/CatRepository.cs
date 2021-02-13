using Newtonsoft.Json;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CatRepository
    {
        public CatRepository()
        {
            if (cats == null)
            {
                InitializeCats();
            }
        }
        private static List<Cat> cats;

        private void InitializeCats()
        {
            cats = new List<Cat>
            {
                new Cat
                {
                    Name = "Olie",
                    Age = 0,
                    Birthdate = DateTime.Now,
                    Color = "Black"
                },
                new Cat
                {
                    Name = "Selina",
                    Age = 3,
                    Birthdate = DateTime.Now.AddYears(-3),
                    Color = "Brown"
                },
                new Cat
                {
                    Name = "Roger",
                    Age = 8,
                    Birthdate = DateTime.Now.AddYears(-8),
                    Color = "White"
                }
            };
        }

        public string GetCats()
        {
            return JsonConvert.SerializeObject(cats);
        }

        public string GetCat(string name)
        {
            return JsonConvert.SerializeObject(cats.FirstOrDefault(x => x.Name.Equals(name)));
        }

        public void AddCat(string cat)
        {
            cats.Add(JsonConvert.DeserializeObject<Cat>(cat));
        }

        public void EditCat(string cat)
        {
            var deselializedCat = JsonConvert.DeserializeObject<Cat>(cat);
            var index = cats.IndexOf(cats.SingleOrDefault(x => x.Name == deselializedCat.Name));
            cats[index] = deselializedCat;
        }

        public void DeleteCat(string name)
        {
            cats.Remove(cats.SingleOrDefault(x => x.Name.Equals(name)));
        }

        public bool CatExists(string name)
        {
            if(cats.Any(x => x.Name.Equals(name)))
            {
                return true;
            }
            return false;
        }
    }
}
