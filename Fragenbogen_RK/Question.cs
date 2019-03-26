using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fragenbogen_RK
{
    class Question
    {
        public int id;
        public string question;
        public List<Answer> answers = new List<Answer>();

        public Question(int id, string question, List<Answer> answers)
        {
            this.id = id;
            this.question = question;
            this.answers = answers;
        }
    }
}
