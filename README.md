Build under Mac OS X using Xamarin Studio/MonoDevelop and Mono

Step 1:
Download MySql connector from the following URL: http://dev.mysql.com/downloads/connector/net/5.2.html

Step 2:
Unzip and copy v4/mysqldata.dll to /Libraries/Frameworks/Mono.framework/Libraries/MySqlData.dll and register MySqlData in the GAC:

```
sudo gacutil /i /Libraries/Frameworks/Mono.framework/Libraries/MySql.Data.dll
```

The original installation instructions can be found at http://dev.mysql.com/doc/refman/5.0/en/connector-net-installation-unix.html.

Step 3:
The old reference to MySql.Data.dll must be removed, and the new one (/Libraries/Frameworks/Mono.framework/Libraries/MySql.Data.dll) need to be added. This is done by right-clicking the "References" folder in Xamarin Studio/MonoDevelop and choose "Edit references".
