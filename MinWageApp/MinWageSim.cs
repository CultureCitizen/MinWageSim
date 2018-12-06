using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinWageApp {
    public static class Utils {
        public static double median(List<double> list) {
            int n = list.Count;
            if (n % 2 == 0) {
                int d1 = n / 2;
                int d2 = d1 + 1;
                return (list[d1] + list[d2]) / 2;
            } else {
                int d = n / 2;
                return list[d];
            }
        }
        /******************************************************************************************
         * Calculates the gini index given a list of income segments
         ******************************************************************************************/
        public static double calcGini(List<double> acumSegments) {
            List<double> pct = new List<double>();
            //goal area : represents perfect equallity
            double ab = acumSegments.Count()/2 + 0.5;
            double m = acumSegments.Max();

            //Area covered by the accumulated income segments
            for (int i = 0; i < acumSegments.Count; i++) {
                pct.Add(acumSegments[i] / m);
            }
            double b = pct.Sum();
            double a = ab - b;
            return a / ab;
        }

        /******************************************************************************************
         * Obtains the area covered by a trapezoid with the lower points in the x axis
         * and the upper points at located at (x1,y1) (x2, y2)  
         ******************************************************************************************/
        public static double segmentArea(double y1, double y2, double dx = 1) {
            return y1 * dx + (y2 - y1) * dx / 2;
        }

        /******************************************************************************************
         * Converts a coma delimited string into a list with decimals
         * Each number represents the average income for the population segment ( quintile, decile)
         * returns true if the string was successfully parsed
         ******************************************************************************************/
        public static bool fillIncome(string s, List<double> segments, bool addZero = false) {
            string[] values = { };

            if (!string.IsNullOrEmpty(s)) {
               values = s.Split(',');
            }
            segments.Clear();

            if (addZero) {
                segments.Add(0);
            }
            foreach (var v in values) {
                double f = 0;
                if (double.TryParse(v, out f)) {
                    segments.Add(f);
                } else {
                    segments.Clear();
                    return false;
                }
            }
            return true;
        }

        /******************************************************************************************
         * Divides a segment into several smaller segments (e.g. convert quintiles into deciles)
         * seggments = list with income segments
         * newSegments = the new segments created using linear interpolation
         * deltax = the x increments used to create the new segments
         ******************************************************************************************/
        public static void reshape(List<double> seg, List<double> newSegments, double max, double deltax = 1) {
            List<double> segments = new List<double>();
            segments.Add(0);
            segments.AddRange(seg);
            segments.Add(max);


            double maxx = Convert.ToDouble( segments.Count - 0.5);
            int xa = 0;
            int xb = 0;
            double x = 0;
            double y1;
            double y2;
            double y = 0;
            double maxSize = seg.Count / deltax;

            newSegments.Clear();
            x = 1 - deltax * 2;
            while (newSegments.Count < maxSize) {
                //take the values from the two enclosing segments
                xa = Convert.ToInt32(Math.Truncate(x));
                xb = xa + 1;
                x = x + deltax;

                y1 = segments[xa];
                y2 = segments[xb];
                double dx = x - xa;
                //interpolate
                y = y1 + (y2 - y1) * dx;
                newSegments.Add(y);
            }

        }

        /******************************************************************************************
         * Creates a list with the cumulative values from another list
         * seggments = list with income segments
         * acumSegments = the list with cumulative income  
         ******************************************************************************************/
        public static void acumulate(List<double> segments, List<double> acumSegments, bool addZero = false) {
            double acum = 0;
            acumSegments.Clear();
            if (addZero) {
                acumSegments.Add(0);
            }
            for (int i = 0; i < segments.Count; i++) {
                acum = acum + segments[i];
                acumSegments.Add(acum);
            }
        }
        public static double WageExpenditure(List<double> segments, double saveBase, double savePct) {
            double total = 0;
            for (int i = 0; i < segments.Count; i++) {
                double y = segments[i];
                if (y > saveBase)
                {
                    double save = y - saveBase;
                    save = save * savePct;
                    y = y - save;
                    total = total + y;
                }
                else {
                    total = total + y;
                }
            }
            return total;
        }
    }




    public class Simulation {
        private int _iteration = 0;

        public SimInput Input { get; set; }
        public SimOutput Output { get; set; } = new SimOutput();
        public int Iteration { get { return _iteration; } }
        public double Gdp0 { get; set; }
        public double Gini { get; set; }


        public void newCycle() {
            Input.StartWage.Clear();
            Input.StartWage.AddRange(Output.Segments);
            Output.Segments.Clear();
        }


        public Simulation(SimInput input) {
            Input = input;
            this._iteration = 0;
        }

        public double FindIncrement(SimInput si) {
            double deltaPct = 0;
            double maxValue = 0;
            double maxPct = 0;
            double baseInflation = 0;
            double infDelta = si.MaxInflationDelta;

            //Get the starting increment result = 0;
            SimInput oldInput = (SimInput)si.Clone();
            SimOutput oldOutput = new SimOutput();
            oldInput.MinIncAboveInf = 0;
            oldInput.CalcMode = CalcModeEnum.Manual;
            Simulation oldSim = new Simulation(oldInput);
            oldSim.Execute(false);
            oldOutput.FillFromInput(oldInput);

            deltaPct = -0.01;

            if (si.CalcMode == CalcModeEnum.MedianWage) {
                maxValue = oldOutput.MedianWageIA;
            } else if (si.CalcMode == CalcModeEnum.AverageWage) {
                maxValue = oldOutput.AverageWageIA;
            } else if (si.CalcMode == CalcModeEnum.Gini) {
                maxValue = 1 - oldOutput.Gini;
                deltaPct = 0.00;
            }

            
            baseInflation = oldOutput.Inflation;
            double maxInflation = baseInflation + infDelta;

            do{
                deltaPct = deltaPct + 0.005;
                if (deltaPct > 0.5) {
                    break;
                }
                SimOutput newOutput = new SimOutput();
                SimInput newInput = (SimInput)si.Clone();
                newInput.MinIncAboveInf = deltaPct;
                newInput.CalcMode = CalcModeEnum.Manual;
                Simulation sim = new Simulation(newInput);
                sim.Execute(false, CalcModeEnum.Manual);
                newOutput.FillFromInput(newInput);
                if (si.CalcMode == CalcModeEnum.MedianWage){
                    if (newOutput.MedianWageIA > maxValue && newOutput.Inflation <= maxInflation){
                        maxValue = newOutput.MedianWageIA;
                        maxPct = deltaPct;
                    }
                }else if (si.CalcMode == CalcModeEnum.AverageWage){
                    if (newOutput.AverageWageIA > maxValue && newOutput.Inflation <= maxInflation) {
                        maxValue = newOutput.AverageWageIA;
                        maxPct = deltaPct;
                    }
                }
                else if (si.CalcMode == CalcModeEnum.Gini) {
                    double gini_1 = 1 - newOutput.Gini;
                    if (gini_1 > maxValue && newOutput.Inflation <= maxInflation) {
                        maxValue = 1 - newOutput.Gini;
                        maxPct = deltaPct;
                    }
                }
            } while (true);
            return maxPct;
        }

        public void ApproxIncrement() {
            SimInput tmp = (SimInput)Input.Clone();

            double ratio = Input.Gdp / Input.WageExpenditure(Input.StartWage ) * (1 + Input.GenIncAboveInf);
            double deltaPct = Input.MaxGrowthPct * ratio;
            if (deltaPct > 0.25) {
                deltaPct = 0.25;
            }

            /*
            double high = 0.5m;
            double low = -0.5m;
            double deltaPct = (high + low) / 2;
            double maxDelta = Input.Gdp * (Input.MaxGrowthPct + 0.005m);
            double minDelta = Input.Gdp * (Input.MaxGrowthPct - 0.005m);
            while (true)
            {
                Input = (SimInput)tmp.Clone();
                Input.EstInflation = 0.01m;
                Input.MinIncAboveInf = deltaPct;
                Execute(false);
                double w1 = Input.WageExpenditure(Input.StartWage);
                double w2 = Input.WageExpenditure(Input.EndWage);
                double dw = (w2 - w1);
                if (dw > maxDelta)
                {
                    high = deltaPct;
                    deltaPct = (deltaPct + low) / 2;
                }
                else if (dw < minDelta)
                {
                    low = deltaPct;
                    deltaPct = (deltaPct + high) / 2;
                }
                else
                {
                    break;
                }
                if (low > 0.25m) {
                    deltaPct = 0.25m;
                    break;
                }
            }
            Input = (SimInput)tmp.Clone();
            */
            Input.MinIncAboveInf = deltaPct;
        }

        public void Execute(bool nop, CalcModeEnum calcMode) {

            if (nop == true)
            {
                Execute(nop);
            } else {
                if (calcMode == CalcModeEnum.Manual){
                    Execute(nop);
                } else {
                    double inc = FindIncrement(Input);
                    Input.MinIncAboveInf = inc;
                    Execute(nop);
                }
            }
        }
        /******************************************************************************************
         * Executes the simulation
         * p = Simulation parameters  
         ******************************************************************************************/
        public void Execute(bool nop) {
            Input.EndWage.Clear();

            if (nop) {
                Input.Reshape();
                Input.EndWage.AddRange(Input.StartWage);
                
            } else {

                double oldMinWage = Input.MinWage;
                double newMinWage = 0;
                double minWageInc = Input.MinIncAboveInf + Input.EstInflation;
                double genWageInc = Input.GenIncAboveInf + Input.EstInflation;
                double minGenDelta = minWageInc - genWageInc;
                newMinWage = Input.MinWage * (1 + minWageInc);

                int maxx = 0;
                double maxAffected = Input.MinWage * Input.DispFactor;

                double factor = 0;
                double dwPct = Input.GenIncAboveInf - minWageInc;
                Input.GetTopAffectedSegment(oldMinWage * Input.DispFactor, Input.TruncDisp, out maxx, out factor);
                
                //Increase the wages
                for (int i = 0; i < Input.StartWage.Count; i++) {
                    double y = Input.StartWage[i];
                    if (i <= maxx) {
                        if (y <= newMinWage && Input.EnforceMin) {
                            y = newMinWage;
                        } else {

                            //Get the ratio with respect to the maximum influence area
                            double wRatio = 1 - ((y - oldMinWage) / (maxAffected - oldMinWage));

                            if (wRatio > 1 || y < newMinWage) {
                                wRatio = 1;
                            }

                            if (wRatio < 0) {
                                wRatio = 0;
                            }
                            if (i == maxx && factor != 1) {
                                wRatio = wRatio * factor;
                            }

                            y = y * (1 + genWageInc + minGenDelta * wRatio);

                        }
                    } else {
                        y = y * (1 + genWageInc);
                    }
                    Input.EndWage.Add(y);
                }
                this.Input.MinWage = newMinWage;
            }
            _iteration++;

        }
               
      
    }
}
