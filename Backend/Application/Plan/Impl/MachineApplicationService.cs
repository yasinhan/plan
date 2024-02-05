using plan.Backend.Application.Model;
using plan.Backend.plan;
using plan.Backend.Plan.Interface.model;
using plan.Backend.Plan.Interface.model.Command;

namespace plan.Backend.Application.Impl;

public class MachineApplicationService : IMachineApplicationService
{
    private MachineRepository _machineRepository;
    
    public PageData<MachineDto> PageQueryMachine()
    {
        
        throw new System.NotImplementedException();
    }

    public void BatchImportMachine(ImportMachineCommand command)
    {
        throw new System.NotImplementedException();
    }
}