using System;

public interface IEventHandler<in TEvent>:IEventHandler where TEvent:Event
{
	
}
public interface IEventHandler
{

}
