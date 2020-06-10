---
title: "Announcing Four New F# Projects For Creating Web Apps"
date: 2011-06-28T12:28:11.2800000
draft: false
---

<p>Lately I’ve been taking a look at how you might write web apps with F# using various existing frameworks. Often these frameworks don’t quite work the way you want them to and have small but annoying nuances when using them from F#. These projects are: </p>  <p><strong>PicoMvc</strong> – a minimalist MVC like framework. The basic aim of PicoMvc is to make it really easy to map an incoming URL to an F# controller function and then choose a view engine to render the result of this function. (<a href="https://github.com/robertpi/PicoMvc/">github</a>/<a href="http://nuget.org/List/Packages/PicoMvc">nuget</a>)</p>  <p><strong>Log4f</strong> – an F# wrapper for the popular logging framework log4net (<a href="https://github.com/robertpi/Log4f">github</a>/<a href="http://nuget.org/List/Packages/Log4f">nuget</a>)</p>  <p><strong>FsRavenDbTools</strong> – some tools to make it easier to use the NoSQL database from F#, including adding the ability to save union types to RavenDb (record types can be save out of the box, but the Json serialize doesn’t know how to work with unions). (<a href="https://github.com/robertpi/FsRavenDbTools/">github</a>/<a href="http://nuget.org/List/Packages/FsRavenDbTools">nuget</a>)</p>  <p><strong>FsLinqFixed</strong> – this is a version of the F# power pack provider that includes fixes for a couple of small but annoying bugs. Full details of the fixes are in the read me on github. (<a href="https://github.com/robertpi/FsLinqFixed">github</a>/<a href="http://nuget.org/List/Packages/FsLinqFixed">nuget</a>)</p>  <p>These frameworks consist of very little code, but often you’ll find a little F# goes a long way. Sometimes all you need is a thin veneer of F#ness to make things work the way you want. This is partially true of log4f were I simple got fed-up of having to write <font face="Courier New">logger.Info(sprintf "Message: %s" value)</font> and created a wrapper that would allow me to write <font face="Courier New">logger.Info "Message: %s" value</font>, i.e. no separate sprint call required.</p>  <p>All tools need some improvement, this especially PicoMvc which is the largest of the three frameworks. Having said that I think it’s pretty usable so don’t be afraid to try it out, and if you find something you don’t like or want to work differently, send me a patch!</p>  <p>I have a little project that will involve using all four projects so hopefully we’ll see this pushing thought improvements to them all.</p>  <p>I’ll be writing a little more about them in the coming weeks/months.</p>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: Announcing Four New F# Projects For Creating Web Apps - David Grenier**

I owe you a big one... didn&#39;t know RavenDB existed and was struggling to get queries working from F# with db4o.<br /><br />This looks like a very viable alternative AND you provide an F# wrapper.

