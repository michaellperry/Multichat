using System;
using System.Linq;
using UpdateControls.Correspondence;

namespace Multichat.Model
{
    public partial class Individual
    {
        public bool ToastNotificationEnabled
        {
            get { return IsToastNotificationEnabled.Any(); }
            set
            {
                if (IsToastNotificationEnabled.Any() && !value)
                {
                    Community.AddFact(new DisableToastNotification(IsToastNotificationEnabled));
                }
                else if (!IsToastNotificationEnabled.Any() && value)
                {
                    Community.AddFact(new EnableToastNotification(this));
                }
            }
        }

        public MessageBoard JoinMessageBoard(string topic)
        {
            MessageBoard messageBoard = Community.AddFact(new MessageBoard(topic));
            Community.AddFact(new Share(this, messageBoard));
            return messageBoard;
        }
    }
}
