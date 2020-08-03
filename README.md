# AP_DebugAndFreecam
Accounting+ Modified Files

## Instructions

1. Install dnSpy from https://github.com/0xd4d/dnSpy/releases
2. Open dnSpy and then click on File -> Open
3. Navigate to your copy of Accounting+ <Steam Install>\steamapps\common\AccountingPlus
4. Then navigate to AccountingPlus_Data\Managed
5. Click on Assembly-CSharp.dll
6. In the assembly explorer, open up the tree like so:
    Assembly-CSharp (0.0.0.0)
    > Assembly-CSharp.dll
      > NewtonVR
        > NVRHead
7. Click on NVRHead and then in the code view to the right, right click and click on Edit Class (C#)...
8. Ctrl+a, delete all the code
9. Copy in the code from https://github.com/SumOfAllN00bs/AP_DebugAndFreecam/blob/master/WIP_NVRHead.cs
10. Click on Compile (if there are errors I can't help here)
11. Click on File -> Save Module... and then OK

## Usage
If everything worked then when you start Accounting+ F1 will bring up a Debug Menu where you can read Debug.Log() messages.
F4 will gradually increase speed until you reach the max of 10 and then it will wrap it around to 0.
F3 will toggle whether or not touchpad will be used for vertical movement.
And by default the code will run so that the thumbstick will control your location forward and backward and will rotate you left and right.
