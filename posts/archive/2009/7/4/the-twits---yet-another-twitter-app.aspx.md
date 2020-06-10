---
title: "The twits - Yet another Twitter app"
date: 2009-07-04T14:26:35.6730000
draft: false
---

<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><span style="mso-ansi-language: EN-US" lang="EN-US"><font size="3">Taking its name from <a href="http://twitter.com">twitter</a>, with a large nod towards <a href="http://www.amazon.com/gp/product/014241039X?ie=UTF8&amp;tag=strangelights-20&amp;linkCode=as2&amp;camp=1789&amp;creative=9325&amp;creativeASIN=014241039X">Roald Dahl's cautionary tale</a>, the twits is a twitter app that lets you visualize you network of friends on twitter. <a href="http://strangelights.com/blog/downloads/thetwits.0.1.zip">It’s available to try here</a>. Before we go any further you should know that this software is in alpha status, i.e. not for the fait hearted. Here’s an image of the results below. <o:p /></font></span></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><span style="mso-ansi-language: EN-US" lang="EN-US"><o:p><font size="3"> <img alt="the twites" src="/blog/images/thetwits.png" /></font></o:p></span></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><span style="mso-ansi-language: EN-US" lang="EN-US"><font size="3">As you can see it does a reasonable job of separating other developers I follow from people at the guardian I follow (the coloured lines &amp; text are added afterwards).<o:p /></font></span></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><span style="mso-ansi-language: EN-US" lang="EN-US"><font size="3">The app is designed to run local and uses <a href="http://www.microsoft.com/downloads/details.aspx?FamilyId=333325FD-AE52-4E35-B531-508D977D32A6&amp;displaylang=en">.NET 3.5</a>, <a href="http://research.microsoft.com/en-us/um/cambridge/projects/fsharp/release.aspx">F#</a>, and <a href="http://www.microsoft.com/downloads/details.aspx?FamilyID=10CC340B-F857-4A14-83F5-25634C3BF043&amp;displaylang=en">WPF</a>, if you’re running vista or win7 it’ll probably work okay out of the box, any other else and you’ll need install .NET 3.5 etc. Caveat: if you have more than about 50 friends (people you follow) it’s unlike to be able to map them all at once, first there’s the twitter API limits, then there’s the fact the algorithm is exponentially expensive in processing time and also you just won’t be able to find them on the screen. I may consider doing a <a href="http://silverlight.net/">Silverlight port</a>, if it becomes popular, to make it more accessible. The main idea of the app is to show off some of Collective Intelligence work, this app is another example of hierarchical clustering and also uses optimization. There’s also some interesting use of async workflows. If you want to try <a href="http://github.com/robertpi/fscollintelli/tree/master">the source it’s available on git hub</a>. I've lots of ideas for future version - but not much time to develop them. Licence is GPL 2.0, if you'd like that to change, lobby me. If you like it let me know!</font></span></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><span style="mso-ansi-language: EN-US" lang="EN-US"><font size="3"><strong>UPDATE:</strong> The download was broken because of a missing dll, this is fixed now. Thanks to <font face=""><a href="http://twitter.com/samjiman">@samjiman</a> for noticing.</font></font></span></p>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: The twits - Yet another Twitter app - [Aleks](http://guardian.co.uk/technology)**

very cool vis: is it PC-only?<br /><br />aleks

**re: The twits - Yet another Twitter app - [Robert Pickering](http://strangelights.com/blog/Default.aspx)**

Yep, PC only at the moment, but if I do a silverlight port it should become multi platform and easier to install too. Not yet sure how much effort a silverlight port would be.

