using UnityEngine;

/// <summary>
/// Behaviour for the ground.
/// </summary>
public class GroundController : MonoBehaviour {
    /// <summary>
    /// The rotation speed.
    /// </summary>
    [SerializeField] private float _speed = 1.0f;

    /// <summary>
    /// The min. rotation in the x axis.
    /// </summary>
    private const float MinRotX = -0.1f;

    /// <summary>
    /// The max. rotation in the x axis.
    /// </summary>
    private const float MaxRotX = 0.1f;

    /// <summary>
    /// The min. rotation in the z axis.
    /// </summary>
    private const float MinRotZ = -0.1f;

    /// <summary>
    /// The max. rotation in the z axis.
    /// </summary>
    private const float MaxRotZ = 0.1f;


    private void Start() {
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

        if (rotationWasTriggered) {
            // First, clamp rotation values
            newRotX = Mathf.Clamp(newRotX, MinRotX, MaxRotX);
            newRotZ = Mathf.Clamp(newRotZ, MinRotZ, MaxRotZ);
            // Then, assign the new rotation value.
            transform.rotation = new Quaternion(newRotX, transform.rotation.y, newRotZ, transform.rotation.w);
        }
    }
}