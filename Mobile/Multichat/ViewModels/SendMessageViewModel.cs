using System;
using System.Windows.Input;
using Multichat.Model;
using Multichat.Models;
using UpdateControls.XAML;

namespace Multichat.ViewModels
{
    public class SendMessageViewModel
    {
        private readonly MessageBoardSelectionModel _selection;
        private readonly Individual _individual;

        public SendMessageViewModel(MessageBoardSelectionModel selection, Individual individual)
        {
            _selection = selection;
            _individual = individual;
        }

        public string Text
        {
            get { return _selection.Text; }
            set { _selection.Text = value; }
        }

        public ICommand Send
        {
            get
            {
                return MakeCommand
                    .When(() =>
                        _selection.SelectedMessageBoard != null &&
                        !String.IsNullOrEmpty(_selection.Text))
                    .Do(delegate
                    {
                        _selection.SelectedMessageBoard.SendMessage(_selection.Text);
                        _selection.Text = null;
                    });
            }
        }
    }
}
