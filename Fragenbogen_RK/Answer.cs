using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fragenbogen_RK
{
    class Answer
    {
        int id;
        string answer;
        bool correct;

        public Answer(int id, string answer, bool correct)
        {
            this.id = id;
            this.answer = answer;
            this.correct = correct;
        }

        public string GetAnswer()
        {
            return answer;
        }

        public bool IsCorrect()
        {
            return correct;
        }
    }
}
