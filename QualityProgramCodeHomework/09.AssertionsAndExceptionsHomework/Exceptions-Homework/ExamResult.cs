using System;

public class ExamResult
{
    int grade, minGrade, maxGrade;
    string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MaxGrade = maxGrade;
        this.MinGrade = minGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Grade cannot be less than zero.");
            }
            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }
        private set
        {
            if (minGrade < 0)
            {
                throw new ArgumentException("MinGrade cannot be less than zero.");
            }
            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }
        private set
        {
            if (value <= this.minGrade)
            {
                throw new ArgumentException("MaxGrade cannot be less then MinGrade.");
            }
            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }
        private set
        {
            if (value == null || value == "")
            {
                throw new Exception();
            }
            this.comments = value;
        }
    }
}
