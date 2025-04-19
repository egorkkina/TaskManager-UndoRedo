using System;
using System.Collections.Generic;

namespace TaskManager
{
    class TaskManager
    {
        private Queue<string> _tasks = new Queue<string>();

        public void AddTask(string task)
        {
            _tasks.Enqueue(task);
        }

        public void InsertTaskAtFirst(string task)
        {
            var helperQueue = new Queue<string>();
            helperQueue.Enqueue(task);
            while (helperQueue.Count > 0) _tasks.Enqueue(helperQueue.Dequeue());
        }

        public string? CompleteTask()
        {
            return _tasks.Count > 0 ? _tasks.Dequeue() : null;
        }

        public void RemoveLastTask()
        {
            if (_tasks.Count == 0) return;

            var sideQueue = new Queue<string>();
            while (_tasks.Count > 1) sideQueue.Enqueue(_tasks.Dequeue());
            _tasks = sideQueue;

        }

        public void ShowAllTasks()
        {
            if (_tasks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("no tasks at the moment");
                return;
            }

            foreach (var task in _tasks)
            {
                Console.WriteLine($"task: | {task} |");
            }
        }

    }
}
