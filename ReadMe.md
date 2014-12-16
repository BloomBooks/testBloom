# **License**

Bloom is open source, using the [MIT License](http://sil.mit-license.org).

# Development Process

## RoadMap / Day-to-day progress

See the [Bloom Trello Board](https://trello.com/board/bloom-development/4f087ec138f81c83752051a0).

## Bug Reports

Reports can be entered in [http://jira.palaso.org/issues/browse/BL](http://jira.palaso.org/issues/browse/BL). They can be entered there via email by sending to [issues@bloom.palaso.org](mailto:issues@bloom.palaso.org); things sent there will be visible on the web to anyone who makes an account on the jira system.

## Continuous Build System

Each time code is checked in, an automatic build begins on our [TeamCity build server](http://build.palaso.org/project.html?projectId=project16&amp;tab=projectOverview), running all the unit tests. Similarly, when there is a new version of some Bloom dependency (e.g. Palaso, PdfDroplet, our fork of GeckoFX), that server automatically rebuilds Bloom. This automatic build doesn't publish a new installer, however. That kind of build is launched manually, by pressing a button on the TeamCity page. This "publish" process builds Bloom, makes and installer, rsyncs it to the distribution server, and writes out a little bit of html which the [Bloom download page](../download/) then displays to the user.

## Source Code

Bloom is written in C# with Winforms, with an embedded Gecko (Firefox) browser and a bunch of jquery-using javascript. You will need Visual Studio 2010 SP1, or greater, to build it. The free Visual Studio Express version should be fine, but we don't test it.

To get the source code, you'll need Mercurial. Windows users, install TortoiseHg. Then from a command line, go to where you keep your development projects, and give this command:
`
hg clone http://hg.palaso.org/bloom
`
You should now have a solution which you can build using any 2010 edition of Visual Studio 2010, including the free Express version. We could help you do it in VS 2008, if necessary.

Now, what revision should you be on? If you're not familiar with DVCS (Distributed version control), this could be a big stumbling block. I hesitate to give advice in this document in case I forget to update it. But a reasonable start is to update to the tip revision, which is the most recent one that anyone has checked in, regardless of which branch it is on. To update to the tip, do:
`
hg update tip`

It will avoid some complications if you do that now, before adding the dependencies which follow.

## Binary Dependencies

Some of the dependencies are very large, and others are updated frequently. For both of those reasons, you can't just pull the code and expect it to compile. First, you will have to do some extra work to get Bloom's library dependencies complete and up to date. To make that easy, each time our TeamCity server builds Bloom via [Bloom-Default-Win32-Auto](http://build.palaso.org/viewType.html?tab=buildTypeStatusDiv&amp;buildTypeId=bt222), it creates a [Bloom32Dependencies.zip](http://build.palaso.org/guestAuth/repository/download/bt222/.lastSuccessful/BloomWin32Dependencies.zip) file, which has one file for distfiles (exiftool.exe), and a bunch of files for the lib directory, including the full xulrunner. Extract this file on top of your bloom source directory, allowing your zip utility to replace any conflicting files with the ones in the zip file:

![](data:image/png;base64,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)

If you'll be working with Send/Receive, please copy the "Mercurial" and "Mercurial Extensions" folders from an installation of Bloom to the root of your Bloom source directory.

Next, find and double-click "Bloom VS2010.sln" and choose "Debug:Start Debugging". Problems? Don't get frustrated, just drop us an email: hattonjohn on gmail.

#### About Bloom Dependencies

Our **[Palaso libraries](http://projects.palaso.org/projects/palaso)** hold the classes that are common to multiple products. If you need to build palaso from source, see [projects.palaso.org/projects/palaso/wiki](http://projects.palaso.org/projects/palaso/wiki).

Our **[PdfDroplet ](http://pdfdroplet.palaso.org)**engine drives the booklet-making in the Publish tab. If you need to build PdfDroplet from source, see [projects.palaso.org/projects/pdfdroplet/wiki](http://projects.palaso.org/projects/palaso/wiki).

Our **[Chorus](http://projects.palaso.org/projects/chorus)** library provides the Send/Receive functionality.

**GeckoFX**: Much of Bloom happens in its embedded Firefox browser. This has two parts: the XulRunner engine, and the GeckoFX .net wrapper.

GeckoFX is included in the BloomWin32Dependencies.zip file. If you need to build GeckoFX from source, see [https://bitbucket.org/geckofx](https://bitbucket.org/geckofx). Note that Bloom is actually built off of the [Hatton fork](https://bitbucket.org/hatton/geckofx-11.0). In either case, you'll need to figure out which version of gecko (firefox) Bloom is currently using.

**XulRunner**: If you need some other version that what is already in the BloomWin32Dependencies.zip, they come from here: [http://ftp.mozilla.org/pub/mozilla.org/xulrunner/releases](http://ftp.mozilla.org/pub/mozilla.org/xulrunner/releases). You want a "runtime", not an "sdk". Note, in addition to the generic "lib/xulrunner", the code will also work if it finds "lib/xulrunner8" (or 9, or 10, or whatever the current version is). I prefer to append that number so that I'm clear what the version of xulrunner is that I have sitting there.

More information on XulRunner and GeckoFX: Firefox is a browser which uses XulRunner which uses Gecko rendering engine. GeckoFX is the name of the .net dll which lets you use XulRunner in your WinForms applications, with .net or mono. This is a bit confusing, because GeckoFX is the wrapper but you won't find something called "gecko" coming out of Mozilla and shipping with Bloom. Instead, "XulRunner" comes from Mozilla and ships with Bloom, which accesses it using the GeckoFX dll. Got it?

Now, Mozilla puts out a new version of XulRunner every 6 weeks at the time of this writing, and Hindle's GeckoFX keeps up with that, which is great, but also adds a level of complexity when you're trying to get Bloom going. Bloom needs to have 3 things in sync:
1) XulRunner
2) GeckoFX intended for that version of XulRunner
3) Bloom source code which is expecting that same version of GeckoFX.

&nbsp;

More text
