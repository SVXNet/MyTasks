using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.Platform.Platform;
using MvvmCross.Plugins.File;
using MyTasks.Core.Models;

namespace MyTasks.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMvxFileStore _fileStore;
        private readonly IMvxJsonConverter _jsonConverter;
        private List<TaskModel> _tasks;
        const string JsonDataFilePath = "encryptedtaskdata.json";

        public TaskService(IMvxFileStore fileStore, IMvxJsonConverter jsonConverter)
        {
            _fileStore = fileStore;
            _jsonConverter = jsonConverter;
            LoadTasksFromFile();
        }

        public TaskModel AddTask(string title, DateTime? completeBy = null)
        {
            var nextId = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;

            //Add the file to the json list and save the json data file
            var newTask = new TaskModel
            {
                Id = nextId,
                Title = title,
                CompleteBy = completeBy ?? DateTime.Now.AddDays(7),
                AddedOn = DateTime.UtcNow
            };
            _tasks.Add(newTask);

            SaveTasksToFile();

            return newTask;
        }

        public List<TaskModel> GetTasks()
        {
            var tasks = _tasks
                .OrderBy(t => t.CompletedOn)
                .ThenByDescending(t => t.CompleteBy)
                .ThenByDescending(t => t.AddedOn)
				.ToList();
				
			return tasks;
        }

        public TaskModel GetTaskDetails(int taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            return task;
        }

        public void SaveTasks()
        {
            SaveTasksToFile();
        }

        public bool CompleteTask(int taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                return false;
            }
            task.Completed = true;
            task.CompletedOn = DateTime.UtcNow;
            SaveTasksToFile();

            return true;
        }

        public bool DeleteTask(int taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                return false;
            }
            _tasks.Remove(task);
            SaveTasksToFile();

            return true;
        }

        /// <summary>
        /// Load tasks data from json file
        /// </summary>
        private void LoadTasksFromFile()
        {
            string contents;
            _fileStore.TryReadTextFile(JsonDataFilePath, out contents);
            if (string.IsNullOrWhiteSpace(contents))
            {
                _tasks = new List<TaskModel>();
                return;
            }
            var decrypted = Encryption.DecryptString(contents, "password", "saltandpepper");
            _tasks = _jsonConverter.DeserializeObject<List<TaskModel>>(decrypted);
        }

        private void SaveTasksToFile()
        {
            var contents = _jsonConverter.SerializeObject(_tasks);
            var encrypted = Encryption.EncryptString(contents, "password", "saltandpepper");
            _fileStore.WriteFile(JsonDataFilePath, encrypted);
        }


    }
}
