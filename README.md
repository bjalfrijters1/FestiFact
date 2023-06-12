# FestiFact

################
# INSTALLATION #
################

1. Clone repo
2. run update-database in packet management console
3. Build solution
4. If you run into build problems, check dependecies, all projects use Festifact.Models.
5. Testing also uses Mobile
6. Run solution with multiple projects (Api AND Web and/or Mobile), can run all three at once.

You can use both an Android and a WinUI application to run the Mobile project.

You may run into some issues, mainly when mailing stuff,
mailing defaults to ethereal.email, 

You can check the project's ethereal email in Mobile.Services.MailService and check the Authenticate() method.
This is a temporary mailbox, the authentication does not matter.

Android location is wildly off course (it showed my device being in the USA), while WinUI would use my actual location.


With debugging the Web client, make sure to use a chromium-based browser (Edge/Chrome, etc.),
FIREFOX CANNOT RUN THE DEBUGGER!!!
Which basically means you cannot attach breakpoints in Blazor with a non-chromium based browser running.

If you run into building issues, try restarting MS Visual Studio.
Or try clean and (re)build the project(s), then restarting.
Or try unloading the project, restarting MS Visual Studio, then reloading the project.





