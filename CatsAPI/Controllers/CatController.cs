using CatsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;

namespace CatsAPI.Controllers
{
    public class CatController : Controller
    {
        public CatController()
        {
            catsContext = new CatRepository();
        }

        private CatRepository catsContext;

        public string GetCats()
        {
            return catsContext.GetCats();
        }

        public string GetCatByName(string name)
        {
            return catsContext.GetCat(name);
        }

        public void EditCat(string cat)
        {
            catsContext.EditCat(cat);
        }

        public bool AddCat(string cat)
        {
            Cat deserialize = JsonConvert.DeserializeObject<Cat>(cat);
            if (catsContext.CatExists(deserialize.Name))
            {
                return false;
            }
            catsContext.AddCat(cat);
            return true;
        }

        public void RemoveCat(string name)
        {
            catsContext.DeleteCat(name);
        }
    }
}
