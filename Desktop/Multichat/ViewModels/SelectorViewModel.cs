using System;
using System.Collections.Generic;
using System.Linq;
using Multichat.Models;
using Multichat.Model;
using System.Windows.Input;
using UpdateControls.XAML;

namespace Multichat.ViewModels
{
    public class SelectorViewModel
    {
        private readonly Individual _individual;
        private readonly MessageBoardSelectionModel _selection;

        public SelectorViewModel(Individual individual, MessageBoardSelectionModel selection)
        {
            _individual = individual;
            _selection = selection;
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

        public MessageBoardViewModel SelectedMessageBoard
        {
            get
            {
                return _selection.SelectedMessageBoard == null
                    ? null
                    : new MessageBoardViewModel(_selection.SelectedMessageBoard);
            }
            set
            {
                _selection.SelectedMessageBoard = value == null
                    ? null
                    : value.MessageBoard;
            }
        }

        public string Topic
        {
            get { return _selection.Topic; }
            set { _selection.Topic = value; }
        }

        public ICommand JoinMessageBoard
        {
            get
            {
                return MakeCommand
                    .When(() => !string.IsNullOrWhiteSpace(_selection.Topic))
                    .Do(delegate
                    {
                        _individual.JoinMessageBoard(_selection.Topic);
                        _selection.Topic = string.Empty;
                    });
            }
        }
    }
}
