---
title: "Solving Sudoku Puzzles using F# and Microsoft Solver Foundation"
date: 2010-12-12T03:53:54.8000000
draft: false
---

<p>I’ve been doing a bit of work with <a href="http://code.msdn.microsoft.com/solverfoundation">Solver Foundation</a> lately and as I got to know the package it suddenly occurred to me Solver Foundation could be easily used to solve Sudoku puzzles. While I knew that solving Sudoku in F# wasn’t particularly an original idea, Jon Harrop has a <a href="http://www.ffconsultancy.com/dotnet/fsharp/sudoku/index.html">custom Sudoku solver in F#</a> that dates back to 2007, but I thought using Solver Foundation might be an interesting approach. I was on the train at the time so I fired up VS and pretty quickly had a working solution. A <a href="http://www.google.com/search?q=solver+foundation+sudoku">little googling later</a> revealed that I wasn’t at all the first to have thought of this, in fact there’s event a Sudoku example packaged with Solver Foundation, but using the OML solver language rather than F#. Anyway, as I have a working solution I thought I may as well show it here. At 121 lines, including comments, inputs and solution printing functions, I don’t think it’s too bad, however I do think there’s some room to make it even shorter.</p> <script src="https://gist.github.com/737992.js?file=solverFoundationSudoku.fs"></script>

### Feedback:

*Feedback was imported from my only blog engine, it's no longer possible to post feedback here.*

**re: Solving Sudoku Puzzles using F# and Microsoft Solver Foundation - [Frank de Groot - Schouten](http://frankapi.wordpress.com/)**

At Microsoft PDC 2010, Bart de Smet demonstrated a LINQ provider that spews OML and invokes Solver Foundation, solving a Sudoku using LINQ in C#: <a rel="nofollow external" href="http://bit.ly/bfzKCk" title="http://bit.ly/bfzKCk">http://bit.ly/bfzKCk</a>. Unfortunately I haven't seen his code online anywhere.

