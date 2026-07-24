# DVDCollectR
A Web Application that enables you to import your DVD Collection from DVD Profiler (Invelos Software) and make it available as - you will never guess this - a Web Application. 

## DVD Profiler - Getting Your Data
So, back in April 2009 I bougth a license for DVD Profiler and between 2009 and 2012 I cataloged my collection of 453 DVD's. This year I started to wonder if it was possible to:
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
Even though the data exported from DVD Profiler is the foundation of this project (no data, no fun) this GitHub project is of course all about the Web App. 
