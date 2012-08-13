using System.Linq;
using UpdateControls.Fields;
using UpdateControls.Correspondence.BinaryHTTPClient;
using Multichat.Model;

namespace Multichat
{
    public class HTTPConfigurationProvider : IHTTPConfigurationProvider
    {
        private Independent<Individual> _individual = new Independent<Individual>();

        public Individual Individual
        {
            get { return _individual; }
            set { _individual.Value = value; }
        }

        public HTTPConfiguration Configuration
        {
            get
            {
                string address = "https://api.facetedworlds.com/correspondence_server_web/bin";
                string apiKey = "<<Your API key>>";
                return new HTTPConfiguration(address, "Multichat", apiKey);
            }
        }

        public bool IsToastEnabled
        {
            get { return Individual == null ? false : Individual.ToastNotificationEnabled; }
        }
    }
}
