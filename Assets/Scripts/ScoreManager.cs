using UnityEngine;

/// <summary>
/// Class in charge of managing the player's scores and lives.
/// </summary>
public class ScoreManager : MonoBehaviour {
    /// <summary>
    /// The actual score.
    /// </summary>
    [SerializeField] private int _score;


    private void Start() {
        _score = 0; // Start with no score
    }

    /// <summary>
    /// Adds score.
    /// </summary>
    /// <param name="score">The amount of score units to be added.</param>
    public void AddScore(int score) {
        _score += score;
    }
}
