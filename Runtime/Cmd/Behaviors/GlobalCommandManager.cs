using System.Collections.Generic;
using UnityEngine;

namespace JasonStorey
{
    public class GlobalCommandManager : MonoBehaviour
    {
        private void Awake()
        {
            _stacks = new Dictionary<string, CommandStack>();
        }

        public void Undo(string stack)
        {
            if (!_stacks.ContainsKey(stack)) return;
            var undoStack = _stacks[stack];

            if (!undoStack.CanUndo) return;
            
            var lastCommand = undoStack.Peek();
            Logger.Undoing(lastCommand.ToString());
            undoStack.Undo();
         
        }

        public void Undo() => Undo(DEFAULT_COMMAND_STACK);
        
        public void Execute(ICommand cmd) => Execute(DEFAULT_COMMAND_STACK, cmd);

        public void Execute(string stack, ICommand cmd)
        {
            if (!_stacks.ContainsKey(stack)) _stacks[stack] = new CommandStack();
            _stacks[stack].Execute(cmd);
            Logger.Performing(cmd.ToString());
        }

        private Dictionary<string, CommandStack> _stacks;
        private const string DEFAULT_COMMAND_STACK = "Default";

        public void EnableCommandLogging()
        {
            Logger.PrintExecutions = Logger.PrintUndos = true;
        }

        public void DisableCommandLogging()
        {
            Logger.PrintExecutions = Logger.PrintUndos = false;
        }



        protected CommandLogger Logger => _logger ?? (_logger = CreateDefaultCommandLogger());
        private CommandLogger CreateDefaultCommandLogger() => new UnityConsoleCommandLogger();

        private CommandLogger _logger;
    }
}