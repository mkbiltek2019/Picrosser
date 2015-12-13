﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picrosser {
    public class Question {
        public int Width {
            get; private set;
        }
        public int Height {
            get; private set;
        }
        private int[/*Width*/][] colNumbers;
        private int[/*Height*/][] rowNumbers;
        public int[] GetColNumbers(int index) {
            return colNumbers[index];
        }
        public int[] GetRowNumbers(int index) {
            return rowNumbers[index];
        }
        void ThrowIfContainZero(int[] numbers) {
            foreach(int number in numbers)
                if(number == 0) {
                    throw new ArgumentException("invalid number");
                }
        }
        public void SetColNumbers(int index, int[] numbers) {
            ThrowIfContainZero(numbers);
            colNumbers[index] = numbers;
        }
        public void SetRowNumbers(int index, int[] numbers) {
            ThrowIfContainZero(numbers);
            rowNumbers[index] = numbers;
        }
        public Question(int width, int height) {
            colNumbers = new int[Width = width][];
            rowNumbers = new int[Height = height][];
        }
        public Question() :
            this("0\n\n0\n") { }

        int[] StringToNumbers(string line) {
            string[] split = line.Split(new char[] { ' ', ',' });
            if(split.Length == 0) throw new ArgumentException();
            int[] numbers = split.Select(Int32.Parse).ToArray();
            if(numbers.Length == 1 && numbers[0] == 0) return new int[0];
            if(numbers.Any((x) => x < 1)) throw new ArgumentException();
            return numbers;
        }

        public Question(string text) {
            LinkedList<int[]> col = new LinkedList<int[]>();
            LinkedList<int[]> row = new LinkedList<int[]>();
            System.IO.StringReader reader = new System.IO.StringReader(text);
            string line;
            while(true) {
                line = reader.ReadLine();
                if(line == null || line.Equals("")) break;
                col.AddLast(StringToNumbers(line));
            }
            while(true) {
                line = reader.ReadLine();
                if(line == null) break;
                row.AddLast(StringToNumbers(line));
            }
            if(!col.Any() || !row.Any()) throw new ArgumentException();
            colNumbers = col.ToArray();
            rowNumbers = row.ToArray();
            Width = colNumbers.Length;
            Height = colNumbers.Length;
        }


    }
}