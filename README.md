# Pacman AI Pathfinding

The Pacman AI Pathfinding project is designed to use Artificial Intelligence (AI) to find the shortest path in a 2D Pacman game, evaluate user performance, and manage various game mechanics. The project includes features like multiple levels, score tracking, and sound management.

> The game offers a unique twist on the classic Pacman game. Instead of controlling Pacman, players take on the role of a ghost, aiming to eat all Pacmen on the map. The goal is to find and follow the shortest path to capture all Pacmen, providing a fresh and challenging gameplay experience. The shorter the path you find, the higher your score.

## Screenshots

Here's a glimpse of the game:
![image](https://github.com/user-attachments/assets/1de439e5-060e-4b35-995d-266bd544a8f6)
<div style="display: flex; justify-content: center;">
  <img src="https://github.com/user-attachments/assets/b77f43db-113e-464a-bf69-5cf1ff3238cb" alt="d1" width="49%">
  <img src="https://github.com/user-attachments/assets/66a3e4b4-b815-4c3d-811b-d5fd3344c422" alt="d2" width="49%">
</div>
<div style="display: flex; justify-content: center;">
  <img src="https://github.com/user-attachments/assets/0ce3eb48-d873-4a07-85d8-95d6680e40ba" alt="d1" width="49%">
  <img src="https://github.com/user-attachments/assets/7b0a97e4-9afa-4183-9f47-03379c80b70d" alt="d2" width="49%">
</div>

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

- **Script:** `CalculateBestWay.cs`
- This script calculates the distance between the pacmans and the ghost and each other with MinPathBetweenTwoLoc.cs, creating a tree structure to explore possible paths and choosing the most suitable route with the least steps.

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

