using System;
using System.Collections.Generic;

namespace plan.Backend.plan;

public class Machine
{
    #region Fields

    readonly string Code;

    readonly int BoreDiameter;

    readonly int? NeedleSpacing, Stitches;
    
    private List<MachineTask>? AssignedTasks;

    private bool TaskSorted = false;
    
    #endregion

    #region Methods

    public void AttachTasks(List<MachineTask>? tasks)
    {
        if (null == tasks)
        {
            return;
        }
        tasks.Sort((task1, task2) => task1.EarlierThan(task2));
        AssignedTasks = tasks;
        TaskSorted = true;
    }

    public (int, decimal) CalculateAvailableTime(DateTime deadline)
    {
        var totalSeconds = (int)(deadline - DateTime.Now).TotalSeconds;
        if (null == AssignedTasks || AssignedTasks.Count == 0) 
        {
            return (totalSeconds, decimal.One);
        }

        if (!TaskSorted)
        {
            AssignedTasks.Sort((task1, task2) => task1.PlanEndTime.CompareTo(task2.PlanEndTime));
        }

        var lastFinishedTime = AssignedTasks[^1].PlanEndTime;
        if (lastFinishedTime.CompareTo(deadline) >= 0)
        {
            return (0, decimal.Zero);
        }

        var remainSeconds = (int)(deadline - lastFinishedTime).TotalSeconds;
        return (remainSeconds, Math.Round((decimal)remainSeconds / totalSeconds, 2));
    }

    public bool CanProduce(Style style)
    {
        return BoreDiameter == style.NeedBoreDiameter && Stitches == style.NeedStitches;
    }

    public Machine(string code, int boreDiameter, int? needleSpacing, int? stitches)
    {
        if (null == needleSpacing && null == stitches)
        {
            throw new ArgumentException("针距、针数不可都为空");
        }
        Code = code;
        BoreDiameter = boreDiameter;
        
        if (null != needleSpacing && null != stitches)
        {
            NeedleSpacing = needleSpacing;
            Stitches = stitches;
        }
        else if (null == needleSpacing)
        {
            NeedleSpacing = (int)Math.Round(BoreDiameter * float.Pi / stitches.Value);
        }
        else
        {
            Stitches = (int)Math.Round(BoreDiameter * float.Pi / needleSpacing.Value);
        }
        
    }
    
    #endregion
}