using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel.Syndication;
using System.Configuration;

namespace NWSAlert4
{
    public partial class Default : System.Web.UI.Page
    {
        // Warning feed source.
        string strWarningFeed = ConfigurationManager.AppSettings["alertFeed"]; 

        protected void Page_Load(object sender, EventArgs e)
        {
            parseWarnings(strWarningFeed);
        }

        void parseWarnings(string strWarningFeed)
        {
            try
            {
                // Connect an instance of XDocument to alert.
                XDocument xmlDoc = XDocument.Load(strWarningFeed);

                // Handle those non-standard namespaces.
                XNamespace ns = "http://www.w3.org/2005/Atom";
                XNamespace cap = "urn:oasis:names:tc:emergency:cap:1.1";
                XNamespace ha = "http://www.alerting.net/namespace/index_1.0";

                // 
                if (xmlDoc.Descendants(cap + "event").Count() == 0)
                {
                    litOut.Text = "No alerts currently.";
                }
                else
                {
                    // LINQ work.
                    // Stick ":::" in the middle for splitting the results into an array later.
                    var q = from c in xmlDoc.Descendants(ns + "entry")
                            select (string)c.Element(cap + "event") + ":::" + (string)c.Element(ns + "id");

                    foreach (string str in q)
                    {
                        // Loop through the strings in q and add to the Literal. 
                        string[] strSeparators = new string[] { ":::" };
                        // Turn str into an array of strings split on ":::";
                        string[] strResult = str.Split(strSeparators, StringSplitOptions.None);
                        litOut.Text += String.Format("<h1>{0}</h1><p><a href=\"{1}\">Read more.</a></p>", strResult[0], strResult[1]);
                    }
                }
            }
            catch (Exception exBadWeather)
            {
                // Can't get weather.
                litOut.Text = exBadWeather.ToString();
            }
        }
    }
}