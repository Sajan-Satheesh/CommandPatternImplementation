public abstract class UnitCommand : ICommand
{
    public int ActorUnitID;
    public int ActorPlayerID;
    public int TargetUnitID;
    public int TargetPlayerID;

    void ICommand.Execute()
    {
        throw new System.NotImplementedException();
    }

}
