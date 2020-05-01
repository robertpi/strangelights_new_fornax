---
title: "Don Box/Sam Ruby on Continuations"
date: 2005-04-23T16:04:00.0000000
draft: false
---

<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>The ever charismatic Mr. Box made a lovely post about continuations in C# 2.0:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><A title=http://pluralsight.com/blogs/dbox/archive/2005/04/17/7467.aspx href="http://pluralsight.com/blogs/dbox/archive/2005/04/17/7467.aspx"><FONT face=Arial size=2>http://pluralsight.com/blogs/dbox/archive/2005/04/17/7467.aspx</FONT></A></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Because I have used a simpler Fibonacci implementation in couple of places, I thought I&#8217;d port it to F#.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Of course continuations are not a new idea; they have been used for a long time in ML style programming. The implementation is most like the continuations by anonymous methods, as anonymous methods work well in ML as they are very similar idea to lambdas.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Here is the source:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><o:p><FONT size=2>&nbsp;</FONT></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>let fib() = <o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>let i = ref 0 in <o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>let j = ref 1 in<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>let cont() = (<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-spacerun: yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>let result = !i in<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>i := !j;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>j := result + !j;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>result<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>) in<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>cont<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><o:p><FONT size=2>&nbsp;</FONT></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>let _ = let x = ref 0 in<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>let f = fib() in<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>while !x &lt; 1000 do<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>x := f();<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-spacerun: yes">&nbsp;</SPAN><SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>Printf.printf "%d\n" !x;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>done;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>()<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><SPAN style="mso-tab-count: 1"><FONT size=2></FONT></SPAN></SPAN></P>
