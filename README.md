# TMP

TMP stands for Temperature Management Program. *Very straight forward, I know*


## Whats the aim of TMP?
  It was designed by me initally for personal use only and initially it had just the console as ui. I was annoyed that my laptop would constantly be at his temperature limits, the fans reving at its maximum rotational momentum, creating noise and making me the center of attention. So I decided to control the clock speed based on my cpu temperature.
  I was unsatisfied with the way the built in power plans work. I wanted full control.
  Decided to share it and make it open source. On the way I noticed there are better ways to do some things and made a 2.0 version with GUI and stuff. I myself enjoy the new version too haha

## How is it implemented?
 - works by using windows powerplans
 - Hardware readings are made via the OpenHardwareMonitor library. Check it out at https://openhardwaremonitor.org
 - admin permissions are required to read cpu data
 - no networking bs


## Legal:
- I take no responsability if you wreck your cpu or anything else by using this program. Software is provided as a tool and may contain bugs.

## Regarding wrecking your tech:
- I have used my program for over a year, my cpu still seems to work fine till now. I never tried setting the shift timer to low values, I think rapid clock speed switching may create some issues (but I don't know and won't test it). And also expect your os to freeze if you set your cpu max limit to 10% or lower (obviously). You may have a hard time switching it back XD

## Bugs
If you find any bugs feel free to create an issue
I know the code is not the best in some areas but it fills its purpose for now


# Wiki


