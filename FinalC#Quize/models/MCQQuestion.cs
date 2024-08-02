using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalC_Quize.models
{
    public class MCQQuestion : Question
    {
        public Answer[] AnswerList { get; set; }
        public int RightAnswerId { get; set; }
        public string[] AnswerOptions { get; set; }
        public int CorrectAnswerIndex { get; set; }

        public MCQQuestion(string header, string body, int mark, Answer[] answerList, int rightAnswerId, string[] answerOptions, int correctAnswerIndex)
            : base(header, body, mark)
        {
            AnswerList = answerList;
            RightAnswerId = rightAnswerId;
            AnswerOptions = answerOptions;
            CorrectAnswerIndex = correctAnswerIndex;
        }

        public override string ToString()
        {
            string answers = string.Join(", ", AnswerOptions);
            return base.ToString() + $", Answers: [{answers}], Right Answer ID: {RightAnswerId}";
        }
    }

}
