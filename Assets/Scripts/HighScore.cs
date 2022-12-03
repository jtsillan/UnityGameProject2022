using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public int newhighScore;

    public TMP_Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        newhighScore = DataManager.instance.currentScore;
        highScoreText.text = "NEW HIGHSCORE!\n" + newhighScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
