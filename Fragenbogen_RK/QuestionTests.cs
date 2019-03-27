using System;
using System.Collections.Generic;
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
        public void ShowAnswer()
        {
            //TODO
            QuestionManagement qManager = new QuestionManagement();
            var help = qManager.getQuestionById(1);

            Assert.AreEqual(help.answers[0].GetAnswer(), "122");

            

        } 
    }
}
