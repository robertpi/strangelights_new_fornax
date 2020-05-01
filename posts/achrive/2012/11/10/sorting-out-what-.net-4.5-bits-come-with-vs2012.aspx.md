---
title: "Sorting Out What .NET 4.5 Bits Come With VS2012"
date: 2012-11-10T07:24:48.0930000
draft: false
---

<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">Visual Studio 2012 has been out for a while now, I’ve been using it every day at work and I’m generally very happy with it. The biggest win is the performance, which is some much better than VS2010.<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">I’ve finally begun to get curious about the new stuff in VS2012. Visual Studio was delivered with .NET 4.5 a shiny new version of the .NET framework, that will allow developers to create “Metro” style apps (which for reason that are too silly to go into are no longer called Metro style apps, but we will continue to call them Metro style apps in this article as suitable name has yet to be found). You can also develop all the apps you used to be able to develop using .NET 4.5, such as WinForm, WPF, ASP.NET etc.<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">Metro style apps are the new style of application that will only run on Windows 8. They take up the full screen and are design to be used on touch screen tablet devices, though it is possible to use them from a device that isn’t touch screen. Metro style apps do not run on the Win34/Win64 Windows APIs we have come to know and love, they have their own APIs that are completely isolated from the classic Win34/Win64 Windows APIs. These new APIs are called WinRT, confusingly also the name of the version of Windows that runs on ARM based devices. WinRT will not load executable or .dll that target Win32/Win64, code must be compile specially for WinRT and applications cannot simple be download from the internet, they must be installed via the Windows Store (all though inevitably someone will find a way to hack there way round this restriction). The idea is that WinRT is locked down and completely isolated from the Win32/Win64 world to try and prevent the malware issues that plagued Win32/Win64 ‘anything goes’ world.<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">As we know the .NET framework is built on top of the Win32/Win64, so how does .NET 4.5 allow developers to create Metro style apps, while still allowing them create apps that run on Win32/Win64? The answer is simple, .NET 4.5 is not one framework but two:<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoListParagraphCxSpFirst" style="margin: 0cm 0cm 0pt 36pt; text-indent: -18pt; mso-list: l0 level1 lfo1;"><!--[if !supportLists]--><span style="mso-ascii-font-family: Calibri; mso-fareast-font-family: Calibri; mso-hansi-font-family: Calibri; mso-bidi-font-family: Calibri;"><span style="mso-list: Ignore;"><font face="Calibri" size="3">-</font><span style="font: 7pt/normal &quot;Times New Roman&quot;; font-size-adjust: none; font-stretch: normal;">          </span></span></span><!--[endif]--><font size="3"><font face="Calibri">.NET 4.5 is an in-place update for .NET 4.0 used by Windows 7 applications, Windows 8 classic desktop mode, Mono-Mac, Mono-Linux etc.<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoListParagraphCxSpLast" style="margin: 0cm 0cm 8pt 36pt; text-indent: -18pt; mso-list: l0 level1 lfo1;"><!--[if !supportLists]--><span style="mso-ascii-font-family: Calibri; mso-fareast-font-family: Calibri; mso-hansi-font-family: Calibri; mso-bidi-font-family: Calibri;"><span style="mso-list: Ignore;"><font face="Calibri" size="3">-</font><span style="font: 7pt/normal &quot;Times New Roman&quot;; font-size-adjust: none; font-stretch: normal;">          </span></span></span><!--[endif]--><font size="3"><font face="Calibri">.NETCore 4.5 is the core implementation of .NET used by Windows Store apps written in .NET languages.<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">In VS2012 you know have the possibility to target either framework (or both in the case of building a library), it just depends on the project type you choose. So say you decided to create a .NET library, you now have the following choices:<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoListParagraphCxSpFirst" style="margin: 0cm 0cm 0pt 36pt; text-indent: -18pt; mso-list: l0 level1 lfo1;"><!--[if !supportLists]--><span style="mso-ascii-font-family: Calibri; mso-fareast-font-family: Calibri; mso-hansi-font-family: Calibri; mso-bidi-font-family: Calibri;"><span style="mso-list: Ignore;"><font face="Calibri" size="3">-</font><span style="font: 7pt/normal &quot;Times New Roman&quot;; font-size-adjust: none; font-stretch: normal;">          </span></span></span><!--[endif]--><font size="3"><font face="Calibri">‘Class Library’ project type, this creates a library that will target .NET 4.5 or any of the older ‘classic frameworks’<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoListParagraphCxSpMiddle" style="margin: 0cm 0cm 0pt 36pt; text-indent: -18pt; mso-list: l0 level1 lfo1;"><!--[if !supportLists]--><span style="mso-ascii-font-family: Calibri; mso-fareast-font-family: Calibri; mso-hansi-font-family: Calibri; mso-bidi-font-family: Calibri;"><span style="mso-list: Ignore;"><font face="Calibri" size="3">-</font><span style="font: 7pt/normal &quot;Times New Roman&quot;; font-size-adjust: none; font-stretch: normal;">          </span></span></span><!--[endif]--><font size="3"><font face="Calibri">‘Portable Class Library’ project type, this creates a library that could potentially be used on any version of .NET, that is the ‘classic frameworks’, Silverlight, XBox and the new .NETCore 4.5 for Windows Store.<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoListParagraphCxSpMiddle" style="margin: 0cm 0cm 0pt 36pt; text-indent: -18pt; mso-list: l0 level1 lfo1;"><!--[if !supportLists]--><span style="mso-ascii-font-family: Calibri; mso-fareast-font-family: Calibri; mso-hansi-font-family: Calibri; mso-bidi-font-family: Calibri;"><span style="mso-list: Ignore;"><font face="Calibri" size="3">-</font><span style="font: 7pt/normal &quot;Times New Roman&quot;; font-size-adjust: none; font-stretch: normal;">          </span></span></span><!--[endif]--><font size="3"><font face="Calibri">‘Class Library (Windows Store Apps)’ project type, this produces a class library that can only be used with .NETCore 4.5 for Windows Store.<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoListParagraphCxSpLast" style="margin: 0cm 0cm 8pt 36pt; text-indent: -18pt; mso-list: l0 level1 lfo1;"><!--[if !supportLists]--><span style="mso-ascii-font-family: Calibri; mso-fareast-font-family: Calibri; mso-hansi-font-family: Calibri; mso-bidi-font-family: Calibri;"><span style="mso-list: Ignore;"><font face="Calibri" size="3">-</font><span style="font: 7pt/normal &quot;Times New Roman&quot;; font-size-adjust: none; font-stretch: normal;">          </span></span></span><!--[endif]--><font size="3"><font face="Calibri">‘Windows Runtime Component’ project type, this doesn’t produce a .dll like all the other project types, but instead produces a .winmd file. A file .winmd still uses the same Common-IL (CIL) format as a the other libraries, but winmd library can be used from JavaScript and C++ applications that target Windows Store, were as a .dll produced by a ‘Class Library (Windows Store Apps)’ project can’t be.<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font face="Calibri" size="3">I wanted to understand the difference between these projects types. I was particularly interested in what was the difference between the files produced ‘Class Library (Windows Store Apps)’ project type and the ‘Windows Runtime Component’ project type. I could seem to find a good explanation of this on the internet. So I open Visual Studio create project of each project type and then used ildasm to decompile each library so that I could compare them in WinMerge. For those who want to play with this for themselves I’ve </font><a href="https://github.com/robertpi/TestNet45"><font face="Calibri" size="3">uploaded by project here</font></a><font size="3"><font face="Calibri">.<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">This is a summary of what I found and few other tip bits about .NET 4.5:<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><strong style="mso-bidi-font-weight: normal;"><font size="3"><font face="Calibri">‘Portable Class Library’<o:p /></font></font></strong></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">These are very similar to the ‘Class Library’ project type. The only difference is that they create ‘retargetable’ reference to mscorlib. It looks something like this in the text version of IL:<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">.assembly extern retargetable mscorlib<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">{<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri"><span style="mso-spacerun: yes;">  </span>.publickeytoken = (7C EC 85 D7 BE A7 79 8E )<span style="mso-spacerun: yes;">                         </span>// |.....y.<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri"><span style="mso-spacerun: yes;">  </span>.ver 2:0:5:0<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">}<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font face="Calibri" size="3">I’ve failed to find a good explanation of ‘retargetable’ keyword does in IL. It seems to be an old idea that’s been in available in IL for a good while as I found a reference to it </font><a href="http://plus.kaist.ac.kr/~shoh/fsharp/extern/README-fsharp.html"><font face="Calibri" size="3">on this site</font></a><font size="3"><font face="Calibri"> that was put together around 2005, which is actually an old readme file from an old distribution of F#, but it’s on the top results when you google for ‘extern retargetable mscorlib’. The site does offer a little inside what retargetable does:<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">“<em style="mso-bidi-font-style: normal;">Retargetable binaries are neutral w.r.t. the publisher of particular referenced binaries.<span style="mso-spacerun: yes;">  </span>For example, a truly portable .NET program will be neutral w.r.t. the publisher of mscorlib - rather than picking up a dependency against the publisher of mscorlib used at compile-time. This means the program will bind to ANY assembly called "mscorlib", which is OK for mscorlib but is not necessarily such a good idea for other strong named assemblies.</em>”<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">So there you go.<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">The programmer also gets a lot of choice about what can be targeted, they could choose to target .NET 4.5 and .NETCore 4.5 but not Silverlight, for example. To make this possible, Microsoft has create different “profiles”. Each profile allows to target a different set of frameworks for example “Profile1” lets you target .NET for Windows Store apps, .NET Framework 4, Silverlight 4, Windows Phone 7, XBox 360. Microsoft provide a set of reference assemblies that have all the methods that are common across all these frameworks, these live under: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.0\Profile\Profile1.<span style="background: white; color: rgb(51, 51, 51); line-height: 107%; font-family: &quot;Verdana&quot;,&quot;sans-serif&quot;; font-size: 10pt;"><o:p /></span></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">To add extra-meta data to the assembly the msbuild project produces a .cs file you’re temp directory and add this into the build. Here’s an example of the generated file:<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3">using System;<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3">using System.Reflection;<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3">[assembly: global::System.Runtime.Versioning.TargetFrameworkAttribute(".NETPortable,Version=v4.0,Profile=Profile4", FrameworkDisplayName = ".NET Portable Subset")]<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font face="Calibri" size="3">A full list of all the </font><a href="http://nitoprograms.blogspot.fr/2012/05/framework-profiles-in-net.html"><font face="Calibri" size="3">different profiles can be found here</font></a><font size="3"><font face="Calibri">.<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><strong style="mso-bidi-font-weight: normal;"><font size="3"><font face="Calibri">‘Class Library (Windows Store Apps)’ and ‘Windows Runtime Component’<o:p /></font></font></strong></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">These differ hugely from the ‘Class Library’ project type. In .NET Core mscorlib has been renamed to ‘System.Runtime’. So we seem this import at the top of both files:<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3">.assembly extern System.Runtime<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3">{<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3"><span style="mso-spacerun: yes;">  </span>.publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )<span style="mso-spacerun: yes;">                         </span>// .?_....:<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3"><span style="mso-spacerun: yes;">  </span>.ver 4:0:0:0<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3">}<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">Confusingly the .winmd file also imports a version of mscorlib, whereas the .dll produced by ‘Class Library (Windows Store Apps)’ does not:<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3"><span style="mso-spacerun: yes;"> </span>.assembly extern mscorlib<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3">{<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3"><span style="mso-spacerun: yes;">  </span>.publickeytoken = (B7 7A 5C 56 19 34 E0 89 )<span style="mso-spacerun: yes;">                         </span>// .z\V.4..<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3"><span style="mso-spacerun: yes;">  </span>.ver 255:255:255:255<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3">}<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">This seems to be because a .winmd file uses the definition of System.Object and System.Type from mscorlib whereas the .dll does not. I have no idea why this is. <o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">For the ‘Class Library (Windows Store Apps)’ project type the renaming of mscorlib to System.Runtime accounts for most of the difference, (since the text IL format is very verbose and the assembly name and names is needed each time a type is referenced).<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">For the ‘Windows Runtime Component’ project there are more changes. I think these changes are to make the expose the managed class via COM to JavaScript and C++. Any public class in a ‘Windows Runtime Component’ project must be sealed, have no new virtual or abstract members and no events. I assume this is to make it COM compatible. We then see that our class also implements an interface:<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3">.class public auto ansi windowsruntime sealed beforefieldinit TestNet45.Class1<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3"><span style="mso-spacerun: yes;">       </span>extends [mscorlib]System.Object<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3"><span style="mso-spacerun: yes;">       </span>implements TestNet45.IClass1Class<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">This implementation is completely implicit, no changes to the C# code where necessary. The implantation of the interface is accounts for most of the rest of the differences in the .winmd file and an ordinary .dll.<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">Another minor difference is that methods in .winmd file have attributes attached that specify the direction:<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3"><span style="mso-spacerun: yes;">  </span>.method public hidebysig specialname rtspecialname <o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3"><span style="mso-spacerun: yes;">          </span>instance void<span style="mso-spacerun: yes;">  </span>.ctor([in] int32 a,<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3"><span style="mso-spacerun: yes;">                               </span>[in] string b,<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3"><span style="mso-spacerun: yes;">                               </span>[in] float64 c) cil managed<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font face="Calibri" size="3">If you want to see </font><a href="https://twitter.com/robertpi/status/264407307423739904/photo/1"><font face="Calibri" size="3">a picture of the IL diffs you can see one here</font></a><font size="3"><font face="Calibri">. <o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><strong style="mso-bidi-font-weight: normal;"><font size="3"><font face="Calibri">Other Differences in .NETCore 4.5<o:p /></font></font></strong></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">I’ve been trying to port some existing code to .NETCore 4.5 and keep it compatible with plain old .NET 4.5. There’s a couple of other difference that make this tricky. Firstly, .NETCore 4.5 assemblies are much more fine grain that their .NET 4.0 equivalents. Assemblies tend to only cover one namespace, so were as most of the System.Threading namespace as in mscorlib before it’s now split over several assemblies:<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3">System.Threading.dll<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3">System.Threading.Tasks.dll<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><span style="font-family: &quot;Courier New&quot;;"><font size="3">System.Threading.Tasks.Parallel.dll<o:p /></font></span></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font face="Calibri" size="3">This can be a little annoying, trying to work out where stuffs gone, but I quickly got used to and it doesn’t make a huge difference. The second problem is much more annoying. It seems Microsoft has taken the opportunity to redesign some parts of the framework, System.Reflection has be heavily affect by this. The CLR team </font><a href="http://blogs.msdn.com/b/dotnet/archive/2012/08/28/evolving-the-reflection-api.aspx"><font face="Calibri" size="3">has a good blog post explaining the changes</font></a><font size="3"><font face="Calibri">. While I understand the design rational, and even think the new API as are better some respect, it’s still very annoying porting code between the two models. Worse is trying to write code that is compatible with the two models, you end up drowning in ‘#if’ definitions. To add insult to injury some of the more powerful features, like the System.Reflection.Emit namespace have been completely removed.<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
<p class="MsoNormal" style="margin: 0cm 0cm 8pt;"><font size="3"><font face="Calibri">Hope you’ve found this little tour of the difference between .NET 4.5 and .NETCore 4.5 useful. Happy hacking!<o:p /></font></font></p>
<font face="Times New Roman" size="3">  </font>
