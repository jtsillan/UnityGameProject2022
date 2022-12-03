using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowScore : MonoBehaviour
{
    public static ShowScore instance;

    public List<inputdata> uiscore;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    [System.Serializable]
    public struct inputdata
    {
        public TextMeshProUGUI txt_name;
        public TextMeshProUGUI txt_score;

    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
