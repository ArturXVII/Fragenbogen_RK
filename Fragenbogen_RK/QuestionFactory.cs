using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fragenbogen_RK
{
    class QuestionFactory
    {
        public Question MapQuestion(Fragenbogen_RK.Fragen tquestion, List<Antworten> tanswers)
        {
            return new Question(tquestion.P_Id,tquestion.Frage,MapAnswers(tanswers))
            {

                id = tquestion.P_Id,
                question = tquestion.Frage,
                answers = MapAnswers(tquestion.Antwortens)
        };
        }

        public List<Answer> MapAnswers(ICollection<Fragenbogen_RK.Antworten> tanswers)
        {
            List<Answer> answers = new List<Answer>();
            if (tanswers != null)
            {
                foreach (var answer in tanswers)
                {
                    answers.Add(new Answer(answer.P_Id, answer.Antwort, answer.Richtig));
                }
            }
            else { return null; }
            return answers;
        }
    }
}
