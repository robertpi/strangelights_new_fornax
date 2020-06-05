---
title: ".NET Today and Tomorrow"
date: 2020-06-05T05:59:48.5170000
draft: false
---

Recently a conversation made me think about the current state of .NET. Someone from outside the .NET community asked me if .NET ran on Linux. The answer is that .NET has great cross platform support, running on Windows, Linux, maxOS, Android, iOS, WebAssembly, but I can see why someone from outside .NET might think that it didn't.

There are still a few nuance when it comes to cross platform support in the .NET world, but I think that's true of most development platforms today. This post aims to explain those nuances.

I looked for a good post to explain the state of .NET to someone outside the .NET community, but I had trouble finding one. For example, the [Microsoft .NET blog](https://devblogs.microsoft.com/dotnet/introducing-net-5/) does a great job of explaining the changes coming up in .NET 5 to the .NET community, but it assumes that your already know the difference between .NET Framework and .NET Core which I think most people outside of .NET have no idea about.

.NET Today
==========

.NET is a platform for developing software. There are two parts to .NET. The first part of .NET is a virtual machine for executing programs written an abstract assembly language, the virtual machine is called the Common Language Runtime (CLR) and the assembly language is called Intermediate Language (IL). The second part is a large standard class library called the Framework Class Library (FCL). Together the CLR and FCL make up .NET. 

An important goal for the CLR was to allow the smooth interoperation of many programming languages. This achieved via .NET assemblies, these are class libraries that contain binary IL and also enough meta data for a compiler to be able consume them directly. This means that a program executing on the CLR can be made up of assemblies that are written in different programming languages. The only difference between executables and libraries in .NET is that executables have an entry point specified. Therefore, any compiler that targets the CLR and can produce assemblies, can both create class libraries that are consumable by any other .NET compiler and create executables from assemblies that may have been written in other languages.

Assemblies can be created from the text form of the IL assembly language using the [IL Assembler](https://docs.microsoft.com/en-US/dotnet/framework/tools/ilasm-exe-il-assembler), but it's much more common to us a programming language to create assemblies. There are many programming languages that can create .NET assemblies, the most common being [C#](https://docs.microsoft.com/en-us/dotnet/csharp/), [F#](https://fsharp.org/) and [Visual Basic](https://docs.microsoft.com/en-us/dotnet/visual-basic/getting-started/).

We'll take a quick tour of the features of the CLR and then talk about the implementations of the CLR and FCL that exist today.

The usual way that code is executed in the CLR is by 'just in time' (JIT) compilation, meaning each method is compiled from byte codes to native machine code just before the method is executed. There some version of the CLR support 'ahead of time' (AOT) compilation of .NET assembles and even interpretation of IL, but the main focus of the CLR has been JIT, so AOT compilation support is not as fully developed as it might be and only fairly idiosyncratic version of the CLR offer IL interpretation.

The CLR is garbage collected environment, meaning that the programer does not need to manage the deallocation of memory directly, a garbage collector (GC) will decide whether memory is till in use of not and de-allocate it detects it's not in use. Different version of the CLR have different GC algorithms, but the most commonly used one is [tracing garbage collection](https://en.wikipedia.org/wiki/Tracing_garbage_collection) with additional heuristics to try and optimize memory management in a number of different scenarios.

Despite the CLR using GC it also provides many mechanisms to allow the programmer to control memory allocation and deallocation themselves. It is possible, with considerable effort, to write programs than never, at or least very rarely, invokes the GC.

Other features available in the CLR include the ability to easily invoke native code and structured exception handling. 

Standards specifying the behavior of both CLR and FCL exist and have been ratified by both Ecma International (ECMA) standards and International Organisation for Standardisation (ISO). The current version of ISO standards are ISO/IEC 23271:2012 and ISO/IEC 23270:2006.

If you are interested in doing .NET development today. There are three different version of the CLR you can choose from. These are:

Name            |   Open Source     |    OS Support
----------------|-------------------|-----------------------
.NET Framework  | No                | Windows
.NET Core       | Yes               | Windows, Linux, macOS
Mono            | Yes               | Windows and any *nix like OS

There are other implementation of the CLR available, but these three are being actively development and are fully supported today.

While having to choose between three different implementations of the sample platform isn't ideal, it really no different than having to choose between [CPython](https://www.python.org/) and [PyPY](https://www.pypy.org/) or [GCC](https://gcc.gnu.org/), [Microsoft Visual C++](https://docs.microsoft.com/en-us/cpp/?view=vs-2019) or [Intel C](https://software.intel.com/content/www/us/en/develop/tools/compilers/c-compilers.html). 

In the .NET world there is a high degree of compatibility between the three CLR implementations I talk about. The CLR implementations are now being development with a high degree of cooperation between the teams maintaining them and are synchronizing their release cycles.

Code can generally be crossed compiled between these three different CLR implementations and sometimes binaries targeting CLR implementation can be used by another CLR implementation without any change. The pain points when trying to port code from one CLR implementation tend to be the libraries. There are small variations in the FCL for each implementation, while effort has been made to keep the variations to a minimum, even a missing class can cause a lot of pain, if you depend on that class a lot from client code. Some libraries may only work on some OSs because the take dependencies on the features only available in that particular OS.

To dig a little deeper into whether an implementation is open source or not, ".NET Framework" isn't open source, parts of the source code are available, but it isn't available under an open source license and it does not accept pull requests. From their beginning both "Mono" and ".NET Core" have been fully open source. They are [both](https://github.com/dotnet) [hosted](https://github.com/mono/) on github.com now (which admittedly is owned by Microsoft these days). They both accept pull requests.

In terms of OS support ".NET Framework" just supports Windows, ".NET Core" supports Windows, Linux and MacOS, while "Mono" has been ported to a large range of *nix like operating systems and so provides support for mobile development by being able to create apps for Android and iSO.

.NET Tomorrow
=============

The .NET teams have announced that in the next version of .NET there will be only two version implementations of the CLR. .NET core will renamed and .NET and any features from .NET Framework missing .NET Core will be added. This will mean from the release of .NET 5 are main choice of CLR implementations will look like:

Name            |   Open Source     |    OS Support
----------------|-------------------|-----------------------
.NET            | Yes               | Windows, Linux, macOS
Mono            | Yes               | Windows and any *nix like OS

For the .NET 5 release further work will be done to make .NET and Mono more compatible, with the aim being to it easy to move code between the two platforms, so the developers choice is do they want a CLR that is less configurable and supports a few operating systems very well, in that case use .NET or do they want a CLR that is very configurable and can run across a huge range of operating systems, in that case use Mono.

Summary
=======

We have a high level overview of what .NET is and the features that make it up. We seen that at it's core .NET is a software runtime called the CLR that will execute an abstract assembly language called IL. We've seen that the CLR is open standard with several different implementation and had a quick look at the differences between the most relevant implementations. We have seen that although one CLR implementation is closed source software with that only runs on Windows, the other two major CLR implementations are fully open source and between them have support for a wide variety of OSs. The current direction of the project is towards more parts being open source.

Acknowledgements
================

I have drawn significant influence Wikipedia's [many](https://en.wikipedia.org/wiki/.NET_Framework) [articles](https://en.wikipedia.org/wiki/.NET_Core) [on](https://en.wikipedia.org/wiki/.NET_Framework_version_history) and [.NET](https://en.wikipedia.org/wiki/Common_Language_Infrastructure), I would like to thank the authors of these articles. The idea of this article was present a simplified version of the extensive details available on Wikipedia. 