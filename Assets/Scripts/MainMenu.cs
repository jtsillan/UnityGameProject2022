using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("Randomized_Tiles");
    }

        public void BackToMain ()
    {
        SceneManager.LoadScene("Menu");
    }
}
