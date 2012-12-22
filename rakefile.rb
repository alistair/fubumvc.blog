require 'albacore'

MAIN_SLN = "FubuMVC.Blog.sln"
tests = FileList["**/*.Tests.dll"].exclude(/obj/)

task :default => [ "nuget:install", :compile, :tests]

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

tests.uniq do |dir|
  dir.pathmap('%f')
end
.each do |assembly|
  desc "Run tests for fubumvc.blog and all included packages."
  xunit :tests do |xunit|
    xunit.command = "packages/xunit.console.exe"
    xunit.assembly = assembly
  end
end
