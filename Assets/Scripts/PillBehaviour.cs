using UnityEngine;

/// <summary>
/// Behaviour for pills.
/// </summary>
public class PillBehaviour : MonoBehaviour {
    /// <summary>
    /// Holds an instance to the game controller.
    /// </summary>
    private GameController _gameController;

    /// <summary>
    /// Flag indicating whether this capsule is being collected right now.
    /// It helps the process of player collision processing, by avoiding several calls to the method
    /// (collision might happen using more than one contact point).
    /// </summary>
    private bool _isBeingCollected;

    // Use this for initialization
    private void Start() {
        _gameController = FindObjectOfType<GameController>();
        _isBeingCollected = false;
    }

    // Update is called once per frame
    private void Update() {
        _isBeingCollected = false;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag.Equals("Player")) {
            ProcessPlayerCollision();
        }
    }

    /// <summary>
    /// Processes a collision with the player (i.e score, remove, etc.)
    /// </summary>
    private void ProcessPlayerCollision() {
        if (_isBeingCollected) {
            return; // Already called this method, so procesing has already started
        }
        _isBeingCollected = true;
        Debug.Log("Score for the player");
        _gameController.Score();
        Destroy(gameObject); // TODO: destroy? or just unspawn?
    }
}