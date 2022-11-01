using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int ScoreInt;
    public Text ScoreText;
    

    //lis‰‰ pisteen scoreen
    public void ScorePlusOne()
    {
        ScoreInt++;
    }


    //p‰ivitt‰‰ score tekstin
    private void Update()
    {
        ScoreText.text = ScoreInt.ToString();
    }
}