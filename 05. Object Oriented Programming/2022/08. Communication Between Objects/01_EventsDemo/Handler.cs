﻿/// <summary>
/// Обработчик
/// </summary>
public class Handler
{
    public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
    {
        Console.WriteLine("Dispatcher's name changed to " + args.Name);
    }
}
