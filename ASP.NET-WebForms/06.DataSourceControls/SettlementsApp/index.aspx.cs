using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Settlements.Data;
using Settlements.Model;

namespace SettlementsApp
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
   
        }

        protected void ContinentsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedContinent = ContinentsList.SelectedIndex;
        }
        public int SelectedContinent { get; set; }
        public string CountryName { get; set; }
        public string CountryLanguage { get; set; }
        public int CountryPopulation { get; set; }
        public int CountryContinentId { get; set; }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            string countryName = (string)ViewState["CountryName"];
            string countryLanguage = (string)ViewState["CountryLanguage"];
            if (string.IsNullOrWhiteSpace(countryName) || string.IsNullOrWhiteSpace(countryLanguage))
            {
                return;
            }

            SettlementsContext db = new SettlementsContext();

            var contId = (int)ViewState["CountryContinentId"];

            var foundContinent = db.Continents.Where(x => x.Id == contId).FirstOrDefault();

            var newCountry = new Country
            {
                Name = countryName,
                Language = countryLanguage,
                Population = (int)ViewState["CountryPopulation"],
                Continend = foundContinent
                
            };

            db.Countries.Add(newCountry);
            db.SaveChanges();
        }

        protected void tbgridName_PreRender(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            CountryName = tb.Text;
            ViewState.Add("CountryName", tb.Text);
        }

        protected void tb_grid_Language_PreRender(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            CountryLanguage = tb.Text;
            ViewState.Add("CountryLanguage", tb.Text);
        }

        protected void tb_grid_Population_PreRender(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            var text = tb.Text;
            if (!string.IsNullOrWhiteSpace(text))
            {

                ViewState.Add("CountryPopulation",  int.Parse(text));
            }
        }

        protected void tb_grid_ContentId_PreRender(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
             var text = tb.Text;
             if (!string.IsNullOrWhiteSpace(text))
             {
                 this.CountryContinentId = int.Parse(text);
                 ViewState.Add("CountryContinentId", int.Parse(text));
             }
        }




    }


    public class ContinentsRepository
    {
        SettlementsContext db = new SettlementsContext();

        public List<Settlements.Model.Continent> GetContinents()
        {
            return (from c in db.Continents
                    select c).ToList();
        }
    }

    public class TownsRepository
    {
        SettlementsContext db = new SettlementsContext();

        public List<Town> GetTowns(int selectedCountryId)
        {
            return (from c in db.Towns
                    where c.Country.Id == selectedCountryId
                    select c).ToList();
        }

        public Town Insert(string Name, int Population, string Country)
        {
            var foundCountry = db.Countries.Where(x => x.Name == Country).Single();

            var added = db.Towns.Add(new Town
            {
                Name = Name,
                Country = foundCountry,
                Population = Population
            });

            db.SaveChanges();

            return added;
        }

        public void Update(int Id, string Name, int Population, string Country)
        {
            var foundCountry = db.Countries.Where(x => x.Name == Country).Single();

            var updated = (from t in db.Towns
                           where t.Id == Id
                           select t).First();

            updated.Name = Name;
            updated.Population = Population;
            updated.Country = foundCountry;

            db.SaveChanges();
        }
    }

    public class CountriesRepository
    {
        SettlementsContext db = new SettlementsContext();

        public List< Settlements.Model.Country> GetCountriesInContinent(int selectedContinentId)
        {


            return (from c in db.Countries
                    where c.Continend.Id == selectedContinentId
                    select c).ToList();

        }

        public List< Settlements.Model.Country> GetCountriesInContinent(int selectedContinentId, string sortColumnBy)
        {
            List< Settlements.Model.Country> found = new List< Settlements.Model.Country>();
            switch (sortColumnBy)
            {
                case "Name":
                    {
                        found = (from c in db.Countries
                                 where c.Continend.Id == selectedContinentId
                                 orderby c.Name
                                 select c).ToList();
                    }
                    break;
                case "Name DESC":
                    {
                        found = (from c in db.Countries
                                 where c.Continend.Id == selectedContinentId
                                 orderby c.Name
                                 select c).ToList();
                        found.Reverse();
                    } break;
                case "":
                    {
                        found = (from c in db.Countries
                                 where c.Continend.Id == selectedContinentId
                                 select c).ToList();
                    } break;
            }

            return found;

        }

        public void Insert(string Name, string Language, int Population)
        {
            var added = db.Countries.Add(new Country
            {
                Name = Name,
                Language = Language,
                Population = Population
            });

            db.SaveChanges();

        }

        public void Update(int Id, string Name, string Language, int Population)
        {
            var found = db.Countries.Find(Id);

            found.Name = Name;
            found.Language = Language;
            found.Population = Population;

            db.SaveChanges();
        }


    }


}