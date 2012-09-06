using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Multichat.Model;
using Multichat.Models;
using UpdateControls.XAML;

namespace Multichat.ViewModels
{
    public class MainViewModel
    {
        private Individual _individual;
        private SynchronizationService _synhronizationService;
        private MessageBoardSelectionModel _selection;

        public MainViewModel(Individual individual, SynchronizationService synhronizationService, MessageBoardSelectionModel selection)
        {
            _individual = individual;
            _synhronizationService = synhronizationService;
            _selection = selection;
        }

        public bool Synchronizing
        {
            get { return _synhronizationService.Synchronizing; }
        }

        public string LastException
        {
            get
            {
                Exception lastException = _synhronizationService.LastException;
                return lastException == null
                    ? null
                    : lastException.Message;
            }
        }

        public bool HasException
        {
            get { return _synhronizationService.LastException != null; }
        }

        public bool ShowInstructions
        {
            get
            {
                return
                    !_synhronizationService.Synchronizing &&
                    !_individual.MessageBoards.Any();
            }
        }

        public IEnumerable<MessageBoardViewModel> MessageBoards
        {
            get
            {
                return
                    from messageBoard in _individual.MessageBoards
                    orderby messageBoard.Topic
                    select new MessageBoardViewModel(messageBoard);
            }
        }

        public void SetSelectedMessageBoard(MessageBoardViewModel value)
        {
            _selection.SelectedMessageBoard = value == null
                ? null
                : value.MessageBoard;
        }

        public string Text
        {
            get { return _selection.Text; }
            set { _selection.Text = value; }
        }

        public ICommand SendMessage
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
