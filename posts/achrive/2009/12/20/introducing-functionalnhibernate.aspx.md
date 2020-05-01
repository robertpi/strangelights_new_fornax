---
title: "Introducing FunctionalNHibernate"
date: 2009-12-20T12:26:44.5230000
draft: false
---

<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><span style="mso-ansi-language: EN-US" lang="EN-US"><font size="3">It’s already fairly well documented that <a href="http://www.atrevido.net/blog/2009/04/01/Using+Fluent+NHibernate+With+F.aspx">F# doesn’t play too well with NHibernate and Fluent NHibernate</a>, although you can <a href="http://www.atrevido.net/blog/2009/04/23/Update+On+F+With+Fluent+NHibernate.aspx">make it play a littler nice with a bit of effort</a>. However there are a few fundamental problems with this approach. The first is F# class’ are not really designed to be data containers because that’s what its record type is for. The second is that F# class’ do not put too much emphasis on virtual methods as in functional programming we tend to using pass functions as values as a way to achieve polymorphism rather than virtual methods. Third and finally FluentNHibernate works with C#’s expression trees, it would be nice use F#’s quotation system instead. <o:p /></font></span></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><span style="mso-ansi-language: EN-US" lang="EN-US"><font size="3">Record types are a fixed collection of names and fields a lot like the row in a database. Below shows a record type we’d like to be able to store in a database table. Here we show an invoice record type that we’d like to serialize in the database.<o:p /></font></span></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><span style="mso-ansi-language: EN-US" lang="EN-US"><o:p><font size="3"><img alt="Record type" src="/blog/Photos/FunNH_record.png" /> </font></o:p></span></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><span style="mso-ansi-language: EN-US" lang="EN-US"><font size="3">What we’d like to be able to write is a mapping class that describes how it should be serialized, like you can do in FluentNHibernate:<o:p /></font></span></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><span style="mso-ansi-language: EN-US" lang="EN-US"><o:p><font size="3"><img alt="functional nhibernate mapping" src="/blog/photos/FunNH_mapping.png" /> </font></o:p></span></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><span style="mso-ansi-language: EN-US" lang="EN-US"><font size="3">The idea of FunctionalNHibernate is to provide a layer to do just this. As you see we provide a neat way to describe the mappings. We achieve the record serialization by providing a custom tupilizer for F# record types. There’s also the start of a wrapper for the SessionFactory that will hopefully allow you to store and retrieve data in way more natural for F#. <o:p /></font></span></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><span style="mso-ansi-language: EN-US" lang="EN-US"><font size="3">The idea of this project is not to detract from FluentNHibernate, it’s a great project and works really nicely from C#. I want to provide something that will work equally well from F#. We’re a long way behind them and to be honest the project isn’t really usable yet. I have project in mind that I want to use it on, so hopefully I’ll be able to improve it as I go along.<o:p /></font></span></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><span style="mso-ansi-language: EN-US" lang="EN-US"><font size="3">The result is you can now write the following program to store, update and retrieve our invoice record type:<o:p /></font></span></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><span style="mso-ansi-language: EN-US" lang="EN-US"><o:p><font size="3"><img alt="fun nhibernate program" src="/blog/photos/FunNH_prog.png" /> </font></o:p></span></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><span style="mso-ansi-language: EN-US" lang="EN-US"><font size="3">The project is hosted on <a href="http://bitbucket.org/robertpi/functionalnhibernate/">bitbucket.org</a>, where you can explore or download the code. Feel free to drop me a line if you want to help out.<o:p /></font></span></p>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**Social comments and analytics for this post - [uberVU - social comments](http://www.ubervu.com/conversations/strangelights.com/blog/archive/2009/12/20/1650.aspx)**

This post was mentioned on Twitter by robertpi: Introducing FunctionalNHibernate: <a rel="nofollow external" href="http://bit.ly/6tSmtE" title="http://bit.ly/6tSmtE">http://bit.ly/6tSmtE</a>

**The Morning Brew - Chris Alcock  &amp;amp;raquo; The Morning Brew #502 - http://blog.cwa.me.uk/2009/12/21/the-morning-brew-502/**

The Morning Brew - Chris Alcock  &amp;amp;raquo; The Morning Brew #502

**F# Discoveries This Week 12/21/2009 - [Rick Minerich's Development Wonderland](http://www.atalasoft.com/cs/blogs/rickm/archive/2009/12/21/f-discoveries-this-week-12-21-2009.aspx)**

By far the most exciting news this week was the preview release of Microsoft Research Accelerator.&amp;amp;#160;

**F# Database Programming &amp;amp;#8211; FunctionalNHibernate? &amp;amp;laquo; Tales from a Trading Desk - http://mdavey.wordpress.com/2009/12/25/f-database-programming-functionalnhibernate/**

F# Database Programming &amp;amp;#8211; FunctionalNHibernate? &amp;amp;laquo; Tales from a Trading Desk

**Xanax. - [Xanax.](http://mehm75.multiply.com/journal/compose)**

Buy xanax without prescription in usa. Xanax. No prescription xanax.

**re: Introducing FunctionalNHibernate - Jim Ray**

Great article!<br /><br />Nit-pick: the plural of &quot;class&quot; is &quot;classes.&quot;<br /><br /><a rel="nofollow external" href="http://grammar.ccc.commnet.edu/grammar/plurals.htm" title="http://grammar.ccc.commnet.edu/grammar/plurals.htm">http://grammar.ccc.commnet.edu/grammar/plurals.htm</a>

