namespace plan.Backend.Plan.Interface.model;

public record MachineDto(long MachineId, string MachineCode, int BoreDiameter, List<TaskSegmentDto> Tasks);

public record TaskSegmentDto();