using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.DFS
{
    class c8QueenBranchAndBoundSolver
    {


        int N = 8;


        public void GetSolution(int[,] board)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Log(board[i, j].ToString());
                    Log(" ");
                }

                Log(Environment.NewLine);
            }
        }


        public bool IsCanput(int row, int col, 
                    int[,] slashCode,
                    int[,] backslashCode, 
                    bool[] rowLookup,
                    bool[] slashCodeLookup, 
                    bool[] backslashCodeLookup)
        {
            if (slashCodeLookup[slashCode[row, col]] ||
                backslashCodeLookup[backslashCode[row, col]] ||
                rowLookup[row])
                return false;

            return true;
        }

        StringBuilder strB = new StringBuilder();
        public string GetLog()
        {
            return strB.ToString();
        }
        private void Log(string str)
        {
            strB.Append(str);
        }
        /* A recursive utility function to solve N Queen problem */
        public bool solveNQueensUtil(int[,] board, 
            int col,
            int[,] slashCode, 
            int[,] backslashCode, 
            bool[] rowLookup,
            bool[] slashCodeLookup, 
            bool[] backslashCodeLookup)
        {
            /* base case: If all queens are placed
            then return true */
            if (col >= N)
                return true;

            /* Consider this column and try placing
               this queen in all rows one by one */
            for (int i = 0; i < N; i++)
            {
                /* Check if queen can be placed on
                   board[i,col] */
                if (IsCanput(i, col, slashCode, backslashCode, rowLookup,
                            slashCodeLookup, backslashCodeLookup))
                {
                    /* Place this queen in board[i,col] */
                    board[i, col] = 1;
                    rowLookup[i] = true;
                    slashCodeLookup[slashCode[i, col]] = true;
                    backslashCodeLookup[backslashCode[i, col]] = true;

                    /* recur to place rest of the queens */
                    if (solveNQueensUtil(board, col + 1, slashCode, backslashCode,
                            rowLookup, slashCodeLookup, backslashCodeLookup))
                        return true;

                    /* If placing queen in board[i,col]
                    doesn't lead to a solution, then backtrack */

                    /* Remove queen from board[i,col] */
                    board[i, col] = 0;
                    rowLookup[i] = false;
                    slashCodeLookup[slashCode[i, col]] = false;
                    backslashCodeLookup[backslashCode[i, col]] = false;
                }
            }

            /* If queen can not be place in any row in
                this colum col then return false */
            return false;
        }

        /* This function solves the N Queen problem using
        Branch and Bound. It mainly uses solveNQueensUtil() to
        solve the problem. It returns false if queens
        cannot be placed, otherwise return true and
        prints placement of queens in the form of 1s.
        Please note that there may be more than one
        solutions, this function prints one of the
        feasible solutions.*/
        public bool solveNQueens()
        {
            int[,] board ={
                 {0,0,0,0,0,0,0,0},
                                  {0,0,0,0,0,0,0,0},
                                                   {0,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,0},
                                  {0,0,0,0,0,0,0,0},
                                                   {0,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,0},
                                  {0,0,0,0,0,0,0,0}
                 };



            // helper matrices
            int[,] slashCode = new int[8, 8];
            int[,] backslashCode = new int[8, 8];

            // arrays to tell us which rows are occupied
            bool[] rowLookup = new bool[8];
            rowLookup[0] = false;

            //keep two arrays to tell us which diagonals are occupied
            bool[] slashCodeLookup = new bool[2 * N - 1];
            bool[] backslashCodeLookup = new bool[2 * N - 1];

            slashCodeLookup[0] = false;
            backslashCodeLookup[0] = false;

            // initalize helper matrices
            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    slashCode[r, c] = r + c;

                    backslashCode[r, c] = r - c + 7;
                }
            }
            if (solveNQueensUtil(board, 0, slashCode, backslashCode,
              rowLookup, slashCodeLookup, backslashCodeLookup) == false)
            {
                Log("Solution does not exist");
                return false;
            }

            // solution found
            GetSolution(board);
            return true;
        }

    }
}
