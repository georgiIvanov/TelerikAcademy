using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _05.TicTacToe
{
    public partial class index : System.Web.UI.Page
    {
        string[][] field;
        string setSign;
        string computerSign;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["field"] == null)
            {
                field = new string[3][];
                field[0] = new string[3];
                field[1] = new string[3];
                field[2] = new string[3];

                
                ViewState.Add("field", field);
                ViewState.Add("winner", "");
                ViewState.Add("turns", 1);

            }
            else
            {
                computerSign = "O";
                setSign = "X";
                field = (string[][])ViewState["field"];
            }
        }

        protected void top_left_Click(object sender, EventArgs e)
        {
            if (IsMoveValid(0, 0))
            {
                //top_left.InnerHtml = "X";
                //field[0][0] = "X";
                //ProcessGame();
                //int turns = (int)ViewState["turns"];
                //ViewState["turns"] = turns + 1;
                ProcessMove(setSign, top_left, 0, 0);
            }
        }

        protected void top_center_Click(object sender, EventArgs e)
        {
            if (IsMoveValid(0, 1))
            {
                //top_center.InnerHtml = "X";
                //field[0][1] = "X";
                //ProcessGame();
                ProcessMove(setSign, top_center, 0, 1);
            }
        }

        protected void top_right_Click(object sender, EventArgs e)
        {
            if (IsMoveValid(0, 2))
            {
                //top_right.InnerHtml = "X";
                //field[0][2] = "X";
                //ProcessGame();
                ProcessMove(setSign, top_right, 0, 2);
            }
        }

        protected void middle_left_Click(object sender, EventArgs e)
        {
            if (IsMoveValid(1, 0))
            {
                //middle_left.InnerHtml = "X";
                //field[1][0] = "X";
                //ProcessGame();
                ProcessMove(setSign, middle_left, 1, 0);
            }
        }

        protected void middle_center_Click(object sender, EventArgs e)
        {
            if (IsMoveValid(1, 1))
            {
                //middle_center.InnerHtml = "X";
                //field[1][1] = "X";
                //ProcessGame();
                ProcessMove(setSign, middle_center, 1, 1);
            }
            
        }

        protected void middle_right_Click(object sender, EventArgs e)
        {
            if (IsMoveValid(1, 2))
            {
                //middle_right.InnerHtml = "X";
                //field[1][2] = "X";
                //ProcessGame();
                ProcessMove(setSign, middle_right, 1, 2);
            }
        }

        protected void bottom_left_Click(object sender, EventArgs e)
        {
            if (IsMoveValid(2, 0))
            {
                //bottom_left.InnerHtml = "X";
                //field[2][0] = "X";
                //ProcessGame();
                ProcessMove(setSign, bottom_left, 2, 0);
            }
           
        }

        protected void bottom_center_Click(object sender, EventArgs e)
        {
            if (IsMoveValid(2, 1))
            {
                //bottom_center.InnerHtml = "X";
                //field[2][1] = "X";
                //ProcessGame();
                ProcessMove(setSign, bottom_center, 2, 1);
            }
            
        }

        protected void bottom_right_Click(object sender, EventArgs e)
        {
            if (IsMoveValid(2, 2))
            {
                //bottom_right.InnerHtml = "X";
                //field[2][2] = "X";
                //ProcessGame();
                ProcessMove(setSign, bottom_right, 2, 2);
            }
            
        }

        void ProcessGame()
        {
            if (CheckForWinner())
            {
                PrintScore();
            }
            else
            {
                ComputerMove();
                PrintComputerMoves();
                if(CheckForWinner())
                {
                    PrintScore();
                }
            }

        }

        void PrintScore()
        {
            score.InnerHtml = "Winner is " + ViewState["winner"] + "<br/>In " + ViewState["turns"] + " turns";
            ViewState["field"] = null;
        }

        void PrintComputerMoves()
        {
            if (field[0][0] == computerSign)
            {
                top_left.InnerHtml = computerSign;
            }
            if (field[0][1] == computerSign)
            {
                top_center.InnerHtml = computerSign;
            }
            if (field[0][2] == computerSign)
            {
                top_right.InnerHtml = computerSign;
            }

            if (field[1][0] == computerSign)
            {
                middle_left.InnerHtml = computerSign;
            }
            if (field[1][1] == computerSign)
            {
                middle_center.InnerHtml = computerSign;
            }
            if (field[1][2] == computerSign)
            {
                middle_right.InnerHtml = computerSign;
            }

            if (field[2][0] == computerSign)
            {
                bottom_left.InnerHtml = computerSign;
            }
            if (field[2][1] == computerSign)
            {
                bottom_center.InnerHtml = computerSign;
            }
            if (field[2][2] == computerSign)
            {
                bottom_right.InnerHtml = computerSign;
            }
        }

        void ComputerMove()
        {
            var rng = new Random();

            while (true)
            {
                var row = rng.Next(0, 3);
                var col = rng.Next(0, 3);
                if (field[row][ col] == null)
                {
                    field[row][col] = computerSign;
                    break;
                }
            }
            
        }

        void ProcessMove(string playerSign, HtmlButton btn, int row, int col)
        {
            btn.InnerHtml = playerSign;
            field[row][col] = playerSign;
            ProcessGame();
            int turns = (int)ViewState["turns"];
            ViewState["turns"] = turns + 1;
        }

        bool IsMoveValid(int row, int col)
        {
            if (field[row][col] == null)
            {
                return true;
            }

            return false;
        }

        bool CheckForWinner()
        {
            // rows
            for (int i = 0; i < 3; i++)
            {
                int count = 1; string lastP = field[i][0];
                for (int j = 1; j < 3; j++)
                {
                    if (field[i][j] == lastP && lastP != null)
                    {
                        count++;
                        lastP = field[i][j];
                    }
                    else
                    {
                        break;
                    }
                }

                if (count == 3)
                {
                    ViewState["winner"] = lastP;
                    return true;
                }

            }

            // cols
            for (int i = 0; i < 3; i++)
            {
                int count = 1; string lastP = field[0][i];
                for (int j = 1; j < 3; j++)
                {
                    if (field[j][i] == lastP && lastP != null)
                    {
                        count++;
                        lastP = field[j][i];
                    }
                    else
                    {
                        break;
                    }
                }

                if (count == 3)
                {
                    ViewState["winner"] = lastP;
                    return true;
                }

            }

            //diagonals

            if (field[0][0] == field[1][1] && field[1][1] == field[2][2] && field[1][1] != null)
            {
                ViewState["winner"] = field[0][0];
                return true;
            }

            if (field[0][2] == field[1][1] && field[1][1] == field[2][0] && field[1][1] != null)
            {
                ViewState["winner"] = field[1][1];
                return true;
            }

            return false;
        }
    }
}