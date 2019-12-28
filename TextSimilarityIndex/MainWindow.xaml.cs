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
            
            List<Word> leftList = new List<Word>().SplitIntoWords(textLeft).OrderBy(p => p.Element).ToList();
            List<Word> rightList = new List<Word>().SplitIntoWords(textRight).OrderBy(p => p.Element).ToList();
            //подсчет совпадений меньшего списка в большем
            long simCount = 0; //число совпадений
           if (leftList.Sum(n=>n.Count) < rightList.Sum(n => n.Count))
            {
                IEnumerable<string> simElenents =  leftList.Select(n => n.Element).ToArray().Intersect(rightList.Select(n => n.Element).ToArray()); //массив совпадающих названий
            }

            return simIndex;

        }

        /// <summary>
        /// Список слов из текста, с количеством вхождений каждого слова
        /// </summary>
        /// <param name="text"></param>
        static List<Word> SplitIntoWords (this List<Word> list, string text)
        {
            string[] textArr = text.ToLower().Split(' '); //Для TextBox возможен только такой разделитель слов
            foreach (string str in textArr)
            {
                if(!list.Select(n => n.Element).Contains(str))
                {
                    list.Add(new Word() {Element = str, Count = textArr.Count(n=>n == str)});
                }
            }
            return list;
        }

        /// <summary>
        /// Число слов в списке
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        /*static int WordsCount (this List<Word> list)
        {
            int wrdscount = 0;
            list.ForEach(delegate (Word wrd)
            { wrdscount += wrd.Count; }
            );
            return wrdscount;
        }*/

    }

    class Word
    {
        public int Count { get; set; }
        public string Element { get; set; }
    }

    

}
