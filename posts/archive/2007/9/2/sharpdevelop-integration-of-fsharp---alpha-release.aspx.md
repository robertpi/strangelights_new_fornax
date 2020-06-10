---
title: "#Develop integration of F# - Alpha Release"
date: 2007-09-02T11:50:17.4470000
draft: false
---

<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3"><em>[Update 05-09_2007: minor change to both source and binary release to fix F# interactive intergration, if you download a version before this date please redownload]</em></font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Recently I’ve been working on integrating F# into #Develop. It’s a nice, well designed and developed platform, and despite one or two glitches integration has gone pretty quick. My aim is to get the F# made part of the #Develop distribution, but, rightly so, there are a couple of legal and quality hurdles that need to be reached before it can be integrated into their main release. I’m sure these hurdles will be over come soon, but I decide to do an alpha release from my own site to solicit feedback and in case there’s anyone out there eager to see this sort of thing.</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Download:</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3"><a href="http://www.strangelights.com/blog/Downloads/SharpDevelop.FSharpBinding_Source.zip">Source</a></font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3"><a href="http://www.strangelights.com/blog/Downloads/SharpDevelop.FSharpBinding_bin.zip">Binaries</a></font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Installation of Binaries:</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Create a new folder FSharpBindings in <span style="mso-spacerun: yes"> </span>\AddIns\AddIns\BackendBindings</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Copy FSharpBinding.addin, fsharpbinding.dll, fsharpbinding.pdb and Templates folder to this new directory</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Copy ICSharpCode.Build.Tasks.dll, ICSharpCode.Build.Tasks.pdb and SharpDevelop.Build.Fsc.targets to \Bin the versions of ICSharpCode.Build.Tasks.dll and ICSharpCode.Build.Tasks.pdb that exist in this directory should be over written</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Build instructions:</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">fsharpbinding.dll: This can be build with either visual studio, #Develop or msbuild using FSharpBinding.VisualStudio.sln or FSharpBinding.SharpDevelop.sln</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">ICSharpCode.Build.Tasks.dll: This requires the #Develop source. Add fsc.cs to this ICSharpCode.Build.Tasks project and add a reference to System.Configuration</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">I have tested this installation using F# version 1.9.2.5 and SharpDev 2.2.1. 2648, if you intend to us another version F#, or it is not installed in the default location, you will need set an AppSettings key “alt_fs_bin_path” to give the location of the compilers bin directory. If you want to use another version of #Develop you will probably need to rebuild the binaries.</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Features:</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Code Colouring</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Project System</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Reorder of Source Files</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">F# Interactive integration</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">TODO List (roughly in order of priority):</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Clever search for the F# compiler and other binaries</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Support .fsi interface files</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Support Automatic Error Checking</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Support Auto-Completion</font></p>
<p class="MsoNormal" style="MARGIN: 0cm 0cm 10pt"><font face="Calibri" size="3">Create Icons to avoid icon theft!</font></p>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: #Develop integration of F# - Alpha Release - Josef**

Sorry for the stupid question, but how do I set an "AppSettings key"?

**re: #Develop integration of F# - Alpha Release - [Robert Pickering](http://strangelights.com/)**

The appSettings are set in the SharpDevelop.exe.config. You need to add a section as shown below under the configuration node:<br />  &lt;appSettings&gt;<br />    &lt;add key="alt_fs_bin_path" value="c:\...."/&gt;<br />  &lt;/appSettings&gt;<br />

**re: #Develop integration of F# - Alpha Release - [Robert Pickering](http://strangelights.com/blog)**

Thanks for noticing, should be fixed now.

**re: #Develop integration of F# - Alpha Release - Jeff Williams**

the SharpDevelop.Build.Fsc.targets is missing from the binary.zip but is in the source.zip if anyone is having trouble finding it.<br /><br />

**re: #Develop integration of F# - Alpha Release - [Hamlet D'Arcy](http://hamletdarcy.blogspot.com/)**

This post is about 9 months old now... do you have any updates at all? (sorry, can't seem to search your site).

