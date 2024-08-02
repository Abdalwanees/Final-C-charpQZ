using FinalC_Quize.Controller;
using FinalC_Quize.models;

namespace FinalC_Quize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = null;
            Exam exam;
            ExamType examType;

            #region Choice type of exam

            while (true)
            {
                Console.WriteLine("Enter the type of exam.\n(1) Final.\n(2) Practical.");
                Console.Write("Your Choice: ");
                string input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int examTypeInput))
                {
                    if (examTypeInput == 1)
                    {
                        examType = ExamType.Final;
                        exam = new FinalExam(0, 0);
                        break;
                    }
                    else if (examTypeInput == 2)
                    {
                        examType = ExamType.Practical;
                        exam = new PracticalExam(0, 0);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter 1 for Final or 2 for Practical.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number (1 or 2).");
                }
            }

            #endregion

            Console.Clear();

            #region Enter Time
            Console.WriteLine("Enter the time of the exam (in minutes):");
            int timeOfExam;
            while (!int.TryParse(Console.ReadLine(), out timeOfExam) || timeOfExam <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid number greater than 0 for the time of the exam.");
                Console.Write("Time : ");
            }
            #endregion

            Console.Clear();

            #region Number Of Questions
            Console.WriteLine("Enter the number of questions:");
            int numberOfQuestions;
            while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || numberOfQuestions <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid number greater than 0 for the number of questions.");
                Console.Write("Number of questions:");
            }
            #endregion

            Console.Clear();

            #region  Reinitialize exam with correct number of questions and time

            if (examType == ExamType.Final)
            {
                exam = new FinalExam(numberOfQuestions, timeOfExam);
            }
            else
            {
                exam = new PracticalExam(numberOfQuestions, timeOfExam);
            }

            #endregion

            #region Questions details
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine($"Enter details for question {i + 1}:");
                Console.WriteLine("Enter the header of the question:");
                string header = Console.ReadLine();

                Console.WriteLine("Enter the body of the question:");
                string body = Console.ReadLine();

                Console.WriteLine("Enter the mark for the question:");
                int mark;
                while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number greater than 0 for the mark.");
                }

                if (examType == ExamType.Final)
                {
                    Console.WriteLine("Enter the type of question\n(1) TrueFalse\n(2) MCQ:");
                    Console.Write("Your Choice: ");
                    string questionTypeInput = Console.ReadLine();
                    int questionType;
                    while (!int.TryParse(questionTypeInput, out questionType) || (questionType != 1 && questionType != 2))
                    {
                        Console.WriteLine("Invalid input. Please enter 1 for TrueFalse or 2 for MCQ.");
                        questionTypeInput = Console.ReadLine();
                    }

                    if (questionType == 1)
                    {
                        Console.WriteLine("Enter the correct answer (True/False):");
                        bool correctAnswer;
                        while (!bool.TryParse(Console.ReadLine(), out correctAnswer))
                        {
                            Console.WriteLine("Invalid input. Please enter True or False.");
                        }

                        Answer[] tfAnswers = new Answer[]
                        {
                    new Answer(1, "True"),
                    new Answer(2, "False")
                        };
                        Question tfQuestion = new TrueFalseQuestion(header, body, mark, tfAnswers, correctAnswer ? 1 : 2, correctAnswer);
                        exam.AddQuestion(tfQuestion);
                    }
                    else if (questionType == 2)
                    {
                        Console.WriteLine("Enter the number of choices:");
                        int numChoices;
                        while (!int.TryParse(Console.ReadLine(), out numChoices) || numChoices <= 0)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number greater than 0 for the number of choices.");
                        }

                        Answer[] mcqAnswers = new Answer[numChoices];
                        string[] answerOptions = new string[numChoices];

                        for (int j = 0; j < numChoices; j++)
                        {
                            Console.WriteLine($"Enter text for choice {j + 1}:");
                            string choiceText = Console.ReadLine();
                            mcqAnswers[j] = new Answer(j + 1, choiceText);
                            answerOptions[j] = choiceText;
                        }

                        Console.WriteLine("Enter the correct answer index :");
                        int correctAnswerIndex;
                        while (!int.TryParse(Console.ReadLine(), out correctAnswerIndex) || correctAnswerIndex <= 0 || correctAnswerIndex > numChoices)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number within the range of choices for the correct answer index.");
                        }

                        Question mcqQuestion = new MCQQuestion(header, body, mark, mcqAnswers, correctAnswerIndex, answerOptions, correctAnswerIndex - 1);
                        exam.AddQuestion(mcqQuestion);
                    }
                }
                else if (examType == ExamType.Practical)
                {
                    Console.WriteLine("Enter the number of choices:");
                    int numChoices;
                    while (!int.TryParse(Console.ReadLine(), out numChoices) || numChoices <= 0)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number greater than 0 for the number of choices.");
                    }

                    Answer[] mcqAnswers = new Answer[numChoices];
                    string[] answerOptions = new string[numChoices];

                    for (int j = 0; j < numChoices; j++)
                    {
                        Console.WriteLine($"Enter text for choice {j + 1}:");
                        string choiceText = Console.ReadLine();
                        mcqAnswers[j] = new Answer(j + 1, choiceText);
                        answerOptions[j] = choiceText;
                    }

                    Console.WriteLine("Enter the correct answer index:");
                    int correctAnswerIndex;
                    while (!int.TryParse(Console.ReadLine(), out correctAnswerIndex) || correctAnswerIndex <= 0 || correctAnswerIndex > numChoices)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number within the range of choices for the correct answer index.");
                    }

                    Question mcqQuestion = new MCQQuestion(header, body, mark, mcqAnswers, correctAnswerIndex, answerOptions, correctAnswerIndex - 1);
                    exam.AddQuestion(mcqQuestion);
                }

                Console.Clear();
            } 
            #endregion

            Console.WriteLine("Enter the subject name:");
            string subjectName = Console.ReadLine();
            subject = new Subject(subjectName, exam);

            Console.WriteLine("\nExam Created Successfully!\n");
            SolveExam(exam);
        }

        #region Solve Exam Method

        static void SolveExam(Exam exam)
        {
            int totalScore = 0;
            int totalMarks = 0;

            foreach (var question in exam.Questions)
            {
                if (question != null)
                {
                    totalMarks += question.Mark;
                    Console.Clear();
                    Console.WriteLine($"Question: {question.Header}");
                    Console.WriteLine($"{question.Body} (Mark: {question.Mark})");

                    if (question is MCQQuestion mcq)
                    {
                        for (int i = 0; i < mcq.AnswerList.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {mcq.AnswerList[i].AnswerText}");
                        }

                        Console.Write("Enter your answer: ");
                        int userAnswer;
                        while (!int.TryParse(Console.ReadLine(), out userAnswer) || userAnswer <= 0 || userAnswer > mcq.AnswerList.Length)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number within the range of choices.");
                        }

                        if (userAnswer == mcq.RightAnswerId)
                        {
                            Console.WriteLine("Correct!");
                            totalScore += question.Mark;
                        }
                        else
                        {
                            Console.WriteLine("Wrong!");
                        }
                    }
                    else if (question is TrueFalseQuestion tf)
                    {
                        Console.WriteLine("1. True");
                        Console.WriteLine("2. False");

                        Console.Write("Enter your answer: ");
                        int userAnswer;
                        while (!int.TryParse(Console.ReadLine(), out userAnswer) || (userAnswer != 1 && userAnswer != 2))
                        {
                            Console.WriteLine("Invalid input. Please enter 1 for True or 2 for False.");
                        }

                        if (userAnswer == tf.RightAnswerId)
                        {
                            Console.WriteLine("Correct!");
                            totalScore += question.Mark;
                        }
                        else
                        {
                            Console.WriteLine("Wrong!");
                        }
                    }

                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                }
            }

            Console.Clear();
            Console.WriteLine("Exam completed!");
            Console.WriteLine($"Your score: {totalScore} out of {totalMarks}");

            double percentage = (double)totalScore / totalMarks * 100;
            Console.WriteLine($"Your grade: {percentage:F2}%");

            if (exam is FinalExam)
            {
                Console.WriteLine("Final Exam Details:");
                foreach (var question in exam.Questions)
                {
                    Console.WriteLine(question.ToString());
                }
            }
            else if (exam is PracticalExam)
            {
                Console.WriteLine("Practical Exam Answers:");
                foreach (var question in exam.Questions)
                {
                    if (question is MCQQuestion mcq)
                    {
                        Console.WriteLine($"Question: {question.Header}");
                        Console.WriteLine($"Correct Answer: {mcq.AnswerList[mcq.RightAnswerId - 1].AnswerText}");
                    }
                    else if (question is TrueFalseQuestion tf)
                    {
                        Console.WriteLine($"Question: {question.Header}");
                        Console.WriteLine($"Correct Answer: {(tf.CorrectAnswer ? "True" : "False")}");
                    }
                }
            }
        }

        #endregion
    }
}
