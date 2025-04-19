using System;

namespace TaskManager
{
    class App
    {
        private readonly TaskManager _taskManager = new TaskManager();
        private readonly CommandHistory _history = new CommandHistory();

        public void Run()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n╔════════════════════════════════╗");
                Console.WriteLine("║                                ║");
                Console.WriteLine("║        МЕНЮ ЗАДАЧ              ║");
                Console.WriteLine("║                                ║");
                Console.WriteLine("╠════════════════════════════════╣");
                Console.ResetColor();
                Console.WriteLine("║ 1. Добавить задачу             ║");
                Console.WriteLine("║ 2. Выполнить задачу            ║");
                Console.WriteLine("║ 3. Отменить (Undo)             ║");
                Console.WriteLine("║ 4. Повторить (Redo)            ║");
                Console.WriteLine("║ 5. Показать задачи             ║");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("║ 6. Выход                       ║");
                Console.ResetColor();
                Console.WriteLine("║                                ║");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚════════════════════════════════╝");
                Console.ResetColor();

                Console.Write("\n ? Ваш выбор: ");

                var input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Введите задачу: ");
                        string task = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(task)) 
                            _history.ExecuteCommand(new AddTaskCommand(_taskManager, task));
                        else 
                            Console.WriteLine("Задача не может быть пустой");
                        break;

                    case "2":
                        _history.ExecuteCommand(new CompleteTaskCommand(_taskManager));
                        break;

                    case "3":
                        _history.Undo();
                        break;

                    case "4":
                        _history.Redo();
                        break;

                    case "5":
                        _taskManager.ShowAllTasks();
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
        }
    }
}
