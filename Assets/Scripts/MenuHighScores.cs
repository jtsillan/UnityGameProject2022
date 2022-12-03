using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuHighScores : MonoBehaviour
{
    public TMP_Text highscoretext;
    public string highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore =""+DataManager.instance.currentScore;
        highscoretext.text = highscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
