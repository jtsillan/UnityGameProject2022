using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData  
{

    public List<scores> scoredata;    

    [System.Serializable]
    public struct scores
    {
        public string name;
        public int score;

    }
}
