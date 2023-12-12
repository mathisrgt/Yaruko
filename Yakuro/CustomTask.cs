using System;

class CustomTask
{
    private string title;
    private string description;
    private int priority;
    private string tag;
    private bool completed;

    public CustomTask(string title, string description, int priority, string tag, bool completed)
    {
        this.title = title;
        this.description = description;
        this.priority = priority;
        this.tag = tag;
        this.completed = completed;
    }

    public string Title { get => title; }
    public string Description { get => description; }
    public int Priority { get => priority; }
    public string Tag { get => tag; }
    public bool Completed { get => completed; }

    // Méthode pour remplir une tâche depuis la console
    public static CustomTask RemplirTask()
    {
        Console.WriteLine("Entrez le titre de la tâche :");
        string title = Console.ReadLine();

        Console.WriteLine("Entrez la description de la tâche :");
        string description = Console.ReadLine();

        Console.WriteLine("Entrez la priorité de la tâche (un entier) :");
        int priority = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Entrez l'étiquette de la tâche :");
        string tag = Console.ReadLine();

        // Par défaut, une nouvelle tâche n'est pas encore complétée
        bool completed = false;

        // Crée et retourne une nouvelle instance de CustomTask avec les données fournies
        return new CustomTask(title, description, priority, tag, completed);
    }

    public override string ToString()
    {
        return $"Titre : {title}, Description : {description}, Priorité : {priority}, Étiquette : {tag}, Complétée : {completed}";
    }
}
