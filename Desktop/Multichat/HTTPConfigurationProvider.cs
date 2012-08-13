using System.Linq;
using UpdateControls.Fields;
using UpdateControls.Correspondence.BinaryHTTPClient;

namespace Multichat
{
    public class HTTPConfigurationProvider : IHTTPConfigurationProvider
    {
        public HTTPConfiguration Configuration
        {
            get
            {
                string address = "https://api.facetedworlds.com/correspondence_server_web/bin";
                string apiKey = "D1920D309A4E43EB85BD14833AFEF7E8";
				int timeoutSeconds = 30;
                return new HTTPConfiguration(address, "Multichat", apiKey, timeoutSeconds);
            }
        }
    }
}
