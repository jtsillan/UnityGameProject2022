using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOverHighScore : MonoBehaviour
{
    public TMP_Text highscoretext;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        highscoretext.text = "SCORE: " + DataManager.instance.currentScore;

    }
}
