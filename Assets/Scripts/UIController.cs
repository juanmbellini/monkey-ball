using TMPro;
using UnityEngine;

/// <summary>
/// Controller class for the UI.
/// </summary>
public class UIController : MonoBehaviour {
    /// <summary>
    /// Textfield for time.
    /// </summary>
    [SerializeField] private TextMeshProUGUI _timeText;

    /// <summary>
    /// Textfield for score.
    /// </summary>
    [SerializeField] private TextMeshProUGUI _scoreText;

    /// <summary>
    /// Textfield for lives.
    /// </summary>
    [SerializeField] private TextMeshProUGUI _livesText;

    /// <summary>
    /// A reference to the game controller, in order to notify out of time.
    /// </summary>
    private GameController _gameController;

    // Use this for initialization
    private void Start() {
        _gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    private void Update() {
        UpdateUI();
    }

    /// <summary>
    /// Updates the UI.
    /// </summary>
    private void UpdateUI() {
        _timeText.SetText("Time\n" + (int) _gameController.GetTimeRemaining());
        _scoreText.SetText("Score\n" + _gameController.GetScore());
        _livesText.SetText("Lives " + _gameController.GetLives());
    }
}