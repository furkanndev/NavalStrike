# Naval Strike

[![C#](https://img.shields.io/badge/Language-C%23-239120?style=flat-square&logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/Platform-.NET%20Framework-512BD4?style=flat-square&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Architecture](https://img.shields.io/badge/Architecture-Clean%20Layered%20%2F%20OOP-blue?style=flat-square)](https://en.wikipedia.org/wiki/Object-oriented_programming)
[![UI](https://img.shields.io/badge/UI-Windows%20Forms-0078D7?style=flat-square)](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
[![License: GPL 3.0](https://img.shields.io/badge/License-GPL%203.0-blue?style=flat-square)](LICENSE)

A desktop naval arcade game developed in C# demonstrating object-oriented design principles, clean separation of concerns, and real-time event-driven entity simulations.

---

## Architectural Design

The project is structured into two decoupled assemblies following clean layered architecture:

```
naval-strike/
├── Savas.sln
├── Savas.Library/              # Domain & Game Logic Engine
│   ├── Interface/              # Game contracts (IHareketEden, IOyun, etc.)
│   ├── Abstract/               # Base entity abstractions (Cisim, Arac)
│   ├── Concrete/               # Concrete implementations (Gemi, Denizalti, Fuze)
│   └── Enum/                   # Direction, game state, weapon types
└── Savas.Desktop/              # Presentation Layer (Windows Forms)
    ├── AnaForm.cs              # Main game viewport & rendering loop
    ├── GirisForm.cs            # Pre-game session configuration
    └── SkorForm.cs             # Top score leaderboards & file persistence
```

### Key Object-Oriented Principles Applied
- **Interface Segregation:** Movable, damaging, and scoreable entities adhere to strict lightweight contracts.
- **Polymorphism:** Shared base classes (`Cisim`, `Arac`) handle spatial velocity, boundary clipping, and bounding-box collision detection.
- **Event-Driven Architecture:** Decoupled game timers trigger state transitions without blocking UI message pumps.

---

## Game Mechanics & Features

- **Dynamic Entity Spawning:** Enemy submarines spawn from screen boundaries with dynamic velocity curves scaling by difficulty.
- **Dual Ammunition Arsenal:** Multiple weapon archetypes with unique ballistic velocities and trajectory calculations.
- **Mystery Cache Drops:** Random interval drops (10s cadence) introducing probabilistic score boosts or tactical penalties.
- **High Score Persistence:** File-backed persistent leaderboards recording and updating top five player performances.
- **Game State Controls:** Comprehensive menu configuration, difficulty selection, countdown timers, and pause (`P`) toggling.

---

## Controls

| Key | Action |
| :--- | :--- |
| `Left Arrow` / `Right Arrow` | Move naval vessel |
| `Space` | Fire primary ammunition |
| `P` | Pause / Resume active session |
| `Enter` | Confirm / Start from menu |

---

## Getting Started

### Prerequisites
- Windows OS (Windows 10 / 11)
- [.NET Framework 4.7.2+](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with the *.NET Desktop Development* workload.

### Build & Run

```bash
# Clone the repository
git clone https://github.com/furkanndev/NavalStrike.git
cd NavalStrike/naval-strike

# Open solution in Visual Studio or build with MSBuild
msbuild Savas.sln /p:Configuration=Release
```

*Alternatively, double-click `naval-strike/Savas.sln` to open directly in Visual Studio and press `F5`.*

---

## License

This project is licensed under the [GNU General Public License v3.0](LICENSE).
