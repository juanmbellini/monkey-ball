using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private static GameController _instance;

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
    void Start() {

    }

    // Update is called once per frame
    void Update() {
    }

    public void Score() {
        _scoreManager.AddScore(1); // TODO: remove magic number
    }

    public void Lose() {
        _scoreManager.LoseLife();
    }
}
