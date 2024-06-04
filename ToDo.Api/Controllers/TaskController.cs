using Microsoft.AspNetCore.Mvc;

namespace ToDo.Api.Controllers
{
    public class TaskController : Controller
    {
        [HttpGet]
        public IEnumerable<Domain.Entities.Task> Get()
        {
            return Enumerable.Range(1, 5)
                .Select(index => Domain.Entities.Task.New(name: "Test", description: "teste", expireAt: DateTime.UtcNow.AddDays(2)))
            .ToArray();
        }
    }
}
