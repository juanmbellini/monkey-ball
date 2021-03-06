﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    /// <summary>
    /// The pills manager.
    /// </summary>
    private PillsManager _pillsManager;

    /// <summary>
    /// The UI Controller (used to notify time's up, game over, and win events).
    /// </summary>
    private UIController _uIController;

    /// <summary>
    /// The camera controller.
    /// </summary>
    private CamaraController _cameraController;


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

    private bool _gameIsFinished;

    private void Awake() {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _livesManager = FindObjectOfType<LivesManager>();
        _timeManager = FindObjectOfType<TimeManager>();
        _pillsManager = FindObjectOfType<PillsManager>();
        _groundController = FindObjectOfType<GroundController>();
        _ballController = FindObjectOfType<BallController>();
        _uIController = FindObjectOfType<UIController>();
        _cameraController = FindObjectOfType<CamaraController>();

        // Load only if not already loaded
        if (_instance == null) {
            _instance = this;
        }
        else {
            Destroy(this);
        }
    }

    private void Start() {
        _gameIsFinished = false;
    }

    /// <summary>
    /// Indicates the min. height the player can be (in order to be considered alive).
    /// </summary>
    /// <returns></returns>
    public float GetLosingHeight() {
        return _groundController.GroundHeight - _relativeLoseHeight;
    }

    public int GetScore() {
        return _scoreManager.Score;
    }

    public int GetLives() {
        return _livesManager.LivesRemaining;
    }

    public float GetTimeRemaining() {
        return _timeManager.TimeRemaining;
    }

    /// <summary>
    /// Notifies this game controller that a score was performed.
    /// </summary>
    public void Score() {
        if (_gameIsFinished) {
            return;
        }
        Debug.Log("Player has earned one point.");
        _scoreManager.AddScore(1); // TODO: remove magic number
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
        if (_gameIsFinished) {
            return;
        }
        StartCoroutine(Die());
        Debug.Log("Started Die process");
    }

    /// <summary>
    /// Notifies this game controller that there is no more time.
    /// </summary>
    public void NotifyNoMoreTime() {
        if (_gameIsFinished) {
            return;
        }
        _timeManager.StopTimer();
        StartCoroutine(NoMoreTime());
    }

    /// <summary>
    /// The winning process.
    /// </summary>
    /// <returns>IEnumerator for waiting an amount of time</returns>
    private IEnumerator Win() {
        PlayerPrefs.SetInt("Lives", GetLives());
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        _gameIsFinished = true;
        _timeManager.StopTimer();
        Debug.Log("Player win");
        _uIController.NotifyWin();
        yield return new WaitForSeconds(1f); // Wait some time before executiong the win process.
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            FinishGame();    
        }
        else
        {
            string newLevel = "Level" + PlayerPrefs.GetInt("Level").ToString();
            SceneManager.LoadScene(newLevel);
        }
        
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
        if (_livesManager.NoMoreLives()) {
            Debug.Log("No more lives");
            StartCoroutine(GameOver());
        }
        else {
            _groundController.RestartGround();
            _ballController.Reborn();
            _timeManager.ResumeTimer();
            _cameraController.RestartCamera();
        }
    }

    /// <summary>
    /// The no more time process.
    /// </summary>
    /// <returns>IEnumerator for waiting an amount of time</returns>
    private IEnumerator NoMoreTime() {
        _gameIsFinished = true;
        Debug.Log("Player is out of time");
        _uIController.NotifyTimeUp();
        yield return new WaitForSeconds(2f); // Wait some time before executiong the no more time process.
        StartCoroutine(GameOver());
    }

    /// <summary>
    /// The game over process.
    /// </summary>
    /// <returns>IEnumerator for waiting an amount of time</returns>
    private IEnumerator GameOver() {
        _gameIsFinished = true; // Sanity check (should not enter here with this in false, but just in case).
        _timeManager.StopTimer();
        Debug.Log("Game over");
        _uIController.NotifyGameOver();
        yield return new WaitForSeconds(2f); // Wait some time before executiong the die process.
        FinishGame();
    }

    /// <summary>
    /// Finishes the game.
    /// </summary>
    private static void FinishGame() {
        SceneManager.LoadScene("MainMenu");
    }
}