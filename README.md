# Vivantio Pro / ITSM API Samples
This is the new home for API samples for Vivantio Pro / ITSM. We're just getting started with introducing the samples, so we'd love to hear back from you with your thoughts on:
* What languages / technologies you use
* What sort of samples you'd like to see
* Any other feedback!

## Live Samples
You can view the live samples here:
http://dotnet.samples.vivantio.com/

## License
All our API samples are published under the MIT Public License; see https://github.com/Vivantio/apisamples/blob/master/License.txt for further information.

## Getting Started with the API Samples
### Downloading the Samples
You can download the samples as a zip file, or clone the Git repo - whatever works best for you.

### Running the samples
Before you can run the sample, you'll need to add your credentials to the web.config file. Open the web.config, and fill in the following settings:

* **Vivantio.ApiUrl** - available from the Vivantio Admin Area under Admin > Integration & API > Downloads
* **Vivantio.ApiUser** - the username to connect to the API with (must have the 'Allow API Access' permission)
* **Vivantio.ApiPassword** - the password for that account

We **do not** recommend storing API credentials in the web.config long term - typically you should have your users log in to your API application each time.

Once those values are filled in, you should be able to "Run" the sample from within Visual Studio!
