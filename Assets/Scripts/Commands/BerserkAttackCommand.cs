using Command.Main;
public class BerserkAttackCommand : UnitCommand
{
    public BerserkAttackCommand(CommandData commandData)
    {
        this.commandData = commandData;
    }
    public override void Execute()
    {
        GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, WillHitTarget());
    }

    public override bool WillHitTarget() => true;

}
