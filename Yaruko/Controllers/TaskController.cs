using Microsoft.AspNetCore.Mvc;
using Yaruko.Models;

namespace YourProjectName.Controllers
{
    public class TaskController : Controller
    {
        private List<CustomTask> tasks = new List<CustomTask>();

        // Actions du contrôleur (Ajouter, Supprimer, etc.)
        // Utilisez des actions pour gérer les opérations CRUD sur les tâches

        // Exemple d'action pour afficher la liste des tâches
        public ActionResult Index()
        {
            return View(tasks);
        }

        // Exemple d'action pour ajouter une tâche
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomTask task)
        {
            // Code pour ajouter la tâche à la liste
            tasks.Add(task);

            return RedirectToAction("Index");
        }

        // ... Autres actions pour gérer les opérations sur les tâches
    }
}
