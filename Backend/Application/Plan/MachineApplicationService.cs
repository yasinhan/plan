using plan.Backend.Application.Model;
using plan.Backend.Plan.Interface.model;

namespace plan.Backend.Application;

public interface IMachineApplicationService
{
    PageData<MachineDto> PageQueryMachine();
}