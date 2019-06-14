This web page is designed to test TLS connection to Redis and any server end point. It is comprised of six separate tests. The tests are not done in a loop or with repeated code by design. 

Upload this solution to an Azure App service and the make the following entries into application settings. 

Add the following values in Application Settings of the web app.

Add three separate connection strings to explicitly test TLS at each version. Make sure to set the sslProtocols setting in each connection string. Ex: sslProtocols=tls1

Example string: YOURREDISSERVER,abortConnect=false,ssl=true,sslProtocols=Tls,password=YOURPASSWORD

CacheConnectiontls1  -> set to Redis Cache Connection Settings from Redis Server<br>
CacheConnectiontls11 -> set to Redis Cache Connection Settings from Redis Server<br>
CacheConnectiontls12 -> set to Redis Cache Connection Settings from Redis Server<br>


Add FQDN for socket testing 

FQDNToTest -> set to URL of Redis

Add FQDN port to test on   

FQDNPortToTest -> set to port to test for redis server
