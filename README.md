Mini-Project
Harry Potter – But Worse
Project Name: Harry Potter – But Worse
Name: Mathias Sejr Frandsen
Student Number: 20234722
Link to video of game: https://youtu.be/cCrQkFeJdgA 

This mini game is inspired by the Harry Potter universe and is a “but worse” version of the game “Hogwarts Legacy ”. It is only a very short experience of fighting a troll and defeating by casting spells from your wand. As there is only one troll, the fighting ends rather quickly. If more time were at hand the spell would contain a nice shader, and there would be more trolls to fight. The Spells are cast by clicking the left mouse button! Which should have been explained in the game. 
The mini game utilizes to some degree nine out of the eleven given components for the project. The Player is controlled by Unity`s Input System and the players camera is controlled by the mouse. During the game the player can interact with the Troll which can be shot by casting a spell towards it. The interaction with the troll contains: 
-	Ray-cast for shooting and hurting the troll
-	Animation for moving the wand and casting the spell
-	Lightning which was made with unity`s particle System
The world is built with Unity’s terrain Tools with the default materials and assets which was used for the ground, grass and rocks. The Troll is borrowed from Sketchfab.com and contains animations for walking, attacking, idle, taking damage and death. The only animation that gave some trouble during the development of the game was the “walk” animation which did not work very well with the Patroling method in TrollMovement.cs. and therefore, not included in the game.

 
Project parts:
The hierarchy contains the following:
-	Environment
o	Terrain (Unity`s terrain tools)
o	Rain (Particle System)
o	Rocks (Unity`s terrain tools)
o	Signs (3D object)
o	NavMesh (NavMeshSurface)

-	Player (Playermovement.cs + WandAnimation.cs)
o	POV (Player Camera)
	PlayerLook.cs
o	Capsule
o	Wand (3D Object)
o	Lightning (Particle System)

-	Troll 
o	NavMeshAgent
o	TrollMovement.cs
o	EnemyHealth.cs
The project also contains 
Time schedule
Part of Game	Time Spent (Hours)
Terrain Building	1
Player: Movement + Camera	2
Wand + Animation	3
Navmesh +  NavMeshAgent 	3
Troll Animations	3
Total:	12

 
Refences
-	NavmeshAgent Tutorial on youtube
o	https://www.youtube.com/watch?v=UjkSFoLxesw 
-	First Person Movement Tutorial
o	https://www.youtube.com/watch?v=5Rq8A4H6Nzw&t=376s 
-	3D Game Assets
o	Troll (CC licensed)
	https://sketchfab.com/3d-models/troll-bceb1cb47186457c8571a23e6aff1b8e 
o	Signs (CC licensed)
	https://www.fab.com/listings/cdf20b18-8038-4f97-93d3-50dea4990a4e 
