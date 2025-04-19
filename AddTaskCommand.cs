using System;

namespace TaskManager
{
    class AddTaskCommand : ICommand
    {
        private readonly TaskManager _taskManager;
        private readonly string _task;

        public AddTaskCommand(TaskManager taskManager, string task)
        {
            _taskManager = taskManager;
            _task = task;
        }

        public void Execute()
        {
            _taskManager.AddTask(_task);
        }

        public void Undo()
        {
            _taskManager.RemoveLastTask();
        }
    }
}
