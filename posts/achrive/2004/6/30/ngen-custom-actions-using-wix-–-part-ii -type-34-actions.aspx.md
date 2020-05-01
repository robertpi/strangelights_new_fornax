---
title: "NGen Custom Actions using WiX – Part II: Type 34 actions"
date: 2004-06-30T12:27:00.0000000
draft: false
---

<FONT size=2><FONT face=Arial><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>As I alluded to in my <A href="http://www.strangelights.com/blog/archive/2004/06/29/152.aspx">last wix blog entry </A>if you want to provide any sort of location robust access to well known folders Type 50 CustomActions are not for you. I thought I could get away with this as we&#8217;re just using msi to deploy our bespoke app to the testing environments which we control. However my boss came to me this morning saying they had one machine on behaving in a pre-jited manor could I take a look; sure enough the windows folder on this machine was c:\winnt rather than c:\windows like I had assumed it would be. Lesson learn, I set off to alter my install scripts to produce Type 34 custom actions. Again much bashing of head against monitor (although slightly less than last time), so I thought I&#8217;d again share the results.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>The only really change you have to make to yesterdays scripts is to the CustomAction tag itself. The syntax is shown below.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>&lt;CustomAction Id="Test.exeFileNGen" ExeCommand='"[WindowsFolder]Microsoft.NET\Framework\v1.1.4322\ngen.exe" "[#DataPharm.PharmaNet.Logging.dllFile]"' Directory="InstallDir" /&gt;<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>The Directory property is the working of the command and it is a foreign to an entry into the directory table. I chose the install dir for this; it wasn&#8217;t a critical decision since everything is using a full path anyway. Probably the most important thing to note is the subtle difference between access a property and accessing a file path. A property has the syntax [<I style="mso-bidi-font-style: normal">Property</I>] where <I style="mso-bidi-font-style: normal">Property</I> is the name of the property (this is where I get the value for the windows folder). File paths, as discussed yesterday, use a similar syntax but with a hash (#) symbol.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>The other slightly annoying thing is there is no well know of accessing the framework directory; you just specify the path you want to use starting from the windows folder. I guess this is because several versions of the framework installed all running side by side, but it does mean you end up hard coding you&#8217;re install against a specific version of the framework. This is definitely okay for me as I know were always going to be using framework v1.1.4322 during testing, well put it this way: we&#8217;ll having bigger problems than just ngening if we&#8217;re not.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>Anyway the full wxs script is available <A href="http://www.strangelights.com/download.aspx?url=/blog/downloads/ngentype34example.zip">here</A>. Again it will compile but not link, unless you provide your own test.exe assembly.<o:p></o:p></FONT></FONT></P></o:p></FONT></FONT>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: NGen Custom Actions using WiX – Part II: Type 34 actions - [M. Scott Ford](http://vaderpi.scottandlaurie.com)**

You zipped up the wxsobj file not the wxs file.<br><br>Thanks for the post!

**re: NGen Custom Actions using WiX – Part II: Type 34 actions - [M. Scott Ford](http://vaderpi.scottandlaurie.com/)**

I forgot to mention something. Reading that little bit about sequencing the actions after InstallFinalize was a life saver. I kept trying to sequence mine after InstallFiles, and was struggling to figure out why it was not working. <br><br>Thanks again!

**re: NGen Custom Actions using WiX – Part II: Type 34 actions - [Robert Pickering](http://www.strangelights.com)**

A big d'oh re: file up load. This has now been corrected. Glad you found the info useful.

**re: NGen Custom Actions using WiX – Part II: Type 34 actions - [Graeme Foster](http://graemef.com)**

I know this post was a long time ago, but the zip I just downloaded contains the .wixobj file not the .wxs file - are you sure you fixed the download? :)<br><br>Good post, thanks!

**re: NGen Custom Actions using WiX – Part II: Type 34 actions - [Robert Pickering](http://strangelights.com)**

I _did_ fix it, but that change must have been undone in a redeployment or something. I seem to have miss placed the orginal, so I will have to redo the download sample. This will happen soon(ish).<br><br>However, some seems to have placed a pretty complete version of the sample &lt;a href=&quot;<a target="_new" href="http://graemef.com/?q=using_wix_to_run_ngen_2_0_against_your_application_during_installation_part_2&amp;PHPSESSID=daf6ae6f5882866e2d7f03b0889e552d&quot;&gt;here&lt;/a&gt;">http://graemef.com/?q=using_wix_to_run_ngen_2_0_against_your_application_during_installation_part_2&amp;PHPSESSID=daf6ae6f5882866e2d7f03b0889e552d&quot;&gt;here&lt;/a&gt;</a>.<br><br>Thanks!

