# 3D Obstacle Course Game

Welcome to the 3D Obstacle Course Game, a Unity-based 3D game where players control a cube navigating through a dynamic obstacle course to reach the finish line. Avoid obstacles, jump over gaps, and race to the end to achieve the highest score!

## Table of Contents
- [Game Overview](#game-overview)
- [Features](#features)
- [Installation](#installation)
- [How to Play](#how-to-play)
- [Scripts Overview](#scripts-overview)
- [Requirements](#requirements)
- [Contributing](#contributing)
- [License](#license)
- [Known Issues](#known-issues)

## Game Overview
In this game, players control a cube that automatically moves forward through a 3D environment. The objective is to reach the cube named "Finish" without colliding with obstacles. The score is calculated based on the player's progress along the Z-axis, displayed in real-time.

## Features
- **Player Movement**: Smooth left and right movement using `A`/`D` or arrow keys, with a jump mechanic activated by the spacebar.
- **Obstacles**: Colliding with objects tagged "Obstacle" stops the player's movement.
- **Scoring System**: Real-time score display based on the distance traveled along the Z-axis.
- **Scene Management**: Automatic scene reload if the player falls below a certain height, and transition to an "EndScene" upon reaching the finish line.
- **Restart Functionality**: A simple scene manager to restart the game from the main menu.

## Installation
1. **Download the Project**:
   - Download the project files from the repository.
2. **Open in Unity**:
   - Open Unity Hub.
   - Click `Add` and select the project folder.
   - Open the project in Unity (recommended version: Unity 2020.3 or later).
3. **Set Up Scenes**:
   - Ensure `GameScene` and `EndScene` are added to the Build Settings.
   - Verify that the `Ground`, `Obstacle`, and `Finish` objects are correctly tagged/named in the scene.
4. **Run the Game**:
   - Press the Play button in Unity to start the game.

## How to Play
- **Objective**: Navigate the player cube to the "Finish" cube without hitting obstacles.
- **Controls**:
  - `A` or `Left Arrow`: Move left.
  - `D` or `Right Arrow`: Move right.
  - `Spacebar`: Jump (only when on the ground).
- **Scoring**: The score is displayed as `Score: [distance]`, calculated as `59 - player.position.z`.
- **Game Over**: If the player falls below `y = -4`, the scene restarts after a 2-second delay.
- **Victory**: Reaching the "Finish" cube loads the "EndScene".

## Scripts Overview
- **PlayerScript.cs**:
  - Controls player movement (forward, sideways, and jumping).
  - Handles collisions with `Ground`, `Obstacle`, and `Finish` objects.
  - Manages scene reloading if the player falls.
- **SceneManage.cs**:
  - Provides a method to transition to the `GameScene` (e.g., from a main menu).
- **ScoreManager.cs**:
  - Updates the score display based on the player's Z-position using TextMeshPro.

## Requirements
- **Unity Version**: 2020.3 or later.
- **Packages**:
  - TextMeshPro (included in Unity by default).
- **Assets**:
  - 3D models for the player, ground, obstacles, and finish line.
  - Scenes: `GameScene` and `EndScene`.
- **System**:
  - Windows, macOS, or Linux with Unity installed.

## Contributing
Contributions are welcome! To contribute:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Make your changes and commit (`git commit -m "Add your feature"`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Open a Pull Request.

Please ensure your code follows the existing style and includes comments for clarity.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Known Issues
- The player may jump multiple times if the `onGround` check is delayed.
- Obstacle collisions permanently disable movement (`forwardForce = 0`, `sideForce = 0`); consider adding a reset mechanism.
- The scoring system assumes a fixed endpoint at `z = 59`, which may need adjustment for different level lengths.
