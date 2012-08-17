using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Multichat.Model;

namespace Multichat.Models
{
    public class MessageBoardViewModel
    {
        private readonly MessageBoard _messageBoard;

        public MessageBoardViewModel(MessageBoard messageBoard)
        {
            _messageBoard = messageBoard;
        }

        public string Topic
        {
            get { return _messageBoard.Topic; }
        }

        public IEnumerable<MessageViewModel> Messages
        {
            get
            {
                return
                    from message in _messageBoard.Messages
                    select new MessageViewModel(message);
            }
        }
    }
}
