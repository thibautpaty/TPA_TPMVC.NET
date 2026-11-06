using Microsoft.AspNetCore.Mvc;

using TPLOCAL1.Models;

namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
     
        public ActionResult Index(string id)
        {
            if (id == "AvisList")
            {
                OpinionList listeAvis = new OpinionList();
                List<Opinion> avis = listeAvis.GetAvis("XlmFile/DataAvis.xml");
                return View("AvisList", avis);
            }

            if (id == "Form")
            {
                Formulaire formulaire = new Formulaire();
                return View("Form", formulaire);
            }

            return View();
        }

        [HttpPost]
        public ActionResult ValidationFormulaire(Formulaire formulaire)
        {
            if (string.IsNullOrWhiteSpace(formulaire.LastName)
                || string.IsNullOrWhiteSpace(formulaire.FirstName)
                || string.IsNullOrWhiteSpace(formulaire.Gender)
                || string.IsNullOrWhiteSpace(formulaire.Address)
                || string.IsNullOrWhiteSpace(formulaire.PostalCode)
                || string.IsNullOrWhiteSpace(formulaire.City)
                || string.IsNullOrWhiteSpace(formulaire.Email)
                || string.IsNullOrWhiteSpace(formulaire.TrainingType))
            {
                ViewBag.Erreur = "Veuillez remplir tous les champs.";
                return View("Form", formulaire);
            }

            if (formulaire.Address.Length < 5)
            {
                ViewBag.Erreur = "L'adresse est trop courte.";
                return View("Form", formulaire);
            }

            if (formulaire.TrainingType == "Formation Cobol"
                && string.IsNullOrWhiteSpace(formulaire.CobolFormation))
            {
                ViewBag.Erreur = "Veuillez renseigner votre avis sur la formation Cobol.";
                return View("Form", formulaire);
            }

            if (formulaire.TrainingType == "Formation C#"
                && string.IsNullOrWhiteSpace(formulaire.CSharpFormation))
            {
                ViewBag.Erreur = "Veuillez renseigner votre avis sur la formation C#.";
                return View("Form", formulaire);
            }

            if (formulaire.TrainingType == "Formation à double compétence"
                && (string.IsNullOrWhiteSpace(formulaire.CobolFormation)
                || string.IsNullOrWhiteSpace(formulaire.CSharpFormation)))
            {
                ViewBag.Erreur = "Veuillez renseigner votre avis sur les deux formations.";
                return View("Form", formulaire);
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(formulaire.PostalCode, @"^[0-9]{5}$")
                || !System.Text.RegularExpressions.Regex.IsMatch(formulaire.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ViewBag.Erreur = "Le code postal ou l'adresse e-mail est invalide.";
                return View("Form", formulaire);
            }

            if (formulaire.StartDate == DateTime.MinValue
                || formulaire.StartDate >= new DateTime(2021, 1, 1))
            {
                ViewBag.Erreur = "La date de début doit être antérieure au 01/01/2021.";
                return View("Form", formulaire);
            }

            return View(formulaire);
        }
    }
}