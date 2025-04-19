using System;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        // приватные поля
        private int _output;

        // публичные св-ва
        public int Output => _output;

        // конструктор
        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }

        // методы
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = 0;
                return;
            }

            int current = 0;
            while (current < Input.Length)
            {
                // Пропускаем не-цифры
                while (current < Input.Length && !char.IsDigit(Input[current]))
                {
                    current++;
                }
                if (current >= Input.Length) break;

                // Находим начало числа
                int numberStart = current;
                // Находим конец числа
                while (current < Input.Length && char.IsDigit(Input[current]))
                {
                    current++;
                }

                // Если нашли число
                if (numberStart < current)
                {
                    string numberStr = Input.Substring(numberStart, current - numberStart);
                    int number = ParseNumber(numberStr);
                    _output += number;
                }
            }
        }

        private int ParseNumber(string str)
        {
            int result = 0;
            foreach (char c in str)
            {
                result = result * 10 + (c - '0');
            }
            return result;
        }

        public override string ToString()
        {
            return _output.ToString();
        }
    }
}