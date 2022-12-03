using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int ScoreInt;
    public Text ScoreText;
    public int highScore;
    public bool newHighScore;
    
    public void Start()
    {
         
        highScore = DataManager.instance.currenthighScore;
    }

    //lis�� pisteen scoreen
    public void ScorePlusOne()
    {
        ScoreInt++;
        DataManager.instance.currentScore = ScoreInt;

    }


    //p�ivitt�� score tekstin
    private void Update()
    {
        ScoreText.text = ScoreInt.ToString();
        if(ScoreInt > highScore)
        {
//            DataManager.instance.currentScore=ScoreInt ;
          
            

        }

    }
}