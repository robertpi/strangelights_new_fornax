---
title: "NGen Custom Actions using WiX"
date: 2004-06-29T20:34:00.0000000
draft: false
---

<P class=MsoNormal style="MARGIN: 0in 0in 0pt"></P><FONT face=Arial size=2>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>I recently had to create an msi installer that ran ngen on each of the assemblies that I installed. I had a number of difficulties doing this, so I thought I share my findings here an hopefully save others a bit of time.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>I won&#8217;t have been able to do this at all with out orca, an MSI decompiler supplied with the installer section of the platform SDK. Also looking at the <A href="http://msdn.microsoft.com/library/default.asp?url=/library/en-us/msi/setup/database_tables.asp">definitions of the MSI</A> tables helped a lot.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>The <A href="http://msdn.microsoft.com/library/default.asp?url=/library/en-us/msi/setup/customaction_table.asp">CustomActions </A>is a bit of a strange beastie, it has just 4 column, these are Action (the primary key), Type, Source and Target, but the mean of the columns Sources and Target can vary radically depending on the integer value in Type. Wix does not allow you to directly add values to Type column; it provides a number of different properties, with each property representing a different type of thing that could go in the CustomActions table. From the action that you describe using the properties it then works out what type of action you want. This sounds more complex than it really is, for example if you have a custom action tag &lt;CustomAction Id=&#8221;&#8221; VBcriptCall=&#8221;MsgBox &#8216;dump thing to do&#8217;&#8221;&gt; a custom action of Type 6 gets generated because Type 6 is a VBScript call.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>I looked at the windows installer documentation for the CustomActions table. From a quick review of the <A href="http://msdn.microsoft.com/library/default.asp?url=/library/en-us/msi/setup/summary_list_of_all_custom_action_types.asp">list of custom action types </A>I saw that I either needed an action of 34 or 50. I plumped for type 50 for no other reason than I figured out the wix syntax to generate this first. For reasons I&#8217;ll explain later I may have been better going for a type 34, but for now I&#8217;m happy with what I&#8217;ve got.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>Actions of type 50 require an entry in the property table that points to the executable location a foreign key to the property table is placed in the Source column and the Target column is the command line parameters for the executable.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>Creating an entry in the property table is easy, the syntax is given below. But this is why I suggest a Type 34 might have been more appropriate. Entries in the property table provide no way of giving indirection to well know directories, so I was stuck with hard coding the path. I tried using the %windir% shell environment variable syntax, [%windir] msi environment variable syntax and [WindowsDirectory] to reference the msi property. None worked; it has to be just a plain old string. This is okay for me as my msi only be deployed on environments that we control, so we can be sure ngen will always be in the same place.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>&lt;Property Id="NGenLocationProperty" Value="c:\windows\Microsoft.NET\Framework\v1.1.4322\ngen.exe" /&gt;</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>Now to add the CustomAction all we need to do is add a custom action tag, the syntax for this is shown below. The ExeCommand property contains the command line parameters, the most important thing to note about these is I can refernce the full file path of a file in my wix script using the syntax [#<I style="mso-bidi-font-style: normal">FileId</I>] where <I style="mso-bidi-font-style: normal">FileId </I>is the Id property of a file tag.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>&lt;CustomAction Id="Test.exeFileNGen" ExeCommand='"[#DataPharm.PharmaNet.Logging.dllFile]"' Property="NGenLocationProperty" /&gt;</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>You then need to ensure you CustomAction is run by giving it an entry in the InstallExecuteSequence table. This is dead easy and the syntax is shown below. The only thing you have to whatch is the After property on the Custom tag, I found this had to be InstallFinalize as the files haven&#8217;t been written to disk until after this.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>&lt;InstallExecuteSequence&gt;<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT size=2><FONT face=Arial>&lt;Custom Action="Test.exeFileNGen" After="InstallFinalize" /&gt;<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>&lt;/InstallExecuteSequence&gt;</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>That about it, the full script is available for down load <A href="http://www.strangelights.com/download.aspx?url=/blog/downloads/ngenexample.zip">here</A>. It should compile, but will require a .Net assembly called test.exe in the same directory to link. The script also has an example of a short cut but I don&#8217;t feel that really needs any explanation.</FONT></P></FONT>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: NGen Custom Actions using WiX - [Rob Mensching](http://blogs.msdn.com/robmen)**

Very cool, Robert.  Also, one of the big changes I have on my machine (that I need to get pushed to SourceForge, hopefully by end of next week) has lots more documentation about the CustomAction element.  Hopefully, that documentation will help map to the Windows Installer SDK as well.

**Re: Anyone use WiX? - [Channel 9](http://beta.channel9.msdn.com/Forums/Techoff/14155-Anyone-use-WiX/Comments/14252/)**

Yes, I use wix, I have to admit it's not the easiest tool in the world, but it does give you a fair bit of flexiblity.

