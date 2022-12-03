using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        DataManager.instance.currentScore = 0;
        DataManager.instance.isnewscore = false;
        SceneManager.LoadScene("StartScene");
    }

        public void BackToMain ()
    {
        Destroy(GameObject.FindGameObjectWithTag("datamanager"));
        SceneManager.LoadScene("Menu");
    }
}
