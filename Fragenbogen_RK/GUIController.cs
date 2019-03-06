using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fragenbogen_RK
{
    class GUIController
    {
        public string GetQuestion(int i)
        {
            return "Ist zweite Hilfe auch noch ok?";
        }

        public string[] GetAnswers(int i)
        {
            string[] items = { "Item1", "Item2", "Item3", "Item4" };
            return items;
        }

        public Boolean IsCorrect(int i, string[] answers)
        {
            string[] correctAnswers = {"Item1", "Item2"};
            if (correctAnswers.Length != answers.Length) return false;
            foreach (string answer in answers)
            {
                if (Array.IndexOf(correctAnswers, answer) <= -1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
