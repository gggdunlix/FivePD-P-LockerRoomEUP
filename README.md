# FivePD Locker Room EUP Plugin

FivePD Plugin that allows you open the EUP Menu by pressing E at custom locations. Map Blips, markers, location, and text are all custom. 

## Installation:

1. Download the plugin DLL at [releases](https://github.com/gggdunlix/FivePD-P-LockerRoomEUP/releases)
2. Paste it into the `fivepd\plugins` folder
3. open the `fivepd\config\coordinates.json` file:
 ![image](https://user-images.githubusercontent.com/33298379/212459455-ddfa9fb6-6845-44c6-a256-db05cdcefaa8.png)

4. Add the following code after the end of the `jailDropoffs` array:
```
"LockerEUP": {
		"locations": [
			{
				"blip": false,
				"coords": {
					"x": 459.7299,
					"y": -990.9896,
					"z": 29.68961
				},
				"marker": true,
				"tooltip": "Press ~INPUT_CONTEXT~ to change clothes"
			},
			{
				
				"blip": true,
				"marker": true,
				"coords": {
					"x": 455.7299,
					"y": -990.9896,
					"z": 29.68961
				},
				"tooltip": "Press ~INPUT_CONTEXT~ to change clothes"
			}
		]
	}
```
 * Each setting for each location can be modified: 
* * `"blip": true` adds a map blip of a clothes icon. 
* * `coords": {}` define the location of the locker.
* * `"marker": true` adds a blue 3D marker where the location should be.
* * `"tooltip": "text"` displays "text" as a tooltip (top left) when near the locker.



The file shoud look like:
![image](https://user-images.githubusercontent.com/33298379/212459646-36328c1e-346f-4cda-8860-c5d1e6003477.png)
You can add more locations by duplicating individual configs and changing coordinates:
![image](https://user-images.githubusercontent.com/33298379/212459678-2ca593bb-2694-4f0a-a438-a2666635ec8f.png)
