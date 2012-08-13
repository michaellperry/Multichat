using System;

namespace Multichat.Model
{
    public partial class MessageBoard
    {
        public void SendMessage(string text)
        {
            Domain theDomain = Community.AddFact(new Domain());
            Community.AddFact(new Message(this, theDomain, text));
        }
    }
}
