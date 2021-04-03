using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Char;

namespace BullsAndCows
{
    public class Row : IEnumerable<int>
    {
        public Row(int[] row)
        {
            if (row.Length != 4)
                throw new ArgumentException();

            var usedDigits = new List<int>();
            
            foreach (var digit in row)
            {
                if (digit > 9 || digit < 0)
                    throw new ArgumentException();

                if (usedDigits.Contains(digit))
                    throw new ArgumentException();
                
                usedDigits.Add(digit);
            }
            
            _row = row;
        }

        public Row(string input) : this(Parse(input))
        {
        }

        public static Row GetRandomRow()
        {
            var random = new Random();
            var numbers = new int[4];
            var usedDigits = new List<int>();

            var i = 0;
            while (i < 4)
            {
                var digit = random.Next(0, 9);
                if (usedDigits.Contains(digit))
                    continue;
                
                numbers[i] = digit;
                usedDigits.Add(digit);
                i++;
            }

            return new Row(numbers);
        }

        private static int[] Parse(string input) 
            => input
                .ToCharArray()
                .Select(c => (int) GetNumericValue(c))
                .ToArray();
        
        private readonly int[] _row;

        public int this[int index]
        {
            get => _row[index];
            set => _row[index] = value;
        }

        public static Result Check(Row actual, Row expected)
        {
            var bullsCount = 0;
            var cowsCount = 0;

            foreach (var digit in actual)
            {
                if (!expected.Contains(digit)) continue;
                
                if (actual.IndexOf(digit) == expected.IndexOf(digit))
                    bullsCount++;
                else
                    cowsCount++;
            }

            return new Result(bullsCount, cowsCount);
        }
        
        public int IndexOf(int requiredDigit)
        {
            for (var i = 0; i < _row.Length; i++)
            {
                if (requiredDigit == _row[i])
                    return i;
            }

            return -1;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>) _row).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}