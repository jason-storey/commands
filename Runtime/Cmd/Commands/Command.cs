using System;
using UnityEngine;

namespace JasonStorey
{
    public static class Command
    {

        public static void Execute(ICommand cmd) => GetCommandManager().Execute(cmd);

        public static void Execute(string stack, ICommand cmd) => GetCommandManager().Execute(stack, cmd);

        public static void Undo(string stack) => GetCommandManager().Undo(stack);
        
        public static void Undo() => GetCommandManager().Undo();

        public static void Execute(Action action) => Execute(new ActionCommand(action));
        public static void Execute(Action action,Action undo) => Execute(new ActionCommand(action,undo));
        
        public static void Execute(Action action,Action undo,string stackToUse) => Execute(stackToUse,new ActionCommand(action,undo));

        public static void StartLoggingCommands() => GetCommandManager().EnableCommandLogging();
        public static void StopLoggingCommands() => GetCommandManager().DisableCommandLogging();
        static GlobalCommandManager GetCommandManager()
        {
            if (_gcm == null)
            {
                var g = new GameObject("[Global Command Manager]");
                _gcm = g.AddComponent<GlobalCommandManager>();
            }
            return _gcm;
        }

        private static GlobalCommandManager _gcm;
    }
}