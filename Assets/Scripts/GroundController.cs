using UnityEngine;

/// <summary>
/// Behaviour for the ground.
/// </summary>
public class GroundController : MonoBehaviour {
    /// <summary>
    /// The min. rotation in the x axis.
    /// </summary>
    private const float MinRotX = -0.15f;

    /// <summary>
    /// The max. rotation in the x axis.
    /// </summary>
    private const float MaxRotX = 0.15f;

    /// <summary>
    /// The min. rotation in the z axis.
    /// </summary>
    private const float MinRotZ = -0.15f;

    /// <summary>
    /// The max. rotation in the z axis.
    /// </summary>
    private const float MaxRotZ = 0.15f;

    /// <summary>
    /// Initial rotation (i.e used for restarting).
    /// </summary>
    private Quaternion _rotation;

    /// <summary>
    /// Initial local rotation (i.e used for restarting).
    /// </summary>
    private Quaternion _localRotation;

    /// <summary>
    /// The rotation speed.
    /// </summary>
    [SerializeField] private float _speed = 0.25f;

    /// <summary>
    /// The starting height of the ground (i.e the height of the ground when it's not rotated).
    /// </summary>
    public float GroundHeight { get; private set; }


    private void Start() {
        _rotation = transform.rotation;
        _localRotation = transform.localRotation;
        GroundHeight = transform.position.y;
    }


    private void FixedUpdate() {
        CheckRotation();
    }

    /// <summary>
    /// Checks whether a rotational input was triggered.
    /// </summary>
    private void CheckRotation() {
        var newRotX = transform.rotation.x;
        var newRotZ = transform.rotation.z;

        var rotationWasTriggered = false;

        // First, check rotation in the x axis
        if (Input.GetKey(KeyCode.DownArrow)) {
            newRotX = transform.rotation.x - _speed * Time.deltaTime; // New rotation value for x
            rotationWasTriggered = true;
        }
        else if (Input.GetKey(KeyCode.UpArrow)) {
            newRotX = transform.rotation.x + _speed * Time.deltaTime; // New rotation value for x
            rotationWasTriggered = true;
        }

        // First, check rotation in the z axis
        if (Input.GetKey(KeyCode.LeftArrow)) {
            newRotZ = transform.rotation.z + _speed * Time.deltaTime; // New rotation value for z
            rotationWasTriggered = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            newRotZ = transform.rotation.z - _speed * Time.deltaTime; // New rotation value for z
            rotationWasTriggered = true;
        }

        if (!rotationWasTriggered) {
            return;
        }
        // First, clamp rotation values
        newRotX = Mathf.Clamp(newRotX, MinRotX, MaxRotX);
        newRotZ = Mathf.Clamp(newRotZ, MinRotZ, MaxRotZ);
        // Then, assign the new rotation value.
        transform.rotation = new Quaternion(newRotX, transform.rotation.y, newRotZ, transform.rotation.w);
    }

    /// <summary>
    /// Restart the ground to the initial configuration.
    /// </summary>
    public void RestartGround() {
        transform.localRotation = _localRotation;
        transform.rotation = _rotation;
    }
}