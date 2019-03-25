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
            switch (i)
            {
                case 1:
                    return "Ist zweite Hilfe auch noch ok?";
                case 2:
                    return "Wo helf ig am liebste?";
            }
            return "Woah something went wrong!";
        }

        public string[] GetAnswers(int i)
        {
            switch (i) {
                case 1:
                    return new string[]{ "Item1", "Item2", "Item3", "Item4" };
                case 2:
                    return new string[]{ "Berlin", "Paris", "Rom", "Washington"};
            }
            return new string[]{ "Item1", "Item2", "Item3", "Item4" };
        }

        public string[] GetCorrectAnswers(int i)
        {
            switch (i)
            {
                case 1:
                    return new string[] { "Item1", "Item2" };
                case 2:
                    return new string[] { "Berlin" };
            }
            return new string[] { "Item1" };
        }

        public Boolean IsCorrect(int i, List<string> answers)
        {
            string[] correctAnswers = GetCorrectAnswers(i);
            if (correctAnswers.Length != answers.Count) return false;
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
