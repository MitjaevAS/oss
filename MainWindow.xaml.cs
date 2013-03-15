using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using Microsoft.Win32;
namespace lab_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private ArrayList myAL = new ArrayList();
        private bool flagButton;
        private void button1_Click(object sender, RoutedEventArgs e)
        {
           if(textBox2.Text != "")
           {
               flagButton = true;
            int index;            
            int itemCount = Convert.ToInt32(textBox2.Text);
            Random rnd1 = new Random();
            int number;
            listBox1.Items.Clear();
            for (index = 1; index <= itemCount; index++)
            {
                number = -100 + rnd1.Next(200);
                myAL.Add(number);
                listBox1.Items.Add(number);
            }
           }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (textBox2.Text != "")
            {
                flagButton = false;
                int index;
                int itemCount = Convert.ToInt32(textBox2.Text);
                Random rnd1 = new Random();
                int number;
                listBox1.Items.Clear();
                listBox1.Items.Add("Исходный массив");
                for (index = 1; index <= itemCount; index++)
                {
                    number = -100 + rnd1.Next(200);
                    myAL.Add(number);
                    listBox1.Items.Add(number);
                }
                myAL.Sort();
                listBox1.Items.Add("Отсортированный массив");
                foreach (int elem in myAL)
                {
                    listBox1.Items.Add(elem);
                }
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "Текст(*.TXT)|*.TXT" + "|Все файлы (*.*)|*.* ";

            if (myDialog.ShowDialog() == true)
            {
                string filename = myDialog.FileName;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false))
                {
                    foreach (Object item in listBox1.Items)
                    {
                        file.WriteLine(item);
                    }
                }
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if (flagButton == true)
            {
                int[] arList = new int[10] ;
                myAL.CopyTo(arList);
                int number = 0;
                for (int i = 1; i < arList.Length-1 ; i++)
                {
                    if (arList[i] > arList[i + 1] && arList[i] > arList[i - 1])
                    {
                        number++;
                    }

                }
                listBox1.Items.Add("Колличество элементов больших свойх соседей:");
                listBox1.Items.Add(number);

            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



    }
}
