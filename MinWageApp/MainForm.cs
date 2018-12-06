using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MinWageApp {
    public partial class MainForm : Form {
        public SimInput inputParams { get; set; } = new SimInput();

        public List<double> finalSegments = new List<double>();
        public List<double> gini = new List<double>();
        public List<double> inflation = new List<double>();
        public List<double> wagePct = new List<double>();
        public List<double> medianWage = new List<double>();
        public List<double> avgWage = new List<double>();
        public List<double> wageInflation = new List<double>();

        public MainForm() {

            InitializeComponent();
        }

        public void Clear() {
            logTxt.Clear();
            finalSegments.Clear();
            gini.Clear();
            inflation.Clear();
            wagePct.Clear();
            medianWage.Clear();
            avgWage.Clear();
        }
        private void calcBtn_Click(object sender, EventArgs e) {
            List<double> startSegments = new List<double>();
            StringBuilder sb = new StringBuilder();

            if (String.IsNullOrWhiteSpace(inputParams.WageSegments)) {
                MessageBox.Show("You must fill income segments");
                return;
            }
            Clear();
            SimInput input = (SimInput) inputParams.Clone();
            Simulation sim = new Simulation(input);

            sb.AppendLine(sim.Output.Header("|",inputParams.ReshapeCount));
            if (Utils.fillIncome(inputParams.WageSegments,inputParams.Segments)) {
                sim.Input.Reshape();
                this.plotValues(sim.Input.StartWage, segStartChart);

                for (int i = 0; i < sim.Input.Iterations; i++) {
                    if (i == 0) {
                        
                        sim.Execute(true,input.CalcMode);
                        sim.Output.FillFromInput(sim.Input,true);
                    } else {
                        sim.Execute(false,input.CalcMode);
                        sim.Output.FillFromInput(sim.Input,false);
                    }
                    if (i == 11) {

                    }
                    //Plot income segments
                    this.finalSegments.Clear();
                    this.finalSegments.AddRange(sim.Output.Segments);
                    //Add the history of the indicators
                    this.gini.Add(sim.Output.Gini);
                    this.inflation.Add(sim.Output.Inflation);
                    this.wagePct.Add(sim.Output.WagePct);
                    this.medianWage.Add(sim.Output.MedianWageIA);
                    this.avgWage.Add(sim.Output.AverageWageIA);
                    this.wageInflation.Add(sim.Output.WageInflationPct);

                    string s = sim.Output.ToString(1000000, "|");
                    sb.AppendLine(s);
                    //
                    sim.Input.FillFromOutput(sim.Output);
                }
                this.logTxt.Text = sb.ToString();
                //this.plotValues(inputParams.StartWage, segStartChart);
                this.plotValues(sim.Output.SegmentsIA, segEndChart);
                this.plotValues(gini, giniChart);
                this.plotValues(inflation, chartInflation);
                this.plotValues(wagePct, minWagePctChart);
                this.plotValues(medianWage, medianAvgChart, 0);
                this.plotValues(avgWage, medianAvgChart, 1);
            }
            inputPg.Refresh();
            tcMain.SelectedTab = tpChartsSample;
            labInfo.Text =
            String.Format("Inflation = {0}, Growth = {1}, Min Wage Inc = {2} , GenWageInc = {3}",
            input.EstInflation, input.MaxGrowthPct, input.MinIncAboveInf, input.GenIncAboveInf);

        }



        private void exitBtn_Click(object sender, EventArgs e) {
            Close();
        }

        private void plotValues(List<double> segs, Chart chart,int idx = 0) {
            chart.Series[idx].Points.Clear();
            int x = chart.Series[idx].Points.Count();
            for (int i = 0; i < segs.Count; i++) {
                double y = Convert.ToDouble(segs[i]);
                chart.Series[idx].Points.AddY(y);
            }
        }

        private void mainTs_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void btnPlot_Click(object sender, EventArgs e) {

        }

        private void btnSample_Click(object sender, EventArgs e) {
        }

        private void MainForm_Load(object sender, EventArgs e) {
            this.inputPg.SelectedObject = this.inputParams;
        }

        private void btnCalc_Click(object sender, EventArgs e) {

        }

        private void btnPick_Click(object sender, EventArgs e) {
            //Pick an input selection


        }

        private void btnTestData_Click(object sender, EventArgs e) {
            double million = 1000000;
            this.inputParams.Gdp = 1250002 * million * 19.50;
            this.inputParams.Imports = inputParams.Gdp * 0.39685;
            this.inputParams.Population = 125 * million;
            this.inputParams.Workforce = 50 * million;
            this.inputParams.WageSegments = "2722,4735,6306,7852,9604,11612,14144,17794,24014,56285";
            this.inputParams.TopIncome = 120000;
            this.inputParams.EstInflation = 0.03;
            this.inputParams.GenIncAboveInf = 0.001;
            this.inputParams.MinIncAboveInf = 0.0;
            this.inputParams.DispFactor = 8;
            this.inputParams.MinWage = 2100;
            this.inputParams.ReshapeCount = 20;
            this.inputParams.MaxGrowthPct = 0.02;
            this.inputParams.SaveBase = 12000;
            this.inputParams.SavePct = 0.25;
            this.inputParams.CalcMode = CalcModeEnum.Gini;
            inputPg.Refresh();
        }

        private void cbChart_SelectedIndexChanged(object sender, EventArgs e) {
            string item = cbChart.Text;

            if (item == "SegmentsStart") {
            } else if (item == "SegmentsEnd") {
            } else if (item == "Gini") {
            } else if (item == "Inflation") {
            } else if (item == "Gdp") {
            } else if (item == "Gdp IA") {
            } else if (item == "Wage % Gdp") {
            } else if (item == "Median / Avg Wage") {

            }
        }
    }
}
