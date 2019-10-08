using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickSort
{
    public partial class Form1 : Form
    {
        private List<SortedItem> items = new List<SortedItem>();
        private const int sleep = 50;

       
        private void BtnClick(AlgorithmBase<SortedItem> algorithm)
        {
            RefreshItems();

            for (int i = 0; i < algorithm.Items.Count; i++)
            {
                algorithm.Items[i].SetPosition(i);
            }
            panel1.Refresh();

            algorithm.CompareEvent += AlgorithmCompareEvent;
            algorithm.SwapEvent += AlgorithmSwapEvent;
            algorithm.SetEvent += AlgorithmSetEvent;
            var time = algorithm.Sort();

        }
        private void AlgorithmSwapEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            e.Item1.SetColor(Color.Aqua);
            e.Item2.SetColor(Color.Brown);
            panel1.Refresh();

            Thread.Sleep(sleep);

            var temp = e.Item1.Number;
            e.Item1.SetPosition(e.Item2.Number);
            e.Item2.SetPosition(temp);
            panel1.Refresh();

            Thread.Sleep(sleep);

            e.Item1.SetColor(Color.Blue);
            e.Item2.SetColor(Color.Blue);
            panel1.Refresh();

            Thread.Sleep(sleep);
        }

        private void AlgorithmCompareEvent(object sender, Tuple<SortedItem, SortedItem> e)
        {
            e.Item1.SetColor(Color.Red);
            e.Item2.SetColor(Color.Green);
            panel1.Refresh();

            Thread.Sleep(sleep);

            e.Item1.SetColor(Color.Blue);
            e.Item2.SetColor(Color.Blue);
            panel1.Refresh();

            Thread.Sleep(sleep);
        }

        private void AlgorithmSetEvent(object sender, Tuple<int, SortedItem> e)
        {
            e.Item2.SetColor(Color.Red);
            panel1.Refresh();

            Thread.Sleep(sleep);

            e.Item2.SetPosition(e.Item1);
            panel1.Refresh();

            Thread.Sleep(sleep);

            e.Item2.SetColor(Color.Blue);
            panel1.Refresh();

            Thread.Sleep(sleep);
        }
        private void RefreshItems()
        {
            foreach (var item in items)
            {
                item.Refresh();
            }

            DrawItems(items);
        }
        private void DrawItems(List<SortedItem> items)
        {
            panel1.Controls.Clear();
            panel1.Refresh();

            foreach (var item in items)
            {
                panel1.Controls.Add(item.ProgressBar);
                panel1.Controls.Add(item.Label);
            }

            panel1.Refresh();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void QuickSort_Click(object sender, EventArgs e)
        {
            var quick = new Quick<SortedItem>(items);
            BtnClick(quick);
        }
        private void BubbleSort_Click(object sender, EventArgs e)
        {
            var quick = new Bubble<SortedItem>(items);
            BtnClick(quick);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(FillTextBox.Text, out int value))
            {
                var rnd = new Random();
                for (int i = 0; i < value; i++)
                {
                    var item = new SortedItem(rnd.Next(100), items.Count);
                    items.Add(item);
                }
            }

            RefreshItems();

            FillTextBox.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
