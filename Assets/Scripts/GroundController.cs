using UnityEngine;

public class GroundController : MonoBehaviour {
    public float speed = 1.0f;
    private float minRotX = -0.2f;
    private float maxRotX = 0.2f;
    private float minRotY = -0.2f;
    private float maxRotY = 0.2f;


    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        CheckMove();
    }

    private void CheckMove() {
        float newRotX = transform.rotation.x;
        float newRotZ = transform.rotation.z;

        {
            if (Input.GetKey(KeyCode.DownArrow)) {
                // Nueva posición de X
                newRotX = transform.rotation.x - speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.UpArrow)) {
                // Nueva posición de X
                newRotX = transform.rotation.x + speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftArrow)) {
                // Nueva posición de X
                newRotZ = transform.rotation.z + speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.RightArrow)) {
                // Nueva posición de X
                newRotZ = transform.rotation.z - speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) ||
                Input.GetKey(KeyCode.RightArrow)) {
                // Clampeo la posición a la pos mínima y máxima
                newRotX = Mathf.Clamp(newRotX, minRotX, maxRotX);
                newRotZ = Mathf.Clamp(newRotZ, minRotY, maxRotY);

                // Asigno la posición
                transform.rotation = new Quaternion(newRotX, transform.rotation.y, newRotZ, transform.rotation.w);
            }
        }
    }
}
