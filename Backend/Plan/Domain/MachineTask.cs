namespace plan.Backend.plan;

public class MachineTask
{
    #region Fields

    public readonly string MachineCode;

    public readonly Style Style;

    public readonly int PlannedQuantity;

    public readonly DateTime PlanStartTime, PlanEndTime;

    private long _seconds;

    private List<TaskSegment> _segments;

    #endregion

    #region Methods

    public void SplitSegment(long segmentId, int remainQuantity, DateTime curPlanEndTime, DateTime nextPlanStartTime)
    {
        var segment = _segments.Find(it => it.SegmentId == segmentId) ?? throw new ArgumentException("任务不存在，无法切分");

        var newSegment = segment.Split(remainQuantity, curPlanEndTime, nextPlanStartTime);
        
    }

    public int EarlierThan(MachineTask other)
    {
        return PlanEndTime.CompareTo(other.PlanEndTime);
    }

    #endregion
    
}

public class TaskSegment
{
    #region Fields
    
    public readonly long MachineTaskId;

    public readonly long SegmentId;
    
    public readonly int PlannedQuantity;

    private int _index;
    
    private long _seconds;
    
    #endregion

    #region Methods

    public int Index => _index;

    public TaskSegment(long machineTaskId, long segmentId, int plannedQuantity, int index)
    {
        MachineTaskId = machineTaskId;
        SegmentId = segmentId;
        PlannedQuantity = plannedQuantity;
        _index = index;
    }

    public TaskSegment Split(int remainQuantity, DateTime curPlanEndTime, DateTime nextPlanStartTime)
    {
        ModifySelf(remainQuantity, curPlanEndTime);
        return CreateNewSegment(remainQuantity, nextPlanStartTime); 
    }

    public void Backward()
    {
        _index++;
    }

    private void ModifySelf(int remainQuantity, DateTime curPlanEndTime)
    {
        
    }

    private TaskSegment CreateNewSegment(int remainQuantity, DateTime nextPlanStartTime)
    {
        
    }

    #endregion
    
}