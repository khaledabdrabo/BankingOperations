using System;

public abstract class Command:Message
{
    public DateTime TimeStap { get;  protected set; }
    public  Command()
	{
        this.TimeStap = DateTime.Now;
	}
}
