using Command.Main;
using UnityEngine;

namespace Command.Commands
{
    public class CleanseCommand : UnitCommand
    {
        private bool willHitTarget;
        public int powerBeforeCleansing;
        private const float hitChance = 0.2f;

        public CleanseCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Cleanse).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override void Undo()
        {
            if (willHitTarget)
            {
                if (!targetUnit.IsAlive()) targetUnit.Revive();

                targetUnit.CurrentPower = powerBeforeCleansing;
            }
            actorUnit.Owner.ResetCurrentActiveUnit();
        }
        public override bool WillHitTarget() => Random.Range(0f, 1f) < hitChance;
    }
}
