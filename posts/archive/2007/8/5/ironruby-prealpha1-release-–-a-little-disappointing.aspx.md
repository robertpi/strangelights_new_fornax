---
title: "IronRuby PreAlpha1 Release – A Little Disappointing"
date: 2007-08-05T12:48:05.2670000
draft: false
---

<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">When I saw that <a href="http://www.iunknown.com/2007/07/a-first-look-at.html">IronRuby had been released</a> I thought I’d put it through its paces seeing how the language preformed with respect to IronPython and of course F#. Perhaps a little unfair for a number of reasons, firstly this is a pre-alpha release so one can’t really expect much, we need to give it time to mature and two, ruby generally performs slow than python in the “Computer Language Bench Mark Game”, <span style="mso-spacerun: yes"> </span>(<a href="http://shootout.alioth.debian.org/">http://shootout.alioth.debian.org/</a>) so one wouldn’t really except IronRuby to outperform either IronPython or F#. However I thought what the heck and downloaded the source for the ruby bench marks.</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">I was a disappointed with what I found, every single one of the programs crashes. And even worse it difficult to tell exactly why they failed. I’ve listed here the command lines that I ran along with abridged versions of the exception I got:</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">&gt;rbx.exe /run:binarytree.rb</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">Unhandled exception:</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">System.NotImplementedException: Statement transformation not implemented</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font size="3"><font face="Calibri"><span style="mso-spacerun: yes">   </span>at Ruby.Compiler.AST.Statement.Transform(AstGenerator gen) in Statement.cs:line 31</font></font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><o:p><font face="Calibri" size="3"> </font></o:p></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">&gt;rbx.exe /run:fannkuch.rb</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">Unhandled exception:</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">System.NotImplementedException: Statement transformation not implemented</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font size="3"><font face="Calibri"><span style="mso-spacerun: yes">   </span>at Ruby.Compiler.AST.Statement.Transform(AstGenerator gen) in Statement.cs:line 31</font></font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><o:p><font face="Calibri" size="3"> </font></o:p></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">&gt;rbx.exe /run:nbody.rb</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">Unhandled exception:</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">System.NotImplementedException: TODO</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font size="3"><font face="Calibri"><span style="mso-spacerun: yes">   </span>at Ruby.Compiler.AST.InstanceVariable.TransformWrite(AstGenerator gen, Expression rightValue) in InstanceVariable.cs:line 31</font></font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><o:p><font face="Calibri" size="3"> </font></o:p></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">&gt;rbx.exe /run:nsieve.rb</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">Unhandled exception:</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">System.NotImplementedException: Statement transformation not implemented</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font size="3"><font face="Calibri"><span style="mso-spacerun: yes">   </span>at Ruby.Compiler.AST.Statement.Transform(AstGenerator gen) in Statement.cs:line 31</font></font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><o:p><font face="Calibri" size="3"> </font></o:p></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">&gt;rbx.exe /run:partialsums.rb</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">Unhandled exception:</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">System.MemberAccessException: uninitialized constant ARGV</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font size="3"><font face="Calibri"><span style="mso-spacerun: yes">   </span>at Ruby.Runtime.RubyOps.GetConstant(CodeContext context, Object target, SymbolId name) in RubyOps.cs:line 349</font></font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><o:p><font face="Calibri" size="3"> </font></o:p></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">&gt;rbx.exe /run:pidigits.rb</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">Unhandled exception:</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">System.NotImplementedException: TODO</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font size="3"><font face="Calibri"><span style="mso-spacerun: yes">   </span>at Ruby.Compiler.AST.InstanceVariable.TransformWrite(AstGenerator gen, Expression rightValue) in InstanceVariable.cs:line 31<span style="mso-spacerun: yes">   </span></font></font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><o:p><font face="Calibri" size="3"> </font></o:p></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">&gt;rbx.exe /run:recursive.rb</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">Unhandled exception:</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">System.MemberAccessException: uninitialized constant ARGV</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font size="3"><font face="Calibri"><span style="mso-spacerun: yes">   </span>at Ruby.Runtime.RubyOps.GetConstant(CodeContext context, Object target, SymbolId name) in RubyOps.cs:line 349</font></font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><o:p><font face="Calibri" size="3"> </font></o:p></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">I decided it might be nice to try and fix at least some of the programs, after all I reasoned, the programs are all pretty similar and some of the exceptions are the same, perhaps there all just using some obscure feature of the language that can be easily worked round. I worked out that ARGV was a command for access command line parameters, I replaced this with a hard coded value in both partialsums.rb and recusive.rb that had both failed because of this. Both now failed for other reasons.</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">&gt;rbx.exe /run:partialsums.rb</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">Unhandled exception:</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">System.MissingMethodException: undefined local variable or method `upto' for 1:Fixnum</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font size="3"><font face="Calibri"><span style="mso-spacerun: yes">   </span>at Ruby.Builtins.Kernel.MethodMissing(CodeContext context, Object self, Procproc, SymbolId name, Object[] args) in Kernel.cs:line 169</font></font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><o:p><font face="Calibri" size="3"> </font></o:p></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">&gt;rbx.exe /run:recursive.rb</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">Unhandled exception:</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">System.MissingMethodException: undefined local variable or method `printf' for #</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">&lt;Object:0000002b&gt;:Object</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font size="3"><font face="Calibri"><span style="mso-spacerun: yes">   </span>at Ruby.Builtins.Kernel.MethodMissing(CodeContext context, Object self, Proc</font></font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><font face="Calibri" size="3">proc, SymbolId name, Object[] args) in Kernel.cs:line 169</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 0pt"><o:p><font face="Calibri" size="3"> </font></o:p></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">At this point I gave up. I although I appreciate this early access we are being given to the IronRuby project, maybe this is a little too early? It seems like this particularly drop of the code is just too raw to be much use.</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Don’t get me wrong I don’t want to seem anti-ruby, there are a number of positive things about the release – particularly the very liberal license, the fact it will be hosted on RubyForge and the fact that they will be accepting community contributions for the libraries. In fact I’m so intrigued by Ruby I’ve actually ordered a book <a href="http://www.amazon.com/gp/product/0974514055?ie=UTF8&amp;tag=strangelights-20&amp;linkCode=as2&amp;camp=1789&amp;creative=9325&amp;creativeASIN=0974514055">Programming Ruby by Dave Thomas, Chad Fowler and Andy Hunt</a>, I’m particularly interested in how creating DSLs in Ruby differs from creating them in an ML style language (i.e. F#). All I’m saying is maybe the IronRuby team would have been better holding off the release a wee bit longer and delivering something a little more complete.</font></p>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: IronRuby PreAlpha1 Release – A Little Disappointing - [Aaron Junod](http://rubydoes.net/)**

From what I have read, the point of this release was to get the community access to view the underpinnings, not so much for real use. Array and string are the only builtins that have been implemented in any usable form, and even those aren't done yet.

**re: IronRuby PreAlpha1 Release – A Little Disappointing - [Robert Pickering](http://strangelights.com/)**

On further reflection I guess what surprises me is that the community would want something so raw, but if they want it, I guess there’s no harm in letting them have it.

**re: IronRuby PreAlpha1 Release – A Little Disappointing - Seo Sanghyeon**

The thing is that John Lam said in May that the source will be released at OSCON. If he didn't release "pre-alpha", he would have been accused of playing Microsoft, not intending to publish source code at all, etc.

**re: IronRuby PreAlpha1 Release – A Little Disappointing - [Robert Pickering](http://strangelights.com/)**

Isn’t that an admitting that a PreAlpha release is just an exercise in propagranda? :-)

