using Command.Main;
public class HealCommand : UnitCommand
{
    public HealCommand(CommandData commandData)
    {
        this.commandData = commandData;
    }
    public override void Execute()
    {
        GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.Heal).PerformAction(actorUnit, targetUnit, WillHitTarget());
    }

    public override bool WillHitTarget() => true;

}