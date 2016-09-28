using MvvmCross.Core.ViewModels;
using MyTasks.Core.Models;
using MyTasks.Core.Services;

namespace MyTasks.Core.ViewModels
{
    public class TaskDetailsViewModel : MvxViewModel
    {
        private readonly ITaskService _taskService;
        public TaskDetailsViewModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        #region navigation parameters
        public void Init(Parameters parameters)
        {
            TaskId = parameters.TaskId;

        }
        public class Parameters
        {
            public int TaskId { get; set; }
        }
        public int TaskId { get; set; }
        #endregion

        private TaskModel _taskModel;

        public TaskModel TaskModel
        {
            get { return _taskModel; }
            set { SetProperty(ref _taskModel, value); }
        }

        public override void Start()
        {
            base.Start();
            if (TaskId == 0)
            {
                return;
            }
            TaskModel = _taskService.GetTaskDetails(TaskId);
        }

        public IMvxCommand UpdateCommand => new MvxCommand(Update);
        private void Update()
        {
            _taskService.SaveTasks();
            Close(this);
        }

        public IMvxCommand MarkAsDoneCommand => new MvxCommand(MarkAsDone);
        private void MarkAsDone()
        {
            _taskService.CompleteTask(TaskId);
            Close(this);
        }


    }
}
