
using Command.Commands;
using Command.Main;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ReplayService 
{
    private Stack<ICommand> replayStack = new Stack<ICommand>();

    public ReplayState replayState { get; private set; }

    public ReplayService() => SetReplayState(ReplayState.DEACTIVE);

    public void SetReplayState(ReplayState state)
    {
        replayState = state;
    }

    public void SetCommandStack(Stack<ICommand> replayCommands)
    {
        replayStack = new Stack<ICommand>(replayCommands);
    }

    public async void ExecuteNext()
    {
        await Task.Delay(1000);
        if (replayStack.Count > 0 )
        {
            GameService.Instance.ProcessUnitCommand(replayStack.Pop());
        }
        
    }
}
