# Update From Developer
This project was developed by me for me; and *for* Windows and *using* Windows. But since I later switched to Linux I stopped using this program and also now don't have the tools to finish the final touches. It is functional and documented  below, the extra features are not finished yet. Maybe at some point I will set up a VM and finish it, but right now it is unlikely.
Check out my other project
![FTreeViewer](https://github.com/BruhBruhDev/FTreeViewer)! (also GitHub)

# TMP

TMP stands for Temperature Management Program. *Very straight forward, I know*

![screenshot](/images/screenshot-2.0.0.png)

## Whats the aim of TMP?
It was designed by me initally for personal use only and initially it had just the console as UI. I was annoyed that my laptop would constantly be at his temperature limits, the fans reving at its maximum rotational momentum, creating noise and making me the center of attention. And I was unsatisfied with the way the built-in power plans work. I wanted full control.

I wanted to control the clock speed based on my cpu temperature.
And it worked out well!

Later I decided to share it and make it open source. On the way I noticed there are better ways to implement some things and made a overhaul 2.0 version with GUI and stuff. I myself enjoy the new version too haha

## What OS is supported?
Only Windows.
Note: it was developed and tested in both Win7 and Win10. Not tested in Win11. Although should work the same way.

## Building
You can build it using Visual Studio (not to confuse with VS Code). You will need to install C# language support and Windows Forms. Thats it. Clone. Open the project and build. Don't forget OpenHardwareMonitor. It should be in the same directory as the .exe

## How is it implemented?
 - works by using windows powerplans (*very os friendly*)
 - Hardware readings are made via the OpenHardwareMonitor library. Check it out at https://openhardwaremonitor.org
 - admin permissions are required to read cpu data
 - no networking bs


## Legal:
- I take no responsability if you wreck your cpu or anything else by using this program. Software is provided as a tool and may contain bugs.

## Regarding wrecking your tech:
- I have used my program for over a year, my cpu still seems to work fine till now. I never tried setting the shift timer to low values, I think rapid clock speed switching may create some issues (but I don't know and won't test it). And also expect your os to freeze if you set your cpu max limit to 10% or lower (obviously). You may have a hard time switching it back.

## Bugs
If you find any bugs feel free to create an issue
I know the code is not the best in some areas but it fills its purpose for now

Known Issues:
- Modifying "Upper p%" and "Lower p%" directly might sometimes have unexpected behaviour
- Sometimes after starting the program and Cycle no WPP modifications are applied. It has something to do with the CMD part and is a bit messy to debug. The version 2.0.1 includes the working "Current WPP:"-label which should tell you if something messed up during start. It either shows "TMP" or "Not detected". The version doesn't include the bug fix yet, maybe later 😂


# Wiki
written for v2.0.0-alpha
![screenshot with asterics](/images/screenshot-2.0.0-edit.png)

### Where do I find the .exe file?
Look on the right side under releases

## Sections  (sorted in a meaningful order)
### Section 1 - "Toggle Manager"
In the "Toggle Manager" view you can toggle if the program shall run or not. If "Running/Idle" is unticked nothing will happen. After ticking it the Cycle timer will start. (see section 6 "Cycle")
### Section 6 - "Cycle"
"Cycle" view:
- "Length" lets you control how long a cycle should be.
- "Current Cycle" displays the time in miliseconds of the current Cycle

Once the running time hits the time specified in "Length", the program will handle according to the logic specified in the other Sections. It either idles and waits or does a upshift or downshift. (see section 5 "Temp Bounds")

On upshift/downshift the cycle will reset and repeat. Additionally the two arrows will light up accordingly.

<sup>\["Step size" is not implemented yet\]</sup>
### Section 5 - "Temp Bounds"
Once the Cycle hits the target time it will look at values in the "Temp Bounds" section. If the current cpu temperature (the one shown in the center) is above the one specified in "Max Temp @" it will try to downshift. If the cpu temp is below "Min Temp @" it will try to upshift.

What does upshift downshift mean and why "try"?
- upshift means it will raise the maximum allowed cpu frequency (this currently happens in 5% steps)
- downshift means it will lower the minimum allowed cpu frequency (also happens in 5% steps)
- and it will "try" to do this, because it may be prevented by values specified in section 2 "P% Limiter" and 3 "Current CPU Setting" (see section 2,3)

<sup>\[The up/down buttons are not implemented\]</sup>
### Section 2 - "P% Limiter"
- "Max p%" lets you specify the maximum allowed cpu frequency
- "Min p%" lets you specify the minimum allowed cpu frequency

On an upshift/downshift attempt it will prevent the operation if the new CPU frequency values would be above or below the limits.

This is useful if your laptop gets loud or hot at above 90% CPU frequency, this way you can put a limit to it. And the Min p% is useful to stop the program from downshifting your cpu into a OS freeze. 10% is the lowest you can set. If you need or want to go lower you have to modify it in the code.

<sup>\[The up/down buttons are not implemented\]</sup>
### Section 3 - "Current CPU Setting"
Shows the current settings for the cpu.
- "Upper p%" the upper frequency bound
- "Lower p%" the lower frequency bound

The CPU will change dynamically its frequency in between this bounds.  You can this way modify your range. Program currently always starts with lower=45% and upper=50% and has this 5% range. The range doesn't change after enabling the Cycle.

Note: I don't use it that much myself. It is not fully implemented, might behave unexpectedly. 

Also note: you are prevented from modifying these values after starting the Cycle. The code would be unnecessarily complicated and for the added complexity unconvienient to use.

<sup>\["Carry Lower" is not implemented\]
\[The up/down buttons are not implemented\]</sup>
## other
### Section 4 - "Current CPU"
This shows the current CPU frequency and current load infomration
### Section 8 - Apply and Labels below
After modifying any values you can press "X" and discard the changes made or press "Apply" and well apply them. If there are any *strange* or unlogical inputs it will discard your changes.

"Current WPP:" is not implemented in the version 2.0.0-alpha (WPP stands for Windows Power Plan)
"Last update:" tells you the last time the power plan was modified
### Section 9 - Graphical Visualization
The visualization of the stuff happening.
- the red dotted line is the CPU temperature
- the dark red lines are the boundaries ("Max Temp" & "Min Temp"). The red area in between marks the temperature where no shift will take place
- the chess pattern is kinda there. No meaning, just some early on debug thing which evolved into a design 😂
- the two labels on the left: current temperature and current CPU load
- the white vertical bars are the CPU load
- the white horizontal stripe marks the upper and lower CPU frequency percent range

<sup>\[The checkboxes are not implemented\]</sup>
