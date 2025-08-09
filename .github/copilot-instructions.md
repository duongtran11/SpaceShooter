# Copilot Instructions for SpaceShooter (Unity 2D)

## Project Overview
- This is a Unity 2D space shooter game. Core gameplay includes player movement, shooting, enemy waves, and object pooling.
- Main logic is in `Assets/Scripts/`. Scenes, prefabs, and assets are under `Assets/`.
- Enemies follow paths defined by `FlyPath` and are spawned in waves via `EnemySpawner` and `EnemyWave`.
- Player movement and shooting is handled in `PlayerController`. Bullets are managed by `Bullet`.
- Health bars use the `HealthBar` component, which wraps a Unity UI Slider.

## Key Components & Data Flow
- **Enemy Spawning:**
  - `EnemySpawner` reads `EnemyWave[]` and instantiates enemies at positions from `FlyPath`.
  - Each enemy gets its path and speed from the wave definition.
- **Enemy Movement:**
  - `EnemyController` moves enemies along waypoints from `FlyPath`.
  - Index bounds must be checked before accessing waypoints to avoid exceptions.
- **Object Pooling:**
  - `ObjectPooling<T>` (WIP) is intended for pooling reusable objects (e.g., bullets, enemies).
- **Player:**
  - `PlayerController` uses mouse position for movement and fires bullets from multiple gun positions.
- **Background:**
  - `MovingBackground` scrolls backgrounds and repositions them for infinite scrolling.

## Patterns & Conventions
- **MonoBehaviour Usage:** All gameplay scripts inherit from MonoBehaviour and are attached to GameObjects.
- **Serialized Fields:** Use `[SerializeField]` for private fields that need to be set in the Unity Editor.
- **Component Access:** Use `GetComponent`/`GetComponentInChildren` for runtime component references.
- **Prefab Instantiation:** Use `Instantiate` for spawning objects; set up references immediately after instantiation.
- **Path Navigation:** Always check array bounds before accessing waypoints in movement scripts.
- **Pooling:** Pooling is not yet fully implemented; see `ObjectPooling.cs` for the intended pattern.

## Build, Test, Debug
- **Build:** Use Unity Editor's build menu. No custom build scripts detected.
- **Play/Test:** Use Unity Editor Play mode. No automated test scripts found, but `com.unity.test-framework` is included in packages.
- **Debug:** Use Unity's Inspector, Console, and Gizmos (see `OnDrawGizmos` in path scripts).

## External Dependencies
- Unity packages managed in `Packages/manifest.json` (e.g., Input System, Universal Render Pipeline, Visual Scripting).
- No custom package management or external service integration detected.

## Examples
- **Enemy Path Access:**
  ```csharp
  if (_nextPathIndex < FlyPath.Waypoints.Length) {
      var target = FlyPath[_nextPathIndex];
      // ...
  }
  ```
- **Prefab Instantiation:**
  ```csharp
  var enemyGO = Instantiate(wave.EnemyPrefab, startPos, Quaternion.identity);
  var enemy = enemyGO.GetComponentInChildren<EnemyController>();
  enemy.FlyPath = wave.FlyPath;
  ```

## Key Files
- `Assets/Scripts/EnemySpawner.cs`, `Assets/Scripts/EnemyWave.cs`, `Assets/Scripts/Enemy/EnemyController.cs`, `Assets/Scripts/FlyPath.cs`, `Assets/Scripts/ObjectPooling.cs`, `Assets/Scripts/PlayerController.cs`, `Assets/Scripts/Bullet.cs`, `Assets/Scripts/HealthBar.cs`, `Assets/Scripts/MovingBackground.cs`

---

If any section is unclear or missing important project-specific details, please provide feedback or point to relevant files for deeper analysis.
