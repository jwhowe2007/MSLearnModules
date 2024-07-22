﻿string[] students = ["Sophia", "Andrew", "Emma", "Logan", "Becky", "Magnus", "Astrid", "Zoltan"];

int exams = 5;
decimal[][] studentExamScores = [
    [90, 86, 87, 98, 100, 94, 90], // Sophia
    [92, 89, 81, 96, 90, 89], // Andrew
    [90, 85, 87, 98, 68, 89, 89, 89], // Emma
    [90, 95, 87, 88, 96, 96], // Logan
    [92, 91, 90, 91, 92, 92, 92], // Becky
    [84, 86, 88, 90, 92, 94, 96, 98], // Magnus
    [80, 90, 100, 80, 90, 100, 80, 90], // Astrid
    [91, 91, 91, 91, 91, 91, 91] // Zoltan
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
