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

        public List<Question> getQuestionSet()
        {
            Random rnd = new Random();
            List<Question> results=new List<Question>();
            var amount = questionEntitie.Fragens.Max(x => (x.P_Id));
            List<int> used = new List<int>();
            for(int i=0; i < 10; i++)
            {
                int id = rnd.Next(amount+1);
                while (!used.Contains(id))
                {
                    var entry = getQuestionById(id);
                    used.Add(id);
                    if (entry != null)
                    {

                        results.Add(entry);
                    }
                    else
                    {

                        throw new Exception("Keine Frage zur Id gefunden");
                    }
                }
            }
            return results;
        }

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
                return null;
            }
        }
    }
}
