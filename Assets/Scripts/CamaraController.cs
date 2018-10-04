using UnityEngine;

public class CamaraController : MonoBehaviour {
    /// <summary>
    /// The ball that must be followed.
    /// </summary>
    [SerializeField] private Transform _ball;

    /// <summary>
    /// A value used for adapting the camera movement.
    /// </summary>
    [SerializeField] private float _value = 50;

    /// <summary>
    /// Initial camera position.
    /// </summary>
    private Vector3 _initialPosition;

    // Use this for initialization
    private void Start() {
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    private void Update() {
        var distance = Vector3.Distance(transform.position, _ball.position);
        var delta = distance / (2 + distance);
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, _ball.transform.position.x, delta * Time.deltaTime),
            Mathf.Lerp(transform.position.y, _ball.transform.position.y + 7, delta * Time.deltaTime),
            Mathf.Lerp(transform.position.z, _ball.transform.position.z - 10, delta * Time.deltaTime * _value));
        transform.LookAt(_ball);
    }

    /// <summary>
    /// Restarts the camera to the initial position.
    /// </summary>
    public void RestartCamera() {
        transform.position = _initialPosition;
    }
}