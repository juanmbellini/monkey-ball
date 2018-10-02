using UnityEngine;

public class CamaraController : MonoBehaviour {
    public Transform ball;

    // Use this for initialization
    private void Start() {
    }

    // Update is called once per frame
    private void Update() {
        transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y + 5,
            ball.transform.position.z - 7);
        transform.LookAt(ball);
    }
}