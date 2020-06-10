---
title: "Installing Services, User, Virtual Directories etc. using Wix"
date: 2004-09-06T19:42:00.0000000
draft: false
---

<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>If you have had a look at the documentation you&#8217;ve probably noticed a few elements like &#8220;ServiceInstall&#8221;, &#8220;User&#8221; and &#8220;WebVirtualDir&#8221;. What these elements all have in common is that if you add them to a wix document they will compile and link with out any problem, but they will not do anything at all on installation. If you take a closer at the msi produced using the reason they do nothing becomes clear, for example the User elements generates a table called user in the Msi and if you read the <A href="http://msdn.microsoft.com/library/en-us/msi/setup/database_tables.asp">windows installer documentation </A>you will quickly see there is no User table defined.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>But why go to all the bother of putting these elements into the wix schema if they don&#8217;t do anything? They are there because they are designed to work with the wix custom action dlls, that is &#8220;scasched.dll&#8221; and &#8220;scaexec.dll&#8221;. The idea behind these is that common task such as creating users, installing services and virtual directories have been given there own set of wix commands even though they are not natively supported natively by the windows installer. I think this is a really good idea, but there is a down side, which I&#8217;ll cover towards then end of this post.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>To make these elements work correctly you have to follow a number of steps that I have not seen documented anywhere. First of you need include the dll from the wix\ca in you&#8217;re install script, this is done with the following wix syntax (paths make of course vary depending on you&#8217;re install):</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial><BINARY id=ScaSchedule src="Binary\scasched.dll" /><o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2><BINARY id=ScaExecute src="Binary\scaexec.dll" /></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>Next you need to try out the wix code to call into the correct custom action for the kind of elements you&#8217;re adding. Again I&#8217;ve not see this documented anywhere, but you can find what you need to know form the &#8220;scasched.cpp&#8221; file in the fix source. If you were trying to add a user then you would need the following CustomAction tag to call into the write bit of code.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial><CUSTOMACTION id=ConfigureUsers DllEntry="ConfigureUsers" BinaryKey="ScaSchedule" Execute="immediate" Return="check" /><o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>You also need to specific when the custom action should be called; here is an easy to do this.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial><INSTALLEXECUTESEQUENCE><o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial><CUSTOM After="InstallFiles" Action="ConfigureUsers" /><o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial></INSTALLEXECUTESEQUENCE><o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>In all there are 6 custom action entry points listed in the source file &#8220;scasched.cpp&#8221;, these are: <SPAN style="mso-spacerun: yes">&nbsp;</SPAN>ConfigureIIs<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>ConfigureSql<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>ConfigurePerfmonInstall<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>ConfigurePerfmonUninstall</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>ConfigureSmb<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>ConfigureUsers<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial><SPAN style="mso-spacerun: yes">&nbsp;</SPAN>It is not entry clear which elements in wix these map, although they all probably map to sets of elements that will not work with out calling into code in the custom action dlls. It is important to note that these are sets of elements not individual elements. Some are fairly obvious; for example instal using any element prefixed with web needs to call into the ConfigureIIs custom action and ConfigureUsers action has three elements that will not work with out it, these are User, Group and GroupRef. However it&#8217;s odd that these is both ConfigurePerfmonInstall and ConfigurePerfmonUninstall where as the others just have one action. Also there appears to be a customaction missing as the element ServiceArgument, ServiceConfig, ServiceControl, ServiceDependency, ServiceInstall have no equivalent in the <A href="http://msdn.microsoft.com/library/en-us/msi/setup/database_tables.asp">window install documentation</A>, yet there is no customaction for them. <SPAN style="mso-spacerun: yes">&nbsp;</SPAN>I&#8217;m going to try and work out exactly what maps to what and list in a later blog entry. </FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>As I have menationed there is a down side to these none native elements. They don&#8217;t work very well. I&#8217;ve being trying to use them to install a user and it just isn&#8217;t working. I&#8217;ve put together this <A href="http://www.strangelights.com/download.aspx?url=/blog/downloads/testuser.zip">short sample</A> that should install a local user, but it does not, it breaks with some very obscure errors. Create a log of the msi action clear show that the entires from the user table are being used, but don&#8217;t really reveal why it fails. Here is an excerpt log of the msi:</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>Action start <?xml:namespace prefix = st1 ns = "urn:schemas-microsoft-com:office:smarttags" /><st1:time Minute="8" Hour="18">18:08:33</st1:time>: ConfigureUsers.<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>MSI (s) (F4:F0): Creating MSIHANDLE (33) of type 790542 for thread 2544<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>Action start <st1:time Minute="8" Hour="18">18:08:33</st1:time>: CreateUserRollback.<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>Action ended <st1:time Minute="8" Hour="18">18:08:33</st1:time>: CreateUserRollback. Return value 0.<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>ConfigureUsers:<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>Error 0x8007065a: Failed MsiDoAction on deferred action<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>ConfigureUsers:<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>Error 0x8007065a: failed to schedule RemoveUser<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>ConfigureUsers:<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>Error 0x8007065a: failed to add/remove User actions<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>Action ended <st1:time Minute="8" Hour="18">18:08:33</st1:time>: ConfigureUsers. Return value 3.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>Can any one explain this error? Answers on a post card ... </FONT></P>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: Installing Services, User, Virtual Directories etc. using Wix - Paul Gunn**

<br>Thanks for the information - it was very helpful in getting me started. I ran into the same issue as you and on investigation, it seems that the main configure functions are basically setting up a number of deferred actions, but the actions themselves need to be predefined. The easy way to do this is to link the sca.wixlib file in the ca directory (this file was apparently added sept. 10). Once I did that, things started working for me.

**re: Installing Services, User, Virtual Directories etc. using Wix - [Eric Bowen](http://scrappydog.com/blog)**

FYI: None of your XML code samples are showing up in the post (I dug around in the source to find them  ;-)

