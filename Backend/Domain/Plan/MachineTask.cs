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

    public List<TaskSegment> Segments => _segments;

    #endregion

    #region Methods

    public void SplitSegment(long segmentId, int remainQuantity, DateTime curPlanEndTime, DateTime nextPlanStartTime)
    {
        var segment = _segments.Find(it => it.SegmentId == segmentId) ?? throw new ArgumentException("任务不存在，无法切分");

        var beforeEndTime = segment.PlanEndTime;
        var newSegment = segment.SplitIntoTwoSeg(remainQuantity, curPlanEndTime, nextPlanStartTime);

        var postponeSeconds = (long) (newSegment.PlanEndTime - beforeEndTime).TotalSeconds;
        for (int i = 0; i < _segments.Count; i++)
        {
            if (i > segment.Index)
            {
                _segments[i].ReAssign(postponeSeconds);
            }
        }
        _segments.Add(newSegment);
        _segments.Sort((seg1, seg2) => seg1.Index - seg2.Index);

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

    public int Index { get; private set; }

    private DateTime _planStartTime;

    private DateTime _planEndTime;
    
    private long _seconds;

    private Status _status = Status.INIT;
    
    public int StatusCode => (int)_status;
    
    #endregion

    #region Methods
    
    public DateTime PlanEndTime => _planEndTime;

    public TaskSegment SplitIntoTwoSeg(int remainQuantity, DateTime curPlanEndTime, DateTime nextPlanStartTime)
    {
        ModifySelf(remainQuantity, curPlanEndTime);
        return CreateNewSegment(remainQuantity, nextPlanStartTime); 
    }

    public void ReAssign(long postponeSeconds)
    {
        Postpone(postponeSeconds);
        Backward();
    }

    private void Postpone(long postponeSeconds)
    {
        _planStartTime = _planStartTime.AddSeconds(postponeSeconds);
        _planEndTime = _planEndTime.AddSeconds(postponeSeconds);
    }

    private void Backward()
    {
        Index += 1;
    }

    private void ModifySelf(int remainQuantity, DateTime curPlanEndTime)
    {
        
    }

    private TaskSegment CreateNewSegment(int remainQuantity, DateTime nextPlanStartTime)
    {
        return new TaskSegment();
    }

    #endregion

    #region InnerClass

    private enum Status
    {
        INIT = 0,
        EXECUTING = 1,
        INTERRUPTED = 2,
        FINISHED = 100
    } 

    #endregion
}