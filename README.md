<h1>fubumvc.blog</h1>
A blogging web application using:

* FubuMVC
* SparkViewEngine
* mongoDB, <a href="https://github.com/kharlamov/mongo-csharp-adapt">mongoAdapt</a>
* JavaScript (require, underscore, pagedown, and jQuery)
* Less, TwitterBootstrap

<h2>Documentation:</h2>
To setup and run, follow these steps: 
* Run `rake`, to pull nuget packages and build the project. _([Building fubumvc.blog for the first time](https://github.com/kharlamov/fubumvc.blog/wiki/Building-fubumvc.blog-for-the-first-time.))_.
* Run mongoDB, `mongod`  _(Installation instructions: [Setup mongoDB for fubumvc.blog](https://github.com/kharlamov/fubumvc.blog/wiki/Setup-mongoDB-for-fubumvc.blog))_.
* Run FubuMVC.Blog.sln, and click F5 start the project.


<h2>TODO (v 1.0):</h2>
* Add support for custom pages.
* Remove Information bottle, in favor of custom pages.
* Complete profile section.
* Add support for permissions/user roles.
* Add administration settings section bottle.
* Convert all packages to use actual nuget packages. Awaiting fubuMVC 1.0.
* Clean up UI.
* Add support for Internet Explorer 8-10.
