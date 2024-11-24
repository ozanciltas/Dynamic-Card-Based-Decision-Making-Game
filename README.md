# Dynamic Card-Based Decision-Making Game  

Dynamic Card-Based Decision-Making Game is an interactive Unity project that combines strategic decision-making and dynamic scenario generation. Players swipe cards left or right to make decisions, affecting the game's resources and narrative progression. The project integrates external API data to generate scenarios tailored to player profiles, offering a unique and replayable experience.  

---
## ScreenShots

![Image Sequence_019_0000](https://github.com/user-attachments/assets/7f8cc0a5-ab0d-4bba-aec1-31dcbf2fd3b3)

![Image Sequence_020_0000](https://github.com/user-attachments/assets/098e8818-1758-4f14-8f54-a136f8008d74)

---

## Features  

- **Dynamic Scenario Generation:**  
  Uses an external API to fetch personalized scenarios based on player profiles.  

- **Card Swipe Mechanics:**  
  Players interact with cards by swiping, triggering various in-game effects.  

- **Resource Management:**  
  Game outcomes are influenced by resource changes, creating a balance between strategy and risk.  

- **Responsive UI:**  
  Built with Unity's TextMesh Pro for high-quality, adaptable user interfaces.  

- **Replayability:**  
  Randomized effects and dynamic storylines make every playthrough unique.  

- **Optimized Performance:**  
  Ensures smooth gameplay even with dynamic content updates.  

---

## Tech Stack  

- **Game Engine:** Unity (Version X.X)  
- **Programming Language:** C#  
- **API Integration:** RESTful API with JSON parsing  
- **UI Framework:** Unity UI, TextMesh Pro  
- **Version Control:** Git  
- **Platform:** Cross-platform (Windows, macOS, WebGL)  

---

## Gameplay  

Players make decisions by swiping cards left or right. Each decision affects the game's resources, represented by visual indicators, and progresses the narrative. Players must strategically balance resource consumption to achieve success.  

---

## Core Components  

### APIManager  
Handles API integration for dynamic scenario generation.  
- **Responsibilities:**  
  - Fetch scenarios based on player profiles.  
  - Parse JSON responses into usable game data.  
  - Update the UI with scenario details.  
- **Key Methods:**  
  - `GetScenarioFromAPI`: Fetches and processes scenarios.  
  - `ExtractScenarioResponse`: Parses API responses into usable data.  
- **Technologies:** REST API, JSON parsing  

### CardSwipe  
Manages the card swipe mechanic, which is the core of the gameplay.  
- **Responsibilities:**  
  - Detect swipe direction and apply appropriate effects.  
  - Update resources and initiate new scenarios.  
- **Key Methods:**  
  - `OnBeginDrag`, `OnDrag`, `OnEndDrag`: Handle swipe gestures.  
  - `ApplyEffects`: Updates resource values based on decisions.  

### GameManager  
Controls the overall game flow, including start, restart, and game-over scenarios.  
- **Responsibilities:**  
  - Manage UI transitions between screens.  
  - Monitor resource depletion to determine game-over conditions.  
- **Key Methods:**  
  - `StartGame`: Initializes the game and fetches the first scenario.  
  - `EndGame`: Displays the end screen and resource status.  

### InputManager  
Handles player input using Unity's new Input System.  
- **Responsibilities:**  
  - Detect player interactions (e.g., swipes, clicks).  
  - Pass input data to other game components.  
- **Key Methods:**  
  - `Touch`: Processes touch or click inputs.  

---

## Challenges & Solutions  

- **API Integration:**  
  - **Challenge:** Synchronizing data from the external API with in-game logic.  
  - **Solution:** Developed robust JSON parsing and added error handling for API failures.  

- **Performance Optimization:**  
  - **Challenge:** Maintaining smooth performance with dynamic content updates.  
  - **Solution:** Optimized card rendering and resource indicator updates.  

- **User Feedback:**  
  - **Challenge:** Balancing difficulty and intuitiveness.  
  - **Solution:** Collected feedback from playtesters and iteratively improved UI and mechanics.  

---

## How to Run  

1. Clone the repository:  
   ```bash
   git clone https://github.com/username/project-name.git  

---



