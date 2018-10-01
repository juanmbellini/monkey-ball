using UnityEngine;

/// <summary>
/// Class in charge of managing the player's scores and lives.
/// </summary>
public class ScoreManager : MonoBehaviour {
    /// <summary>
    /// The actual score.
    /// </summary>
    [SerializeField] private int _score;

    /// <summary>
    /// The actual amount of lives remiaing the player has.
    /// </summary>
    private int _lives;


    void Start() {
        _score = 0; // Start with no score
        _lives = 3; // TODO: magic number
    }

    /// <summary>
    /// Adds score.
    /// </summary>
    /// <param name="score">The amount of score units to be added.</param>
    public void AddScore(int score) {
        _score += score;
    }

    /// <summary>
    /// Makes the player lose one life (i.e it decrements by one the life value).
    /// </summary>
    public void LoseLife() {
        _lives--;
    }
}
