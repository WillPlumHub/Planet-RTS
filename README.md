# Planet RTS

A 3D real-time strategy game set on a fully navigable, rotatable planet, designed to emphasize macro-level strategic decisions and arcade-style skill expression over traditional micromanagement and min-maxing. Built in Unity with a custom spherical coordinate system, the game reimagines RTS mechanics on a seamless globe, encouraging dynamic spatial control and large-scale tactical play.


# Core Systems:

Spherical World Navigation:
The game world is rendered as a sequence of fully rotatable planets with seamless movement across their entire surface. Camera movement, unit navigation, and UI overlays are designed to account for curvature and continuous surface traversal, avoiding traditional map edges or wrapping artifacts.

Planetary Coordinate & Movement System:
World positions are calculated using spherical coordinates to ensure consistent movement and placement regardless of latitude or longitude. This allows for features like global fog-of-war, long-range artillery, or orbital unit paths to function naturally in a 3D space.

Simplified Control for Macro Decisions:
Gameplay is designed to reduce traditional micromanagement, encouraging players to make high-level strategic choices and execute skillful maneuvers within an arcade-like control framework.


# Design & Programming Goals:

Innovating RTS on a Spherical Map:
Reimagining RTS core loops—resource management, combat, and visibility—within a planet’s curved surface to create fresh tactical possibilities and spatial challenges.

Systems-First Design Approach:
Rather than starting with units or factions, development has focused on creating scalable infrastructure: world logic, UI integration, and camera systems that can support a variety of gameplay styles (e.g., large-scale war, colonization, or asymmetrical stealth).

Clean, Modular Architecture:
Emphasis on decoupled systems and testable code. Unit movement, rendering, and input are separated to allow for experimentation with alternate control schemes or AI strategies.

Macro Strategy & Skill-Driven Play:
Prioritize broad strategic decisions like planetary control, timing, and positioning, with skill expression through real-time decision making rather than micro-optimization.

Arcade Structure for Planet Conquests:
Planets are conquered one by one through fast, skill-based battles that thread together in an arcade-style campaign. Players collect conquered planets into a mega-planet, creating a layered strategic progression.

Endgame: Mega-Planet and Solar Sacrifice:
Once players unify multiple planets into a mega-planet, the final objective is to send this colossal sphere into the nearest sun to secure victory points, adding a climactic strategic layer to the gameplay loop.



# Technologies & Architecture:
Unity (C#): Core engine used for 3D rendering, input, and system management;
Spherical Navigation Logic: Custom math for movement, orientation, and targeting;
Modular Component Design: Independent systems for pathfinding, fog of war, building logic.


# Current Status & Future Plans:
Exploring unique unit archetypes designed for 3D space traversal (e.g., tunneling, orbiting);
Prototyping arcade-style conquest progression and mega-planet mechanics;
Developing arcade-style score architecture and distinct 'run' loop
