Add the following values in Application Settings of the web app.

Add three separate connection strings to explicitly test TLS at each version.

CacheConnectiontls1  -> set to Redis Cache Connection Settings from Redis Server
CacheConnectiontls11 -> set to Redis Cache Connection Settings from Redis Server
CacheConnectiontls12 -> set to Redis Cache Connection Settings from Redis Server


Add FQDN for socket testing 

FQDNToTest -> set to URL of Redis

Add FQDN port to test on   

FQDNPortToTest -> set to port to test for redis server
