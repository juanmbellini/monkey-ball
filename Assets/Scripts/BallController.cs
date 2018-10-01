using UnityEngine;

public class BallController : MonoBehaviour {
    private bool _isAlive;

    // Use this for initialization
    void Start() {
        _isAlive = true;
    }

    // Update is called once per frame
    void Update() {
        CheckLose();
    }


    private void CheckLose() {
        // TODO: remove magic number. Maybe when it touches a plane?
        if (_isAlive && transform.position.y < -10.0f) {
            Debug.Log("You lose");
            _isAlive = false;
        }
    }
}
