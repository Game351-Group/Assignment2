# F-Zero: Cross-Country README

## Overview
This project is a submission for GAME 351, focusing on the "Intro to Scripting in C#" assignment. Our team has developed a pseudo-game titled "F-Zero: Cross-Country," a futuristic racing game set in the 22nd century. This game is a reboot of the F-Zero series, featuring all-terrain hovercraft races not confined to roads.

## Features Implemented
We have successfully implemented all the required features outlined in the assignment, along with one choice feature for enhanced gameplay. Below are the details of our implementation:

### Required Features
1. **Driving a Hovercraft:** Implemented as specified, with 'A' and 'D' keys for turning and 'W' and 'S' keys for acceleration and deceleration. The hovercraft movement is smooth and terrain-following, with a follow camera providing a third-person view.
2. **Three Car Types:** We have created three visually distinct hovercraft types with varying speeds and cornering abilities, settable via the Unity inspector.
3. **Hovercraft Levitation:** Our hovercraft levitate above the ground, with a slight quiver when stationary to simulate hover engine activity. This effect was enhanced using the "Spacecraft Engines" sound pack from the Unity Asset Store: [Spacecraft Engines](https://assetstore.unity.com/packages/audio/sound-fx/transportation/spacecraft-engines-196623).
4. **Toggling Between Cars:** Implemented the ability to cycle through hovercraft using the 'C' key, with seamless transitions and maintained follow camera functionality.

### Choice Feature Implemented
- **Laser-Firing Car:** One of our hovercraft can now fire laser bolts each time the player presses the spacebar, adding an exciting combat element to the race. The laser bolts emanate from the front center of the car, moving at a high but visible speed towards the direction the car is facing.
- **More Realistic Effects:** We added realistic engine sounds that vary with speed, and implemented glowing effects on engines and other parts of the hovercraft for a visually immersive experience.

## Additional Information
- **Sound Assets:** Basic hover sound effects were incorporated from the "Spacecraft Engines" pack available on the Unity Asset Store to enhance the levitation feature.

## Installation Procedure
To play "F-Zero: Cross-Country," please follow these steps:
1. Download the project ZIP file and extract it to a location of your choice.
2. Open Unity Hub and import the project by selecting the extracted folder.
3. Once the project is loaded in Unity, navigate to the 'Scenes' folder and open the main game scene.
4. Press the play button in Unity to start the game.

## Controls
- `W`: Accelerate forward
- `S`: Decelerate/Move backward
- `A`: Turn left
- `D`: Turn right
- `C`: Cycle through hovercraft

## Rendering Pipeline
This project utilizes Unity's Standard Rendering Pipeline, optimized for the best balance between performance and visual quality in our game design.

## Known Issues
- No major issues are known at this time. The game has been tested for smooth gameplay and stability.

## Team Members
- Quynn Bell
- Sage Ashur Newton
- Dong Young Yang
- Charis Pace

We hope you enjoy playing "F-Zero: Cross-Country" as much as we enjoyed developing it. For any feedback or issues, please contact us through [contact method].
