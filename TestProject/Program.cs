string[] students = ["Sophia", "Andrew", "Emma", "Logan", "Becky", "Magnus", "Astrid", "Zoltan"];

int exams = 5;
Dictionary<String, decimal[]> studentExamScoreResults = new()
{
    {"Sophia", [90, 96, 87, 98, 100, 94, 90]},
    {"Andrew", [92, 89, 81, 96, 90, 89]},
    {"Emma",   [90, 80, 70, 60, 50, 100, 100, 100, 100, 100]},
    {"Logan",  [90, 95, 87, 88, 96, 96]},
    {"Becky",  [92, 91, 90, 91, 92, 92, 92]},
    {"Magnus", [84, 56, 88, 50, 52, 54, 96, 98]},
    {"Astrid", [80, 90, 100, 80, 90, 100, 80, 90]},
    {"Zoltan", [61, 61, 61, 61, 51, 61, 61]}
};

static decimal listSum(decimal[] list) {
    decimal sum = 0;

    foreach (decimal listItem in list) {
        sum += listItem;
    }

    return sum;
}

Console.WriteLine("Student\t\tGrade");

int studentID = 0;
foreach (String studentName in students) {
    decimal[] examScores = studentExamScoreResults[studentName];
    for (int i = exams; i < examScores.Length; i++) {
        examScores[i] = (int)(examScores[i] * 0.1m);
    }

    // Each entry is a student's list of exam scores
    decimal studentExamAverage = listSum(examScores) / (decimal)exams;
    string examAvgLetterGrade = "F";

    if (studentExamAverage >= 97) {
        examAvgLetterGrade = "A+";
    } else if (studentExamAverage >= 93) {
        examAvgLetterGrade = "A";
    } else if (studentExamAverage >= 90) {
        examAvgLetterGrade = "A-";
    } else if (studentExamAverage >= 87) {
        examAvgLetterGrade = "B+";
    } else if (studentExamAverage >= 83) {
        examAvgLetterGrade = "B";
    } else if (studentExamAverage >= 80) {
        examAvgLetterGrade = "B-";
    } else if (studentExamAverage >= 77) {
        examAvgLetterGrade = "C+";
    } else if (studentExamAverage >= 73) {
        examAvgLetterGrade = "C";
    } else if (studentExamAverage >= 70) {
        examAvgLetterGrade = "C-";
    } else if (studentExamAverage >= 67) {
        examAvgLetterGrade = "D+";
    } else if (studentExamAverage >= 63) {
        examAvgLetterGrade = "D";
    } else if (studentExamAverage >= 60) {
        examAvgLetterGrade = "D-";
    }

    Console.WriteLine($"{students[studentID++]}:\t\t{studentExamAverage}\t{examAvgLetterGrade}");
}
