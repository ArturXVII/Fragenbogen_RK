using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fragenbogen_RK
{
    class QuestionManagement
    {
        EHFragenEntities questionEntitie = new EHFragenEntities();
        Antworten answerEntitie = new Antworten();

        QuestionFactory questions = new QuestionFactory();

        public Question getQuestionById(int id)
        {
            var question = questionEntitie.Fragens.Where(x => (x.P_Id == id)).FirstOrDefault();
            var answers = questionEntitie.Antwortens.Where(x => (x.P_Id == id)).ToList();

            if(question!= null)
            {
                return questions.MapQuestion(question, answers);
            }
            else
            {
                throw new Exception("Keine Frage zur Id gefunden.");
            }
        }
    }
}
