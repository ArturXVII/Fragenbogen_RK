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
        private string[] checkedAnswers;
        public MainWindow()
        {
            InitializeComponent();
            controller = new GUIController();
            SetQuiz(0);
        }

        private void SetQuiz(int i)
        {
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

        private void chkA_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnWeiter_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
