using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker 
{
    Stack<ICommand> commandRegistry;

    public CommandInvoker()
    {
        commandRegistry = new Stack<ICommand>();
    }

    public void ProcessCommand(ICommand command)
    {
        RegisterCommand(command);
        ExecuteCommand(command);
    }

    private void RegisterCommand(ICommand command) => commandRegistry.Push(command);
    private void ExecuteCommand(ICommand command) => command.Execute();
}
