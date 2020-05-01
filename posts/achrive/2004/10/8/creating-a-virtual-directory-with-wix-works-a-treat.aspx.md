---
title: "Creating a virtual directory with Wix works a treat"
date: 2004-10-08T07:54:00.0000000
draft: false
---

<FONT face=Arial size=2>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>I&#8217;ve just tried out creating a virtual directory with Wix and there&#8217;s really not that much too it, there&#8217;s a couple of places where the syntax isn&#8217;t that intuitive but the compiler nudges you in the right direction. I thought I&#8217;d share my experience anyway as the Wix post seem quite popular and it&#8217;s often nice to have a template to start from if you&#8217;re setting out to do these things.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>There&#8217;s just three parts to it, first you create the files for you&#8217;re website in the location of you&#8217;re choosing. Something like this:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><o:p><FONT size=2>&nbsp;</FONT></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>&lt;Directory Id="ProgramFilesFolder" Name="PFiles"&gt;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>&lt;Directory Id="InstallDir" Name="TEST" LongName="Test" &gt;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>&lt;Component Id="default.htmlComponent" Guid="af0b56d1-7660-4172-9f16-a4e29d343341"&gt;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>&lt;File Id="default.htmFile" Name="DEFUALT.HTM" LongName="default.htm" KeyPath="yes" DiskId="1" src="default.htm" /&gt;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>&lt;/Component&gt;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>&lt;/Directory&gt;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>&lt;/Directory&gt;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Then create the entries for the virtual directory itself, you don&#8217;t really need the &#8220;WebApplication&#8221; node but most of the time when you create a virtual directory you create it in its own application.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>&lt;Component Id="TestWebVirtualDirComponent" Guid="054604ca-1790-4c0c-b076-531ff9a5b374"&gt;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>&lt;WebVirtualDir Id="TestWebVirtualDir" Alias="Test" Directory="InstallDir" WebSite="DefaultWebSite"&gt;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>&lt;WebApplication Id="TestWebApplication" Name="Test" /&gt;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>&lt;/WebVirtualDir&gt;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>&lt;/Component&gt;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Finally you need an entry to reference the web site itself; because you don&#8217;t want this to be created it is placed under the product node. Not much to say about this, except you need the &#8220;WebAddress&#8221; node even though it doesn&#8217;t really provide any extra info.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>&lt;WebSite Id="DefaultWebSite" Description="Default Web Site"&gt;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>&lt;WebAddress Id="AllUnassigned" Port="80" /&gt;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>&lt;/WebSite&gt;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>As discussed in a <A href="http://strangelights.com/blog/archive/2004/09/27/176.aspx">pervious blog</A> post you will need to include the wix server custom actions for this to work correctly.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>The only real problem I found was that it only seems to work with IIS 6.0, installing on an IIS 5.5 machine gives the rather cryptic error &#8220;Product: Test Virtual Dir -- Error 1316. A network error occurred while attempting to read from the file: C:\wixinstalls\virtualdir\output\testuser.msi&#8221;. I&#8217;ll be reporting this to the bug tracking tool, so I guess we&#8217;ll soon find out weather this is a bug or a feature.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Download the complete source <A href="http://strangelights.com/download.aspx?url=/blog/downloads/virtualdir.zip">here</A>.</P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"></FONT></P></FONT>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: Creating a virtual directory with Wix works a treat - [Chris Bilson](http://weblogs.factored-software.com/chris)**

This is excellent information. Information about using the CustomActions is hard to come by. I am in the process of trying to do this for an installer for a product I work on, and several times have considered giving up writing what I want in C++. Thanks!

**re: Creating a virtual directory with Wix works a treat - [龙龙](http://www.cnblogs.com/huqingyu)**

I had meet Your error “Product: Test Virtual Dir -- Error 1316. A network error occurred while attempting to read from the file: C:\wixinstalls\virtualdir\output\testuser.msi”. It's the product ID problem. I did down all samples from your blog, there product ID is same! after you install any one, when you install another will recieve this error.<br>I test this IIS install script, It works fine in WindowsXP or Win2003, But not work in Win2000

**re: Creating a virtual directory with Wix works a treat - [龙龙](http://www.cnblogs.com/huqingyu)**

It just a very small bug.<br>if you change the sequence of Directory And alias in &quot;WebVirtualDir&quot; node, it can work fine in win2000 too.<br>good luck

**re: Creating a virtual directory with Wix works a treat - [Robert Pickering](http://www.strangelights.com)**

Thanks for the info. I hope to have to revisit my samples and give them different guid soon!

**re: Creating a virtual directory with Wix works a treat - [Steven Melzer](http://smelzer@paymentech.com)**

Thank you.  I was beating my head trying to get the correct syntax for this.

**re: Creating a virtual directory with Wix works a treat - Horea**

Maybe you should include a link to the original tutorial where you copied this from<br><br><a target="_new" href="http://www.tramontana.co.hu/wix/lesson6.html">http://www.tramontana.co.hu/wix/lesson6.html</a>

**re: Creating a virtual directory with Wix works a treat - Horea**

Or maybe he copied it from you, nevertheless the samples look very much alike.<br><br>:)

**re: Creating a virtual directory with Wix works a treat - toml**

Unfortunately, when you uninstall the package, it removes the website also, even if it existed before your install.

**re: Creating a virtual directory with Wix works a treat - [Robert Pickering](http://strangelights.com)**

Toml,<br><br>It shouldn't remove the website because it not marked with a GUID so should be a permitant feature. I definly didn't see this behavior when I ran the sample. Maybe you should try and pin down the exact circumstances it does this and report it as a WIX bug.<br><br>Horea,<br><br>My name appears on the credit list:<br><a target="_new" href="http://www.tramontana.co.hu/wix">http://www.tramontana.co.hu/wix</a><br><br>Cheers,<br>Rob

**re: Creating a virtual directory with Wix works a treat - [Francisco](http://franciscoder.blogspot.com/)**

You said that WebAddress does not provide extra info. Did you try to install your application in a IIS with more than 1 website.<br />Try to install you application in a second Website, this website has as Identification and Ip or an Host Header...<br /><br />This Web Address is the identifier that make you choose the website that you want to install you application.<br /><br />Look at this:<br /><br />  &lt;WebSite xmlns="http://schemas.microsoft.com/wix/IIsExtension"  Id="SelectedWebSite" Description="[WEBSITENAME]"&gt;    <br />    &lt;WebAddress Id="WebsiteIdentity" Port="[WEBSITEPORT]" Header="[WEBSITEHEADER]" IP="[WEBSITEIP]" /&gt;<br />  &lt;/WebSite&gt;

**re: Creating a virtual directory with Wix works a treat - Rom&#225;n**

Rob<br /><br />Although this post is quite old, I am trying to create a virtual directory using that same example, but still there are two things I'm not happy with (I'm using WiX 3):<br />1- If I don't specify a <b>CreateFolderElement</b> under the component that creates the virtual directory, Votive gives me an ICE18 compilation error.If I do, the installer also creates a web directory under the DefaultWebSite, alongside the virtual directory, with the same path.<br />2- I'm trying to create a parent directory P restricted to SSL access and a child directory C without SSL access to which I want to redirect the users after a HTTP 403.4. The setting on P works fine, but I have to go to IIS to change the setting for C manually.<br /><br />Any idea of how to solve this issues?<br /><br />Thanks in advance<br />Román

