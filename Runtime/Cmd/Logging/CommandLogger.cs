namespace JasonStorey
{
    public interface CommandLogger
    {
        bool PrintExecutions { get; set; }
        bool PrintUndos { get; set; }

        void Performing(string name);
        void Undoing(string name);
    }
}