using System;
using System.Collections.Generic;
using MyTasks.Core.Models;

namespace MyTasks.Core.Services
{
    public interface ITaskService
    {
        TaskModel AddTask(string title, DateTime? completeBy = null);

        List<TaskModel> GetTasks();

        TaskModel GetTaskDetails(int taskId);

        void SaveTasks();

        bool CompleteTask(int taskId);

        bool DeleteTask(int taskId);
    }
}