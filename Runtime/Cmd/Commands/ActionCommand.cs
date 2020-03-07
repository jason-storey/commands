using System;

namespace JasonStorey
{
    public class ActionCommand : ICommand
    {
        private readonly string _name;
        private readonly Action _action;
        private readonly Action _undo;

        public ActionCommand(string name,Action action,Action undo = null)
        {
            _name = name;
            _action = action;
            _undo = undo;
            CanUndo = _undo != null;
        }

        public ActionCommand(Action action,Action undo = null)
        {
            _name = action.Method.Name;
            _action = action;
            _undo = undo;
            CanUndo = _undo != null;
        }
        
        public void Execute() => _action.Invoke();

        public bool CanUndo { get; }
        public void Undo() => _undo.Invoke();

        public override string ToString() => _name;
    }
}