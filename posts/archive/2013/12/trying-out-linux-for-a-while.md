---
title: "Trying Out Linux for a While"
date: 2013-12-14T05:59:48.5170000
draft: false
---

<div class="entry-content"><p>So, I had a good time at <a href="http://BuildStuff.lt/">BuildStuff.lt</a>, but my laptop died in quite an odd way. I&rsquo;ll write more about the laptop death in another post.
I&rsquo;ll also write more about <a href="http://BuildStuff.lt/">BuildStuff.lt</a> in another post. This post is about the laptops resurrection.</p>

<p>I tried to repair the laptop using a windows using a bootable USB rescue disk kindly provided by <a href="https://twitter.com/thinkb4coding">Jemery</a> and <a href="https://twitter.com/ronanklyne">Ronan</a>, but despite taking a long time this just made it worse.</p>

<p>So when I got home I decided to zap everything and install Linux. I&rsquo;ve been a Windows for a long, long time now. I&rsquo;ve made various attempts to use Linux instead but I&rsquo;ve also either hosted Linux in a VM or duel booted and this means I always drift back to Windows in the end, more for the software than the OS. So this time instead of missing the windows software, I&rsquo;m going to attempt to do things the &ldquo;Linux way&rdquo;, meaning instead of using specialist software for each task (ie Visual Studio for coding, Word for writing, Live Writer for blogging etc.), I&rsquo;m going to try and learn one text editor well and use it for doing all those things in plain text plus markup/markdown.</p>

<p>This new blog is the first visible sign of this. It&rsquo;s octopress based and hosted on github, if everything works out I&rsquo;ll eventually migrate my domain and old blog posts here. If it doesn&rsquo;t it&rsquo;ll be quietly dropped.</p>

<p>The first 72 hours has had it&rsquo;s ups and downs. Here&rsquo;s a summary:</p>

<h1>The good</h1>

<p>The Linux terminal is great, light years heard of either cmd or powershell in Windows. If I do go back to Windows, I think I&rsquo;ll just use Cygwin as my terminal and do more stuff through that.</p>

<p>Having repository based app installation is great, especially as if a command is missing the shell will often tell you what package it&rsquo;s in.</p>

<h1>The bad</h1>

<p>The version of LibreOffice wouldn&rsquo;t open (I didn&rsquo;t want to use it for writing but I need to be able to read a word doc). Doing <code>apt-get install libreoffice</code> fixed this, but still if it comes pre-installed would be nice if it worked out the box, right?</p>

<p>The latest version of Skype wouldn&rsquo;t install, so I&rsquo;m stuck with one from apt-get which has no web cam support.</p>

<p>The cloud disky type thing I&rsquo;m using, copy.com, has a Linux client, but it comes with no installer. You install it where you like. Which had me scratching my head where should I install this?</p>

<p>Octopress depends on version 1.9.3 of Ruby that isn&rsquo;t on apt-get. The solution seems to be building from source. Getting the right source and building was pretty easy. The problem is running <code>./configure</code> cleverly doesn&rsquo;t compile the bits that rely on libraries that aren&rsquo;t there. This is great if you don&rsquo;t need that bit, but if you do it sends you down a cycle of find the library, install it then recompile. This is what was missing for me:</p>

<ul>
<li>You need to change the default yaml parser to install a gem that octopress relies on, following the instructions from <a href="http://collectiveidea.com/blog/archives/2011/10/31/install-ruby-193-with-libyaml-on-centos/">this post</a></li>
<li>Ensure zlib is installed, the apt-get package name is zlibc on zlib</li>
<li>Ensure OpenSsl is installed, the apt-get packages that need to be installed can be <a href="https://help.ubuntu.com/community/OpenSSL">found here</a></li>
</ul>


<p>On the one hand, this is all noobe stuff, on the other hand it makes me feel I&rsquo;m climbing a hill that didn&rsquo;t ought to be there.</p>
