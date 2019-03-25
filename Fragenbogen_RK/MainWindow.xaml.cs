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
        private GUIController controller;
        private int score = 0;
        private int questionIndex = 1;
        private List<string> checkedAnswers;
        private CheckBox[] chkBoxes;
        private TextBox[] lblPruefs;
        public MainWindow()
        {
            InitializeComponent();
            controller = new GUIController();
            chkBoxes = new CheckBox[]{ chkA, chkB, chkC, chkD };
            lblPruefs = new TextBox[] { lblPruefA, lblPruefB, lblPruefC, lblPruefD };
            SetQuiz(0);
        }

        private void SetQuiz(int i)
        {
            chkA.IsChecked = false;
            chkB.IsChecked = false;
            chkC.IsChecked = false;
            chkD.IsChecked = false;
            checkedAnswers = new List<string>();
            lblFrage.Content = "Frage " + questionIndex + ": " + controller.GetQuestion(i);
            SetQuestions(controller.GetAnswers(i));
        }

        private void SetQuestions(string[] questions)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        chkA.Content = questions[i];
                        break;
                    case 1:
                        chkB.Content = questions[i];
                        break;
                    case 2:
                        chkC.Content = questions[i];
                        break;
                    case 3:
                        chkD.Content = questions[i];
                        break;
                }
            }
        }

        private void btnWeiter_Click(object sender, RoutedEventArgs e)
        {
            if (btnWeiter.Content.ToString() == "Weiter")
            {
                btnWeiter.Content = "Prüfen";
                questionIndex++;
                SetQuiz(questionIndex);
                return;
            }
            if ((bool)chkA.IsChecked) checkedAnswers.Add(chkA.Content.ToString());
            if ((bool)chkB.IsChecked) checkedAnswers.Add(chkB.Content.ToString());
            if ((bool)chkC.IsChecked) checkedAnswers.Add(chkC.Content.ToString());
            if ((bool)chkD.IsChecked) checkedAnswers.Add(chkD.Content.ToString());
            for (int i = 0; i < chkBoxes.Length; i++)
            {
                string[] correctAnswers = controller.GetCorrectAnswers(questionIndex);
                if (Array.IndexOf(correctAnswers, chkBoxes[i].Content) <= -1)
                {
                    lblPruefs[i].Text = "X";
                }
                else lblPruefs[i].Text = "✔";
            }
            btnWeiter.Content = "Weiter";
        }

        private void chkA_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void chkB_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void chkC_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void chkD_Checked(object sender, RoutedEventArgs e)
        {
        }
    }
}
