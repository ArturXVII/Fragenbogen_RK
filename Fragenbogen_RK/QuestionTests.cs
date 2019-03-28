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
