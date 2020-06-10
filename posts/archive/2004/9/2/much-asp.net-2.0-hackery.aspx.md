---
title: "Much ASP.NET 2.0 hackery"
date: 2004-09-02T22:31:00.0000000
draft: false
---

<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>I&#8217;ve always been interested in the inner workings of ASP.NET, and with ASP.NET 2.0 coming out along with a new version of F# I decided I&#8217;d have a better stab at creating some kind of support of ASP.NET in F#.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><?xml:namespace prefix = o ns = "urn:schemas-microsoft-com:office:office" /><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>To create a page the framework compiles the aspx source into a .NET type that derives from System.Web.UI.Page. In the frameworks version 1.0 and 1.1 the API that did the compilation of ASP.NET pages was very closed. Most of the classes in them were declared as internal. Sure the model was extensible you control which classes were the compilation with web.config or the machine.config but you couldn&#8217;t reference any of the types involved in compilation in the so you couldn&#8217;t get any help parsing the asp.net page. Very annoy, becasue parsing is a difficult task and Microsoft have done all the hard work of turning an aspx page into a code dom, yet there not prepared to let the world use these methods. Of course the code is not part of the rotor code base.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>But it looked to me like things had changed in ASP.NET 2.0. There is a public called ClientBuildManager which will has a method that GenerateCodeCompileUnit which appears to be exactly what I&#8217;m looking for. So I gave it a quick test, and then set about building a little UI that should allow me to create a dll containing the pages I wanted and also make some small tweeks to the pages code along the way, such as switching the fields on the page from protected to public. It wasn&#8217;t until the UI was nearly finished that I took a closer look at the code produced by GenerateCodeCompileUnit, it only generates part of the page class that makes up a page. It generates fields for all the pages controls but that&#8217;s about it, now code to initialise them or add text to the rest of the page. I believe this is because this method has not been made public so that people trying to implement there own ASP.NET compiler can use it, but so visual studio can use it, a suspions that was pretty much confirmed when I came across this section of code from a class called BaseTemplateBuildProvider, that is eventually called when you make a call to GenerateCodeCompileUnit, not the call to set design mode in the middle of the method.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>internal override CodeCompileUnit GetCodeCompileUnit(out IDictionary linePragmasTable)<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>{<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-spacerun: yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>Type type1 = this._parser.CompilerType.CodeDomProviderType;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-spacerun: yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>CodeDomProvider provider1 = ((CodeDomProvider) HttpRuntime.CreateNonPublicInstance(type1));<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-spacerun: yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>BaseCodeDomTreeGenerator generator1 = this.CreateCodeDomTreeGenerator(this._parser);<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-spacerun: yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>generator1.SetDesignerMode();<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-spacerun: yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>CodeCompileUnit unit1 = generator1.GetCodeDomTree(provider1, new StringResourceBuilder(), base.VirtualPath);<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-spacerun: yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>linePragmasTable = generator1.LinePragmasTable;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2><SPAN style="mso-spacerun: yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </SPAN>return unit1;<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><SPAN style="FONT-FAMILY: 'Courier New'"><FONT size=2>}<o:p></o:p></FONT></SPAN></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>I decided to see if I could hack my way round this by using reflection, and in short it is possible but it butt ugly. I&#8217;ve hacked together <A href="http://www.strangelights.com/download.aspx?url=/blog/downloads/CreatePage.zip">this</A> method that you may find interesting, currently you have choose the page setting strings in the source but eventually I&#8217;m going to refractor it and slot it into the UI I have created. </FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>Of course using this much reflection is really bad and it will probably break as later releases of ASP.NET 2.0 come out, but for now I am happy.</FONT></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><o:p><FONT face=Arial size=2>&nbsp;</FONT></o:p></P>
<P class=MsoNormal style="MARGIN: 0cm 0cm 0pt"><FONT face=Arial size=2>I may take a deeper look at which classes are involved in aspx compilation in a future blog and I&#8217;ll be sure to share the UI for the compiler once it&#8217;s up and running.</FONT></P>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: Much ASP.NET 2.0 hackery - [JS Greenwood](http://weblogs.asp.net/jsgreenwood/archive/2004/11/10/255336.aspx)**

Just found this blog entry as I was trying to do a similar thing... compile ASCX controls programatically (see my blog post for details).  If you've got any further with this, please get in touch (I tried the sample code here, but it kept throwing exceptions).

**Page comerplation in ASP.NET part I - [Techoff](http://beta.channel9.msdn.com/Forums/Techoff/18484-Page-comerplation-in-ASPNET-part-I/)**

Interested in how page compilation works in ASP.NET 2.0? Take a look at

**re: Much ASP.NET 2.0 hackery - Jake**

I get an error when trying to access the download link (<a rel="nofollow external" href="http://strangelights.com/blog/archive/2004/09/02/171.aspx" title="http://strangelights.com/blog/archive/2004/09/02/171.aspx">strangelights.com/blog/archive/2004/09/02/171.aspx</a>) - Is this download still available?

**re: Much ASP.NET 2.0 hackery - [Robert Pickering](http://strangelights.com/blog)**

No, it&#39;s no longer really relevant, check out: <a rel="nofollow external" href="http://visualstudiogallery.msdn.microsoft.com/f57aa816-e96b-4133-ab5d-9b9b99914ead" title="http://visualstudiogallery.msdn.microsoft.com/f57aa816-e96b-4133-ab5d-9b9b99914ead">visualstudiogallery.msdn.microsoft.com</a>

