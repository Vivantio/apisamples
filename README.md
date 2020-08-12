# Vivantio Pro / ITSM API Samples

This is the home for API code samples for Vivantio Pro / ITSM. We're just getting started with introducing the samples, so we'd love to hear back from you with your thoughts on:

- What languages / technologies you use
- What sort of samples you'd like to see
- Any other feedback!

We currently have two main Visual Studio solutions:

- `Vivantio.Samples.sln` - an ASP.NET MVC full demo application (see the live application [here](https://vivantioapisampleapp.azurewebsites.net/)).
- `VivantioApiSamples.sln` - a .NET Console application that demonstrates various data access techniques using `HttpClient`.

## License

All our API samples are published under the MIT Public License; see [License.txt](https://github.com/Vivantio/apisamples/blob/master/License.txt) for further information.

## Getting Started with the API Samples

### Downloading the Samples

You can download the samples as a zip file, or clone the Git repo - whatever works best for you.

### Running the samples

Before you can run the samples, you'll need to add your credentials to `web.config` (Vivantio.Samples) or `Programs.cs` (VivantioApiSamples). Fill in the following settings:

- `Vivantio.ApiUrl` or `const string baseUrl` - available from the Vivantio Admin Area under Admin > Integration & API > Downloads
- `Vivantio.ApiUser` or `const string username` - the username to connect to the API with (must have the 'Allow API Access' permission)
- `Vivantio.ApiPassword` or `const string password` - the password for that account

We **do not** recommend storing API credentials `web.config` or `Programs.cs` long term - typically you should have your users log in to your API application each time.

Once those values are filled in, you should be able to "Run" the samples from within Visual Studio!

## Additional Resources

- See our [Tutorials repo](https://github.com/Vivantio/apitutorials) that explains how to test our APIs with Postman.
- See our [API Reference](https://webservices-na01.vivantio.com/Help) pages for a catalogue of supported APIs.
