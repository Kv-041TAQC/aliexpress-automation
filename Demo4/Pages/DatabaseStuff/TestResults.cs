using System;
using System.Collections.Generic;
using System.Text;

namespace Pages.DatabaseStuff
{
    public class TestResults
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public bool IsRunned { get; set; }
        public string Name { get; set; }
        public string Result { get; set; } //Pased Failed
        public string ErrorMessage { get; set; } //Optional
    }
}
