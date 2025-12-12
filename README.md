# Growtopia Casino Game Simulator (Console Version)

A **console-based gambling game** inspired by the Growtopia mini casino games **Reme** and **Leme**. This project is created as a **C# practice project** to learn and apply **Object-Oriented Programming (OOP)** concepts.

---

## Features

- Console-based interactive gameplay.
- Two game modes: **Reme** and **Leme**.
- Randomized spins with digit-based scoring.
- Multipliers applied according to game rules.
- Player and hoster balance management.
- Clear visual feedback using colored console output.

---

## Rules

### Reme

1. Spin the roulette wheel.  
2. Add the digits of the number you land on. Examples:  
   - 13 → 1 + 3 = 4  
   - 19 → 1 + 9 = 10 → treat as 1  
   - 29 → 2 + 9 = 11 → treat as 1  
   - 11 → 1 + 1 = 2  
3. Multipliers for special numbers:  
   - Score 0 (numbers 0, 19, 28) → ×3  
4. Tie → hoster wins.  
5. Winning condition: Your score must **beat the hoster's score**.  

### Leme

1. Same digit-adding rule as Reme.  
2. Multipliers for special numbers:  
   - Score 0 (numbers 0, 19, 28) → ×4  
   - Score 1 (numbers 1, 10, 29) → ×3  
3. Automatic loss for hoster if player lands on score 9 (numbers 9, 18, 27, 36).  
4. Tie → hoster wins.  
5. Winning condition: Your score must **beat the hoster's score**.  

---

## How to Play

1. Run the program in your console.  
2. Enter your starting balance and the hoster's balance.  
3. Choose a game mode:  
   - **1 → Reme**  
   - **2 → Leme**  
4. Enter your bet.  
5. Press any key to spin the roulette wheel.  
6. Results and multipliers are calculated automatically.  
7. Continue playing until either the player or hoster is bankrupt.

---

## Project Structure

- **Program.cs** – main entry point and gameplay loop.  
- **Bank.cs** – manages player and hoster balances.  
- **Roulette.cs** – implements the game logic, spin simulation, score calculation, and battle results.  
- **Utility.cs** – helper functions for input validation and colored console output.

---

## Project Purpose

This project was created to practice:

- **C# classes and objects**  
- **Properties and methods**  
- **Encapsulation and access modifiers**  
- **Console input/output**  
- **Random number generation**  
- **OOP design principles in a mini-game context**

---

## Notes

- This is a **practice project**, **not real gambling**.  
- Inspired by Growtopia’s mini casino games for educational purposes only.  
