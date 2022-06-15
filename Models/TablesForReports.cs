namespace AssessmentAssistant.Models
{
    public class TablesForReports
    {
        public static Dictionary<string, int> GradesDictionary()
        {
            return new Dictionary<string, int>()
            {
                { "A Grades", 0 },
                { "B Grades", 0 },
                { "C Grades", 0 },
                { "D Grades", 0 },
                { "F Grades", 0 },
                { "W Grades", 0 },
                { "Total", 0 }
            };
        }
        public static Dictionary<string, MeasuresTable> MeasuresDictionary() {

            // key is course outcome number
            // value is MeasuresTable
            return new Dictionary<string, MeasuresTable>();
        }

        public static Dictionary<string, MeasuresTable> FillMeasuresDictionary(string mp, long courseid, 
            List<CourseOutcome> outcomes, 
            List<CourseOffering> offerings,
            List<OutcomeMeasure> measures)
        {
            Dictionary<string, MeasuresTable> dict = TablesForReports.MeasuresDictionary();

            string outcomeid = "";
            // First filter all the inputs on conditions

            // Filter outcomes on courseid and measurement period
            outcomes = outcomes
                .Where(outcome => outcome.AcademicCourseId == courseid)
                .Where(outcome => outcome.MeasurementPeriod == mp)
                .ToList();

            offerings = offerings
                .Where(offering => offering.AcademicCourseId == courseid)
                .Where(offering => offering.MeasurementPeriod == mp)
                .ToList();

            // Also need to filter list on only those assoicated with the courseofferings
            measures = measures
                .Where(measure => measure.MeasurementPeriod == mp)
                .Where(measure => offerings.Any(offering => offering.CourseOfferingId.Equals(measure.CourseOfferingId)))
                .ToList();

            // Challenge here is mulitple offerings and multiple measures for each outcome 

            foreach (var outcome in outcomes)
            {
                foreach (var offering in offerings)
                {
                    foreach (var measure in measures)
                    {
                        outcomeid = outcome.CourseOutcomeId.ToString() +
                           "-" + offering.CourseOfferingId.ToString() +
                           "-" + measure.OutcomeMeasureId.ToString();

                            dict.Add(outcomeid, new MeasuresTable()
                        {
                            CourseOutcome = outcomeid,
                            CourseOutcomeNumber = outcome.OutcomeNumber.ToString(),
                            CourseOutcomeStatement = outcome.OutcomeStatement,
                            ProgramOutcomeNumber = outcome.ProgramOutcomeNumber.ToString(),
                            MeasurementPeriod = outcome.MeasurementPeriod
                        });
                        
                        if (measure.CourseOutcomeNumber == outcome.OutcomeNumber)
                        {
                            dict[outcomeid].AssessmentType = measure.AssessmentType;
                            dict[outcomeid].AssessmentMeasure = measure.MeasurementStatement;
                            dict[outcomeid].N = (int)measure.NumberMeasured;
                            dict[outcomeid].Threshold = (int)measure.ThresholdValue;
                            dict[outcomeid].N_AboveThreshold = (int)measure.NumberMeetingThreshold;
                            if (dict[outcomeid].N != 0) dict[outcomeid].Percent_N_Above_Threshold = 100.0 * dict[outcomeid].N_AboveThreshold / dict[outcomeid].N;
                        }
                    }
                }
            }

            // Now remove any dictionary where the N = 0
            List<string> remove = new List<string>();
            foreach (var item in dict) if (item.Value.N == 0) remove.Add(item.Key);
            foreach (var item in remove) dict.Remove(item);

            return dict;
        }

        public static void FillGrades(List<CourseOffering> CourseOfferings, Dictionary<string, int> Grades)
        {
            foreach (var course in CourseOfferings)
            {
                Grades["A Grades"] += (course.Number_A == null ? 0 : (int)course.Number_A);
                Grades["B Grades"] += (course.Number_B == null ? 0 : (int)course.Number_B);
                Grades["C Grades"] += (course.Number_C == null ? 0 : (int)course.Number_C);
                Grades["D Grades"] += (course.Number_D == null ? 0 : (int)course.Number_D);
                Grades["F Grades"] += (course.Number_F == null ? 0 : (int)course.Number_F);
                Grades["W Grades"] += (course.Number_W == null ? 0 : (int)course.Number_W);
                Grades["Total"] += Grades["A Grades"] + Grades["B Grades"] + Grades["C Grades"] + Grades["D Grades"] + Grades["F Grades"] + Grades["W Grades"];
            }
        }

    } // end TablesForReports

    public class MeasuresTable
    {
        public string CourseOutcome { get; set; }
        public string CourseOutcomeNumber { get; set; }
        public string CourseOutcomeStatement { get; set; }
        public string ProgramOutcomeNumber { get; set; }
        public string AssessmentType { get; set; }
        public string AssessmentMeasure { get; set; }
        public int N { get; set;}
        public float Threshold { get; set; }    
        public int N_AboveThreshold { get; set; }
        public double Percent_N_Above_Threshold { get; set; }   
        public string MeasurementPeriod { get; set; }

        public void MeasureTable()
        {
            CourseOutcome = "";
            CourseOutcomeStatement = "";
            ProgramOutcomeNumber = "";
            AssessmentType = "";
            AssessmentMeasure = "";
        }

        
    }
} // End Namespace
