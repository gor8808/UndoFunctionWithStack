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
namespace UndoFunctionWithStack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //PressedBtnInfo
        Random _r = new Random();
        Stack<PressedBtnInfo> stack = new Stack<PressedBtnInfo>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddColor(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            stack.Push(new PressedBtnInfo
            {
                BtnName = btn.Name,
                Color = btn.Background
            });
            listBox.Items.Add(btn.Content.ToString() + " " + btn.Background.ToString());
            btn.Background = new SolidColorBrush(Color.FromArgb(100, (byte)_r.Next(0, 255), (byte)_r.Next(0, 255), (byte)_r.Next(0, 255)));
        }

        private void Undo(object sender, RoutedEventArgs e)
        {
            if (stack.Count == 0)
            {
                return;
            }
            PressedBtnInfo btnInfo = stack.Pop();
            UpdateBtnAndLstBox(btnInfo);
        }

        private void UpdateBtnAndLstBox(PressedBtnInfo btnInfo)
        {
            Button btn = (Button)FindName(btnInfo.BtnName);
            btn.Background = btnInfo.Color;
            listBox.Items.RemoveAt(listBox.Items.Count - 1);
        }
    }

    internal class PressedBtnInfo
    {
        public string BtnName { get; set; }
        public Brush Color { get; set; }
    }
}
