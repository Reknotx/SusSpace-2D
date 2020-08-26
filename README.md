# SusSpace-2D

SusSpace is a 2D puzzle game where the goal is to use the space junk around your vessel to move around and repair the
broken pieces of your ship in order to make it to your destination. The various space junk you have in reach all have their own
individual strengths in regards to how far they move you, and there are even buff and debuff items that will help and hinder
your progression. The software architecture is designed with Model-View-Controller in mind to keep data, logic, and collision
detection within the scripts organized and code pathways clean and clear.

The game uses the mouse position to aim the player's desired direction of movement and then linearly interpolates the player
from starting point to end point, using an ease out function to make the movement end off more smoothly rather than abruptly.
The objective points for the levels are big red boxes due to a lack of proper art available at the time. 

Individual info for the usable items such as the distance they move the player and the number of uses they have are stored within 
scriptable objects to decouple the code and make it easier for the other members of the team to know what's going on without having
to understand the code.
