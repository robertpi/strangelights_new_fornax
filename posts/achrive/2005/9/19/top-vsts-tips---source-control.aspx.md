---
title: "Top VSTS Tips - source control"
date: 2005-09-19T13:24:00.0000000
draft: false
---

<SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><FONT size=2><FONT face=Verdana>If you want use the source control get to know the new command line tool 'h'. It seems what you can do though the IDE is a bit limited, for example there doesn't seem to be away to map source control folder to a folder on the disk without using 'h'.<o:p></o:p></FONT></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p><FONT face=Verdana size=2>&nbsp;</FONT></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><FONT size=2><FONT face=Verdana>The full details of the commands are available here:<o:p></o:p></FONT></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><A href="http://blogs.msdn.com/buckh/articles/CommandLineSummary.aspx"><FONT face=Verdana size=2>http://blogs.msdn.com/buckh/articles/CommandLineSummary.aspx</FONT></A><o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p><FONT face=Verdana size=2>&nbsp;</FONT></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><FONT size=2><FONT face=Verdana>And if you did want to map a folder the syntax would be:<o:p></o:p></FONT></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><FONT size=2><FONT face=Verdana>h workfold /map /workspace:MyWorkspaceName $/MySSPath C:\MyPath<o:p></o:p></FONT></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p><FONT face=Verdana size=2>&nbsp;</FONT></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><FONT size=2><FONT face=Verdana>There are a couple of slightly annoying things:<o:p></o:p></FONT></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><FONT size=2><FONT face=Verdana>&nbsp;- There&#8217;s no way copy and past the path so you have type it out in manually<o:p></o:p></FONT></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><FONT size=2><FONT face=Verdana><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><FONT size=2><FONT face=Verdana>&nbsp;- </FONT></FONT></SPAN>Once you&#8217;ve mapped the path you can&#8217;t just &#8220;check out&#8221; and start editing, you have to get latest version first. (All right, this is only a small thing but its very annoying if you have to spend time wondering why &#8220;check out&#8221; is still greyed out)<o:p></o:p></FONT></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p><FONT face=Verdana size=2>&nbsp;</FONT></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p></o:p></SPAN><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><FONT size=2><FONT face=Verdana>More "Top Tips" to follow once I have the msbuild syntax figured out ...<o:p></o:p></FONT></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"></o:p></SPAN></P>
