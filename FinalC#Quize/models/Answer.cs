using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalC_Quize.models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }

        public Answer(int id, string answerText)
        {
            Id = id;
            AnswerText = answerText;
        }
    }

}
