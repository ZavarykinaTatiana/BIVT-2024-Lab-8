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
        public Blue_1(string input) : base(input) { _output = null; }
        
        // методы
        public override void Review()
        {
            if (Input == null) return;
            var words = Input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] lines = new string[0];
            var currentLine = "";
            int linesCount = 0;
            foreach (var word in words)
            {
                if (currentLine.Length == 0) currentLine = word;
                else if (currentLine.Length + word.Length + 1 <= 50) { currentLine += " " + word; }
                else {
                    if (linesCount >= lines.Length) { Array.Resize(ref lines, lines.Length + 1); }
                    lines[linesCount++] = currentLine;
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
            if (_output == null) return null;
            return string.Join(Environment.NewLine, _output);
        }
    }
}