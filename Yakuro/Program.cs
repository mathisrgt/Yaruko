using System;

public class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();

        while (true)
        {
            Console.WriteLine("1. Ajouter une tâche");
            Console.WriteLine("2. Supprimer une tâche");
            Console.WriteLine("3. Afficher les tâches par priorité");
            Console.WriteLine("4. Ajouter un tag à une tâche");
            Console.WriteLine("5. Afficher les tâches par tag");
            Console.WriteLine("6. Ajouter une deadline à une tâche");
            Console.WriteLine("7. Afficher les tâches par deadline");
            Console.WriteLine("8. Afficher toutes les tâches");
            Console.WriteLine("9. Modifier une tâche");
            Console.WriteLine("10. Quitter");
            Console.Write("Choisissez une option : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Entrez le titre de la tâche : ");
                    string title = Console.ReadLine().ToUpper();
                    Console.Write("Entrez la description de la tâche : ");
                    string description = Console.ReadLine();
                    int priority;
                    while (true)
                    {
                        Console.Write("Entrez la priorité de la tâche : ");
                        string priorityInput = Console.ReadLine();

                        if (int.TryParse(priorityInput, out priority))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Veuillez entrer un nombre pour la priorité.");
                        }
                    }

                    CustomTask newTask = new CustomTask(title, description, priority);
                    taskManager.AddTask(newTask);
                    Console.WriteLine("Tâche ajoutée avec succès.");
                    break;

                case "2":
                    Console.Write("Entrez le titre de la tâche à supprimer : ");
                    string taskTitleToRemove = Console.ReadLine().ToUpper();
                    taskManager.RemoveTask(taskTitleToRemove);
                    break;

                case "3":
                    Console.WriteLine("Tâches triées par priorité :");
                    taskManager.ShowTasksByPriority();
                    break;

                case "4":
                    Console.Write("Entrez le titre de la tâche à laquelle vous souhaitez ajouter un tag : ");
                    string taskTitleToAddTag = Console.ReadLine().ToUpper();
                    Console.Write("Entrez le tag à ajouter : ");
                    string tagToAdd = Console.ReadLine().ToLower();
                    taskManager.AddTagToTask(taskTitleToAddTag, tagToAdd);
                    break;

                case "5":
                    Console.Write("Entrez le tag pour afficher les tâches correspondantes : ");
                    string tagToDisplay = Console.ReadLine().ToLower();
                    taskManager.ShowTasksByTag(tagToDisplay);
                    break;

                case "6":
                    Console.Write("Entrez le titre de la tâche à laquelle vous souhaitez ajouter une deadline : ");
                    string taskTitleToAddDeadline = Console.ReadLine();
                    DateTime deadlineToAdd;
                    while (true)
                    {
                        Console.Write("Entrez la deadline de la tâche (au format 'YYYY-MM-DD HH:mm') : ");
                        string deadlineInput = Console.ReadLine();

                        if (DateTime.TryParseExact(deadlineInput, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out deadlineToAdd))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Format de date incorrect. Veuillez entrer une date au format 'YYYY-MM-DD HH:mm'.");
                        }
                    }

                    taskManager.AddDeadlineToTask(taskTitleToAddDeadline, deadlineToAdd);
                    break;

                case "7":
                    Console.WriteLine("Tâches par deadline :");
                    taskManager.ShowTasksByDeadlineStatus();
                    break;

                case "8":
                    taskManager.ShowAllTasks();
                    break;

                case "9":
                    Console.Write("Entrez le titre de la tâche à modifier : ");
                    string taskTitleToModify = Console.ReadLine().ToUpper();
                    taskManager.ModifyTask(taskTitleToModify);
                    break;

                case "10":
                    taskManager.SaveTasks();
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Option invalide. Veuillez réessayer.");
                    break;
            }
        }
    }
}
