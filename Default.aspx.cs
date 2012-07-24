using System;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel.Syndication;
using System.Configuration;

namespace NWSAlert4
{
    public partial class Default : System.Web.UI.Page
    {
        string strWarningFeed = ConfigurationManager.AppSettings["alertFeed"]; // Warning feed source.

        protected void Page_Load(object sender, EventArgs e)
        {
            parseWarnings(strWarningFeed);
        }

        void parseWarnings(string strWarningFeed)
        {
            try
            {
                // Create an instance of XmlReader with the warning feed and then load it into a SyndicationFeed.
                XmlReader reader = XmlReader.Create(strWarningFeed);
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                // Read through the XML, pull out the items we need depending on whether or not there is a warning.
                foreach (var str in feed.Items)
                {
                    if (str.Title.Text.Contains("no active"))
                    {
                        weatherWarning.Visible = false;
                    }
                    else
                    {
                        string strTitle = str.Title.Text;
                        string strId = str.Id.ToString();
                        strTitle = strTitle.Substring(0, strTitle.LastIndexOf("issued"));
                        litOut.Text += String.Format("<p class=\"warningText\">{0}</p><p class=\"warningText\"><a href=\"{1}\">Read more.</a></p>", strTitle, strId);
                    }
                }
            }
            catch (Exception exNoWeather)
            {
                // It didn't work.
                litOut.Text = "<p>I can't seem to connect to the weather.</p><p>" + exNoWeather.ToString() + "</p>";
            }    
        }
    }
}