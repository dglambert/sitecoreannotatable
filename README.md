# SitecoreAnnotatable
A Library for automatically adding annotations to the markup of Sitecore Websites.

- [About this Project](https://github.com/dglambert/sitecoreannotatable#about-the-project)
- [Install with Nuget](https://github.com/dglambert/sitecoreannotatable#install-with-nuget)
- [Getting Started](https://github.com/dglambert/sitecoreannotatable#getting-started) 

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

For information about configuring, see the [Getting Started](https://github.com/dglambert/sitecoreannotatable#Getting-started) section below.


## Getting Started

### Setting up Dependencies

In your IOC container, you will need to register two additional services, `IContentService` and `IRenderingMakerFactory`. 

```csharp
    public class RegisterDependencies : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            Database database = Glass.Mapper.Sc.IoC.SitecoreContextFactory.Default.GetSitecoreContext().Database;

            serviceCollection.AddSingleton<dglambert.SitecoreAnnotatable.Infrastructure.Services.IContentService>(service => new dglambert.SitecoreAnnotatable.Infrastructure.Services.ContentService(database));
            serviceCollection.AddSingleton<dglambert.SitecoreAnnotatable.Infrastructure.Factories.IRenderingMarkerFactory, dglambert.SitecoreAnnotatable.Infrastructure.Factories.RenderingMarkerFactory>();
        }
    }
```