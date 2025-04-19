using System;
using System.Linq;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        // приватные поля
        private string[] _output;

        // публичные св-ва
        public string[] Output => _output;

        // конструктор
        public Blue_1(string input) : base(input) { _output = new string[0]; }
        
        // методы
        public override void Review()
        {
            var words = Input.Split(' ');
            string[] lines = new string[0];
            var currentLine = "";
            int linesCount = 0;
            foreach (var word in words)
            {
                if (currentLine.Length + word.Length <= 49) { currentLine += (currentLine == "" ? "" : " ") + word; }
                else {
                    if (currentLine != "")
                    {
                        if (linesCount >= lines.Length)
                        {
                            Array.Resize(ref lines, lines.Length + 1);
                        }
                        lines[linesCount++] = currentLine;
                    }
                    currentLine = word;
                }
            }
            if (currentLine != "")
            {
                if (linesCount >= lines.Length)
                {
                    Array.Resize(ref lines, lines.Length + 1);
                }
                lines[linesCount++] = currentLine;
            }
            
            Array.Resize(ref lines, linesCount);
            _output = lines;
        }
        public override string ToString()
        {
            return string.Join("\n", _output);
        }
    }
}