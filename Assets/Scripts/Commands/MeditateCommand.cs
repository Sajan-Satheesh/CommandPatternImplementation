using Command.Main;
public class MeditateCommand : UnitCommand
{
    public MeditateCommand(CommandData commandData)
    {
        this.commandData = commandData;
    }
    public override void Execute()
    {
        GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.Meditate).PerformAction(actorUnit, targetUnit, WillHitTarget());
    }

    public override bool WillHitTarget() => true;

}
