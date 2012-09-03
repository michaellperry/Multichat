using System;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Multichat.ViewModels;
using UpdateControls.XAML;

namespace Multichat.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            ForView.BindAppBarItem(
                ApplicationBar.Buttons[1],
                ForView.Unwrap<MainViewModel>(DataContext).SendMessage);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/JoinMessageBoardView.xaml", UriKind.Relative));
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var viewModel = ForView.Unwrap<MainViewModel>(DataContext);
                var messageBoard = ForView.Unwrap<MessageBoardViewModel>(e.AddedItems[0]);
                if (viewModel != null && messageBoard != null)
                {
                    viewModel.SetSelectedMessageBoard(messageBoard);
                }
            }
        }
    }
}