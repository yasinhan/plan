namespace plan.Backend.plan;

public class ProductOrder
{
    public readonly Style Style;

    public readonly int quantity;

    private List<MachineTask> _assignedTasks;
}

public class Style
{
    #region Fields

    public readonly int NeedBoreDiameter, NeedStitches, PredictTime;
    
    #endregion

}