using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatsAPI.Controllers
{
    public class CatController : Controller
    {
        public CatController()
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

        public List<Cat> GetCats()
        {
            return cats;
        }

        public void AddCat(Cat cat)
        {
            cats.Add(cat);
        }

        public void EditCat(Cat cat)
        {
            var index = cats.IndexOf(cats.SingleOrDefault(x => x.Name == cat.Name));
            cats[index] = new Cat
            {
                Name = cat.Name,
                Age = cat.Age,
                Birthdate = cat.Birthdate,
                Color = cat.Color
            };
        }

        public void DeleteCat(string name)
        {
            cats.Remove(cats.SingleOrDefault(x => x.Name.Equals(name)));
        }
    }
}
