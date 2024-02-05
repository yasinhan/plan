using System.Collections.Generic;

namespace plan.Backend.Plan.Interface.model.Command;

public record ImportMachineCommand(List<MachineModel> MachineList);

public record MachineModel(string code, int BoreDiameter, int? NeedleSpacing, int? Stitches);