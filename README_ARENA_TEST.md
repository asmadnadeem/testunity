# Arena Workflow Test — `ArenaWorkflowTest.cs`

A tiny Unity 6 (6000.x) MonoBehaviour used to verify the Arena.ai coding workflow
end to end: branch → edit → commit → push → pull request.

The script keeps an integer score that starts at `0` and adds `1` every time the
player presses the **Space** key, logging each change with `Debug.Log`.

---

## Requirements

- Unity 6 (6000.x) Editor — any template (2D, 3D, URP, HDRP) works.
- No external packages or assets. The script uses only built-in engine APIs.
- The project's **Active Input Handling** must allow the legacy Input Manager
  (see step 3 below).

---

## Add the script to a GameObject

1. **Copy the file into the project.**
   Put `ArenaWorkflowTest.cs` anywhere inside the `Assets/` folder, for example
   `Assets/Scripts/ArenaWorkflowTest.cs`.
   > The file name must match the class name (`ArenaWorkflowTest`) — Unity
   > requires this for every `MonoBehaviour`.

2. **Let Unity compile it.**
   Switch back to the Unity Editor window. It imports the file automatically and
   compiles it. Check the Console window (Window ▸ General ▸ Console) — it should
   report no errors.

3. **Check the input backend (only needed once per project).**
   Go to *Edit ▸ Project Settings ▸ Player ▸ Other Settings ▸ Active Input Handling*
   and select **Input Manager (Old)** or **Both**.
   - Unity 6 templates sometimes default to **Input System Package (New)**, and
     with that setting the built-in `Input` class throws an
     `InvalidOperationException` at runtime.
   - Choosing **Both** keeps the new Input System available while allowing this
     script's `Input.GetKeyDown` call to work.

4. **Create a GameObject and attach the component.**
   - *Hierarchy* window ▸ right-click ▸ **Create Empty** (name it e.g. `ScoreTest`), **or**
   - *GameObject* menu ▸ **Create Empty**.
   Then either:
   - drag `ArenaWorkflowTest.cs` from the Project window onto the new GameObject
     in the Hierarchy, **or**
   - select the GameObject and use *Inspector ▸ Add Component ▸* type
     `ArenaWorkflowTest`.

5. **Save the scene** (*File ▸ Save*, or `Ctrl + S` / `Cmd + S`).

---

## Test it in Play Mode

1. Press the **Play** button (▶) at the top of the Editor (or `Ctrl + P` / `Cmd + P`).
2. Look at the Console: the script logs
   `[ArenaWorkflowTest] Awake - score initialised to 0.` and
   `[ArenaWorkflowTest] Start - press the Space key to add 1 point.`
3. Click inside the **Game** view once so it receives keyboard focus, then press
   **Space**.
4. Each press should produce exactly one new log line:
   `[ArenaWorkflowTest] Space pressed - score: 1`, then `score: 2`, and so on.
   Holding Space down does **not** keep incrementing — `Input.GetKeyDown` fires
   once per physical press.
5. Press **Play** again to stop. The Console logs
   `[ArenaWorkflowTest] OnDestroy - final score: N.`

**Expected result:** the score increases by exactly 1 for every distinct Space
key press, and every change appears in the Console.

### Troubleshooting

| Symptom | Cause / fix |
| --- | --- |
| `InvalidOperationException: You are trying to read Input using the UnityEngine.Input class, but you have switched active Input handling to Input System package` | Set *Active Input Handling* to **Input Manager (Old)** or **Both** (step 3). |
| Nothing is logged when pressing Space | Click the Game view first so it has keyboard focus. |
| Console says the class name and file name differ | Rename the file to `ArenaWorkflowTest.cs`. |
| No log lines at all | Confirm the component is attached to a GameObject in the open scene and that the GameObject is active. |

---

## Verification status

No Unity Editor, .NET SDK, or C# compiler (Mono/`mcs`/`csc`) is available in the
Arena sandbox, so this script has **not been compiled or run in Unity**. Only
static checks were performed (balanced braces/parentheses, file name matching the
class name, no deprecated API usage, no external packages). Please run the Play
Mode test above in a Unity 6 project to confirm runtime behaviour.

---

## Files added by this test

| File | Purpose |
| --- | --- |
| `ArenaWorkflowTest.cs` | The MonoBehaviour under test. |
| `README_ARENA_TEST.md` | This guide. |

No existing files were modified or deleted. `README.md` is unchanged.
