---
title: "A Potted History of .NET"
date: 2020-06-11T05:59:48.5170000
draft: true
---

It's possible after reading [.NET Today and Tomorrow](/posts/archive/2020/06/11/dotnet-today-and-tomorrow.html), that the reader is left wondering why there are three implementations of the CLR, that are all owned / maintained primarly by Microsoft, even if two of them are open source and accepting contributions.

This post will attempt to answer that by giving an overview of how .NET got where it is today.

Before .NET
===========

Microsoft has always placed developers at the center of it's strategy for marketing Windows. They know attracting developers to your platform to create software will keep clients engaged with the platform. It's why, at Microsoft's 25th anniversary conference in 2000, [Steve Ballmer jumps around the stage shouting developers](https://www.youtube.com/watch?v=SaVTHG-Ev4k).

Before .NET, Microsoft's main tool for attracting developers to the Windows platform was [COM](https://en.wikipedia.org/wiki/Component_Object_Model). COM exposed parts of the windows platform and allowed them to be glued together quickly in high level languages like VB (Visual Basic) or VBS (Visual Basic Script), a bit like python today is used to day to quickly glue together code written in C. Developers liked COM because it made the productive, they could write low level stuff in C++ if necessary, but most of the time they could work in a relatively high level world.

COM may have been fairly popular, but it had one big problem: it was badly broken.