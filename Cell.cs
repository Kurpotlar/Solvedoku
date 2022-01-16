using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Created By Scott Stratton
namespace Sudoku_Solver
{
    public class Cell
    {
        public string Name;
        public int Number;        
        public int Row;
        public int Column;
        public int Box;
        public bool Solved = false;

        public Cell(string name)
        {
            this.Name = name;
            this.Column = Convert.ToInt32(name.Substring(1,1));
            this.Row = Convert.ToInt32(name.Substring(3,1));
            this.Box = Convert.ToInt32(name.Substring(5,1));

        }




    }
}
