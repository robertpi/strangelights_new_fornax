---
title: "Functional Programming in C# 2.0 - Folding"
date: 2005-08-12T19:44:00.0000000
draft: false
---

<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><FONT size=2><FONT face=Verdana>Late there has been quite a lot of talk about functional programming in C#. Efforts by <A href="http://www.pluralsight.com/blogs/dbox/default.aspx">Don Box</A>, have been note and used on this blog several times and now that and now <A href="http://blogs.msdn.com/sriram/archive/2005/08/07/448722.aspx">Sriram Krishnan</A> has produced this nice piece on currying in C# 2.0.<?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p></o:p></FONT></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p><FONT face=Verdana size=2>&nbsp;</FONT></o:p></SPAN></P><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><FONT size=2><FONT face=Verdana>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">One area that seams to have been over looked so far is folding. A folding function is similar to a mapping function and mapping functions are supported by the framework library in version 2.0, expect it calls it ConvertAll. For example, the framework defines the following method on the List&lt;T&gt; class:<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p>&nbsp;</o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">public List&lt;TOutput&gt; ConvertAll&lt;TOutput&gt;(Converter&lt;T, TOutput&gt; converter);<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p>&nbsp;</o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">It&#8217;s not hard to see this can be used to map one list to another, like so:<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p>&nbsp;</o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">List&lt;string&gt; stringList = <o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">intList.ConvertAll&lt;string&gt;(<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt 35.4pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">delegate(int intput) { return intput.ToString(); }<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">);<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p>&nbsp;</o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">Folding is similar, except that where a mapping function applies a transformation to a list a folding function produces a summary. F# defines a folding function on this list type like so:<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p>&nbsp;</o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">let rec fold f acc l = <o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><SPAN style="mso-spacerun: yes">&nbsp; </SPAN>match l with <o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><SPAN style="mso-spacerun: yes">&nbsp;&nbsp;&nbsp; </SPAN>[] -&gt; acc<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><SPAN style="mso-spacerun: yes">&nbsp; </SPAN>| (h::t) -&gt; fold_left f (f acc h) t<SPAN style="mso-spacerun: yes">&nbsp; </SPAN><o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p>&nbsp;</o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">This is a function that has 3 parameters; the fist one of these is function that takes two parameters, the second is the accumulator and the third is the list to be folded. This translates to C# something like:<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p>&nbsp;</o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">public delegate TReturn AStarBToB&lt;TInput, TReturn&gt;<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">(TInput value1, <o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">TReturn value2);<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p>&nbsp;</o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">public static TAcc Fold&lt;TList, TAcc&gt;(<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">AStarBToB&lt;TList, TAcc&gt; funct, <o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">TAcc acc, <o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">IEnumerable &lt;TList&gt; list)<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">{<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>foreach (TList item in list)<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">{<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><SPAN style="mso-tab-count: 2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>acc = funct(item, acc);<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>}<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>return acc;<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">}<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p>&nbsp;</o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">This provides a very easy to create summaries of lists:<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p>&nbsp;</o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">// intList = {1, 2, 3, 4, 5, 6}<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">int result1 <o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">= Fold(<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt 35.4pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">delegate(int value1, int value2) { return value1 + value2; }, <o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt 35.4pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">0, <o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt 35.4pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">intList<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">);<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">// result1 = 21<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p>&nbsp;</o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">string result2 = <o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">Fold(<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt 35.4pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">delegate(int value1, string value2) { return value2 + ", " + value1; }, <o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt 35.4pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">"", <o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt 35.4pt; TEXT-INDENT: 35.4pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">intList);<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">// result2 = &#8220;, 1, 2, 3, 4, 5, 6&#8221;<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p>&nbsp;</o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB"><o:p>&nbsp;</o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN lang=EN-GB style="mso-ansi-language: EN-GB">And that&#8217;s it! It takes just one line of code to produce a summering of a list and the technique can be applied to any object that supports the IEnumberable&lt;T&gt; interface, which is quite a few.<o:p></o:p></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"></FONT></FONT></SPAN></P>
