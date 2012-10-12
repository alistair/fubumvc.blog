require 'albacore'

MAIN_SLN = "FubuMVC.Blog.sln"

task :default => [ "nuget:install", :compile]

desc "Compile fubumvc.blog and run its unit test projects."
msbuild :compile do |msb|
  msb.properties = { :configuration => :Debug }
  msb.targets = [ :Clean, :Build ]
  msb.solution = MAIN_SLN
end

namespace :nuget do

  desc "Install packages required by fubumvc.blog."
  task :install do
    sh "packages/nuget.exe install Blog/packages.config -OutputDirectory packages/"
  end


  desc "Update packages required by fubumvc.blog."
  task :update do |cmd|
    #TODO
  end

end

desc "Run unit tests for fubumvc.blog."
task :unittests do
  #Yeah I really have to write some tests for all this.
end


desc "Start RavenDB Server for fubumvc.blog."
task :startdb do |cmd|
    #TODO
end
