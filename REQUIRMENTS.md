In this round we will be asking you to write a small application to serve as a proof of concept for a mock TinyURL style service. Please code in C#.
 
*** We do NOT expect to see an actual web service, and we do not need the application to parse actual HTTP requests. Please do NOT write a web service. And we do not need to see an actual persistent storage layer. Please do NOT use EntityFramework (even in-memory), SQLite, Redis, or similar. ***
 
TinyURL is a service in which users can create short links, such as tinyurl.com/4sa2upes, that redirect to longer links, such as https://www.google.com/. Please do NOT use the actual TinyURL or any other URL shortening service.
 
For this POC, we only need to see it mocked out at the command line level. We expect that the application can be run with user input, or with programmed unit tests to demonstrate functionality. Again, we do NOT expect to see an actual web service, and we do not need the application to parse actual HTTP requests. Similarly, we do not need to see an actual persistent storage layer. Feel free to mock this out in memory however you best see fit. Lastly, note that a single long URL might map to a few different short URLs.
 
Although this is a POC, we would still like to see it designed with architecture in mind. To this end, please consider your schema, service methods, and constraints accordingly. You should also design and write your code with thread-safety and performance in mind.
 
The POC should support:

Creating and Deleting short URLs with associated long URLs.
Getting the long URL from a short URL.
Getting statistics on the number of times a short URL has been "clicked" i.e. the number of times its long URL has been retrieved.
Entering a custom short URL or letting the app randomly generate one, while maintaining uniqueness of short URLs.

 
Good luck!

Best,

