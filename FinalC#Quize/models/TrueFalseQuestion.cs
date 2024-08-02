using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalC_Quize.models
{
    public class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set; }
        public int RightAnswerId { get; set; }

        public TrueFalseQuestion(string header, string body, int mark, Answer[] tfAnswers, int rightAnswerId, bool correctAnswer)
            : base(header, body, mark)
        {
            CorrectAnswer = correctAnswer;
            RightAnswerId = rightAnswerId;
        }

        public override string ToString()
        {
            string correct = CorrectAnswer ? "True" : "False";
            return base.ToString() + $", Correct Answer: {correct}";
        }
    }

}
