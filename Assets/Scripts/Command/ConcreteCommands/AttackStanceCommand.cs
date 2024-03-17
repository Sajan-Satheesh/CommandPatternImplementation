using Command.Main;

namespace Command.Commands
{
    public class AttackStanceCommand : UnitCommand
    {
        private bool willHitTarget;
        public float addedPower;
        public AttackStanceCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.AttackStance).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override void Undo()
        {
            if (willHitTarget)
            {
                if (!targetUnit.IsAlive()) targetUnit.Revive();
                targetUnit.CurrentPower -= (int)addedPower;
            }
            actorUnit.Owner.ResetCurrentActiveUnit();

        }
        public override bool WillHitTarget() => true;
    }
}