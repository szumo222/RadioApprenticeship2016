# Ping Kiosk
Projects that was created while I was taking part in apprenticeship in Polish Radio Szczecin in 2016
This is console application that was made for checking internet connection in mini computers that was connected to TV in the other place than Polish Radio Szczecin building, to made clear if there is a problem internet connection or not.

## Configuration
This application require file called "config.txt" placed in the same folder as "Ping Kiosk.exe". This file contains configuartion ad it looks like this:

```
Browser
chrome
Website address with parameters to for example open browser in kiosk Mode
-kiosk http://radioszczecin.pl/rssplayer/player.php?pin=ycazfg&terminal=32
Path to the HTML that will be shown if there is no connection
-k C:\Temp\strona1.html
Console window height - in rows
30
Console window width - in characters
100
Adress to ping
wp.pl
```

What's important that it has to have this structure, so:
```
- 2 row - browser
- 4 row - website address
- 6 row - path to website when no internet connection
- 8 row - window height
- 10 row - window width
- 12 row - adress to ping
```

## Usage
"Ping Kiosk.exe" with "config.txt" has to be placed together. When application stars it is trying to ping adress that is configured. When there is no connection, it open page for error, and keep working and trying to ping adress. When there is connection to internet it opens the website adress, and stops working. 
