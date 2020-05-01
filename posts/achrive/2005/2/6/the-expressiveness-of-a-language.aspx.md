---
title: "The Expressiveness of a Language"
date: 2005-02-06T18:41:00.0000000
draft: false
---

<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>People have been known to ask me, what makes F# better than C#? This is a since what people think is good or bad about a programming languages just comes down to taste. However Alejandro Serrano blog post about how an <A href="http://serrasfsharp.liquidbluex.net/index.php?title=typeof_msil&amp;more=1&amp;c=1&amp;tb=1&amp;pb=1">F# typeof operator can be defined</A></FONT><FONT face=Arial size=2> got me thinking about things you can do in F# that you can in C#. In it he describes how you can define a typeof operator for F#, this is something you can not do it C# the type of function is build in to the compiler and can not be defined as a method.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>While the typeof operate cheats slightly by utilising F# ability to mix IL source into a F# source file, there are a couple of other operators which replicate functionality build into the C# compiler as pure F# functions. These functions are using and lock, both in F#&#8217;s Microsoft.FSharp.Idioms namespace. Let&#8217;s take a quick look at the using function; F# defines this to be:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT size=2><FONT face=Arial>let using (ie: System.IDisposable) f = <o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT size=2><FONT face=Arial><SPAN style="mso-spacerun: yes">&nbsp; </SPAN>try f()<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT size=2><FONT face=Arial><SPAN style="mso-spacerun: yes">&nbsp; </SPAN>finally ie.Dispose()</FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>One would typically use this something like:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT size=2><FONT face=Arial>open System.IO<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>open Microsoft.FSharp.Idioms</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT size=2><FONT face=Arial>let _ = let writer = File.AppendText("text.txt") in<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT size=2><FONT face=Arial><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>let f() = <o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT size=2><FONT face=Arial><SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>writer.WriteLine("written in a safe way") in<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT size=2><FONT face=Arial><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN><SPAN style="mso-spacerun: yes">&nbsp;</SPAN>using (upcast writer) f<o:p></o:p></FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>So we define some a reference to an object that refers to some unmanaged resources, that is a stream writer in the line &#8220;let writer = File.AppendText("text.txt")&#8221;, then we defines some operations on it, that is the &#8220;let f() = &#8230;&#8221;, then we use the using function to say we&#8217;d like the operations to happen then have the object disposed of in a finally block.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>So why can we do this in C#? The using statement in C# relies on macro like expansion from the C# compiler, so:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>using(StreamWriter writer = File.AppendText("text.txt"))</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>{</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT size=2><FONT face=Arial><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>writer.WriteLine("written in a safe way");</FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>}</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Expands to:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>StreamWriter writer = File.AppendText("text.txt");</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>try</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>{</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT size=2><FONT face=Arial><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>writer.WriteLine("written in a safe way");</FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>}</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>finally</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>{</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT size=2><FONT face=Arial><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>writer.Dispose();</FONT></FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>}</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>You can not do this kind of thing in C# code because C# does not allow you to pass a method as a value; making is impossible insert a function call into the middle of the method unless you resort to using delegates.</FONT></P>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: The Expressiveness of a Language - [Don Syme](http://blogs.msdn.com/dsyme)**

Hi Robert,<br><br>Once you get used to it doing this sort of abstraction-of-control-patterns in F# is very nice.<br><br>Just to note that with the type checking features added in F# 1.0.4 the code above can now be written:<br><br>let writer = File.AppendText(&quot;text.txt&quot;) in<br>let f() = writer.WriteLine(&quot;written in a safe way&quot;) in<br>using (writer) f<br><br>or I prefer to use an inline function with a begin/end pair:<br><br>let writer = File.AppendText(&quot;text.txt&quot;) in<br>using (writer) begin fun () -&gt; <br>  writer.WriteLine(&quot;written in a safe way&quot;)<br>end<br><br>Cheers!<br>Don<br>

