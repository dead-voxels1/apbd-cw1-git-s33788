

using CW1;

public class MainClass
{
    static private List<ToDoTask> toDo = new List<ToDoTask>();

    public static void Main(String[] args)
    {
        Console.WriteLine("-TODO-");
        Console.WriteLine("Dostępne komendy: add, list, next, done, exit");

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n> ");
            string command = Console.ReadLine()?.ToLower() ?? "";

            switch (command)
            {
                case "add":
                    Console.Write("Nazwa zadania: ");
                    string name = Console.ReadLine() ?? "";
                    Console.Write("Opis: ");
                    string desc = Console.ReadLine() ?? "";
                    Console.Write("Priorytet (liczba): ");
                    if (int.TryParse(Console.ReadLine(), out int priority))
                    {
                        AddTask(new ToDoTask(name, desc, priority));
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Błąd: Priorytet musi być liczbą!");
                        Console.ResetColor();
                    }
                    break;

                case "list":
                    PrintToDoList();
                    break;

                case "next":
                    if (toDo.Count > 0) PrintNextTask();
                    else Console.WriteLine("Lista jest pusta.");
                    break;

                case "done":
                    CompleteNextTask();
                    break;

                case "exit":
                    Console.WriteLine("Zamykanie... Do zobaczenia!");
                    return;

                default:
                    Console.WriteLine("Nieznana komenda. Spróbuj: add, list, next, done, exit.");
                    break;
            }
        }
    }

    public static void AddTask(ToDoTask task)
    {
        if (toDo.All(t => t.Name != task.Name))
        {
            toDo.Add(task);
            int index = toDo.Count-1;
            while (index != 0 && toDo[index].Priority > toDo[index - 1].Priority)
            {
                (toDo[index-1], toDo[index]) = (toDo[index], toDo[index-1]);
                index--;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Task ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\""+task.Name +"\"");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" already exists");
            Console.ResetColor();
        }
    }

    public static void CompleteTask(string taskName)
    {
        if (toDo.All(t => t.Name != taskName))
        {
            toDo.RemoveAll(t => t.Name == taskName);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Task " + taskName + " completed");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Task ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\""+taskName +"\"");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" does not exist");
            Console.ResetColor();
        }
    }

    public static void PrintToDoList()
    {
        int index = 1;
        foreach (ToDoTask t in toDo)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(index++ + ". ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(t.Name);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(" " + t.Description);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" " +  t.Priority);
            Console.ResetColor();
        }
    }

    public static void PrintNextTask()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Next Task -> ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(toDo[0].Name);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write(" " + toDo[0].Description);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" " +  toDo[0].Priority);
        Console.ResetColor();
    }

    public static void CompleteNextTask()
    {
        if (toDo.Count > 0)
        {
            string taskName = toDo[0].Name;
            toDo.RemoveAt(0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Task " + taskName + " completed");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Lista pusta!");
            Console.ResetColor();
        }
    }

    public static double CalculateAverage(int[] values)
    {
        if (values.Length == 0)
        {
            return 0.0;
        }
        else return (double)values.Sum() / values.Length;
    }

    public static int CalculateMax(int[] values)
    {
        return values.Max();
    }
}