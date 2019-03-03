using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Timer gameTimer;
    public bool playing;
    public BoxCollider goalCollider;
    // Start is called before the first frame update
    void Start()
    {
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Button.Start")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
