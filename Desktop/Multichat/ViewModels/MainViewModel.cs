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
        public enum SynchronizationStatus
        {
            Good,
            Synchronizing,
            Bad
        }

        private Community _community;
        private MessageBoardSelectionModel _selection;
        private SynchronizationService _synchronizationService;

        public MainViewModel(Community community, MessageBoardSelectionModel selection, SynchronizationService synchronizationService)
        {
            _selection = selection;
            _community = community;
            _synchronizationService = synchronizationService;
        }

        public SynchronizationStatus Status
        {
            get
            {
                return
                    _synchronizationService.LastException != null
                        ? SynchronizationStatus.Bad :
                    _synchronizationService.Synchronizing
                        ? SynchronizationStatus.Synchronizing
                        : SynchronizationStatus.Good;
            }
        }

        public string LastException
        {
            get
            {
                return _synchronizationService.LastException == null
                    ? null
                    : _synchronizationService.LastException.Message;
            }
        }

        public string SelectorTitle
        {
            get
            {
                return _selection.SelectedMessageBoard == null
                    ? "<Click to join a message board>"
                    : _selection.SelectedMessageBoard.Topic;
            }
        }

        public SelectorViewModel Selector
        {
            get { return new SelectorViewModel(_synchronizationService.Individual, _selection); }
        }

        public IEnumerable<MessageViewModel> Messages
        {
            get
            {
                if (_selection.SelectedMessageBoard == null)
                    return Enumerable.Empty<MessageViewModel>();
                else
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
