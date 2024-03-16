using Command.Main;
public class AttackCommand : UnitCommand
{
    public AttackCommand(CommandData commandData)
    {
        this.commandData = commandData;
    }
    public override void Execute()
    {
        GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.Attack).PerformAction(actorUnit, targetUnit, WillHitTarget());
    }

    public override bool WillHitTarget() => true;

}
