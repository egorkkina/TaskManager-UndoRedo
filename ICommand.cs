namespace TaskManager
{
    interface ICommand
    {
        void Execute(); 
        void Undo(); 
    }
}
