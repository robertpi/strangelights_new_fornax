---
title: "Inferred type system"
date: 2004-09-14T20:52:00.0000000
draft: false
---

<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2></FONT>&nbsp;</P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>A couple of days ago I was reading a post about <A href="http://lambda-the-ultimate.org/node/view/252">dynamic languages</A> (scripting languages with good PR) on <A href="http://lambda-the-ultimate.org">lambda the ultimate</A>. The author wrote &#8220;&#8217;strong&#8217; typing is not the same as &#8216;explicit typing&#8217;&#8221;, which is very true and got me thinking about inferred type system, such as the one F# uses.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>The big advantages is that doesn&#8217;t seem to be talked about much is that because in inferred type you don&#8217;t explicitly say what type an identifier is you get a lot more choice about what you compile it down to. This is especially important in the world of .NET where many different languages could use a library that you produce. F# uses this to be able to support both a generic and non generic CLR with out having use different syntax. This is something that none of the commercially supported languages can offer, and will definitely be supported in the as yet unreleased version 0.7 via &#8211;no-generics compiler switch.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>For example the following F# code:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>let add x = x :: []<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Will compile down to equivalent C#:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>public static List&lt;A&gt; add&lt;A&gt;(A x)<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>{<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-spacerun: yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>return new List&lt;A&gt;(x, null);<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>}<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>However specify the &#8211;no-generics switch and the equivalent C# is:</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>public static List add(object x)<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>{<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-spacerun: yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>return new List(x, null);<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>}<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>While there&#8217;s not going to be a huge number of people who will need this feature, it&#8217;s nice to know it&#8217;s there.</FONT></P>
