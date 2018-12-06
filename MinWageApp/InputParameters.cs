using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MinWageApp {

    public enum CalcModeEnum  {AverageWage, MedianWage, Gini,Manual};
    public class SimInput : ICloneable {
        public List<double> Segments = new List<double>();
        public List<double> StartWage = new List<double>();
        public List<double> EndWage = new List<double>();

        [Description("Country"), Category("Identificator")]
        public string Country { get; set; }
        [Description("Year"), Category("Identificator")]
        public string Year { get; set; }
        [Description("Scenario"), Category("Identificator")]
        public string Scenario { get; set; }

        [Description("Gross domestic product"), Category("Global Indicators")]
        public double Gdp { get; set; }
        [Description("Total Imports"), Category("Global Indicators")]
        public double Imports { get; set; }
        [Description("Total Population"), Category("Global Indicators")]
        public double Population { get; set; }
        [Description("Working population"), Category("Global Indicators")]
        public double Workforce { get; set; }

        //
        [Description("Working population"), Category("Work Sector")]
        public string WageSegments { get; set; }
        [Description("Income of the 1%"), Category("Work Sector")]
        public double TopIncome { get; set; }
        [Description("Minimum Wage"), Category("Work Sector")]
        public double MinWage { get; set; }

        [Description("General increment above the inflation index"), Category("1.Simulation Parameters")]
        public double GenIncAboveInf { get; set; }
        [Description("Minimum wage increment above the inflation index"), Category("1.Simulation Parameters")]
        public double MinIncAboveInf { get; set; }
        [Description("Maximum GDP growth per year"), Category("1.Simulation Parameters")]
        public double MaxGrowthPct { get; set; }
        [Description("Dispersion of the minimum wage"), Category("1.Simulation Parameters")]
        public double DispFactor { get; set; }

        //Simulation Execution
        [Description("Calculation Mode of the increment"), Category("2.Simulation Execution")]
        public CalcModeEnum CalcMode { get; set; }
        [Description("Max inflation change"), Category("2.Simulation Execution")]
        public double MaxInflationDelta { get; set; } = 0.01;
        [Description("Estimated inflation"), Category("2.Simulation Execution")]
        public double EstInflation { get; set; }
        [Description("Number of cycles the simulation will run"), Category("2.Simulation Execution")]
        public double Iterations { get; set; } = 18;
        [Description("Resize of the work segments"), Category("2.Simulation Execution")]
        public int ReshapeCount { get; set; } = 20;
        [Description("Enforce the minimum wage"), Category("2.Simulation Execution")]
        public bool EnforceMin { get; set; } = false;
        [Description("Number of wage disbursements per year"), Category("2.Simulation Execution")]
        public double WagePeriods = 12;

        //Work sector
        [Description("Truncate dispersion in the highest decile"), Category("Work Sector")]
        public bool TruncDisp { get; set; }
        [Description("Average wage which allows saving the excedent income"), Category("Work Sector")]
        public double SaveBase { get; set; }
        [Description("Percent of wage saved above the Save Base "), Category("Work Sector")]
        public double SavePct { get; set; }

        public String ToTabString() {
            StringBuilder sb = new StringBuilder();
            Type myType = this.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props) {
                object propValue = prop.GetValue(this, null);
                sb.Append(prop.Name + "="+ propValue.ToString());
                sb.Append("\t");
            }
            return sb.ToString();
        }
        public static SimInput FromTabString(string s) {
            SimInput obj = new SimInput();
            Type objType = obj.GetType();
            string[] strings = s.Split('\t');
            foreach (string item in strings) {
                string[] kv =  item.Split('=');
                PropertyInfo pi = objType.GetProperty(kv[0]);
                if (pi != null) {
                    pi.SetValue(obj, kv[1], null);
                }
            }
            return obj;
        }

        public void Reshape() {
            if (Segments.Count != ReshapeCount) {
                double dx = Convert.ToDouble(Segments.Count) / Convert.ToDouble(ReshapeCount);
                Utils.reshape(Segments, StartWage, ReshapeCount, dx);
            } else {
                StartWage.Clear();
                StartWage.AddRange(Segments);
            }
        }

        public double SegmentSize() {
            return Workforce / StartWage.Count;
        }

        public double TotalWages(List<double> w ) {
            return w.Sum() * SegmentSize() * WagePeriods ;
        }


        public double WageExpenditure(List<double> w) {
            double total = 0;
            if (SaveBase > 0) {
                total = Utils.WageExpenditure(w, SaveBase, SavePct);
                total = total * SegmentSize() * WagePeriods;
            } else {
                total = TotalWages(w); 
            }
            return total;
        }

        public double ImportsPct() {
            return Imports / Gdp;
        }
        
        
        public void FillFromOutput(SimOutput output) {
            StartWage.Clear();
            StartWage.AddRange(output.Segments);

            Gdp = output.Gdp;
            EstInflation = output.Inflation;
            Imports = output.Imports;
            MinWage = output.MinWage;
            TopIncome = TopIncome * output.Inflation;
        }


        /*******************************************************************************
         * Obtain the top segment that will be affected by the minimum wage increase
         * maxy = highest salary to be affected
         * trunc = ignore the effect in the highest segment
         * maxx = highest segment that will be affected
         * factor = weight factor for the highest segment
         *********************************************************************************/
        public void GetTopAffectedSegment(double maxy, bool trunc, out int maxx, out double factor) {
            maxx = 0;
            factor = 0;
            double y1 = 0;
            for (int i = 0; i <StartWage.Count; i++) {
                double y = StartWage[i];
                if (y < maxy) {
                    maxx = i;
                    factor = 1;
                } else if (y == maxy) {
                    maxx = i;
                    factor = 1;
                    break;
                } else if (y > maxy) {
                    if (trunc) {
                        maxx = i - 1;
                        factor = 1;
                        break;
                    } else {
                        maxx = i;
                        factor = (maxy - y1) / (y - y1);
                        break;
                    }

                }
                y1 = y;
            }
            if (maxx == 0) {
                factor = 1;
            }
        }

        public void Clear() {
            Segments.Clear();
            StartWage.Clear();
            EndWage.Clear();
            Gdp = 0;
            Imports = 0;
            Population = 0; 
            Workforce = 0;
            EstInflation = 0;
            WageSegments = "";

            TopIncome = 0;
            ReshapeCount = 0;
            MinWage = 0;
            GenIncAboveInf = 0;
            MinIncAboveInf = 0;
            DispFactor = 0;
            TruncDisp = false;
            SaveBase = 0;

        }

        public object Clone() {
            return this.MemberwiseClone();
        }
    }

    public class SimOutput {

        public List<double> Segments = new List<double>();
        public List<double> SegmentsIA = new List<double>();
        public List<double> AcumSegments = new List<double>();
        public List<double> AcumSegmentsIA = new List<double>();

        public double TotalWages() {
            return Segments.Sum() * SegMentSize() * WagePeriods;
        }

        public double WageExpenditure(SimInput input) {
            double total = 0;
            if (input.SaveBase > 0) {
                total = Utils.WageExpenditure(Segments, input.SaveBase, input.SavePct);
                total = total * input.SegmentSize() * input.WagePeriods;
            } else {
                total = TotalWages();
            }
            return total;
        }

        public double SegMentSize() {
            return WorkForce / Segments.Count;
        }

        public void FillFromInput(SimInput input, bool nop = false) {
            this.WorkForce = input.Workforce;
            this.WagePeriods = input.WagePeriods;
            this.Segments.Clear();
            this.Segments.AddRange(input.EndWage);
            this.MinIncAboveInf = input.MinIncAboveInf;

            //calculate Wage delta 
            double w1 = input.WageExpenditure(input.StartWage);

            double w2 = input.WageExpenditure(input.EndWage);

            double dw = (w2 - w1) ;
            //We asume the import percent remains the same
            double importPct = input.ImportsPct();
            double importsDelta = dw * importPct;
            Imports = input.Imports + importsDelta;
            if (Imports > input.Gdp * 0.5) {
                Imports = input.Gdp;
            }
            //We calculate the "growth" percent 
            WageInflation = 0;
            WageInflationPct = 0;

            double gdpDelta = (dw - importsDelta) ;
            double gdpPct = gdpDelta / input.Gdp;
            double maxGrowth = input.MaxGrowthPct * input.Gdp;
            double dwVsPct = dw / input.Gdp;

            if (nop) {
                MinWage = input.MinWage;
                Gdp = input.Gdp;
                WagePct = this.TotalWages() / Gdp;
                MedianWage = Utils.median(Segments);
                AverageWage = Segments.Average();
                Inflation = input.EstInflation;
                AcumInflation = 1;
                MedianWageIA = MedianWage / AcumInflation;
                AverageWageIA = AverageWage / AcumInflation;
                SaveBase = input.SaveBase;
                CalcIASegments();
            }
            else {
                //If the maximum growth is exceeded, the reminder is added as inflation
                if (gdpDelta > maxGrowth) {
                    WageInflation = gdpDelta - maxGrowth;
                    gdpDelta = gdpDelta - WageInflation;
                } else {
                }
                if (WageInflation < 0) {
                    WageInflation = WageInflation * 0.2;
                }
                MinWage = input.MinWage;
                Gdp = input.Gdp + gdpDelta;
                WageInflationPct = WageInflation / Gdp;
                WagePct = this.TotalWages() / Gdp;
                MedianWage = Utils.median(Segments);
                AverageWage = Segments.Average();
                //Calculate the inflation for the period
                Inflation = input.EstInflation + WageInflationPct;
                //Add the inflation to the GDP
                Gdp = Gdp * (1 + Inflation);
                SaveBase = SaveBase * (1 + Inflation);

                //Cumulative inflation
                AcumInflation = AcumInflation * (1 + Inflation);
                CalcIASegments();

                MedianWageIA = MedianWage / AcumInflation;
                AverageWageIA = AverageWage / AcumInflation;
                this.Gini = Utils.calcGini(AcumSegments);
            }
        }

        public void CalcIASegments() {
            //Real median wage
            this.SegmentsIA.Clear();
            for (int i = 0; i < Segments.Count; i++)
            {
                double y = Segments[i];
                y = y / AcumInflation;
                SegmentsIA.Add(y);
            }
            Utils.acumulate(Segments, AcumSegments);
            Utils.acumulate(SegmentsIA, AcumSegmentsIA);
            Gini = Utils.calcGini(AcumSegmentsIA);

        }

        public double MinIncAboveInf { get; set; }
        public double MinWage { get; set; }
        public double Gini { get; set; }
        public double Imports { get; set; }
        public double Inflation { get; set; }
        public double Gdp { get; set; }
        public double WagePct { get; set; }
        public double MedianWage { get; set; }
        public double AverageWage { get; set; }
        public double AcumInflation { get; set; } = 1;
        public double MedianWageIA { get; set; }
        public double AverageWageIA { get; set; }
        public double WorkForce { get; set; }
        public double WagePeriods { get; set; }
        public double SaveBase { get; set; }
        public double WageInflation { get; set; }
        public double WageInflationPct { get; set; }

        public string ToString(double divisor,string sep) {
            StringBuilder sb = new StringBuilder();
            divisor = Math.Truncate(divisor);
            if (divisor <= 1) {
                divisor = 1;
            }
            sb.AppendFormat("{0:0.00}", this.MinIncAboveInf);
            sb.Append(sep);
            sb.AppendFormat("{0:0.00}", MinWage);
            sb.Append(sep);
            sb.AppendFormat("{0:0.00}", Gini);
            sb.Append(sep);
            sb.AppendFormat("{0:0.00}", Imports / divisor);
            sb.Append(sep);
            sb.AppendFormat("{0:0.00}", Inflation);
            sb.Append(sep);
            sb.AppendFormat("{0:0.00}", Gdp / divisor);
            sb.Append(sep);
            sb.AppendFormat("{0:0.00}", WagePct);
            sb.Append(sep);
            sb.AppendFormat("{0:0.00}", MedianWage);
            sb.Append(sep);
            sb.AppendFormat("{0:0.00}", AverageWage);
            sb.Append(sep);
            sb.AppendFormat("{0:0.00}", AcumInflation);
            sb.Append(sep);
            sb.AppendFormat("{0:0.00}", MedianWageIA);
            sb.Append(sep);
            sb.AppendFormat("{0:0.00}", AverageWageIA);
            sb.Append(sep);
            sb.AppendFormat("{0:0.00}", WageInflationPct);
            sb.Append(sep + "segments" + sep);
            for (int i = 0; i < Segments.Count; i++) {
                sb.AppendFormat("{0:0.00}", Segments[i]);
                sb.Append(sep);
            }
            sb.Append(sep + "segmentsIA" + sep);
            for (int i = 0; i < this.SegmentsIA.Count; i++)
            {
                sb.AppendFormat("{0:0.00}", SegmentsIA[i]);
                sb.Append(sep);
            }

            return sb.ToString();
        }

        public String Header(string sep, int segs) {
            StringBuilder sb = new StringBuilder();
            sb.Append("Min Wage Inc");
            sb.Append(sep);
            sb.Append("MinWage");
            sb.Append(sep);
            sb.Append("Gini");
            sb.Append(sep);
            sb.Append("Imports");
            sb.Append(sep);
            sb.Append("Inflation");
            sb.Append(sep);
            sb.Append("Gdp");
            sb.Append(sep);
            sb.Append("Wage Pct");
            sb.Append(sep);
            sb.Append("Median Wage");
            sb.Append(sep);
            sb.Append("Average Wage");
            sb.Append(sep);
            sb.Append("Acumulated inflation");
            sb.Append(sep);
            sb.Append("Median Wage Inf.Adj");
            sb.Append(sep);
            sb.Append("Average Wage Inf.Adj");
            sb.Append(sep);
            sb.Append("Wage Inflation");
            sb.Append(sep);
            sb.Append("SEGMENTS");
            sb.Append(sep);

            for (int i = 0; i < segs; i++) {
                sb.AppendFormat("W "+i);
                sb.Append(sep);
            }
            sb.Append("SEGMENTS");
            sb.Append(sep);
            for (int i = 0; i < segs; i++)
            {
                sb.AppendFormat("WIA "+i);
                sb.Append(sep);
            }

            return sb.ToString();
        }
    }
}
