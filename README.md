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

Newest Changes
--------------

I went back to using `XDocument` instead of `SyndicationFeed` because I needed to easily read non-standard namespaces.  Now, I am testing for an alert by checking to see if `xmlDoc.Descendants(cap + "event").Count()` is 0.

The Future
----------

I am currently sticking some characters between the results of the query and then splitting those into an array later.  I'd really rather just grab results as an array with LINQ and not have to insert and then remove characters, but I haven't figured that out yet.
