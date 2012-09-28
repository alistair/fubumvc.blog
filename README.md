<h1>FubuMVC.Blog</h1>
A blogging web application using:

* FubuMVC
* SparkViewEngine
* RavenDB
* JavaScript (require, underscore, amplify, showdown, and jQuery)

<h2>Documentation:</h2>
To run:
* Run 'setup.bat' to install nuget packages.
* Start the database by running 'startdb.bat'.
* Run FubuMVC.Blog.sln, and click F5 start the project.

To run via rake:
* Run 'rake', to pull packages and build the project.
* Run 'rake startdb', to start teh database.
* Run FubuMVC.Blog.sln, and click F5 start the project.


<h2>TODO (v 1.0):</h2>
* Complete Profile Section.
* Add permissions.
* Add Administration Section to Profile.
* Create settings POCO, save to RavenDB.
* Wire up compose article quick action buttons, (undo, insert image, etc..)
* Complete Information Pages.
* Convert all packages to use actual nuget packages.
* Clean up UI.
* Add support for Internet Explorer 8-10.
