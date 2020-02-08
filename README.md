# urlshortner 


## Getting Started

This is a .Net Core project that works as a web server on the localhost, It let you send Http request to the server and receive a proper response.

### Prerequisites

- First, You need to install the .Net Core framework, Here it is a guide for installing [.Net Core SDK](https://docs.microsoft.com/en-us/dotnet/core/install/linux-package-manager-ubuntu-1904) on different OS's.

- Second, It's time to install needed dependencies like 
    - Microsoft.EntityFrameworkCore
	- Microsoft.EntityFrameworkCore.Relational
	- Microsoft.EntityFrameworkCore.Design
	
So to add these packages to the project we use the below command:
```
dotnet add package <package_name>
```
Note:  if the project needs any other dependency in the future you can add them the same way.

### Installing

- After you clone the project into your local system, you need to handle migrations part, don't worry if you have no knowledge about migrations(It's a part of EntityFrameworkCore), you need only to execute these commands only:
```
dotnet tool install --global dotnet-ef
dotnet ef migrations add Booking.AppDbContext
dotnet ef database update
```
- Now you can run the project:
```
dotnet run
```

## How To Use

## Project functionalities:
- #### 1. Send the server a long url and receive a short url as response
- #### 2. send the server a shorturl and redirect to the long url by server

### The First functionality
For this purposr we need to send a post request to server with longurl as a key/value entity of Json and the server will return a json containing both LongUrl and generated ShortUrl, For example:
```
curl -i -d '{"LongUrl":"https://google.com"}' -H "Content-Type: application/json" -X POST http://localhost:5000/urls
```
This command send a post request to server (-X POST) run in address of http://localhost:5000/urls (contains port number and route address) with LongUrl of "https://google.com" (I think you got how to use it) and the response will be for example:
```
{"id":11,"shortUrl":"gchoswqh","longUrl":"https://www.google.com"}
```
Another example:
```
curl -i -d '{"LongUrl":"https://bitly.com"}' -H "Content-Type: application/json" -X POST http://localhost:5000/urls
```
- Note #1 : Only the LongUrl has been changed
- Note #2 : If you use an unvalid LongUrl you will get bad request status code 
### The Second one
Assume that you have a shortUrl and wanna to use it to go to the main page the LongUrl represent of, you have to use below command:
```
curl -i localhost:5000/Redirect/<ShortUrl>
```
So the server search for Short in the database and if it exist, automaticly redirect to it and if not return 404 status code, let's use generated Shorturl we receive from server in previous section:
```
curl -i localhost:5000/Redirect/gchoswqh
```
And as response the server redirect us to https://google.com

## Built With 

* [Dotnet](https://dotnet.microsoft.com/) - The web framework used
* [PostgreSQL](https://www.postgresql.org/) - Dependency Management
