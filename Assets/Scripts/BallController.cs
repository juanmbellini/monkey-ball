using UnityEngine;

/// <summary>
/// Behaviour for the ball (i.e the "player").
/// </summary>
public class BallController : MonoBehaviour {
    /// <summary>
    /// Flag indicating whether the playes is alive or dead.
    /// </summary>
    private bool _isAlive;

    // Use this for initialization
    private void Start() {
        _isAlive = true;
    }

    // Update is called once per frame
    private void Update() {
        CheckLose();
    }

    /// <summary>
    /// Checks whether the player has lost (i.e has fallen).
    /// </summary>
    private void CheckLose() {
        // TODO: remove magic number. Maybe when it touches a plane?
        if (_isAlive && transform.position.y < -10.0f) {
            Debug.Log("You lose");
            _isAlive = false;
        }
    }
}