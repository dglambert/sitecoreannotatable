# SitecoreAnnotatable

A Library for automatically adding annotations to the markup of Sitecore Websites.

- [About this Project](https://github.com/dglambert/sitecoreannotatable#about-the-project)
- [Install with Nuget](https://github.com/dglambert/sitecoreannotatable#install-with-nuget)
- [Getting Started](https://github.com/dglambert/sitecoreannotatable#getting-started) 
- [Contributing](https://github.com/dglambert/sitecoreannotatable#contributing)
- [Contact Me](https://github.com/dglambert/sitecoreannotatable#contact-me)


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


## Compatibility

- **Sitecore 8.2.7** [Verified Working]

As the original intention of this project was for my own use, I did not spend time testing this on any installations other that 8.2.7. 

If you are interested in trying it out and would like to contribute by testing against your installation, please let me know if it works and I will update this list as users report expanded compatibility. 



## Contributing

If you encounter a bug or have a feature request, please use the [Issue Tracker](https://github.com/dglambert/sitecoreannotatable/issues/new). The project is also open to contributions, so feel free to fork the project and open pull requests.


## Contact Me

If you have a question or comment you can DM me on the [Sitecore Community Slack Channel](https://sitecorechat.slack.com/app_redirect?channel=U48R1EDCG), [Twitter](https://twitter.com/dGleasonLambert), or [LinkedIn](https://www.linkedin.com/in/dglambert/)
