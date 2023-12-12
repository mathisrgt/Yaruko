class Program
{
    static void Main(string[] args)
    {
        CustomTask nouvelleTache = CustomTask.RemplirTask();
        Console.WriteLine("Tâche créée :");
        Console.WriteLine(nouvelleTache.ToString());
        Console.ReadKey();
    }
}