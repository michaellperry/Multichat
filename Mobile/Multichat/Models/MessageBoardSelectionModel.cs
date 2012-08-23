using Multichat.Model;
using UpdateControls.Fields;
using System;

namespace Multichat.Models
{
    public class MessageBoardSelectionModel
    {
        private Independent<MessageBoard> _selectedMessageBoard = new Independent<MessageBoard>();
        private Independent<string> _topic = new Independent<string>();
        private Independent<string> _text = new Independent<string>();

        public MessageBoard SelectedMessageBoard
        {
            get { return _selectedMessageBoard; }
            set { _selectedMessageBoard.Value = value; }
        }

        public string Topic
        {
            get { return _topic; }
            set { _topic.Value = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text.Value = value; }
        }
    }
}
