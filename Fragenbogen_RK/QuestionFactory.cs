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
                answers = MapAnswers(tanswers)
        };
        }

        public List<Answer> MapAnswers(List<Antworten> tanswers)
        {
            var answers = new List<Answer>();
            if (tanswers != null)
            {
                tanswers.ToList()
                           .ForEach(x => answers
                                    .Add(new Answer(x.P_Id, x.Antwort, x.Richtig)));
            }
            else { return null; }
            return answers;
        }
    }
}
