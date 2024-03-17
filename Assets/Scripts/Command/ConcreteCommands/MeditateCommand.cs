using Command.Main;

namespace Command.Commands
{
    public class MeditateCommand : UnitCommand
    {
        private bool willHitTarget;
        public int healthToIncrease;
        public MeditateCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override void Undo()
        {
            if (willHitTarget)
            {
                if (!targetUnit.IsAlive()) targetUnit.Revive();

                targetUnit.CurrentMaxHealth -= healthToIncrease;
                targetUnit.TakeDamage(healthToIncrease);
            }
            actorUnit.Owner.ResetCurrentActiveUnit();

        }
        public override bool WillHitTarget() => true;
    }
}
