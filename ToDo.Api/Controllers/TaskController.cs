using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Entities;

namespace ToDo.Api.Controllers
{
    public class TaskController : Controller
    {
        [HttpGet]
        public IEnumerable<Domain.Entities.TaskDomain> Get()
        {
            return Enumerable.Range(1, 5)
                .Select(index => TaskDomain.New(name: "Test", description: "teste", expireAt: DateTime.UtcNow.AddDays(2)))
            .ToArray();
        }
    }
}
