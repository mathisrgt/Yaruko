﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization; // Utilisation de XmlSerializer pour la sérialisation XML

public class TaskManager
{
    private List<CustomTask> tasks = new List<CustomTask>();
    private string dataFilePath = "tasks.xml"; // Nom du fichier de données

    public TaskManager()
    {
        LoadTasks(); // Charger les tâches depuis le fichier lors du démarrage
    }

    public void AddTask(CustomTask task)
    {
        tasks.Add(task);
    }

    public void RemoveTask(string title)
    {
        CustomTask taskToRemove = tasks.FirstOrDefault(task => task.Title == title);
        if (taskToRemove != null)
        {
            tasks.Remove(taskToRemove);
            Console.WriteLine($"Tâche '{title}' supprimée.");
        }
        else
        {
            Console.WriteLine($"Tâche '{title}' introuvable.");
        }
    }

    public void ShowTasksByPriority()
    {
        var sortedTasks = tasks.OrderBy(task => task.Priority);
        foreach (var task in sortedTasks)
        {
            Console.WriteLine($"Titre : {task.Title}, Priorité : {task.Priority}");
        }
    }

    public void AddTagToTask(string title, string tag)
    {
        CustomTask task = tasks.FirstOrDefault(t => t.Title == title);
        if (task != null)
        {
            task.Tags.Add(tag);
            Console.WriteLine($"Tag '{tag}' ajouté à la tâche '{title}'.");
        }
        else
        {
            Console.WriteLine($"Tâche '{title}' introuvable.");
        }
    }

    public void AddDeadlineToTask(string title, DateTime deadline)
    {
        CustomTask task = tasks.FirstOrDefault(t => t.Title == title);
        if (task != null)
        {
            task.Deadline = deadline;
            Console.WriteLine($"Deadline ajoutée à la tâche '{title}'.");
        }
        else
        {
            Console.WriteLine($"Tâche '{title}' introuvable.");
        }
    }

    public void ShowTasksByTag(string tag)
    {
        var taggedTasks = tasks.Where(task => task.Tags.Contains(tag));
        Console.WriteLine($"Tâches avec le tag '{tag}' :");
        foreach (var task in taggedTasks)
        {
            Console.WriteLine($"Titre : {task.Title}, Priorité : {task.Priority}");
        }
    }

    public void ShowTasksByDeadlineStatus()
    {
        DateTime currentDate = DateTime.Now;
        var tasksNotPassedDeadline = tasks.Where(task => task.Deadline > currentDate);
        var tasksPassedDeadline = tasks.Where(task => task.Deadline <= currentDate);

        Console.WriteLine("Tâches dont la deadline n'a pas encore été dépassée :");
        foreach (var task in tasksNotPassedDeadline)
        {
            Console.WriteLine($"Titre : {task.Title}, Deadline : {task.Deadline}");
        }

        Console.WriteLine("\nTâches dont la deadline a été dépassée :");
        foreach (var task in tasksPassedDeadline)
        {
            Console.WriteLine($"Titre : {task.Title}, Deadline : {task.Deadline}");
        }
    }

    // Méthode pour sauvegarder les tâches dans un fichier
    public void SaveTasks()
    {
        try
        {
            using (FileStream fs = new FileStream(dataFilePath, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<CustomTask>));
                serializer.Serialize(fs, tasks);
                Console.WriteLine("Tâches sauvegardées avec succès.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la sauvegarde des tâches : {ex.Message}");
        }
    }

    // Méthode pour charger les tâches depuis un fichier
    public void LoadTasks()
    {
        if (File.Exists(dataFilePath))
        {
            try
            {
                using (FileStream fs = new FileStream(dataFilePath, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<CustomTask>));
                    tasks = (List<CustomTask>)serializer.Deserialize(fs);
                    Console.WriteLine("Tâches chargées avec succès.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement des tâches : {ex.Message}");
            }
        }
    }
}
