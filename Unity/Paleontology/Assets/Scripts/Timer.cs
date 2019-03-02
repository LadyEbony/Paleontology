using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Timer : MonoBehaviour
{
    public float TimeLimit = 360f;
    public float CurrentTime;

    public TextMeshProUGUI TextGUI;

    private void Update() {
        CurrentTime = TimeLimit - Time.timeSinceLevelLoad;
        if (CurrentTime <= 0.0f){
            // STOP GAME
            // Reset level?
        } else {
            TextGUI.text = string.Format("{0,0:D2}:{1,0:D2}", Mathf.FloorToInt(CurrentTime / 60f), Mathf.FloorToInt(CurrentTime % 60.0f));
        }
    }
}
