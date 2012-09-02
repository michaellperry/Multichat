using System;
using System.Linq;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Multichat.ViewModels;
using UpdateControls;
using UpdateControls.XAML;

namespace Multichat.Views
{
    public partial class JoinMessageBoardView : PhoneApplicationPage
    {
        private Dependent _depCanJoin;

        public JoinMessageBoardView()
        {
            InitializeComponent();

            _depCanJoin = new Dependent(UpdateOKButton);
            _depCanJoin.Invalidated += delegate
            {
                Dispatcher.BeginInvoke(delegate
                {
                    _depCanJoin.OnGet();
                });
            };
            _depCanJoin.OnGet();
        }

        private void UpdateOKButton()
        {
            var viewModel = ForView.Unwrap<JoinMessageBoardViewModel>(DataContext);
            var okButton = ApplicationBar.Buttons
                .OfType<ApplicationBarIconButton>()
                .FirstOrDefault(button => button.Text == "ok");
            if (viewModel != null && okButton != null)
                okButton.IsEnabled = viewModel.Join.CanExecute(null);
        }

        private void OK_Click(object sender, EventArgs e)
        {
            JoinMessageBoardViewModel viewModel = ForView.Unwrap<JoinMessageBoardViewModel>(DataContext);
            if (viewModel != null)
                viewModel.Join.Execute(null);
            NavigationService.GoBack();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            JoinMessageBoardViewModel viewModel = ForView.Unwrap<JoinMessageBoardViewModel>(DataContext);
            if (viewModel != null)
                viewModel.Topic = null;
            NavigationService.GoBack();
        }
    }
}