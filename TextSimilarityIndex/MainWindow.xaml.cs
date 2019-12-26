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

namespace TextSimilarityIndex
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.TextBlock.Text = "КСТ=" + Controller.CalculateSimTextIndex(LeftBox.Text, RightBox.Text).ToString();
        }
    }

    public static class Controller
    {
        /// <summary>
        /// Вычисление коэффициента совпадения двух текстов
        /// </summary>
        /// <param name="TextLeft"></param>
        /// <param name="TextRight"></param>
        /// <returns></returns>
        public static double CalculateSimTextIndex(string textLeft, string textRight)
        {
            double  simIndex = 0;


            return simIndex;

        }

        /// <summary>
        /// Список слов из текста, с количеством вхождений каждого слова
        /// </summary>
        /// <param name="text"></param>
        static void SplitIntoWords (string text)
        {
            List<Word> TextList = new List<Word>();

        }
    }

    public class Word
    {
        public int Count { get; set; }
        public string Element { get; set; }
    }

    

}
