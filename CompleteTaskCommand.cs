using System;
using System.Collections.Generic;

namespace TaskManager
{
    class CompleteTaskCommand : ICommand
    {
        private readonly TaskManager _taskManager;
        private string? _completedTask;

        public CompleteTaskCommand(TaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        public void Execute()
        {
            _completedTask = _taskManager.CompleteTask();
        }

        public void Undo()
        {
            if (_completedTask != "")
            {
                _taskManager.InsertTaskAtFirst(_completedTask);
            }
        }
    }
}
