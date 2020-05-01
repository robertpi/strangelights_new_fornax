---
title: "Dynamic compilation, evaluation, and a console"
date: 2005-06-05T13:45:00.0000000
draft: false
---

<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>A couple of weeks ago Don Box made a post about <A href="http://www.pluralsight.com/blogs/dbox/default.aspx">dynamic evaluation in C#</A>. Since a console and dynamic evaluation are popular feature request for F# I decided to have ago at implementing this in F#. The results can be found <A href="http://www.strangelights.com/download.aspx?url=/blog/downloads/FsConsole.zip">here</A>.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>At the moment it&#8217;s pretty limited, you can just evaluate an express and the result will get thrown away, only values that are not functions will be evaluated properly, there&#8217;s no error handling and the printing of the output types is a little limited. It's only been tested with Framework 2.0, although it should (in theroy)&nbsp;work with all frameworks.&nbsp;I hope to work on removing these limitations and more add more features, to eventually produce a useful tool.</FONT></P>
