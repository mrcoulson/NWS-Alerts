NWS Alerts
==========

This application queries an XML file hosted by the National Weather Service for alerts.  If there is no alert, nothing is displayed.  If there is an alert, the application shows the title and a link to more information.  Unlike my [forecast application](https://github.com/mrcoulson/ASP.NET-National-Weather-Service-Parser) which copies forecast data locally, this one simply connects directly to the NWS feed.  I figured that fresh information is best with weather warnings.

Requirements
------------

- ASP.NET 4.0 (It can be changed to work with 3.5.)
- IIS 6+

Setup
-----

1. In Visual Studio 2010, add a reference to `System.ServiceModel`.  In 2008, add a reference to `System.ServiceModel.Web`.
2. Set the `alertFeed` key in the Web.config to whatever feed location you prefer.  You can find a list at [http://alerts.weather.gov/](http://alerts.weather.gov/).  Since your area might not be under an alert while you work on this, I've also provided an example alert XML file.
3. Compile and go.

The Future
----------

Right now, the application decides whether or not there's an alert based on text in an element.  I realize that the NWS may not always word things the same way, so my next goal is to find a way to read through those funny namespaces with `SyndicationFeed` or to go back to using `XDocument`.  Then I can test for the existence of an element that is only there in the event of an actual alert.

Credit Is Due
-------------

My friend Matt Potocnik showed me how to use `SyndicationFeed` instead of `XDocument` since this is an Atom feed.