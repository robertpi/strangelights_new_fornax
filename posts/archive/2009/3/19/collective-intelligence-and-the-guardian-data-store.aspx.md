---
title: "Collective Intelligence and the Guardian Data-Store"
date: 2009-03-19T19:33:54.1230000
draft: false
---

<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3">I’ve been interested in <a href="http://en.wikipedia.org/wiki/Collective_intelligence">collective intelligence</a> and <a href="http://en.wikipedia.org/wiki/Machine_learning">machine learning</a> for a while now. These too related fields centre round using statistical tools on large sets of data to make measurements and predictions. So when the <a href="http://www.guardian.co.uk">UK’s Guardian newspaper</a> announced their “<a href="http://www.guardian.co.uk/data-store">Data-store</a>”, a collection of data set open to the public I felt it was time to apply some of what I’ve learned to the data they were offer.</font></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3">I choose to apply <a href="http://www.resample.com/xlminer/help/HClst/HClst_intro.htm">hierarchal clustering</a> to the data on world health. The idea of hierarchal clustering is to measure how similar data sets are then pair off the similar data sets to build a binary tree that will relieve groups of similar data. I used the <a href="http://en.wikipedia.org/wiki/Pearson_product-moment_correlation_coefficient">pearson correlation</a> to compare the data sets and the resulting data is drawn in a <a href="http://en.wikipedia.org/wiki/Dendrogram">dendrogram</a>, a way of showing the distances between the various clusters that emerge from our clustering algorithm.</font></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3">The code I’ve used is available on <a href="http://github.com/">github.com</a>, it’s packaged in an F# project called gdata.fsproj. For a direct link to the project <a href="http://github.com/robertpi/fscollintelli/tree/master">click here</a>. (There’s also a demonstration on hierarchal clustering with word counts from blogs from TechDays Paris 2009 talk).</font></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3">Anyway, I’m not going to dig too deeply into the code, at least for this post, so let’s have a look at the results. First I clustered by county using the following statics to form my vectors: </font></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3">Hospital beds per 1000<br />
Nursing and Midwifery Personnel per 1000<br />
One-year-olds Immunised with diphtheriatetanustoxoidandpertussisdtp<br />
One-year-olds Immunised with hepatitis b<br />
One-year-olds Immunised with hibhib3vaccine<br />
Adolescent fertility rate (%)<br />
Births attended by skilled health personnel (%)<br />
Infant mortality rate (per 1 000 live births) both sexes<br />
Maternal mortality ratio (per 100 000 live births)<br />
Neonatal mortality rate (per 1 000 live births)<br />
Life expectancy at birth (years) both sexes<br />
Life expectancy at birth (years) female<br />
Life expectancy at birth (years) male<br />
Deaths among children under five years of age due to HIV/AIDS (%)<br />
Per capita recorded alcohol consumption (litres of pure alcohol) among adults<br />
Population with sustainable access to improved drinking water sources (%) total<br />
Population with sustainable access to improved sanitation (%) total. </font></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3">The statistics were chosen mainly because they were the most complete; it is only possible to compare countries using this technique if all statistics are available. The resulting dendrogram can be seen below:</font></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><o:p><font size="3"><img alt="" src="/blog/photos/alldata.png" /> </font></o:p></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3">There’s no great surprises from the stats, there appears to be two distinct clusters, one of poor countries towards the bottom of the diagram and one of richer countries towards the top, with the 1</font><sup><font size="2">st</font></sup><font size="3"> world countries being located towards the top of this cluster (absolute position doesn’t matter much is the diagram it’s more who your close to). There are perhaps a few surpises, maybe we wouldn’t have expected to find Cananda quite so close to the Ukraine or perhaps not the Czech Republic so closed to Germany. It may be worth going back to the underlying statistics to find why this is.</font></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3">Perhaps a more interesting analysis is to reverse the matrix so we are no comparing which conditions are related to each other:</font></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3" /></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3"><img alt="" src="/blog/photos/reveresed.png" /></font></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3">Again, the diagram does show some obvious relations. Male and female life expectancies were always going to statically similar to overall life expectancy, but it does appear that this is closely related to infant mortality rates. In turn is closely correlated to births attend by medical professions and access to clean water and sanitations. While this is fairly logical I think it’s good that we can show, statically speaking at least, that access to clean water and sanitation will improve infant mortality rates and life expectancy.</font></p>
<p style="MARGIN: 0cm 0cm 10pt" class="MsoNormal"><font size="3">While these first steps in analysing the Guardian Data didn’t perhaps turn up anything we didn’t already know, I feel it’s shown that if you spend a bit of time working with public available data you can start to find interesting patterns. I shall definitely be looking at how I can further these experiments.</font></p>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: Collective Intelligence and the Guardian Data-Store - [Thibaut Barr&#232;re](http://blog.logeek.fr/)**

Hi Robert,<br /><br />nice post - great to see the Pearson algorithm at work. <br /><br />It seems that the first link of your article (Collective Intelligence) doesn't point to the right page. Thought you'd want to be warned.<br /><br />cheers<br />

**re: Collective Intelligence and the Guardian Data-Store - [Robert Pickering](http://strangelights.com/blog/Default.aspx)**

Thanks! Corrected now.<br /><br />Robert

**Topics about Alcohol  &amp;amp;raquo; Archive   &amp;amp;raquo; Collective Intelligence and the Guardian Data-Store - http://alcohol.linkablez.info/2009/03/19/collective-intelligence-and-the-guardian-data-store/**

Topics about Alcohol  &amp;amp;raquo; Archive   &amp;amp;raquo; Collective Intelligence and the Guardian Data-Store

