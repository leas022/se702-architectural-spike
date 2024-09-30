# SE702: Implementation

This repository covers the unity implementation for our SE702 study, showcasing environmental interactions with two primary scenes: **Air** and **Water**. The focus is on testing interactions within different environments, designed to simulate specific physical properties and measuring user's reaction time and feelings of embodiment across the two secenes. The user study protocol pertaining to this implementation can be found [here](https://docs.google.com/document/d/1mpcQkzV3XXXwH2mWLcpXabVgCbIsed2JqPSplnRSHes/edit?usp=sharing).

## Setting Up and Running the Project

### Installation

Follow these steps to get the project up and running:

1. **Get the [Unity Student Plan](https://unity.com/products/unity-student)**  
   Access Unity's student plan for free by following the link and signing up.

2. **Install Unity Hub**  
   Download and install Unity Hub from [here](https://unity.com/download) if you don't have it already

3. **Install Unity Editor v2020.3.48**  
   - Find version **2020.3.48** on the Unity Hub 'Installs' tab or install it from the web [here](https://unity.com/releases/editor/whats-new/2020.3.48]())
   - Make sure to install the appropriate modules based on your operating system (Mac, Windows etc).

### Running the Project

_Insert Runtime Information Here..._

<!-- 

4. **Open the Project in Unity Hub**  
   - Clone the project to your local machine.
   - Open Unity Hub and select `Add`.
   - Find the project root folder on your disk and select it. Unity Hub will recognize and load it into the project list.

5. **Opening a Scene in the Unity Editor**  
   - Once the project is loaded in Unity Hub, click `Open` to launch the Unity Editor with this project.
   - To open a scene:
     1. In the Unity Editor, go to the top menu and select `File > Open Scene`.
     2. Navigate to the `Scenes` sub-folder.
     3. Select either the **Air** scene or the **Water** scene, depending on which environment the user has been assigned to experience first.

    Both scenes simulate distinct environmental physics and are part of the Implementation.

-->

![Project Screenshot](image/README/1723948782421.png)
_Figure 1: Demonstration of the 'Water' Scene Environment_

## Project Structure

- **Assets**: Contains all game objects, scripts, and resources.

<!-- 
- **Scenes**: Houses the two primary scenes: `Grass` and `Water`.
- **Scripts**: Contains the core logic for interacting with the environments.
- **Prefabs**: Pre-configured game objects that can be reused across scenes. 

-->

## Scenes

- **Air Scene**: Simulates a normal walking environment, with no restrictions on movement speed or acceleration.
- **Water Scene**: Simulates a waterlogged environment, with disctinct visual and reduced movement speed.
