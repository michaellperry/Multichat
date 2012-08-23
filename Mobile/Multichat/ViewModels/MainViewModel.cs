using System.Collections.Generic;
using System.Linq;
using Multichat.Model;
using Multichat.Models;

namespace Multichat.ViewModels
{
    public class MainViewModel
    {
        private Individual _individual;
        private SynchronizationService _synhronizationService;
        private MessageBoardSelectionModel _selection;

        public MainViewModel(Individual individual, SynchronizationService synhronizationService)
        {
            _individual = individual;
            _synhronizationService = synhronizationService;
        }

        public bool Synchronizing
        {
            get { return _synhronizationService.Synchronizing; }
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
    }
}
