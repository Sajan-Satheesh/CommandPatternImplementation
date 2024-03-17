using Command.Main;

namespace Command.Commands
{
    public class ThirdEyeCommand : UnitCommand
    {
        private bool willHitTarget;
        int healthconverted;

        public ThirdEyeCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
            healthconverted = (int)(targetUnit.CurrentHealth * 0.25f);
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.ThirdEye).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override void Undo()
        {
            if (willHitTarget)
            {
                targetUnit.RestoreHealth(healthconverted);
                targetUnit.CurrentPower -= healthconverted;
                actorUnit.Owner.ResetCurrentActiveUnit();
            }
        }
        public override bool WillHitTarget() => true;
    } 
}
