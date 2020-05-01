---
title: "Foundations of F# - Second Edition"
date: 2009-01-17T18:11:42.9670000
draft: false
---

<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3" face="Calibri" /></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3" face="Calibri">I’m very pleased to announce I’ve started working on a second edition of Foundations of F#. The aim is to document the language in the form it will be in when it is released in with Visual Studio 2010. This will be a challenge since it’s not yet known exactly what features will be in the final release.</font></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3" face="Calibri">So, why a second edition? It’s true that the original book is only about 2 years old, but that’s quite a long time in the IT industry these days and much has change in the F# landscape since the original was wrote and indeed much in the .NET platform has evolved. When the original was written F# was still primarily a research project, entirely driven by Microsoft Research and had a relatively small user community and evener fewer commercial users. Now F# is being co-developed by Microsoft Corporate in Seattle and Microsoft Research in Cambridge into a product. While the community remains relative small compared to that of C++, C# and Java the community site </font><a href="http://cs.hubfs.net/"><font size="3" face="Calibri">http://cs.hubfs.net</font></a><font size="3" face="Calibri"> has seen grown enormously since the first editions releases and question regularly pop up on </font><a href="http://stackoverflow.com/"><font size="3" face="Calibri">http://stackoverflow.com</font></a><font size="3" face="Calibri"> too. The language has also attracted some major commercial users, <a href="http://blogs.msdn.com/dsyme/archive/2008/09/19/f-job-senior-role-at-credit-suisse-in-functional-programming.aspx">Credit Suisse </a>recently announced they indented to develop their quantitative models that are deployed on the .NET platform in F#,</font><font size="3" face="Calibri"> other commercial users include <a href="http://www.coherentpdf.com/">Coherent PDF</a></font><font size="3" face="Calibri"> and <a href="http://www.ffconsultancy.com/dotnet/fsharp/index.html">flying frog consultancy</a></font><font size="3" face="Calibri">. Also my own opinions about programming have evolved over the past two years; I’m now a professional functional programmer and so have a much greater experience about functional programming and want to share that with you.</font></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3" face="Calibri">What are my aims for the second edition? I believe the first edition was generally well received I have certainly received a lot of mail form reads and the vast majority of it has been very positive. The reviews on amazon.com are mostly positive too; however there are some criticisms and I indent to address these in the second edition. Name the code will be more accurate, and it will be focused on functional style and give better advice about building applications in F#. The errors in the code generally arouse form the fact the code was written Visual Studio then manually copied and pasted into word, making it difficult to recheck the codes accuracy as version of F# changes, also let to the temptation to make small edits of the code without checking them. To address the code quality issue: all code is now insert via a script and all the code samples will be available on codeplex, meaning there more easily available anyone interested can check them and send me comments. The codeplex project is: </font><a href="http://www.codeplex.com/FOFS"><font size="3" face="Calibri">http://www.codeplex.com/FOFS</font></a><font size="3" face="Calibri">. To address functional programming issues I’ll be doing a major rewrite of the functional programming issue to put more emphasis on good functional style and I’ll also be adding a chapter called “Anatomy of an F# Application” to try and give some guidance on how to build an application in F#. I also want to document all the new features of F#, Active Patterns, Workflows and Units of Measure.</font></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3" face="Calibri">Concretely how will the book change? I’m aiming for evolution rather than revolution, each chapter will be carefully reviewed and updated, and there will be quite a lot of new material too. As I’ve said the chapter that will see the biggest changes is chapter 3, most of the original examples in this chapter will probably stay but this will be better organised to give more emphasis on functional style and there’ll be some new material too. There’ll be three new chapters, “Concurrency”, “Parsing Text” and “Anatomy of an F# Application”. <span style="mso-spacerun: yes"> </span>I didn’t tackle “Concurrency” in the first edition because, to be honest, I didn’t know that much about concurrency, also I felt F# didn’t offer that many advantages in the concurrent programming. In the past two years I’ve learnt a lot more about concurrency (although there’s still more to know), F# has new and interesting features for tackling concurrency and it’s now a more important topic that ever, so it’ll definitely be in this book. The parsing “Parsing Text” chapter is be added because I want to grow the “Language Oriented Programming” chapter, I thought the original chapter was good but I want to put more emphasis on using the technique to tackle real world problems, so the chapter will grow and the sections concerned purely with parsing text will be split off. I also want to cover techniques other than fslex/fsyacc for parsing text such as <a href="http://www.quanttec.com/fparsec/">fsparses</a></font><font size="3" face="Calibri"> and <a href="http://msdn.microsoft.com/en-us/library/dd129869.aspx">mgrammar</a></font><font size="3" face="Calibri">. <span style="mso-spacerun: yes"> </span>“Anatomy of an F# Application” will address the need for more advice on how to build complete applications in F#.</font></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3" face="Calibri">Well that’s it for now. Feel free to send comments and suggestion to the usual address and check out the examples at codeplex: </font><a href="http://www.codeplex.com/FOFS"><font size="3" face="Calibri">http://www.codeplex.com/FOFS</font></a></p>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: Foundations of F# - Second Edition - Andreas**

Typo in Link<br />&quot;<a rel="nofollow external" href="http://cs.hubsf.net/&quot;" title="http://cs.hubsf.net/&quot;">http://cs.hubsf.net/&quot;</a><br /><br />should be<br />&quot;<a rel="nofollow external" href="http://cs.hubfs.net/&quot;" title="http://cs.hubfs.net/&quot;">http://cs.hubfs.net/&quot;</a>

**re: Foundations of F# - Second Edition - [Wonseok Chae](http://fsharp.tistory.com/14)**

Hi, Robert. I am already looking forward to your second edition and post this good news on my blog (Korean though.) Particularly, I really like your F# landscape. Please, keep posting such a good one often. Thanks.<br /><br />p.s. The link to hubFS has a typo.<br />

**re: Foundations of F# - Second Edition - [robert](http://strangelights.com/blog/Default.aspx)**

Thanks!<br /><br />Links fixed now.

**re: Foundations of F# - Second Edition - [Amanda](http://pandamonial.com/)**

Great to hear! Can't wait  to see it.

**re: Foundations of F# - Second Edition - [Nair](http://www.myfavoritemovies.us/movies)**

I bought the first book and I was very happy with that book. I would like to know, will you be adding new section on Silverlight or any web related technologies. Based on my understanding and previous reads I think F# could a good fit for Async calls than C#.

**re: Foundations of F# - Second Edition - [Robert Pickering](http://strangelights.com/blog/Default.aspx)**

Hi Nair,<br /><br />I've just rewritten the section on user interfaces and didn't add too much stuff about the web. I will be adding quite a bit more about making async calls, and I think about including a section about working with different versions of the CRL which will include Sliverlight.<br /><br />Cheers,<br />Rob

**re: Foundations of F# - Second Edition - Christian**

Hi<br />This book will be in spanish too??

**re: Foundations of F# - Second Edition - [Robert Pickering](http://strangelights.com/blog/Default.aspx)**

Only if you can suggest a publisher who would be will to translate it :)<br /><br />Thanks,<br />Robert

**re: Foundations of F# - Second Edition - [Nair](http://www.myfavoritemovies.us/movies)**

Fantastic. Can't wait for the book.

**re: Foundations of F# - Second Edition - [Cheap Web Hosting](http://www.webhostingforest.com/)**

I am already looking forward to your second edition and post this good news on my blog (Korean though.) Particularly, I really like your F# landscape. Please, keep posting such a good one often. Thanks.

**re: Foundations of F# - Second Edition - [Cheap Web Hosting](http://www.webhostingforest.com/)**

I will be adding quite a bit more about making async calls, and I think about including a section about working with different versions of the CRL which will include Sliverlight.<br />

