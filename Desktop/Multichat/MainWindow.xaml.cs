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

namespace Multichat
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

        private void SelectorTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectorPopup.IsOpen = !SelectorPopup.IsOpen;
        }

        private void JoinButton_Click(object sender, RoutedEventArgs e)
        {
            SelectorPopup.IsOpen = false;
        }

        private void MessageBoardListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectorPopup.IsOpen = false;
        }
    }
}
