using AISolver.DFS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AISolver.DFS;

namespace AISolver
{
    public partial class FormCrossingRiver : Form
    {
        public FormCrossingRiver()
        {
            InitializeComponent();
        }
        public class Problem
        {
            public string ProblemName;
            public string ProblemDetail;
            public string Solution;
            public delegate String Solve();
            public Solve SolveFunction;
        }


        private void txtResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProblemDetail_TextChanged(object sender, EventArgs e)
        {

        }
        //  Dictionary<int, Problem> ProblemDic = new Dictionary<int, Problem>();
        List<Problem> listProblem = new List<Problem>();
        private void LoadProblemIntoList()
        {
            int i;
            Problem problem = new Problem();
            problem.ProblemName = "Frog Leap";
            problem.ProblemDetail =
@"Swap the frogs. 
3 from the left have to jump on the 3 stones on the right and vice versa 
Each frog can jump just on the adjacent stone or jump over another frog if there is an empty stone behind it

You can try to play it with this link
https://data.bangtech.com/algorithm/switch_frogs_to_the_opposite_side.htm
";

            problem.SolveFunction = this.ForgSolverMethod;
            listProblem.Add(problem);

            problem = new Problem();
            problem.ProblemName = "Darkness Phobia";
            problem.ProblemDetail =
@"
Four people come to a river in the night. 
There is a narrow bridge, 
but it can only hold two people at a time. 
They have one torch and, because it's night, 
the torch has to be used when crossing the bridge. 

Dad can cross the bridge in 1 minute, 
Mom in 2 minutes, 
Son in 4 minutes, 
Daughter in 5 minutes. 

When two people cross the bridge together, 
they must move at the slower person's pace. 
The question is, can they all get across the bridge if the torch lasts only 12 minutes
";

            problem.SolveFunction = DarkNessPhobiaSolverMethod;
            listProblem.Add(problem);

            problem = new Problem();
            problem.ProblemName = "Japanese IQ Test";
            problem.ProblemDetail =
@"
These 8 people need to use the raft to cross the river.
Father, Mother, Son1, Son2, Daughter1, Daughter2, Policeman, Thief

The problem is
1. Only 2 people on the raft at a time.
2. The Father cannot stay with any of the daughters, without their Mother's presence.
3. The Mother cannot stay with any of the sons, without their Father's presence.
4. The thief (striped shirt) cannot stay with any family member, if the Policeman is not there.
5. Only the Father, the Mother and the Policeman know how to operate the raft.

You can try to play it here
https://games.kidzsearch.com/computer/title/japanese-iq-test-15320
";
            problem.SolveFunction = JapaneseIQPuzzleSolverMethod;
            listProblem.Add(problem);

            problem = new Problem();
            problem.ProblemName = "Jealous husband";
            problem.ProblemDetail =
@"
Three married couple come to a river. The only vessel available is a small boat
that can carry at most two of them. How can they cross the river, if at any time,
no woman is in the company of any man unless her own husband is present?
";
            problem.SolveFunction = JealousHusbandSolverMethod;
            listProblem.Add(problem);


            problem = new Problem();
            problem.ProblemName = "3 Lions 3 Sheeps";
            problem.ProblemDetail =
@"
6 animals need to use a raft to cross the rivers.
Those 6 animals consist of 3 Lions and 3 Sheeps.

The problem is
1. The raft can contain only most 2 animals.
2. The raft cannot move by itself, it requires at least one animal to control it.
3. If the number of lions is more than the number of sheeps, the lions will eat the sheeps then they fail.
4. Rule #3 apply to both side of the river and also on the raft.

You can also watch the clip video 
https://www.youtube.com/watch?v=ADR7dUoVh_c&ab_channel=TED-Ed
";
            problem.SolveFunction = LionsAnd3SheepsSolveMethod;

            listProblem.Add(problem);

        }
        private void FormCrossingRiver_Load(object sender, EventArgs e)
        {


            LoadProblemIntoList();
            this.cboProblem.Items.Clear();
            // int i;
            int i = 0;

            for(i=0;i<listProblem.Count;i++)
            {
                cboProblem.Items.Add(listProblem[i].ProblemName);

            }

            cboProblem.SelectedIndexChanged -= CboProblem_SelectedIndexChanged;
            cboProblem.SelectedIndexChanged += CboProblem_SelectedIndexChanged;
            this.txtProblemDetail.LinkClicked -= TxtProblemDetail_LinkClicked;
            this.txtProblemDetail.LinkClicked += TxtProblemDetail_LinkClicked;
        }

        private void TxtProblemDetail_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            //  throw new NotImplementedException();
            System.Diagnostics.Process.Start(e.LinkText);

        }

        private String ForgSolverMethod()
        {
            cFrogLeapSolver Solver = new cFrogLeapSolver();
            string[] Matrix = { "A", "A", "A", " ", "B", "B", "B" };

            cDFS<cFrogLeapSolver, string[]> CBackTrack1 = new cDFS<cFrogLeapSolver, string[]>();
            CBackTrack1.Run(Solver, Matrix);
            return Solver.ResultDetail;
        }
        private String  DarkNessPhobiaSolverMethod()
        {
            DarkNessPhobiaSolver Solver = new DarkNessPhobiaSolver();
            cDFS<DarkNessPhobiaSolver, BDarkNessPhobiaTable> DFS = new cDFS<DarkNessPhobiaSolver, BDarkNessPhobiaTable>();
            DFS.Run(Solver, new BDarkNessPhobiaTable());
           return  Solver.ResultDetail;
        }

        private String  JapaneseIQPuzzleSolverMethod()
        {
            JapIQRiverCrossingSolver Solver = new JapIQRiverCrossingSolver();

            cDFS<JapIQRiverCrossingSolver, AISolver.DFS.NVJap.cRiverCrossingJapState> DFS = new cDFS<JapIQRiverCrossingSolver, DFS.NVJap.cRiverCrossingJapState>();
            DFS.Run(Solver, new DFS.NVJap.cRiverCrossingJapState());

 
            return  Solver.ResultDetail;
        }
        private String  JealousHusbandSolverMethod()
        {
            JealousHBSolver Solver = new JealousHBSolver();

            cDFS<JealousHBSolver, DFS.NVJealousHusband.RiverCrossingJH> DFS = new cDFS<JealousHBSolver, DFS.NVJealousHusband.RiverCrossingJH>();

            DFS.Run(Solver, new DFS.NVJealousHusband.RiverCrossingJH());



            return  Solver.ResultDetail;
        }
        private String LionsAnd3SheepsSolveMethod()
        {
            c3LionsSolver Solver = new c3LionsSolver();

            cDFS<c3LionsSolver, DFS.NV3Lions.RiverCrossing3Lions> DFS = new cDFS<c3LionsSolver, DFS.NV3Lions.RiverCrossing3Lions>();


            DFS.Run(Solver, new DFS.NV3Lions.RiverCrossing3Lions());

            return  Solver.ClosestSolutionDetail;

        }
        private void CboProblem_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            int index = cboProblem.SelectedIndex;
            Problem problem  = listProblem[index];

            if(String.IsNullOrEmpty (problem.Solution))
            {
                problem.Solution = problem.SolveFunction();

                
            }
            this.txtProblemDetail.Text = problem.ProblemDetail;
            this.txtResult.Text = problem.Solution;
            */
            int index = cboProblem.SelectedIndex;
            Problem problem = listProblem[index];
            this.txtProblemDetail.Text = problem.ProblemDetail;
            this.txtResult.Text = "";

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboProblem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnViewSolution_Click(object sender, EventArgs e)
        {
            int index = cboProblem.SelectedIndex;
            Problem problem = listProblem[index];

            if (String.IsNullOrEmpty(problem.Solution))
            {
                problem.Solution = problem.SolveFunction();


            }
            this.txtResult.Text = problem.Solution;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
