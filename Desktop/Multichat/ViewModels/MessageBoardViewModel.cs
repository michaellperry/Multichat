using System;
using System.Collections.Generic;
using System.Linq;
using Multichat.Model;

namespace Multichat.ViewModels
{
    public class MessageBoardViewModel
    {
        private readonly MessageBoard _messageBoard;

        public MessageBoardViewModel(MessageBoard messageBoard)
        {
            _messageBoard = messageBoard;
        }

        internal MessageBoard MessageBoard
        {
            get { return _messageBoard; }
        }

        public string Topic
        {
            get { return _messageBoard.Topic; }
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            MessageBoardViewModel that = obj as MessageBoardViewModel;
            if (that == null)
                return false;
            return Object.Equals(this._messageBoard, that._messageBoard);
        }

        public override int GetHashCode()
        {
            return _messageBoard.GetHashCode();
        }
    }
}
