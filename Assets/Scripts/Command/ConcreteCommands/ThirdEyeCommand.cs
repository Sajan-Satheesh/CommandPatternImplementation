using Command.Main;

namespace Command.Commands
{
    public class ThirdEyeCommand : UnitCommand
    {
        private bool willHitTarget;
        public int healthconverted;

        public ThirdEyeCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.ThirdEye).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override void Undo()
        {
            if (willHitTarget)
            {
                if (!targetUnit.IsAlive()) targetUnit.Revive();

                targetUnit.RestoreHealth(healthconverted);
                targetUnit.CurrentPower -= healthconverted;
            }
            actorUnit.Owner.ResetCurrentActiveUnit();
        }
        public override bool WillHitTarget() => true;
    } 
}
