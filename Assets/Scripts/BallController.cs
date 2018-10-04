using UnityEngine;

/// <summary>
/// Behaviour for the ball (i.e the "player").
/// </summary>
public class BallController : MonoBehaviour {
    /// <summary>
    /// Holds an instance to the game controller.
    /// </summary>
    private GameController _gameController;

    /// <summary>
    /// Min. y value the transform associated to this mono behaviour can have.
    /// </summary>
    private float _loseHeight;

    /// <summary>
    /// The initial position of the ball (i.e the position in which the ball is started).
    /// </summary>
    private Vector3 _initialPosition;


    /// <summary>
    /// Flag indicating whether the playes is alive or dead.
    /// </summary>
    private bool _isAlive;

    // Use this for initialization
    private void Start() {
        _gameController = FindObjectOfType<GameController>();
        _loseHeight = _gameController.GetLosingHeight();
        _initialPosition = transform.position;
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
        // If already died, then do nothing.
        if (!_isAlive) {
            return;
        }
        // If above losing height, then do nothing
        if (transform.position.y >= _loseHeight) {
            return;
        }
        // At this point we know that the player has died.
        _isAlive = false; // Set the alive flag to false
        _gameController.Lose(); // Notify the game controller that the ball has fallen.
    }

    /// <summary>
    /// Makes the ball reborn (i.e restart when it died).
    /// </summary>
    public void Reborn() {
        if (_isAlive) {
            return; // Do nothing if not dead.
        }
        // Position ball in the initial position
        transform.position = _initialPosition;
        // Remove inertia from the object
        var rigidBody = gameObject.GetComponent<Rigidbody>();
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.velocity = Vector3.zero;
        _isAlive = true;
    }
}