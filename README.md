Mathstation - A Math Based Serious Game

This repository contains the unity project of Mathstation.

Master Thesis by: Jonathan Borowski

##############################################################################

Mathstation includes a math editor system and three game modes that make use of it.
The current state of the game is build ready.

All of the game modes and the math editor's capabilities are expandable.

When introducing new math rules - make sure to add the relevant boolean field in the Policy.cs script, as well as menu elements in the settings page of the main menu. Additionally, new mathematical operations will require implementation in the classes Number.cs and MathOperations.cs. ProblemGenerator will also need to be updated to include the new math rules.

When adding new levels to the games:

In the fight game, new bosses will need to be implemented from scratch. Please make sure to duplicate the existing scenes for essential scripts and UI elements.

In the mine game, a new level can be created by simply modifying the fields Evemts, Occourences of the script Obstacles.cs of the object MineGame, which is in the scene. Using these, you may specify which kind of obstacles can appear, and their planned appearence measured in the percentage of the journey.

Implementing new gadgets and obstacle types will require more asset creation and scripting.

In the explore game, you may freely add prefab objects for the player to interact with in order to construct a new level. The only important setting is the field TargetObjectives in the script Objective.CS of the prefab Player. This int value needs to match the amount of anomalies that the player has to resolve in order to make the goal ring appear. It needs a minimum value of 1.

#############################################################################

For further inquiries, do not hesitate to contact:
borowski@in.tum.de