using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public void PlayGame() {
        SceneManager.LoadScene("Level1");
    }

    // Use this for initialization
    private void Start() {
        PlayerPrefs.SetInt("Lives",3);
        PlayerPrefs.SetInt("Level",1);
    }

    // Update is called once per frame
    private void Update() {
    }
}
