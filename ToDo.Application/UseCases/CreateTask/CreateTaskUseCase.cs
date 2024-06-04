using ToDo.Application.UseCases.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Application.UseCases.CreateTask
{
    public class CreateTaskUseCase : ICreateTaskUseCase
    {


        public async Task<TaskResponse> Execute(TaskRequest request)
        {
            var task = TaskDomain.New(request.Name!, request.Description!, request.ExpireAt.GetValueOrDefault(DateTime.MinValue));
            
            if (!task.IsValid())
            {
                throw new ArgumentException("Task request was invalid");
            }

            //save

            return new TaskResponse("", "", "", DateTime.UtcNow);
        }
    }
}
