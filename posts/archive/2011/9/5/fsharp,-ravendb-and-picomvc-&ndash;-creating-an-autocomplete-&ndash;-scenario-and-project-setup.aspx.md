---
title: "F#, RavenDB and PicoMvc - Creating an Autocomplete - Scenario and Project Setup"
date: 2011-09-05T11:28:06.4470000
draft: false
---

<p>After a few philosophical blog posts, I decided it was time for something a bit more concrete. I’ve been playing around a bit with F# and some web stuff recently using both RavenDB and PicoMvc so I thought I’d share with you how to create an autocomplete drop down using these technologies.</p>  <p>Creating an autocomplete in a HTML form is fairly common these days and there’s a nice jQuery plugin that takes care of the UI side of things. So the heavy lifting that remains, although it’s not really that heavy, is loading the data into RavenDB then exposing a service that will return JSON records corresponding to the users searching.</p>  <p>In this scenario I’m going to create a drop down based on the French “Communes” an administrative area in France that’s roughly equivalent to the idea of a town. This is just because I have the data to hand.</p>  <p>The way we’re going to structure our project is:</p>  <p><img src="http://dl.dropbox.com/u/4679672/autocompletestructure.png" /></p>  <p>Common contains the definition of our types that will be stored in RavenDB and will be referenced from LoadCommunes and Web, which will contain the ETL logic and the logic to drive the web pages respectively. The project WebHost is a C# “web project” it’s just there to hold the html parts of the project and make launching the web server for debugging easier.</p>  <p>So that the scenario and the project setup done, next time we’ll see some actual code when we look at the ETL. If you can’t wait that long the full code base is already available on github in the <a href="https://github.com/robertpi/PicoMvc/tree/master/examples">new examples</a> directory of <a href="https://github.com/robertpi/PicoMvc/">picomvc</a>.</p>  <p>A quick caveated is that since writing this series I’ve read <a href="http://ayende.com/blog/77825/modeling-reference-data-in-ravendb">Ayende’s Modeling Reference Data in RavenDB</a>, the approach we take here is a little different to the one he suggests, I’ll discuss alterative implementations at the end of the series. </p>
