using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Created By Scott Stratton
namespace Sudoku_Solver
{

    public partial class Form1 : Form
    {

        List<TextBox> All = new List<TextBox>();
        List<Cell> AllCells = new List<Cell>();
        List<int> possible = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public Form1()
        {
            InitializeComponent();       
            AllCells = new List<Cell>();
            All = new List<TextBox>();
        }
                

        private void BtnClear_Click(object sender, EventArgs e)
        {
            foreach(TextBox Tb in All)
            {
                Tb.Text = "";
                Tb.ForeColor = Color.Black;
                Tb.Font = new Font(Tb.Font.FontFamily, 24);
            }
            AllCells.Clear();
            All.Clear();
            foreach(TextBox TB in PanelPuzzle.Controls)
            {
                All.Add(TB);
            }
        }

        
        private void BtnSolve_Click(object sender, EventArgs e)
        {
            if (AllCells.Count > 0)
            {
                AllCells.Clear();
                All.Clear();
                foreach (TextBox TB in PanelPuzzle.Controls)
                {
                    Cell cell = new Cell(TB.Name);
                    if (!string.IsNullOrEmpty(TB.Text))
                    {
                        cell.Number = Convert.ToInt32(TB.Text);                        
                        cell.Solved = true;
                    }
                    All.Add(TB);
                    AllCells.Add(cell);
                }
            }
            else
            {
                foreach (TextBox TB in PanelPuzzle.Controls)
                {
                    Cell cell = new Cell(TB.Name);
                    if (!string.IsNullOrEmpty(TB.Text))
                    {
                        cell.Number = Convert.ToInt32(TB.Text); 
                        cell.Solved = true;
                    }
                    All.Add(TB);
                    AllCells.Add(cell);
                }
            }

            bool check = false;
            foreach (TextBox Tb in All)
            {
                if (Tb.Text == "")
                {

                }
                else if (int.TryParse(Tb.Text, out int j))
                {
                    if (Convert.ToInt32(Tb.Text) > 9 || Convert.ToInt32(Tb.Text) < 1)
                    {
                        check = true;
                        MessageBox.Show("You must enter numbers between 1 and 9");
                        break;
                    }
                    else
                    {
                        check = true;
                    }
                }

            }
            if (!check)
            {
                MessageBox.Show("You must enter some numbers");
            }
            else
            {
                SolvePuzzle();
                foreach (TextBox TB in All)
                {
                    foreach (Cell c in AllCells)
                    {
                        if (TB.Name == c.Name)
                        {
                            TB.Text = c.Number.ToString();
                        }
                    }
                }
            }
        }

        private bool SolvePuzzle()
        {
            Cell cellToSolve = solvable_cell();
            if(cellToSolve == null)
            {
                return true;
            }
            else
            {
                foreach(int i in possible)
                {
                    if (validate_cell(cellToSolve, i))
                    {
                        cellToSolve.Number = i;
                        cellToSolve.Solved = true;
                        if (SolvePuzzle())
                        {
                            return true;
                        }

                        cellToSolve.Number = 0;
                        cellToSolve.Solved = false;
                    }
                }


            }

            return false;
        }

        private Cell solvable_cell()
        {
            foreach(Cell c in AllCells)
            {
                if (!c.Solved)
                {
                    return c;
                }
            }
            return null;
        }


        private bool validate_cell(Cell cell, int num)
        {
            foreach(Cell c in AllCells)
            {
                if(c.Row == cell.Row)
                {
                    if(c.Number == num)
                    {
                        return false;
                    }
                }
            }

            foreach (Cell c in AllCells)
            {
                if (c.Column == cell.Column)
                {
                    if (c.Number == num)
                    {
                        return false;
                    }
                }
            }

            foreach (Cell c in AllCells)
            {
                if (c.Box == cell.Box)
                {
                    if (c.Number == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }





        private void BtnGen_Click(object sender, EventArgs e)
        {
            BtnClear_Click(sender, e);
            Random rnd = new Random();
            int puzzle = rnd.Next(1, 4);
            if (puzzle == 1)
            {
                C1R2B1.Text = "2";
                C3R1B1.Text = "7";

                C4R3B2.Text = "8";
                C6R2B2.Text = "5";
                C6R3B2.Text = "1";

                C7R1B3.Text = "3";
                C7R3B3.Text = "4";
                C8R2B3.Text = "1";
                C9R1B3.Text = "2";

                C1R5B4.Text = "7";
                C2R4B4.Text = "1";
                C2R5B4.Text = "6";

                C5R4B5.Text = "9";
                C6R4B5.Text = "6";

                C8R5B6.Text = "4";
                C9R4B6.Text = "8";
                C9R5B6.Text = "9";

                C1R8B7.Text = "8";
                C3R8B7.Text = "1";

                C4R7B8.Text = "1";
                C4R9B8.Text = "7";
                C5R8B8.Text = "6";
                C6R7B8.Text = "3";

                C8R9B9.Text = "6";
                C9R9B9.Text = "3";
            }
            else if (puzzle == 2)
            {
                C1R3B1.Text = "6";
                C2R3B1.Text = "5";
                C3R3B1.Text = "2";

                C4R1B2.Text = "5";
                C4R2B2.Text = "6";
                C4R3B2.Text = "3";
                C5R3B2.Text = "9";
                C6R3B2.Text = "7";

                C8R2B3.Text = "2";
                C9R2B3.Text = "5";

                C1R4B4.Text = "1";
                C2R5B4.Text = "4";
                C2R6B4.Text = "3";
                C3R4B4.Text = "5";
                C3R6B4.Text = "7";

                C4R4B5.Text = "8";
                C5R4B5.Text = "3";
                C6R6B5.Text = "5";

                C7R4B6.Text = "2";
                C7R5B6.Text = "5";
                C9R6B6.Text = "6";

                C1R8B7.Text = "3";
                C2R8B7.Text = "9";
                C2R9B7.Text = "8";
                C3R9B7.Text = "4";

                C4R9B8.Text = "9";
                C5R7B8.Text = "8";
                C6R7B8.Text = "6";
                C6R9B8.Text = "3";

                C7R7B9.Text = "3";
                C7R8B9.Text = "8";
                C9R8B9.Text = "7";
            }
            else
            {
                C1R2B1.Text = "6";
                C2R2B1.Text = "9";
                C3R2B1.Text = "4";

                C4R2B2.Text = "8";
                C5R1B2.Text = "2";
                C6R1B2.Text = "7";
                C6R2B2.Text = "3";

                C7R3B3.Text = "6";
                C9R1B3.Text = "4";

                C1R4B4.Text = "2";
                C1R6B4.Text = "7";
                C3R4B4.Text = "1";

                C4R4B5.Text = "3";
                C5R5B5.Text = "7";
                C6R4B5.Text = "9";

                C7R6B6.Text = "1";
                C8R4B6.Text = "4";
                C8R6B6.Text = "9";
                C9R5B6.Text = "2";

                C2R8B7.Text = "5";
                C2R9B7.Text = "4";
                C3R7B7.Text = "6";

                C4R8B8.Text = "7";
                C4R9B8.Text = "9";
                C5R7B8.Text = "5";
                C5R9B8.Text = "8";
                C6R7B8.Text = "1";

                C8R7B9.Text = "7";
                C8R9B9.Text = "6";
                C9R7B9.Text = "8";
            }

        }

        private void BtnGenExpert_Click(object sender, EventArgs e)
        {
            BtnClear_Click(sender, e);

            Random rnd = new Random();
            int puzzle = rnd.Next(1, 5);

            if (puzzle == 1)
            {
                //first expert puzzle
                C1R1B1.Text = "1";
                C1R3B1.Text = "3";
                C2R3B1.Text = "9";
                C3R3B1.Text = "6";


                C5R3B2.Text = "5";

                C7R1B3.Text = "4";
                C7R2B3.Text = "7";
                C8R1B3.Text = "9";

                C1R4B4.Text = "6";
                C2R6B4.Text = "4";
                C3R6B4.Text = "9";

                C4R4B5.Text = "9";
                C5R5B5.Text = "7";
                C6R6B5.Text = "1";

                C7R6B6.Text = "8";
                C8R6B6.Text = "2";

                C1R7B7.Text = "4";
                C3R8B7.Text = "3";

                C5R7B8.Text = "8";
                C6R7B8.Text = "7";
                C6R8B8.Text = "2";

                C9R8B9.Text = "5";
            }
            else if (puzzle == 2)
            {



                //second expert puzzle
                C1R1B1.Text = "4";
                C1R2B1.Text = "5";
                C3R2B1.Text = "1";

                C4R3B2.Text = "7";
                C5R1B2.Text = "5";
                C5R2B2.Text = "8";
                C5R3B2.Text = "9";
                C6R3B2.Text = "6";

                ////box 3 is empty

                C2R6B4.Text = "5";
                C3R4B4.Text = "7";
                C3R5B4.Text = "9";

                C6R5B5.Text = "8";

                C7R5B6.Text = "6";
                C7R6B6.Text = "9";
                C9R6B6.Text = "7";

                C1R9B7.Text = "2";
                C2R9B7.Text = "3";

                C4R8B8.Text = "6";
                C6R7B8.Text = "3";

                C8R8B9.Text = "8";
                C8R9B9.Text = "1";
                C9R7B9.Text = "5";
            }
            else if (puzzle == 3)
            {
                //Hardest puzzle #1
                C1R3B1.Text = "1";
                C2R2B1.Text = "6";
                C3R3B1.Text = "4";

                C4R3B2.Text = "2";
                C5R1B2.Text = "3";

                C8R1B3.Text = "5";
                C9R3B3.Text = "9";

                C1R5B4.Text = "6";
                C2R4B4.Text = "2";
                C2R6B4.Text = "8";
                C3R5B4.Text = "7";

                C4R6B5.Text = "7";
                C6R5B5.Text = "5";

                C9R4B6.Text = "6";
                C8R5B6.Text = "9";

                C1R7B7.Text = "7";
                C3R7B7.Text = "9";
                C3R8B7.Text = "8";

                C4R7B8.Text = "4";
                C6R9B8.Text = "2";

                C7R9B9.Text = "4";
                C9R7B9.Text = "1";
            }
            else
            {
                //Hardest puzzle #2
                C1R1B1.Text = "8";
                C1R2B1.Text = "4";
                C3R1B1.Text = "6";

                C4R3B2.Text = "2";
                C5R1B2.Text = "5";

                C7R3B3.Text = "5";
                C9R1B3.Text = "9";

                C1R5B4.Text = "6";
                C2R4B4.Text = "4";
                C2R6B4.Text = "2";
                C3R5B4.Text = "7";

                C4R5B5.Text = "1";
                C5R4B5.Text = "6";

                C8R5B6.Text = "8";
                C9R6B6.Text = "7";

                C1R8B7.Text = "5";
                C2R9B7.Text = "7";
                C3R8B7.Text = "9";

                C5R8B8.Text = "2";
                C6R7B8.Text = "3";

                C8R7B9.Text = "1";
                C9R8B9.Text = "8";
            }
        }
    }


}
