using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using UpdateControls.Correspondence;
using UpdateControls.XAML;
using Multichat.Models;
using Multichat.Model;

namespace Multichat.ViewModels
{
    public class MainViewModel
    {
        private Community _community;
        private MessageBoardSelectionModel _selection;
        private SynchronizationService _synhronizationService;

        public MainViewModel(Community community, MessageBoardSelectionModel selection, SynchronizationService synhronizationService)
        {
            _selection = selection;
            _community = community;
            _synhronizationService = synhronizationService;
        }

        public bool Synchronizing
        {
            get { return _synhronizationService.Synchronizing; }
        }

        public SelectorViewModel Selector
        {
            get { return new SelectorViewModel(_synhronizationService.Individual, _selection); }
        }

        public IEnumerable<MessageViewModel> Messages
        {
            get
            {
                return
                    from message in _selection.SelectedMessageBoard.Messages
                    select new MessageViewModel(message);
            }
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
                        !string.IsNullOrWhiteSpace(_selection.Text))
                    .Do(delegate
                    {
                        _selection.SelectedMessageBoard.SendMessage(_selection.Text);
                        _selection.Text = string.Empty;
                    });
            }
        }
    }
}
