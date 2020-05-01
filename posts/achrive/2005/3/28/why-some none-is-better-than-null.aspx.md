---
title: "Why Some/None is better than null"
date: 2005-03-28T07:19:00.0000000
draft: false
---

<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>People interested in the advantages for F# might do well to take a look at F# option type. This allows an F# programmer to specify the presents or absence of some data much the same way a C# programmer might use a null reference. </FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Let us take a quick look at how you might use the option type. It is implemented as a discriminating union so can be investigated with F#&#8217;s pattern matching constructs.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>let nodeText = match (get_single_node node &#8220;/fruit/apples&#8221;) with<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>| None -&gt; &#8220;&#8221;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>| Some node -&gt; get_node_text node<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><o:p><FONT size=2>&nbsp;</FONT></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>If we imagine get_single_node and get_node_text are functions from a ml style Xml api, we can see that above snippet will get the inner text from a single node at the location &#8220;/fruit/apples&#8221; and if the node does not exist it will return the empty string.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>At first this may look overly verbose if you compare it with a similar C# snippet.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>string nodeText = node.SelectSingleNode(&#8220;/fruit/apples&#8221;).Value<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>But here the C# programmer has made a mistake which is common amongst the young players. If the node does not exist then this snippet will throw a NullReferenceException, this can be a nightmare to debug if a method contains lots of statements like the above, as it can be difficult to spot which item is returning null.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>While there is nothing stop the C# programmer checking the item returned reference to set a default value, or throw a more meaningful exception. In the F# way of doing this the programmer is reminded to do this as the compiler will issue an incomplete pattern matching warning if they forget to set a default value.</FONT></P>
