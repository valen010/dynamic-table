## Description

#### A dynamic table application that allows users to create rows and columns of data using sorting/creation and re-ordering functions


built with blazor(WebAssembly ASP.Net Core(5.0) hosted)

## Building

#### 1) make sure that you executed all the required sql trigger/function procedures in scriptdb.sql file which is included in DbFile folder, since it is necessary for application to function as expected.

#### 2)make sure that connection strings in dbcontext and systemlogs.cs file points to your local sql server instance.

#### 3) make sure that application.server.exe is running in the background while you are running the application. you can find exe file under ..\Application\Server\bin\Debug\net5.0\application.server directory.

##### note: if you dont want to use application.server.exe you must start the project as multiple startup projects. 
for this; right click project solution->properties->Multiple startup projects->select start option for application.client and application.server. in this case dont forget to change the port number(Baseurl) in Application.Client/program.cs to the application.server's port number

###
![grab-landing-page](https://github.com/valen010/Application/blob/master/Screenshots/arrange-cols.gif)

![grab-landing-page](https://github.com/valen010/Application/blob/master/Screenshots/arrange-records.gif)
