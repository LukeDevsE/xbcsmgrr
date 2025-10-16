Xbox Connected Storage Manager Revived
======================================
*A quickly written application to easily interact with Xbox Live game save data.*


### Preview
![Application Screenshot](assets/screenshot_example.png)

## How to login
1. press the Open Link button on the dialog when you open the program.
2. Click authorize
3. enter the code after ?code= and press Ok
4. you are now logged into xbcsmgrr (anytime you close it, you will have to log back in)

## Requirements
- Windows 10+
- GamingServices
- Any game that uses Xbox Live (*installed and played recently*)

## Background
Accessing games using Xbox Live's save data requires authorization for the 'TitleStorage' service. This requires a device authenticated token and user token. However, the device token originally went through
a Microsoft SOAP-based stage which required more effort than it was worth. Instead, utilizing the 'wincred' storage was helpful as this is where the relevant Gaming Services on Windows caches tokens. I created
this application to make the process more clean and easier.

There are features missing, or removed for reasons, so it will appear more barebones than it previous and privately was. Again, this is a slightly reworked version that has been private for a few years now.

## Why?
I believe that everyone has the right to access and modify their game save data on the games that they play. Despite potential issues for cheating, there are systems and report functionality in place to help reduce,
detect and generally deal with potential bad actors.

## Credits/References
- [XboxAuthNet](https://github.com/AlphaBs/XboxAuthNet)
- [Prism Launcher for OAuth](https://prismlauncher.org/)
