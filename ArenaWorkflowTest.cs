using UnityEngine;

/// <summary>
/// Small end-to-end workflow test for the Arena.ai coding agent.
///
/// Behaviour:
/// - Keeps an integer score that starts at zero.
/// - Adds one point every time the player presses the Space key.
/// - Prints every score change to the Unity Console via <see cref="Debug.Log(object)"/>.
///
/// Notes:
/// - Targets Unity 6 (6000.x) using only built-in engine APIs.
/// - Uses the legacy Input Manager (<see cref="Input.GetKeyDown(KeyCode)"/>), which ships
///   with the Editor, so no external package is required. The project's
///   "Active Input Handling" setting must allow the old Input Manager
///   ("Input Manager (Old)" or "Both").
/// </summary>
public class ArenaWorkflowTest : MonoBehaviour
{
    /// <summary>Log prefix so this script's messages are easy to find in the Console.</summary>
    private const string LogTag = "[ArenaWorkflowTest]";

    /// <summary>Current score. Starts at zero and increases by one per Space key press.</summary>
    private int score = 0;

    /// <summary>Read-only access to the current score (handy for unit tests or UI binding).</summary>
    public int Score => score;

    /// <summary>
    /// Unity lifecycle: called once when the component is created, before <see cref="Start"/>.
    /// Used here to guarantee the score always begins at zero.
    /// </summary>
    private void Awake()
    {
        score = 0;
        Debug.Log($"{LogTag} Awake - score initialised to {score}.", this);
    }

    /// <summary>
    /// Unity lifecycle: called once on the frame after the component is enabled.
    /// Used here to tell the player how to interact with the test.
    /// </summary>
    private void Start()
    {
        Debug.Log($"{LogTag} Start - press the Space key to add 1 point.", this);
    }

    /// <summary>
    /// Unity lifecycle: called once per frame.
    /// Increments the score on each Space key press and logs the new value.
    /// </summary>
    private void Update()
    {
        // GetKeyDown fires exactly once per physical key press (not every frame the key is held).
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score++;
            Debug.Log($"{LogTag} Space pressed - score: {score}", this);
        }
    }

    /// <summary>
    /// Unity lifecycle: called when the component is destroyed (or Play Mode stops).
    /// Used here to report the final score.
    /// </summary>
    private void OnDestroy()
    {
        Debug.Log($"{LogTag} OnDestroy - final score: {score}.", this);
    }
}
