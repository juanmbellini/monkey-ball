using System.Collections;
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
    /// The score manager.
    /// </summary>
    private ScoreManager _scoreManager;

    /// <summary>
    /// The lives manager.
    /// </summary>
    private LivesManager _livesManager;

    /// <summary>
    /// The time manager.
    /// </summary>
    private TimeManager _timeManager;

    private PillsManager _pillsManager;

    /// <summary>
    /// The ground controller (which provides the ground height, in order to calculate the losing height).
    /// </summary>
    private GroundController _groundController;

    /// <summary>
    /// Ball controller (used to reborn the player).
    /// </summary>
    private BallController _ballController;


    /// <summary>
    /// Relative losing height (must be positive).
    /// Note that, depending on the ground, it might have to be adjusted to avoid being moved to the min. height
    /// due to rotations.
    /// </summary>
    [SerializeField] private float _relativeLoseHeight = 10f;

    private void Awake() {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _livesManager = FindObjectOfType<LivesManager>();
        _timeManager = FindObjectOfType<TimeManager>();
        _pillsManager = FindObjectOfType<PillsManager>();
        _groundController = FindObjectOfType<GroundController>();
        _ballController = FindObjectOfType<BallController>();

        // Load only if not already loaded
        if (_instance == null) {
            _instance = this;
//            DontDestroyOnLoad(_scoreManager);
//            DontDestroyOnLoad(_livesManager);
//            DontDestroyOnLoad(_timeManager);
//            DontDestroyOnLoad(_ballController);
        }
        else {
            Destroy(this);
        }
    }

    /// <summary>
    /// Indicates the min. height the player can be (in order to be considered alive).
    /// </summary>
    /// <returns></returns>
    public float GetLosingHeight() {
        return _groundController.GroundHeight - _relativeLoseHeight;
    }

    /// <summary>
    /// Notifies this game controller that a score was performed.
    /// </summary>
    public void Score() {
        Debug.Log("Player has earned one point.");
        _scoreManager.AddScore(1); // TODO: remove magic number
        // TODO: check if there are more pills to be collected (if no more pills, load win scene).
        if (_pillsManager.PillsRemaining()) {
            return; // Do nothing else if there are pills remaining
        }
        Debug.Log("All pills collected");
        StartCoroutine(Win());
    }

    /// <summary>
    /// Notifies this game controller that the player has lost.
    /// </summary>
    public void Lose() {
        StartCoroutine(Die());
        Debug.Log("Started Die process");
    }

    /// <summary>
    /// Notifies this game controller that there is no more time.
    /// </summary>
    public void NoMoreTime() {
        // TODO: process no more time
        Debug.Log("Player is out of time");
        StartCoroutine(GameOver());
    }

    /// <summary>
    /// The winning process.
    /// </summary>
    /// <returns>IEnumerator for waiting an amount of time</returns>
    private IEnumerator Win() {
        _timeManager.StopTimer();
        yield return new WaitForSeconds(2f); // Wait some time before executiong the die process.
        Debug.Log("Player win");
        // TODO: process win stuff
    }

    /// <summary>
    /// The dying process.
    /// </summary>
    /// <returns>IEnumerator for waiting an amount of time</returns>
    private IEnumerator Die() {
        _timeManager.StopTimer();
        yield return new WaitForSeconds(1f); // Wait some time before executiong the die process.
        Debug.Log("Player has lost one life.");
        _livesManager.LoseLife();
        // TODO: notify UI, then restart if there are lives remaining.
        // TODO: Maybe make camera stop following the player?
        if (_livesManager.NoMoreLives()) {
            Debug.Log("No more lives");
            StartCoroutine(GameOver());
        }
        else {
            _groundController.RestartGround();
            _ballController.Reborn();
            _timeManager.ResumeTimer();
        }
    }

    /// <summary>
    /// The game over process.
    /// </summary>
    /// <returns>IEnumerator for waiting an amount of time</returns>
    private IEnumerator GameOver() {
        _timeManager.StopTimer();
        yield return new WaitForSeconds(2f); // Wait some time before executiong the die process.
        Debug.Log("Game over");
        // TODO: load game over scene? Maybe load UI to restart the scene? or return to level 1?
    }
}