namespace BuggyBackend.Models
{
    public class TestOperator
    {
        public string Name { get; set; } = string.Empty;
        public DateOnly LastActivityDate { get; set; }
        public int Age { get; internal set; }
    }
}
