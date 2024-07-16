using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tỉme : MonoBehaviour
{
    public TextMeshProUGUI time;
    public float Timer;

    // Update is called once per frame
    void Update()
    {
        if (Timer > 0) {Timer -= Time.deltaTime; }
        else if (Timer < 0) {  Timer = 0;time.color = Color.green; SceneManager.LoadScene("win"); }
        int minutes =Mathf.FloorToInt(Timer / 60);
        int seconds =Mathf.FloorToInt(Timer % 60);
        time.text=string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }
}
