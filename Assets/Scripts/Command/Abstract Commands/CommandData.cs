public struct CommandData 
{
    public int ActorUnitID;
    public int ActorPlayerID;
    public int TargetUnitID;
    public int TargetPlayerID;

    public CommandData(int actorUnitId,int actorPlayerId,  int targetUnitID, int targetPlayerID)
    {
        ActorUnitID = actorUnitId;
        ActorPlayerID = actorPlayerId;
        TargetUnitID = targetUnitID;
        TargetPlayerID = targetPlayerID;
    }
}
