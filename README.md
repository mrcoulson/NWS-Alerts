NWS Alerts
==========

This application queries an XML file hosted by the National Weather Service for alerts.  If there is no alert, nothing is displayed.  If there is an alert, the application shows the title and a link to more information.  Unlike my [forecast application](https://github.com/mrcoulson/ASP.NET-National-Weather-Service-Parser) which copies forecast data locally, this one simply connects directly to the NWS feed.  I figured that fresh information is best with weather warnings.

Requirements
------------

- ASP.NET 4.0 (It can be changed to work with 3.5.)
- IIS 6+

Setup
-----

1) In Visual Studio 2010, add a reference to System.ServiceModel.  In 2008, add a reference to System.ServiceModel.Web.
2) Set the `alertFeed` key in the Web.config to whatever feed location you prefer.  You can find a list at [http://alerts.weather.gov/](http://alerts.weather.gov/).  Since your area might not be under an alert while you work on this, I've also provided an example alert XML file.
3) Compile and go.

Credit Is Due
-------------

My friend Matt Potocnik showed me how to use SyndicationFeed instead of XDocument since this is an Atom feed.