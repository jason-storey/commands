using UnityEngine;

namespace JasonStorey
{
    public class UnityConsoleCommandLogger : CommandLogger
    {
        public bool PrintExecutions { get; set; } = false;
        public bool PrintUndos { get; set; } = true;
        
        public void Performing(string name)
        {
            if(PrintExecutions)
                Print(WritePerformCommand(name));
        }

        public void Undoing(string name)
        {
            if(PrintUndos)
                Print(WriteUndoCommand(name));
        }

        void Print(string message) => Debug.Log(message);
        
        string WritePerformCommand(string name) => $"Execute: <color=blue>[{name}]</color>";
        
        string WriteUndoCommand(string name) => $"Undo:    <color=yellow>[{name}]</color>";

    }
}