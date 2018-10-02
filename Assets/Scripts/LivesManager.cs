using UnityEngine;

public class LivesManager : MonoBehaviour {
    /// <summary>
    /// The amount of lives the player has when the game starts.
    /// </summary>
    [SerializeField] private int _startingLives = 3;

    /// <summary>
    /// The actual amount of lives remiaing the player has.
    /// </summary>
    private int _lives;

    // Use this for initialization
    private void Start() {
        _lives = _startingLives; // TODO: magic number
    }

    /// <summary>
    /// Makes the player lose one life (i.e it decrements by one the life value).
    /// </summary>
    public void LoseLife() {
        _lives--;
    }

    /// <summary>
    /// Indicates whether there are no more lives remaining.
    /// </summary>
    /// <returns>true if there are no more lives remaining, or false otherwise.</returns>
    public bool NoMoreLives() {
        return _lives < 0;
    }
}