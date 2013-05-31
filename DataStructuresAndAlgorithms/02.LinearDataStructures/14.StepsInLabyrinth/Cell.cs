using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.StepsInLabyrinth
{
    struct Cell
    {
        public int Row;
        public int Col;
        public int Value;

        public Cell(int row, int col, int value)
        {
            this.Row = row;
            this.Col = col;
            this.Value = value;
        }
    }
}
