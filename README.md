# Pacman AI Pathfinding

The Pacman AI Pathfinding project is designed to use Artificial Intelligence (AI) to find the shortest path in a 2D Pacman game, evaluate user performance, and manage various game mechanics. The project includes features like multiple levels, score tracking, and sound management.

> The game offers a unique twist on the classic Pacman game. Instead of controlling Pacman, players take on the role of a ghost, aiming to eat all Pacmen on the map. The goal is to find and follow the shortest path to capture all Pacmen, providing a fresh and challenging gameplay experience. The shorter the path you find, the higher your score.

## Screenshots

Here's a glimpse of the game:
![picture1](https://github.com/beyzayildizli/Unity_RobotMaze/assets/77398074/8a18c0ce-83b4-459a-9e8e-47b6d2afac19)
![picture2](https://github.com/beyzayildizli/Unity_RobotMaze/assets/77398074/be9bba6b-353d-4ae0-811a-4e58af4295f0)
![picture3](https://github.com/beyzayildizli/Unity_RobotMaze/assets/77398074/b32d3f7b-6c1c-4e8f-9563-77542b765192)
![picture4](https://github.com/beyzayildizli/Unity_RobotMaze/assets/77398074/d79f6e19-1bd0-4d87-9c00-9a415a4d327e)


## Features

### 1. Map Management
- **Script:** `MapLists.cs`
- Maps are defined as 2D string arrays with the following symbols:  
  - `1`: Walls  
  - ` ` (Space): Walkable paths  
  - `0`: Collectible items (pac-mans)
  - `X`: Player (ghost)  
- New levels can be easily added by editing the map definitions in this script.

### 2. Shortest Path Algorithm
- **Script:** `MinPathBetweenTwoLoc.cs`
- Implements the Breadth-First Search (BFS) algorithm to calculate the shortest path between two points.
- Avoids obstacles and determines the most efficient route.
- Assists the player in planning their moves strategically.

- **Script:** `CalculateBestWay.cs`
- This script calculates the shortest path for the character to collect  all point items on the map using a BFS-based approach.
- It generates a tree structure  to explore possible paths and selects the optimal route with minimal steps.

### 4. Score Tracking
- **Script:** `ScoreLists.cs`
- Evaluates user performance based on:
  - Collected items
  - Minimum and total steps
  - Overall score
- Provides real-time feedback to the user.

### 5. Sound Management
- **Script:** `GameSounds.cs`
- Manages game music and sound effects:
  - Start and end music
  - Item collection sound effects
  - Ghost movement sounds
  - Button click sounds

## Technologies Used
- **Unity Engine:** 2D game development engine  
- **C#:** Programming of game mechanics and algorithms  
- **TextMeshPro:** Advanced UI text support  


## Installation and Setup
1. **Download or Clone the Project:**
   - Obtain the project from GitHub.

2. **Open with Unity:**
   - Launch Unity Editor.
   - Use the "Open Project" option to load the project.

3. **Edit Maps (Optional):**
   - Modify `MapLists.cs` to add new levels.

4. **Run the Game:**
   - Press the **Play** button in Unity Editor to start the game.


## Gameplay Mechanics
- The player controls the ghost (`X`) on the map.
- Collects all items (`0`) to complete the level.
- Avoids walls (`1`) and tries to find the shortest path.
- User performance is evaluated with a score system.


## Contribution
To contribute to the project:  
1. Fork the repository.  
2. Make your changes.  
3. Submit a **Pull Request** to share your updates.


## Credits

This project was developed by Beyza Yıldızlı. You can find me on [LinkedIn](https://www.linkedin.com/in/beyzayildizli/) or [GitHub](https://github.com/beyzayildizli).

