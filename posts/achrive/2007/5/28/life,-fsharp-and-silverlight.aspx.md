---
title: "Life, F# and Silverlight"
date: 2007-05-28T07:34:26.3270000
draft: false
---

<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">As I alluded to in my <a href="http://strangelights.com/blog/archive/2007/05/25/1584.aspx ">earlier post</a> I’ve wanted to find the time to write a longer post on developing Silverlight application. Using Silverlight is very straightforward and does actually require you to install anything other than <a href="http://research.microsoft.com/fsharp/release.aspx">F#</a> and the <a href="http://silverlight.net/GetStarted/">Silverlight runtime</a>. What out when installing the runtime, turn version are available confusingly name “1.0 beta” and “1.1 alpha”. It is the “1.1 alpha” version that you need as this the only one that includes the new version of the CLR, the dynamic language runtime or the “DLR” (not to be confused with the <a href="http://www.tfl.gov.uk/modalpages/2632.aspx">Docklands Light Rail</a>).</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Once installed you need to tell the compiler to use this version of the CLR instead, the compiler switch --clr-root can be used to do this. Because there are some dll the F# compiler tries to reference by default that aren’t available in silverlight you need to use the --no-framework, switch to tell the compiler not to reference any .dll other than mscorlib.dll by default. Then you need to reference any dll you want to use from Silverlight. I also added the --no-mllib switch to tell the compiler not use mllib.dll and<span style="mso-spacerun: yes">  </span>the --static-link fslib switch to tell F# to statically link fslib. The thinking behind this is that these two dll are compiled against a different CLR so there are a few places where you may try and use methods that don’t exists in the silverlight runtime (although these are generally few and far between), by not using mllib.dll you reduce this risk slightly (and all the really useful stuff is in fslib.dll in my opinion) and by statically linking fslib.dll you should at least get a compiler error when you touch a method that doesn’t exist in silverlight, which you would otherwise. Also by staticly linking fslib all the logic you need is in one dll and you avoid having to place multiple dlls on you web server. Although static linking makes the compile process considerably longer, so you may want to add this in when you’ve finished development. All this gives you a “basic” command line listed below to compile a sliverlight application in F#, you may need to pop in extra silverlight dll as you need them:</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">-r System.SilverLight.dll -r agclr.dll -r Microsoft.Scripting.Vestigial.dll -r System.dll -r Microsoft.Scripting.Silverlight.dll -r Microsoft.Scripting.dll --clr-root "C:\Program Files\Microsoft Silverlight" --no-framework --no-mllib --static-link fslib</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">I’ve also created a visual studio project for the life sample which is <a href="http://strangelights.com/blog/downloads/silverlife.zip">available here</a>. This should make it easier if you want to compile the app for yourself, although all the source was available in the last post. Here you will need to take the files “alg.fs”, “alg.fsi”, and “worker.fs” which are available as part of the F# distribution and placement in project directory.</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">To say silverlight is so early on in it product cycle I actually found development fairly straight forward. I think this was at least partially due to the fact the game of life is so well written, it made it very easy to rip off the presentation logic and replace it with a different set of presentation logic. I did hit a number of small stumbling blocks, the most annoying one being that none of the mouse click events seemed to work for me. I mean looking at the other samples it’s clear that they do work but I tried several different ways of wiring them up and nothing seemed to work for me. Also, I’d liked to have used gifs for the cell images, as these allow you to define parts of the image as transparent allowing me to have a stronger back picture (if the back picture is too bright at the moment you can see that they cells are actual square), however sliverlight doesn’t allow you to render gifs, you get a format not supported error. I think you could work round this by using a circle shape with an image brush, but that somehow seems more a lot more work. Also I was slightly surprised I couldn’t debug the application by simple attaching to the IExplore.exe process.</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">All this leads me to question, does silverlight really a useful purpose? After all it really all about embedding managed application in web pages, which you’ve been able to do with java applets for at least 10 years, hell I believe you can already embed winform controls (although this is very problematic) and IE can render some Xaml pages without silverlight. So I guess silverlight is more about making it easier to do fancy graphics, which isn’t too easy with java applets or winforms, and problematic in WPF xaml as the user must have WPF installed and this is a big download. In this sense it main revival is actually probably flash. A lot of people really loath flash, but I think it does quite a nice job of “lighting up the web” already. I guess flash is heavily designer focused, so I guess silverlight is meant allow develops and designers to work together more easily and I guess that is a very good thing. </font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">So anyway, I’m already planning version 2 of the application. Which the user will be able to added new cells to the game; it will have round cells and a strong back picture and probably a restart button to start a new game.</font></p>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: Life, F# and Silverlight - [Richard Hein](http://www.devlinq.com/)**

It's the DLR that matters ... if F# is one of the languages supported on the DLR with Active Patterns ... beautful things can be done with XAML but it's really just another DSL so Silverlight is really about getting .NET in the browser.

**Interesting Finds: May 28, 2007 - [Jason Haley](http://jasonhaley.com/blog/archive/2007/05/28/139395.aspx)**



**re: Life, F# and Silverlight - [Sridhar Ratnakumar](http://nearfar.org/)**

Robert, the link to your project sample (silverlight.zip) is broken.

**re: Life, F# and Silverlight - [Robert Pickering](http://strangelights.com/)**

I've just test the link and it appears to be okay, I'll send you a copy of the zip anyway.

**re: Life, F# and Silverlight - [Darren](http://feb17.org/)**

The project link is still broekn - appears to be behind a firewall which is why it probably works for you ;)

