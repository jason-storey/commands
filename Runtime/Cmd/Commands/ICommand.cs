namespace JasonStorey 
{
    public interface ICommand
    {
        void Execute();
        
        bool CanUndo { get; }

        void Undo();
    }

    public interface ICommand<in T>
    {
        void Execute(T item);
        
        bool CanUndo { get; }

        void Undo(T item);
    }
}