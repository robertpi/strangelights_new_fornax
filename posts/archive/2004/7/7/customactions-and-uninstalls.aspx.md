---
title: "CustomActions and uninstalls"
date: 2004-07-07T15:47:00.0000000
draft: false
---

<FONT size=2><FONT face=Arial>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>I needed to add a CustomAction that removed the native image from the GAC. To do this I came across more slightly odd behaviour from the windows install platform so I thought I&#8217;d write a blog entry about it.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>At first glance creating an uninstall action looks dead easy. Just create a custom action that does the opposite of what you did on install. In the case of ngen this is just adding an extra /delete switch, an absolute cinch! The syntax for the remove custom action is shown below. Note the use of the Return property to ignore the result, it possible that the action will fail because someone has removed the native image by hand; using the Return property this way will stop uninstallation failing if this happens.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>&lt;CustomAction Id="Test.exeFileRemoveNGen" ExeCommand='"[WindowsFolder]Microsoft.NET\Framework\v1.1.4322\ngen.exe" /delete "[#DataPharm.PharmaNet.Logging.dllFile]"' Directory="InstallDir"<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>Return="ignore" /&gt;</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>Then pop a reference to this new custom action in the &#8220;InstallExecuteSequence&#8221; section of the install script. Job&#8217;s a good&#8217;un. Or so I thought.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>An &#8220;normal&#8221; MSI produced by wix will have the following actions in its InstallExecutionSquence table There are many ways to added and remove stuff from this list, if you don&#8217;t do any of them this is what will be produced.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>ValidateProductID<SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>700<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>CostInitialize<SPAN style="mso-tab-count: 3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>800<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>FileCost<SPAN style="mso-tab-count: 3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>900<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>CostFinalize<SPAN style="mso-tab-count: 3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>1000<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>InstallValidate<SPAN style="mso-tab-count: 3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>1400<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>InstallInitialize<SPAN style="mso-tab-count: 3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>1500<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>ProcessComponents<SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>1600<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>UnpublishComponents<SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>1700<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>MsiUnpublishAssemblies<SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>1750<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>UnpublishFeatures<SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>1800<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>RemoveShortcuts<SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>3200<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>RemoveFiles<SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>3500<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>InstallFiles<SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>4000<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>CreateShortcuts<SPAN style="mso-tab-count: 1"> </SPAN><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>4500<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>RegisterUser<SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>6000<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>RegisterProduct<SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>6100<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>MsiPublishAssemblies<SPAN style="mso-tab-count: 1">&nbsp;&nbsp; </SPAN><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>6250<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>PublishFeatures<SPAN style="mso-tab-count: 1"> </SPAN><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>6300<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>PublishProduct<SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>6400<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>InstallFinalize<SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>6600 </FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>The interesting thing is an install whips though all of them on when both installation and uninstalling. On installation it starts with the lowest number and works forward, on uninstallation it starts with the highest number and works backwards. This is cool most of the time because most actions done by the installer are reversible, for example the installer knows that if you try and remover a file before you install it, it&#8217;s not a big deal.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>When you add in custom actions you add extra entries to this list; which creates a problem. Most CustomActions will have problems being run both on install and uninstall. To get round this you have to give your CustomAction a condition so it will only be run on installation or installation. You can find out load of good information about condition at the <A href="http://msdn.microsoft.com/library/default.asp?url=/library/en-us/msi/setup/conditional_statement_syntax.asp">Conditional Statement Syntax</A></FONT><FONT face=Arial size=2> section of the windows installer documentation. In case you&#8217;d rather not read though that and figure it out for you&#8217;re self I&#8217;ve given the systax below.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>A condition for a custom action that should only be run at install has the following format:</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>$<I style="mso-bidi-font-style: normal">ComponentName</I>&gt;2<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>A condition for a custom action that should only be run at uninstall has the following format:</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>$<I style="mso-bidi-font-style: normal">ComponentName</I>=2<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>This condition should be placed inside the Custom tag that controls when the CustomAction is executed. This gives our example wix file the following format:</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>&lt;InstallExecuteSequence&gt;<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>&lt;Custom Action="Test.exeFileRemoveNGen" After="MsiUnpublishAssemblies"&gt;$Test.exeComponent=2&lt;/Custom&gt;<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>&lt;Custom Action="Test.exeFileNGen" After="InstallFinalize"&gt;$Test.exeComponent&amp;gt;2&lt;/Custom&gt;<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>&lt;/InstallExecuteSequence&gt;<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>The full wix sources file is available <A href="http://www.strangelights.com/download.aspx?url=/blog/downloads/ngentypeuninstall.zip">here</A>. Again it should compile but will not link without an available Test.exe assembly.</FONT></P></FONT></FONT>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: CustomActions and uninstalls - Badri**

Hi i am doing upgrade coding using Cadle and light i.e. Wix I am Getting Install Finalize return 3. What Might the causes

**re: CustomActions and uninstalls - [Robert Pickering](http://strangelights.com/blog/)**

Sorry, I have no idea. You probably want to ask the wix mailing list. You will probably need to provide more details.<br><br><a target="_new" href="http://sourceforge.net/mail/?group_id=105970">http://sourceforge.net/mail/?group_id=105970</a>

**re: CustomActions and uninstalls - Warren**

Thankyou for this, it helps me out. With a few tweaks, your code works with the new version. http://schemas.microsoft.com/wix/2006/wi

**re: CustomActions and uninstalls - Pablo**

Great stuff!<br />I have a custom action which is not closely related to a component (it only sets some properties); which component should I use in the condition? Is just picking anyone OK?<br />Thanks for sharing, <br />Pablo.

**re: CustomActions and uninstalls - Sathish**

<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />I need clear unstalled wile unstalled the application services running...While start the unstallation error getting because the application services still running. I need to unstalled the application with custom action needed with stop the services...<br />

