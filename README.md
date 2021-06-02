# SitecoreAnnotatable
A Library for automatically adding annotations to the markup of Sitecore Websites.

- [About this Project](#about-the-project)
- [Install with Nuget](#install-with-nuget)
- [Getting Started](#getting-started) 

## About The Project

SitecoreAnnoatable is a library that can be added to Sitecore installations with little configuration that will generate annotation in the HTML markup of your different Sitecore artifacts.
With SitecoreAnnotatable you will:

- Annotate Sitecore Renderings in HTML.
- Identify the Name, Type, and Datasource of each Rendering.
- Provides OOTB 'Sitecore Markers' to annotate in either XML style tags or HTML style comments.
- Markers are easilably extensible and can be swapped out with your own custom implementation. 


## Install with NuGet

You can install the framework via [NuGet](https://www.nuget.org/packages/dglambert.SitecoreAnnotatable/):

``` powershell
PM> Install-Package dglambert.SitecoreAnnotatable
```

For information about configuring, see the [Getting Started](#Getting-started) section below.


## Getting Started

### Setting up Dependencies
...