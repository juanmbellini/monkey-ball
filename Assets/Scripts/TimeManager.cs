using UnityEngine;

/// <summary>
/// Behaviour for the level timer.
/// </summary>
public class TimeManager : MonoBehaviour {
    /// <summary>
    /// A reference to the game controller, in order to notify out of time.
    /// </summary>
    private GameController _gameController;

    /// <summary>
    /// Initial time (in seconds).
    /// </summary>
    [SerializeField] private float _startingTime = 60f;

    /// <summary>
    /// Time remaining.
    /// </summary>
    [SerializeField] private float _timeRemaining;

    /// <summary>
    /// Flag indicating whether the time is on or off.
    /// </summary>
    private bool _enabled;

    private void Start() {
        _gameController = FindObjectOfType<GameController>();
        _timeRemaining = _startingTime;
        _enabled = true;
    }

    private void FixedUpdate() {
        if (!_enabled) {
            return; // Do not update timer if it is not enabled
        }
        _timeRemaining -= Time.deltaTime;
        if (_timeRemaining <= 0) {
            // If there is no time remaining, then notify the game controller about this event.
            _gameController.NoMoreTime();
        }
    }

    /// <summary>
    /// Stops the timer.
    /// </summary>
    public void StopTimer() {
        _enabled = false;
    }

    /// <summary>
    /// Resumes the timer.
    /// </summary>
    public void ResumeTimer() {
        _enabled = true;
    }
}