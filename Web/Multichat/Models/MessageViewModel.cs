using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Multichat.Model;

namespace Multichat.Models
{
    public class MessageViewModel
    {
        private readonly Message _message;

        public MessageViewModel(Message message)
        {
            _message = message;
        }

        public string Text
        {
            get { return _message.Text; }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            MessageViewModel that = obj as MessageViewModel;
            if (that == null)
                return false;
            return Object.Equals(that._message, this._message);
        }

        public override int GetHashCode()
        {
            return _message.GetHashCode();
        }
    }
}
