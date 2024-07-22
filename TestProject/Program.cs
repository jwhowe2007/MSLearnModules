string[] students = ["Sophia", "Andrew", "Emma", "Logan"];

int exams = 5;
decimal[][] studentExamScores = [
    [90, 86, 87, 98, 100, 94, 90],
    [92, 89, 81, 96, 90, 89],
    [90, 85, 87, 98, 68, 89, 89, 89],
    [90, 95, 87, 88, 96, 96]
];

static decimal listSum(decimal[] list) {
    decimal sum = 0;

    foreach (decimal listItem in list) {
        sum += listItem;
    }

    return sum;
}

Console.WriteLine("Student\t\tGrade");

int studentID = 0;
foreach (decimal[] examScores in studentExamScores) {
    for (int i = exams; i < examScores.Length; i++) {
        examScores[i] = (int)(examScores[i] * 0.1m);
    }

    // Each entry is a student's list of exam scores
    decimal studentExamAverage = listSum(examScores) / (decimal)exams;
    string examAvgLetterGrade = "F";

    if (studentExamAverage >= 97 && studentExamAverage <= 100) {
        examAvgLetterGrade = "A+";
    } else if (studentExamAverage >= 93 && studentExamAverage < 97) {
        examAvgLetterGrade = "A";
    } else if (studentExamAverage >= 90 && studentExamAverage < 93) {
        examAvgLetterGrade = "A-";
    } else if (studentExamAverage >= 87 && studentExamAverage < 90) {
        examAvgLetterGrade = "B+";
    } else if (studentExamAverage >= 83 && studentExamAverage < 87) {
        examAvgLetterGrade = "B";
    } else if (studentExamAverage >= 80 && studentExamAverage < 83) {
        examAvgLetterGrade = "B-";
    } else if (studentExamAverage >= 77 && studentExamAverage < 80) {
        examAvgLetterGrade = "C+";
    } else if (studentExamAverage >= 73 && studentExamAverage < 77) {
        examAvgLetterGrade = "C";
    } else if (studentExamAverage >= 70 && studentExamAverage < 73) {
        examAvgLetterGrade = "C-";
    } else if (studentExamAverage >= 67 && studentExamAverage < 70) {
        examAvgLetterGrade = "D+";
    } else if (studentExamAverage >= 63 && studentExamAverage < 67) {
        examAvgLetterGrade = "D";
    } else if (studentExamAverage >= 60 && studentExamAverage < 63) {
        examAvgLetterGrade = "D-";
    }

    Console.WriteLine($"{students[studentID++]}:\t\t{studentExamAverage}\t{examAvgLetterGrade}");
}
