using FinalC_Quize.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalC_Quize.models
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int numberOfQuestions, int timeOfExam) : base(numberOfQuestions, timeOfExam) { }

        public override string ToString()
        {
            return $"Practical Exam: {NumberOfQuestions} Questions, {TimeOfExam} Minutes";
        }
    }

}
