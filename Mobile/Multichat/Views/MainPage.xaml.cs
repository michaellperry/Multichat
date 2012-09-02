using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using UpdateControls.XAML;
using Multichat.ViewModels;

namespace Multichat.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static void BindAppBarItem(object item, ICommand command)
        {
            var button = item as IApplicationBarMenuItem;
            if (button == null || command == null)
                return;

            button.Click += delegate
            {
                command.Execute(null);
            };

            command.CanExecuteChanged += delegate
            {
                button.IsEnabled = command.CanExecute(null);
            };
            button.IsEnabled = command.CanExecute(null);
        }

        public MainPage()
        {
            InitializeComponent();

            BindAppBarItem(
                ApplicationBar.Buttons[1],
                ForView.Unwrap<MainViewModel>(DataContext).SendMessage);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/JoinMessageBoardView.xaml", UriKind.Relative));
        }
    }
}