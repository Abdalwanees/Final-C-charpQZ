using FinalC_Quize.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalC_Quize.models
{
    public abstract class Exam : ICloneable, IComparable<Exam>
    {
        public Question[] Questions;
        public int NumberOfQuestions { get; set; }
        public int TimeOfExam { get; set; }

        public Exam(int numberOfQuestions, int timeOfExam)
        {
            NumberOfQuestions = numberOfQuestions;
            TimeOfExam = timeOfExam;
            Questions = new Question[numberOfQuestions];
        }

        public void AddQuestion(Question question)
        {
            for (int i = 0; i < Questions.Length; i++)
            {
                if (Questions[i] == null)
                {
                    Questions[i] = question;
                    return;
                }
            }
            Console.WriteLine("Cannot add more questions.");
        }

        public object Clone()
        {
            var clone = (Exam)this.MemberwiseClone();
            clone.Questions = (Question[])this.Questions.Clone();
            return clone;
        }

        public int CompareTo(Exam? other)
        {
            if (other == null) return 1;
            return this.NumberOfQuestions.CompareTo(other.NumberOfQuestions);
        }

        public override string ToString()
        {
            return $"Exam: {NumberOfQuestions} Questions, {TimeOfExam} Minutes";
        }
    }

}
