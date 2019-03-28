using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fragenbogen_RK
{
    [TestClass]
    public class QuestionTests
    {

        [TestMethod]
        public void QuestionFactory_MapAnswers_ReturnValue()
        {
            EHFragenEntities ehfEntitie = new EHFragenEntities();
            QuestionFactory qFactory = new QuestionFactory();

            List<Antworten> antworten = ehfEntitie.Antwortens.Where(x => (x.P_Id == 1)).ToList();
            List<Answer> answerList = qFactory.MapAnswers(antworten);

            Assert.AreEqual(answerList[0].GetAnswer(), "122");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void QuestionFactory_MapAnswersNull_Return_NullReferenceException()
        {
            QuestionFactory qFactory = new QuestionFactory();

            List<Answer> answerList = qFactory.MapAnswers(null);

            String s = answerList[0].GetAnswer();
        }

        [TestMethod]
        public void QuestionFactory_MapQuestion_ReturnValueObject()
        {
            EHFragenEntities ehfEntitie = new EHFragenEntities();
            QuestionFactory qFactory = new QuestionFactory();
            QuestionManagement qManager = new QuestionManagement();
            Question managerQ = qManager.getQuestionById(1);

            Fragenbogen_RK.Fragen fragen = ehfEntitie.Fragens.Where(x => (x.P_Id == 1)).FirstOrDefault();
            List<Antworten> antworten = ehfEntitie.Antwortens.Where(x => (x.P_Id == 1)).ToList();

            Question factoryQ = qFactory.MapQuestion(fragen, antworten);

            Assert.AreEqual(factoryQ.question, managerQ.question);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void QuestionFactory_MapQuestionNull_Return_NullReferenceException()
        {
            QuestionFactory qFactory = new QuestionFactory();

            Question factoryQ = qFactory.MapQuestion(null, null);

            String s = factoryQ.question;
        }

        [TestMethod]
        public void QuestionManagement_getQuestionByIdTest_ReturnValue()
        {
            QuestionManagement qManager = new QuestionManagement();
            Question q = qManager.getQuestionById(1);

            Assert.AreEqual(q.answers[0].GetAnswer(), "122");
            Assert.AreEqual(q.answers[1].GetAnswer(), "133");
            Assert.AreEqual(q.answers[2].GetAnswer(), "144");
            Assert.AreEqual(q.answers[3].GetAnswer(), "112");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void QuestionManagement_getQuestionById0Test_Return_NullReferenceException()
        {
            QuestionManagement qManager = new QuestionManagement();
            Question q = qManager.getQuestionById(0);

            Assert.IsNotNull(q.question);
        }

        [TestMethod]
        public void QuestionManagement_QuestionSet_ReturnValues()
        {
            QuestionManagement qManager = new QuestionManagement();

            List<Question> qList = qManager.getQuestionSet();
            List<Question> qBeforeList = new List<Question>();

            foreach (Question q in qList)
            {
                Assert.IsFalse(qBeforeList.Contains(q));
                Assert.AreNotEqual(q.question, "");
                Assert.AreNotEqual(q.question, null);
                qBeforeList.Add(q);
            }
        }


    }
}
