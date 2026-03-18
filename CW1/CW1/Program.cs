

using CW1;

public class MainClass
{
    static private List<ToDoTask> toDo = new List<ToDoTask>();

    public static void Main(String[] args)
    {
        AddTask(new ToDoTask("gym"));
        PrintNextTask();
        CompleteNextTask();
        CompleteNextTask();
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
}