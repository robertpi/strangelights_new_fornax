---
title: "Wix Custom Actions"
date: 2004-09-27T12:44:00.0000000
draft: false
---

<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>An msi is really a relational database made up of a number of tables. When an installation runs the windows installer parses the msi and then queries tables to see what actions it must perform. Msdn has a <A href="http://msdn.microsoft.com/library/en-us/msi/setup/database_tables.asp?frame=true">complete list of tables</A> that the windows installer uses and it&#8217;s very worth while checking it out because it will give you a good idea of what you&#8217;re install is going to do and why.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>If you use certain wix elements you may notice they create tables that are not listed in the msdn documentation. This is not because they are undocumented tables, it is because the msi format allows you to define custom tables and these custom tables will be ignored by the installer service.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>So why bother putting in these tables if the installer is going to ignore them? This is because the number of things that the installer server can do is somewhat limited; there are quite a few tasks, such as installing virtual directories, file shares or users, that it is very difficult to do with out resorting custom actions. While custom actions are a necessary evil, they are also annoying because they do not fit well into the nice declarative programming model of the installer server and make it very easy to create installs that do not roll back correctly. So wix has come up with a mechanism that allows it to extend the things that installer can do by creating these new tables and providing a set of generic custom actions which queries these tables and install certain items based on the result of the query. This is a fantastic thing in my opinion, because suddenly loads of new installation task become available by a declarative mechanism. Also these mechanism will be tried and test by wix users, so are probably much safer that opening VS.NET and hacking out a few C# based custom actions.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>The unfortunate thing is these custom action based tables are still largely undocumented, so it quite possible to user a wix element in an install without releasing that you need to include a custom action definition. And so it will do not do anything. And so you will bash you head against the monitor trying to find out why it does nothing. </FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Wix comes with two files, &#8216;ca\sca.wixlib&#8217; and &#8216;ca\wixca.wixlib&#8217;, which will add the necessary custom action definitions for you. There is currently no documentation to tell you which elements to require you to include a custom action file in you&#8217;re build, this why I have prepared the following list of elements that need custom actions definitions. I&#8217;ve also listed the name of the method you need to call in the dll that will process the tables produced by the elements listed. </FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Elements that require &#8216;ca\sca.wixlib&#8217; and the dlls &#8216;scaexec.dll&#8217; and &#8216;scasched.dll&#8217;:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>IIs related elements &#8211; &#8216;ConfigureIIs&#8217; custom action:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Certificate</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>MIME</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>WebAddress</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>WebApplication </FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>WebApplicationExtension </FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>WebAppPool</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>WebDir</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>WebDirProperties</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>WebError</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>WebFilter</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>WebProperty</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>WebServiceExtension</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>WebSite</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>WebVirtualDir</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Sql related elements &#8211; &#8216;ConfigureSql&#8217; custom action:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>SqlDatabase</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>SqlFileSpec</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>SqlLogFileSpec</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>SqlScript</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>SqlString</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Performance counter related elements &#8211; &#8216;ConfigurePerfmonInstall&#8217; and &#8216;ConfigurePerfmonUninstall&#8217; custom actions:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>PerfCounter</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>File share related elements &#8211; &#8216;ConfigureSmb&#8217; custom actions:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>FileShare</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Permission (When child of FileShare)</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>User related elements &#8211; &#8216;ConfigureUsers&#8217; custom action:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>User</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Group</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>GroupRef</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Elements that require &#8216;ca\wixca.wixlib&#8217; and the dll &#8216;wixca.dll&#8217;:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Service related elements &#8211; &#8216;CaSchedServiceConfig&#8217; and &#8216;CaExecServiceConfig&#8217; custom action:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT size=2><FONT face=Arial>ServiceArgument<B style="mso-bidi-font-weight: normal"><o:p></o:p></B></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>ServiceConfig</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>ServiceControl</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>ServiceDependency</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>ServiceInstall</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Permission (When child of ServiceInstall)</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>I hopefully this has given you a good idea when you need to included custom action configuration and when you don&#8217;t. I&#8217;m going to creating some more detailed examples of how to use these elements soon.</FONT></P>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: Wix Custom Actions - jmdavidson at gmail dot com**

This is just what I've been looking for.  I'll be waiting anxiously for those more detailed examples.  Thank you.

**re: Wix Custom Actions - Harjit S. Batra**

Looking in the CA folder I also see a PubCA.wixlib. Any idea what Custom Actions one can perform with that one?

**re: Wix Custom Actions - Igal Nassi**

Can someone post the XML that creates an IIS Virtual folder? I am using WiX 3 and I cannot seem to find where the tags should go and what exactly needs to go under it.

**re: Wix Custom Actions - Niclas**

This was exactly the information I was looking for. I have been troubleshooting a linker error I get when I added a FileShare with Permissions to my project. I think the documentation at wix.sourceforge.net should be updated to contain this information. That would have saved med a lot of time.

