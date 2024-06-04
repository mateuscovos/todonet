﻿namespace ToDo.Application.UseCases.CreateTask
{
    public class TaskResponse
    {
        public TaskResponse(string id, string name, string description, DateTime expireAt) 
        {
            Id = id;
            Name = name;
            Description = description;
            ExpireAt = expireAt;
        }

        public string? Id { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime? ExpireAt { get; private set; }
    }
}
