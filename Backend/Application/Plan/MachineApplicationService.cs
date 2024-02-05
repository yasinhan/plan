using plan.Backend.Application.Model;
using plan.Backend.Plan.Interface.model;
using plan.Backend.Plan.Interface.model.Command;

namespace plan.Backend.Application;

public interface IMachineApplicationService
{
    PageData<MachineDto> PageQueryMachine();

    void BatchImportMachine(ImportMachineCommand command);
}