using System.Collections.Generic;

namespace JasonStorey
{
    public class CommandStack
    {
        public CommandStack() => _undoStack = new Stack<ICommand>();

        public void Execute(ICommand cmd)
        {
            cmd.Execute();
            if(cmd.CanUndo)
                _undoStack.Push(cmd);
        }

        public bool CanUndo => _undoStack.Count > 0;
        public int UndoCount => _undoStack.Count;
        
        public void Undo()
        {
            if(CanUndo) _undoStack.Pop().Undo();
        }


        private readonly Stack<ICommand> _undoStack;

        public ICommand Peek() => _undoStack.Peek();
    }
}