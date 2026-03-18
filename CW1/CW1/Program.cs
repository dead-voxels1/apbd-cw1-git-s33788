

public class MainClass
{
    static private List<string> toDo = new List<string>();

    public static void Main(String[] args)
    {
        
    }

    public static void AddTask(string task)
    {
        toDo.Add(task);
    }

    public static void CompleteTask(string task)
    {
        if (toDo.Contains(task))
        {
            toDo.Remove(task);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Task ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\""+task +"\"");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" does not exist");
            Console.ResetColor();
        }
    }
}