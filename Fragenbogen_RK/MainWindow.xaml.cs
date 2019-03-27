using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fragenbogen_RK
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int score = 0;
        private int questionIndex = 1;
        private List<string> checkedAnswers;
        private CheckBox[] chkBoxes;
        private TextBox[] lblPruefs;
        private List<Question> questionSet;
        public MainWindow()
        {
            InitializeComponent();
            chkBoxes = new CheckBox[]{ chkA, chkB, chkC, chkD };
            QuestionManagement qm = new QuestionManagement();
            questionSet = qm.getQuestionSet();
            SetQuiz(0);
        }

        private void SetQuiz(int i)
        {
            foreach (CheckBox chk in chkBoxes)
            {
                chk.IsChecked = false;
                chk.IsEnabled = true;
                chk.Foreground = new SolidColorBrush(Colors.Black);
            }
            checkedAnswers = new List<string>();
            lblFrage.Content = "Frage " + questionIndex + ": " + questionSet[i].question;
            SetQuestions(questionSet[i].answers);
        }

        private void SetQuestions(List<Answer> answers)
        {
            for (int i = 0; i < answers.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        chkA.Content = answers[i].GetAnswer();
                        break;
                    case 1:
                        chkB.Content = answers[i].GetAnswer();
                        break;
                    case 2:
                        chkC.Content = answers[i].GetAnswer();
                        break;
                    case 3:
                        chkD.Content = answers[i].GetAnswer();
                        break;
                }
            }
        }

        private void Reset()
        {
            lblFrage.Visibility = Visibility.Visible;
            brdHeadline.Visibility = Visibility.Visible;
            foreach (CheckBox chk in chkBoxes)
            {
                chk.Visibility = Visibility.Visible;
            }
            lblScore.Visibility = Visibility.Hidden;
            lblScore.Content = "";
            btnWeiter.Content = "Prüfen";
            QuestionManagement qm = new QuestionManagement();
            questionSet = qm.getQuestionSet();
            score = 0;
            questionIndex = 1;
            SetQuiz(questionIndex);
        }

        private void ShowScore()
        {
            lblFrage.Visibility = Visibility.Hidden;
            brdHeadline.Visibility = Visibility.Hidden;
            foreach (CheckBox chk in chkBoxes)
            {
                chk.Visibility = Visibility.Hidden;
            }
            lblScore.Visibility = Visibility.Visible;
            lblScore.Content = "Score: " + score + "/" + questionSet.Count * 100;
            btnWeiter.Content = "Wieder versuchen";
        }

        private string[] GetCorrectAnswers(int index)
        {
            List<string> answers = new List<string>();
            foreach (Answer a in questionSet[index].answers)
            {
                if (a.IsCorrect()) answers.Add(a.GetAnswer());
            }
            foreach (string a in answers)
            {
                Console.WriteLine(a);
            }

            return answers.ToArray<string>();
        }

        private void btnWeiter_Click(object sender, RoutedEventArgs e)
        {
            switch (btnWeiter.Content.ToString())
            {
                case "Weiter":
                    btnWeiter.Content = "Prüfen";
                    if (questionIndex == questionSet.Count - 1)
                    {
                        ShowScore();
                        return;
                    }
                    questionIndex++;
                    SetQuiz(questionIndex-1);
                    break;
                case "Prüfen":
                    foreach (CheckBox chk in chkBoxes)
                    {
                        chk.IsEnabled = false;
                    }
                    int tempScore = 0;
                    int multiplikator = 1;
                    if ((bool)chkA.IsChecked) checkedAnswers.Add(chkA.Content.ToString());
                    if ((bool)chkB.IsChecked) checkedAnswers.Add(chkB.Content.ToString());
                    if ((bool)chkC.IsChecked) checkedAnswers.Add(chkC.Content.ToString());
                    if ((bool)chkD.IsChecked) checkedAnswers.Add(chkD.Content.ToString());
                    for (int i = 0; i < chkBoxes.Length; i++)
                    {
                        string[] correctAnswers = GetCorrectAnswers(questionIndex-1);
                        if ((bool)chkBoxes[i].IsChecked)
                        {
                            if (Array.IndexOf(correctAnswers, chkBoxes[i].Content) <= -1)
                            {
                                multiplikator = 0;
                                chkBoxes[i].Content += " X";
                                chkBoxes[i].Foreground = new SolidColorBrush(Colors.Red);
                            }
                            else
                            {
                                tempScore += 100 / correctAnswers.Length;
                                chkBoxes[i].Content += " ✔";
                                chkBoxes[i].Foreground = new SolidColorBrush(Colors.Green);
                            }
                        }
                        else if (!(Array.IndexOf(correctAnswers, chkBoxes[i].Content) <= -1))
                        {
                            chkBoxes[i].Content += " ✔";
                            chkBoxes[i].Foreground = new SolidColorBrush(Colors.Green);
                        }
                    }
                    score += tempScore * multiplikator;
                    btnWeiter.Content = "Weiter";
                    break;
                case "Wieder versuchen":
                    Reset();
                    break;
            }
            
        }
    }
}
