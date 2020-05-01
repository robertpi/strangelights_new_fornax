---
title: "Extensible programming languages"
date: 2005-01-19T18:09:00.0000000
draft: false
---

<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>I came across this <A href="http://www.acmqueue.com/modules.php?name=Content&amp;pa=showpage&amp;pid=247&amp;page=1">article</A> via <A href="http://developers.slashdot.org/article.pl?sid=05/01/18/2157249&amp;from=rss">Slashdot</A>, which seems to be an abridge of <A href="http://www.third-bit.com/~gvwilson/xmlprog.html">an article</A> that I&#8217;d already seen via <A href="http://lambda-the-ultimate.org/classic/general.html">lambda the ultimate</A>.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>The idea of extensible programming languages is interesting one but not a particularly a new one and nor do I think xml is the right tool for solving these problems. </FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2><STRONG>XML as a programming language</STRONG></FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>XML is a good way of representing data, especially if the data needs to be passed between systems or serialised for storage. This is because there are well established API for processing xml so you don&#8217;t need rewrite a parser for each data format. It is also more human readable than some other formats.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="mso-spacerun: yes"><FONT face=Arial size=2></FONT></SPAN>&nbsp;</P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>But just because it is easier to read than some other data formats doesn&#8217;t mean it is particularly good for expressing programs, in fact expressing things that most people have come to expect from programming languages such as assignments or label associations, in a way that people have come to expect, is pretty difficult because of the tag based nature of the language. I also have some practical experience of using xml based languages from my programming in WIX and, well, they just look plain ugly to me. So for the consumers of xml things are two great.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>The only advantage xml based languages to the extenders of XML based languages is that the abstract syntax tree code be exposed to them thought the DOM interface. But is this really an advantage? Would it be that hard to come up this a better API for exposing the AST? Give that large number of ways to represent an AST (the .NET framework has two API build in to it that do a very similar job, that is, CodeDom and Reflection) I think answer is yes.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2><STRONG>The idea of programming language extensibility</STRONG></FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="mso-spacerun: yes"><FONT face=Arial size=2></FONT></SPAN>&nbsp;</P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Even if you discount C text marcos as not a very good way to extend a languages functionality, the idea of programming language extensibility has still been around for a while. It is used in a lot in functional programming a lot, a common pattern in functional programming is to design a domain specific language (or little language) to describe a problem then use this domain specific language to solve the problem. </FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2><SPAN style="FONT-SIZE: 10pt; FONT-FAMILY: Arial; mso-bidi-font-size: 12.0pt; mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman'; mso-ansi-language: EN-GB; mso-fareast-language: EN-GB; mso-bidi-language: AR-SA"><STRONG>Extensible programming languages are already here</STRONG></SPAN></FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>I&#8217;ve been looking at language called <A href="http://Nemerle.org">Nemerle</A> as part of a wider study on the .NET framework. Put simply Nemerle&#8217;s big idea is to expose the compilers AST to the programmer so that they can create Turing complete macros for the language. It&#8217;s a powerful idea, concepts that are usally hard code into the compiler, like a for loop, are implement as macros in nemerle. It&#8217;s still at the research stage so its difficult to call how well if works in practice, but worth taking a look if you are interested in programming language extensibility.</FONT></P>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: Extensible programming languages - [RichB](http://blogs.aspadvice.com/rbirkby)**

You should also have a look at lcsc - an easily extendable C# compiler from Microsoft Research. In fact, the concurrent programming extensions in Cw (COmega) were originally in a language called Polyphonic C# which  was implemented on top of lcsc's AST.

**re: Extensible programming languages - [Robert Pickering](http://strangelights.com/blog)**

Thanks for the tip, but is lcsc publicly available? I've checked the downloads page (<a target="_new" href="http://research.microsoft.com/research/downloads">http://research.microsoft.com/research/downloads</a>) and the only lcsc item is &quot;LCSC benchmark&quot;, which appears to be a bench marking tool built in on top of LCSC.

**re: Extensible programming languages - [booer](http://boo.codehaus.org/)**

Check this out:<br><a target="_new" href="http://boo.codehaus.org/">http://boo.codehaus.org/</a><br><br>...specially &quot;syntactic attributes&quot; and &quot;syntactic macros&quot;:<br><br><a target="_new" href="http://boo.codehaus.org/">http://boo.codehaus.org/</a>Boo+Compiler

**re: Extensible programming languages - [Thomas Mertes](http://seed7.sourceforge.net/)**

I do not think that XML is the answer to everything. An extensible programming language should IMHO not be XML based. Being an extensible programming language means: User defined statements, operators and declaration constructs. High level constructs should make an extensible programming language easily readable by humans. XML has the opposite goal of being easy readable by programs. I am biased, but take a look at Seed7.<br /><br />Greetings Thomas Mertes<br /><br />Seed7 Homepage:  http://seed7.sourceforge.net<br />Seed7 - The extensible programming language:<br />User defined statements and operators,<br />abstract data types, templates without<br />special syntax, OO with interfaces and multiple<br />dispatch.<br />

