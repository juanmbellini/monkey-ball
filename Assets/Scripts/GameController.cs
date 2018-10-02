using UnityEngine;

/// <summary>
/// The game controller.
/// </summary>
public class GameController : MonoBehaviour {
    /// <summary>
    /// A singleton instance of the game controller.
    /// </summary>
    private static GameController _instance;

    /// <summary>
    /// The score manager, which is in charge of saving score stuff.
    /// </summary>
    private ScoreManager _scoreManager;

    private void Awake() {
        _scoreManager = FindObjectOfType<ScoreManager>();

        // Load only if not already loaded
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(_scoreManager);
        }
        else {
            Destroy(this);
        }
    }

    // Use this for initialization
    private void Start() {
    }

    // Update is called once per frame
    private void Update() {
    }

    /// <summary>
    /// Notifies this game controller that a score was performed.
    /// </summary>
    public void Score() {
        _scoreManager.AddScore(1); // TODO: remove magic number
    }

    /// <summary>
    /// Notifies this game controller that the player has lost.
    /// </summary>
    public void Lose() {
        _scoreManager.LoseLife();
    }
}