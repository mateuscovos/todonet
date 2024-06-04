using ToDo.Application.UseCases.CreateTask;

namespace ToDo.Application.UseCases.Tasks
{
    public interface ICreateTaskUseCase
    {
        Task<TaskResponse> Execute(TaskRequest request);
    }
}
