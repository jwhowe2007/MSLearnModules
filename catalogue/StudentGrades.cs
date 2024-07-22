string[] students = ["Sophia", "Andrew", "Emma", "Logan"];

int exams = 5;
Dictionary<String, decimal[]> studentExamScoreResults = new()
{
    {"Sophia", [90, 86, 87, 98, 100, 94, 90]},
    {"Andrew", [92, 89, 81, 96, 90, 89]},
    {"Emma",   [90, 85, 87, 98, 68, 89, 89, 89]},
    {"Logan",  [90, 95, 87, 88, 96, 96]},
};

/*
 * Computes the sum of a list with optional lowerLimit and upperLimit, which totals a select slice of the given array.
 * If the upperLimit is blank or 0, set the max count to the length of the array.
 */
static decimal listSum(decimal[] list, int lowerLimit, int upperLimit) {
    decimal sum = 0.00m;

    int max = upperLimit == 0 ? list.Length : upperLimit;
    int min = lowerLimit;

    for (int index = min; index < max; index++) {
        sum += list[index];
    }

    return sum;
}

Console.WriteLine("Student\t\tExam Score\tOverall\t\tGrade\t\tExtra Credit");

int studentID = 0;
foreach (String studentName in students) {
    decimal[] examScores = studentExamScoreResults[studentName];

    // Each entry is a student's list of exam scores
    decimal studentExamAverage = listSum(examScores, 0, exams) / (decimal)exams;

    // Extra credit scores get a weight of 10% of the extra credit score total.
    decimal extraCreditScores = listSum(examScores, exams, 0) * 0.1m;

    // Overall average grade including extra credit, used to calculate letter grade
    decimal overallExamGrade = (listSum(examScores, 0, exams) + extraCreditScores) / (decimal)exams;

    // Extra credit scores - average is the unweighted extra credit score divided by the number of extra credit assignments completed.
    decimal extraCreditAverage = extraCreditScores * 10 / (decimal)(examScores.Length - exams);
    decimal extraCreditPoints = extraCreditScores / (decimal)exams;

    string examAvgLetterGrade = "F";

    if (overallExamGrade >= 97) {
        examAvgLetterGrade = "A+";
    } else if (overallExamGrade >= 93) {
        examAvgLetterGrade = "A";
    } else if (overallExamGrade >= 90) {
        examAvgLetterGrade = "A-";
    } else if (overallExamGrade >= 87) {
        examAvgLetterGrade = "B+";
    } else if (overallExamGrade >= 83) {
        examAvgLetterGrade = "B";
    } else if (overallExamGrade >= 80) {
        examAvgLetterGrade = "B-";
    } else if (overallExamGrade >= 77) {
        examAvgLetterGrade = "C+";
    } else if (overallExamGrade >= 73) {
        examAvgLetterGrade = "C";
    } else if (overallExamGrade >= 70) {
        examAvgLetterGrade = "C-";
    } else if (overallExamGrade >= 67) {
        examAvgLetterGrade = "D+";
    } else if (overallExamGrade >= 63) {
        examAvgLetterGrade = "D";
    } else if (overallExamGrade >= 60) {
        examAvgLetterGrade = "D-";
    }

    Console.WriteLine($"{students[studentID++]}:\t\t{studentExamAverage}\t\t{overallExamGrade}\t\t{examAvgLetterGrade}\t\t{extraCreditAverage} ({extraCreditPoints} pts)");
}
