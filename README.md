
# WindowsServiceManager

A single page web interface that provides access to view and control windows services on the host server.


## Security note

Exposing control of windows services via a web interface clearly has a number of security implications so should not be done without careful assessments of the risks involved. 
The intention is to expose this web application only within internal networks, and not exposed to the internet. Permissioning for this website is provided by 
Windows Authentication - **for more details on configuration of the security settings for that application please read the Security section of this read me document**. 


## Getting started

1.  First set up a new windows user for the app pool. This user must be a local administrator (in order to start and stop the windows services). 
2.  Set up a new app pool in IIS. Set the app pool user to the user set up in step 1.
3.  Load the solution in VS and publish the website in release mode.
4.  Double check that all the web.config settings are set correctly:
	1.  Ensure that the RoleAuthorizationDisabled app setting is set to false in order to enable authorization.
	2.  Set the users that are able to view and control the web services by adding groups to the ReadOnlyUsers and ServiceControllers app settings.
	3.  Confirm the connection string is appropriate - the default is a SQLExpress database with the db file stored in the DataDirectory.


## Service filters

One of the main motivations for this project is to make navigation of the hundreds of windows services simple. Filtering the main view to services is possible in 2 ways:


### Text search

It is possible to search for a service based on the service name. Enter the search string into the *Filter By Name* text box. This is a trivial search that only returns
results that contain the entire string entered into the filter text box. More advanced querying may be added at a later stage. 


### Service Tags

Tags can be added to services to create logical groups of services.

Once your services have been tagged you can then filter them by specifying the tags in the *Filter By Tag* tag input field. The only services that are displayed are those that have 
all of the tags specified in the filter box (there os no OR style querying).


## URL parameters

There are 2 URL parameters to load a prefiltered list of services. **Note** url parameters are case sensitive.

**filtertags**: can be used to filter by a comma separated list of tags. Example URL http://MyServiceSite.com/?filtertags=abc,def

**filtertext**: can be used to filter the services based on the service name. Example URL http://MyServiceSite.com/?filtertext=abc

In both cases the url parameters are added to the filter input boxes, so can be altered on the page.  