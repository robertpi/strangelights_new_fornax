---
title: "Tallow! Beware!"
date: 2005-03-07T13:09:00.0000000
draft: false
---

<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p>&nbsp;</o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>I think Tallow is a cool tool it can save you a lot of typing when creating a wix installation. I recently used it to create a couple of installations for a project I&#8217;m not. It was then I noticed it does have one downside: it does not add a Guid attribute to any of the Component tags it generates.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>I know this does sounds like a major thing, but it had me scratching my head of a while. The installation I had created was not uninstalling correctly and I no idea why, other installations I&#8217;d created with wix uninstalled perfectly. I compared the new installs with the previous ones I&#8217;d created and notice the difference in the Component tags and Guid attributes, then uninstallation started to work just as expected.</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2>It&#8217;s fairly easy to see why, if you bother to read the doc (from the wix.chm):</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2><STRONG>Attribute:</STRONG> Guid</FONT></P>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><FONT face=Arial size=2><STRONG>Description:</STRONG> String GUID (without the '{' and '}' braces) that uniquely identifies a component's language, version, and platform. If this attribute is present, the GUID will become the identifier used by the Windows Installer to track this component on the user's machine. If this value is not specified, then the component cannot be removed or repaired by the installer (it is essentially a permanent component). Therefore, a GUID should always be specified for a component which contains any resources that may need to be patched in the future.</FONT></P>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: Tallow! Beware! - [Robert Pickering](http://www.strangelights.com)**

I was going to add a feature request for this, but noticed there already is one:<br><a target="_new" href="http://sourceforge.net/tracker/index.php?func=detail&amp;aid=1120401&amp;group_id=105970&amp;atid=642717">http://sourceforge.net/tracker/index.php?func=detail&amp;aid=1120401&amp;group_id=105970&amp;atid=642717</a>

**re: Tallow! Beware! - Harjit S. Batra**

Stefan Zschocke's &quot;Mallow&quot; should solve your problems with component GUIDs. Get it from <a target="_new" href="http://www.infozoom.de/download/Mallow.zip">http://www.infozoom.de/download/Mallow.zip</a>. Stefan mentioned it at <a target="_new" href="http://sourceforge.net/mailarchive/forum.php?thread_id=6534155&amp;forum_id=39978">http://sourceforge.net/mailarchive/forum.php?thread_id=6534155&amp;forum_id=39978</a>.

