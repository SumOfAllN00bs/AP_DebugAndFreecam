# AP_DebugAndFreecam
Accounting+ Modified Files

## Instructions

1. Install dnSpy from https://github.com/0xd4d/dnSpy/releases
2. Open dnSpy and then click on File -> Open
3. Navigate to your copy of Accounting+ <Steam Install>\steamapps\common\AccountingPlus
4. Then navigate to AccountingPlus_Data\Managed
5. Click on Assembly-CSharp.dll
6. In the assembly explorer, open up the tree like so:
 - Assembly-CSharp (0.0.0.0)
   - Assembly-CSharp.dll
     - NewtonVR
       - NVRHead
7. Click on NVRHead and then in the code view to the right, right click and click on Edit Class (C#)...
8. Ctrl+a, delete all the code
9. Copy in the code from https://github.com/SumOfAllN00bs/AP_DebugAndFreecam/blob/master/NVRHead.cs
10. Click on Compile (if there are errors I can't help here)
11. Click on File -> Save Module... and then OK

## Usage

If everything worked then when you start Accounting+ will have the following bindings:

F2 = Toggle freecam

F3 = Toggle vertical movement

F4 = Step increase freecam speed

F5 = Print to debug trigger meshes found

F6 = Enable all disabled gameobjects

Tilde/Backtick = Debug Console

1 = Add level 0 			(empty)

2 = Add level 1 			(clovis)

3 = Add level 2 			(office)

4 = Add level 3 			(tree)

5 = Add level 4 			(alley)

6 = Add level 5 			(dungeon)

7 = Add level 6 			(stomach)

8 = Add level 7 			(court)

1 + shift = Add level 8 	(Car Chase)

2 + shift = Add level 9 	(Fire)

3 + shift = Add level 10	(Finale)

4 + shift = Add level 11	(Ritual)

5 + shift = Add level 12	(Water Park)

6 + shift = Add level 13	(Biggest Fan)

7 + shift = Add level 14	(Space)

8 + shift = Add level 15	(Nightmare)

H = Unhide all gameobjects

Numpad 1 = (bugged) stomach

Numpad 2 = (bugged) finale

Numpad 3 = (bugged) arg

Numpad 4 = (bugged) office


And by default the code will run so that the thumbstick will control your location forward and backward and will rotate you left and right.

Optional Runtime inspector:

Instructions:
1. Go to: https://github.com/BepInEx/BepInEx/releases
2. Download the x64 version of the latest release (v5.3 now)
3. Extract the contents to the root of Accounting+
     You should have a folder called "BepInEx" in the "AccountingPlus" folder
     And you should see the file "winhttp.dll"
4. Run the game once and you should see the folder "config" and the file "LogOutput.log" appear in the "BepInEx" folder
5. Go to: https://github.com/ManlyMarco/RuntimeUnityEditor/releases
6. Download the latest version that has BepInEx5 in the name
7. Extract the contents and move the BepInEx folder to the "AccountingPlus" folder
8. Click Yes to any overwrite questions (I didn't get any)
9. You should see "RuntimeUnityEditor" folder in "AccountingPlus\BepInEx\plugins"
10. Run the game
11.(a) Now when you click F12 (with the game window in focus) you should see the live inspector appear (and also steam takes a screenshot for me)
11.(b) You can also change the Live Inspector button from F12 to something else by changing the "AccountingPlus\BepInEx\config\RuntimeUnityEditor.cfg" file
