---
title: "Subtle problem"
date: 2004-10-08T08:31:00.0000000
draft: false
---

<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>The following two lines of code look innocent enough, but they create a problem that took us ages to track down. (Well not these exact lines of code but you get the idea).</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt; mso-layout-grid-align: none"><SPAN style="FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 10.0pt"><FONT size=2>IPAddress address = IPAddress.Parse("");<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt; mso-layout-grid-align: none"><SPAN style="FONT-FAMILY: 'Courier New'; mso-bidi-font-size: 10.0pt"><FONT size=2>Console.WriteLine(address.ToString());<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt; mso-layout-grid-align: none"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt; mso-layout-grid-align: none"><FONT face=Arial size=2>The problem is on Windows XP (SP 1) this works fine, on Windows 2003 this code throws a FormatException. The reason is although you&#8217;re running exactly the same managed code the framework relies on unmanaged code to do most of the work, it p/invokes a method &#8220;inet_addr&#8221; in &#8220;ws2_32.dll&#8221; and this must be different between the two platforms. </FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt; mso-layout-grid-align: none"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt; mso-layout-grid-align: none"><FONT face=Arial size=2>I&#8217;ll explain why this caused us such a huge problem in another post. Well maybe.</FONT></P>
