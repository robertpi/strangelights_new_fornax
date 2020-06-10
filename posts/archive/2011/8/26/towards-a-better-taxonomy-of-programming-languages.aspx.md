---
title: "Towards a Better Taxonomy of Programming Languages"
date: 2011-08-26T11:09:34.2070000
draft: false
---

<p>I think the term “Object Oriented” is somewhat over used these days, in fact I’d go so far as to say it’s been applied to such a wide variety of different languages that the term has become somewhat meaningless. Java and C# are object oriented languages and although these languages are fairly similar they are quite different from Javascript which also claims to be an object oriented language. Some might say that Javascript and Python are similar as they are both dynamically typed languages and they are both object oriented yet the way in which they are object oriented differs. All of the languages mentioned above are different to the original object language, SmallTalk, which is why we have Alan Kay’s famous quote “<a href="http://en.wikiquote.org/wiki/Alan_Kay">Actually I made up the term "object-oriented", and I can tell you I did not have C++ in mind</a>”.</p>  <p>To add to the confusion language designs change over time, with each new release of a language the language designers add new feature. Often language designers borrow ideas from other paradigms, meaning languages rarely remain just procedural, functional or object oriented but tend to end up as mixed paradigms language. </p>  <p>Given this, I don’t think it’s particularly useful just to talk about object oriented programming any more. It’s more useful to talk about the programming style that the language emphasizes and perhaps more importantly the set of features a language supports.</p>  <p>When it comes programming style people tend to think that object oriented programming is the opposite of functional programming or at least is in some way juxtaposed to it. I don’t think this is true, object oriented programing tends to concern itself with “programming in the large”, how systems are decomposed into modules while functional programming is about programming with <a href="http://en.wikipedia.org/wiki/Expression_(computer_science)">expressions</a>, some code that produces a results, rather than <a href="http://en.wikipedia.org/wiki/Statement_(computer_science)">statements</a>, code that updates location in memory, this is “programming in the small”. So, in my opinion it more reasonable to talk about whether a languages is functional, encourages you to program with expressions, or imperative encourages you to program with statements, both styles could be object oriented. The functional/imperative style is also related to the idea of <a href="http://en.wikipedia.org/wiki/Referential_transparency_(computer_science)">reference transparency</a> and reference opaqueness, which I think are important concepts. Reference transparence means a reference can be replaced with the value it points to and this style of programming is encouraged by functional programming, reference opaqueness means the opposite and is a style encouraged by imperative languages. Generally, <a href="http://haskell.org">with some exceptions</a>, languages don’t tend to be either functional or imperative but there design does tend to encourage or style or the other.</p>  <p>When it comes features that a programming language supports there tends to be a very long list of features, generally specifications of programming languages run to 100s of pages, and there’s a reason for this all those features take a lot of describing. However, there does tend to be a lot of common ground, stuff that every language covers, so it’s more useful to look at the features that are different in each language. To try and illustrate this I’ve produced this Venn Diagram, that I <a href="http://skillsmatter.com/course/scala/robert-pickerings-beginning-f-workshop">normally use as part of my course</a>:</p>  <p><img src="http://dl.dropbox.com/u/4679672/LanguageVenn.png" /></p>  <p>Here we can see that F# support quite a few more features that its cousins languages C# and VB.NET, it’s a big language, meaning it has a lot of features (although I think both C# and VB.NET have enough features that to be considered big languages, there just a little smaller than F#). I not claiming that F# has every feature a programing language could ever want, there are some features, such as <a href="http://en.wikipedia.org/wiki/Type_class">type classes</a> that are present in <a href="http://www.scala-lang.org/">Scala</a> and <a href="http://haskell.org/">Haskell</a>, which are missing from F#. This leads on a discussion whether or not its good to be a big language or a small language. The small language advocates tend point to the simplicity that they provide and the fact that it reduces the burned on the programmer to learn a lot of features. While I have some sympathies for this argument, I tend to think think that using a big language, like F#, is more productive. If a programming language has lot of features then it give the programmer a large tool set and enables them to choose the right tool of the job. For example, F# has <a href="http://msdn.microsoft.com/en-us/library/dd233250.aspx">asynchronous workflows</a>, this allows a programmer to write simpler code for tackling asynchronous IO, if this feature wasn’t present the code the programmer needs write would be much longer and much trickery to get right. This is true for many programming language features, when used correctly they let programmers write shorter simpler code that they would be able to if they didn’t have them. I think this is why the tag line for <a href="http://www.amazon.com/Programming-comprehensive-writing-complex-problems/dp/0596153643/tag=strangelights-20&amp;ref=pd_sim_b_1">Chris Smith’s Programming F#</a> is “write simple code to solve complex problems”.</p>  <p>To summarize, next time you use the phrase “Object Oriented” try and think a little about what you’re trying describe, and try and think if there is a more precise or relevant term that you could use instead.</p>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: Towards a Better Taxonomy of Programming Languages - Joel Mueller**

Of course, the current version of VB.NET also supports anonymous types. You could put &quot;unsafe programming&quot; in the C# area - it&#39;s a feature you may never need, but if you do there&#39;s no substitute in F# or VB.NET.

**re: Towards a Better Taxonomy of Programming Languages - Jonathan Allen**

VB has had anonymous types just as long as C#.<br /><br />Both VB and C# work just fine with Tuples.

**re: Towards a Better Taxonomy of Programming Languages - Jonathan Allen**

I forgot to mention, VB has even better anonymous types than C#.<br /><br />In VB anonymous types can be mutable or inmutable. In C# they can only be inmutable.

**re: Towards a Better Taxonomy of Programming Languages - [Robert Pickering](http://strangelights.com/blog)**

VB &amp; C# have no tuple unpacking syntax and this makes working with tuples in VB &amp; C# tedious. I didn&#39;t know VB supported anonymous types, I&#39;ll update the diagram.

**re: Towards a Better Taxonomy of Programming Languages - [Robert Pickering](http://strangelights.com/blog)**

Yes, I&#39;d forgotten about unsafe programming in C#, can&#39;t say I&#39;ve ever had the need to use it.

**re: Towards a Better Taxonomy of Programming Languages - Associat0r**

F# got the NativePtr module including stuff like stackalloc and inline IL, it can&#39;t get unsafer than that, also for a good Taxonomy of languages I recommend the CTM book<br /><a rel="nofollow external" href="http://www.info.ucl.ac.be/~pvr/paradigms.html" title="http://www.info.ucl.ac.be/~pvr/paradigms.html">http://www.info.ucl.ac.be/~pvr/paradigms.html</a>

**re: Towards a Better Taxonomy of Programming Languages - [Robert Pickering](http://strangelights.com/blog)**

Thanks for the link, Associate0r, looks like a good read.

