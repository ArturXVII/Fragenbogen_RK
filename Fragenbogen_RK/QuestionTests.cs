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
        public void QuestionManagement_getQuestionByIdTests()
        {
            QuestionManagement qManager = new QuestionManagement();
            Question q = qManager.getQuestionById(1);

            Assert.AreEqual(q.answers[0].GetAnswer(), "122");
        }

        [TestMethod]
        public void QuestionManagement_QuestionSet()
        {
            QuestionManagement qManager = new QuestionManagement();

            List<Question> qList = qManager.getQuestionSet();

            foreach(Question q in qList)
            {
                Assert.AreNotEqual(q.question, "");
                Assert.AreNotEqual(q.question, null);
            }
        }
    }
}
