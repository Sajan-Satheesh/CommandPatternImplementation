using Command.Main;
public class CleanseCommand : UnitCommand
{
    public CleanseCommand(CommandData commandData)
    {
        this.commandData = commandData;
    }
    public override void Execute()
    {
        GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.Cleanse).PerformAction(actorUnit, targetUnit, WillHitTarget());
    }

    public override bool WillHitTarget() => true;

}
