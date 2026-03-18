namespace CW1;

public class ToDoTask
{
    private String name;
    private String description;
    private int priority;

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Description
    {
        get => description;
        set => description = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Priority
    {
        get => priority;
        set => priority = value;
    }

    public ToDoTask(string name, string description, int priority)
    {
        this.name = name;
        this.description = description;
        this.priority = priority;
    }

    public ToDoTask(string name, int priority)
    {
        this.name = name;
        this.priority = priority;
        this.description = "";
    }

    public ToDoTask(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public ToDoTask(string name)
    {
        this.name = name;
        this.priority = 0;
        this.description = "";
    }
}