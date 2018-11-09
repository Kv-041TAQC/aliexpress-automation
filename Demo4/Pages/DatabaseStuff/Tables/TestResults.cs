namespace Pages.DatabaseStuff
{
    public class TestResults
    {
        public int Id { get; set; }
        public string TestRunnigTime { get; set; }
        public string TestName { get; set; }
        public string TestResult { get; set; } //Pased Failed
        public string TestErrorMessage { get; set; } //Optional
    }
}
