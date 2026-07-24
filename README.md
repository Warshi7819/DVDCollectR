# DVDCollectR
A Web Application that enables you to import your DVD Collection from [DVD Profiler](http://www.invelos.com/) and make it available as - you will never guess this - a Web Application. 

sales pictures go here ;)


## DVD Profiler - Getting Your Data
So, back in April 2009 I bougth a license for [DVD Profiler](http://www.invelos.com/) and between 2009 and 2012 I cataloged my collection of 453 DVD's. This year I started to wonder if it was possible to:
* A: Rescue this data about my DVD collection from my old Acer Aspire One Netbook.
* B: Create a Web App so that I could carry this collection with me and access it from my phone.

### Exporting Data From DVD Profiler
Luckily exporting the data from DVD Profiler to XML is quite easy. You'll find the option under **File** -> **Export Profile Database...**. Just accept the default and save everything as a Collection.xml file. Remember, you can use this data as long as it's for your personal use.

We now have the metadata for all our DVD's. Then we need to find the back and front cover images. These are situated on Windows under your home directory:
%USERPROFILE%\Documents\DVD Profiler\Databases\Default\Images

The images are stored with the id of the profile they belong to, with a trailing **f** for front or **b** for back. E.g.
* filename: 044005939026.2f.jpg
* Profile Id: **044005939026.2**f.jpg
* Front cover: 044005939026.2**f**.jpg

There's also a **Thumbnails** directory under the Images folder that contains smaller Thumbnail friendly versions of all the images using the same naming convention. 

## DVD CollectR - The Web App
Even though the data exported from DVD Profiler is the foundation of this project (no data, no fun) this GitHub project is of course all about the Web App. And since I also discovered that DVD Profiler is still alive and kicking, **AND** that my license from 2009 is still valid on the latest version from 2017, this project focuses on the __display__ of my collection. I will still continue to use [DVD Profiler](http://www.invelos.com/) to keep my collection up to date. 

### Architecture
...

### Data Flow
...

## Development
### Built Using AI
I'll just throw in a small disclamer: ~90% of this was built using AI (OpenCode with DeepSeek V4 Flash, and MiMo v.2.5). The structure of the project (API, Web, Shared), the authentication, a few pages with basic navigation and the classes needed to read the Collection.xml file I had already setup before I let AI loose. 

The experience was mostly good except for one rabbit hole where the AI model (DeepSeek) insisted on good error handling and fallbacks instead of fixing the core issue (why the DB migration failed in the first place). This was kinda funny and frustrating at the same time :) After some yelling at the model and re-focus we got there in the end. 

### Visual Studio 2026: Paste XML As Classes
Surly someone has created something that can translate an XML file to the classes needed to read it in C#!? Looking online the answer kinda suprised me as I was not aware of this functionality in Visual Studio 2026 but it's actually built in and you can find it under **Edit**->**Paste Special**->**Paste XML As Classes**

It says that a sample xml file will do, and my sample was my entire ~8mb Collection.xml file and it worked! Zabing!
