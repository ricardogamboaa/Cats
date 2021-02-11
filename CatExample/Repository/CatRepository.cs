using CatsAPI.Controllers;
using ApiModel = CatsAPI.Models;
using WebModel = CatExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatExample.Repository
{
    public class CatRepository
    {
        public CatRepository(CatController cats)
        {
            catsContext = cats;
        }

        private CatController catsContext;

        public List<WebModel.Cat> GetCats()
        {
            List<WebModel.Cat> castCats = new List<WebModel.Cat>();
            List<ApiModel.Cat> cats = catsContext.GetCats();
            foreach(var cat in cats)
            {
                castCats.Add(new WebModel.Cat
                {
                    Name = cat.Name,
                    Age = cat.Age,
                    Birthdate = cat.Birthdate,
                    Color = cat.Color
                });
            }
            return castCats;
        }

        public WebModel.Cat GetCatByName(string name)
        {
            var cat = catsContext.GetCats().SingleOrDefault(x => x.Name.Equals(name));
            return new WebModel.Cat 
            { 
                Age = cat.Age,
                Birthdate = cat.Birthdate,
                Color = cat.Color,
                Name = cat.Name
            };
        }

        public void EditCat(WebModel.Cat cat)
        {
            catsContext.EditCat(new ApiModel.Cat 
            { 
                Name = cat.Name,
                Age = cat.Age,
                Birthdate = cat.Birthdate,
                 Color = cat.Color
            });
        }

        public bool AddCat(WebModel.Cat cat)
        {
            var cats = catsContext.GetCats();
            if(!cats.Any(x => x.Name == cat.Name))
            {
                cats.Add(new ApiModel.Cat 
                { 
                    Name = cat.Name,
                    Age = cat.Age,
                    Color = cat.Color,
                    Birthdate = cat.Birthdate
                });
                return true;
            }
            return false;
        }

        public void RemoveCat(string name)
        {
            catsContext.DeleteCat(name);
        }
    }
}
