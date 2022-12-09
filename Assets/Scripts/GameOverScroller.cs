using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;
public class GameOverScroller : MonoBehaviour
{
    public TMP_Text[] selectionLetters;
    public TMP_Text TimerTxt;
    public int currentLetter;
    private int currentLetterSelection = 0;
    public GameObject RestartArrow;
    public GameObject MainMenuArrow;
    public bool TimerOn = false;
    public float targetTime = 2.0f;
    [SerializeField] CustomController customController;
    private string[] letters = {"Restart", "MainMenu"};
    // Start is called before the first frame update
    private void Start()
    {
        currentLetter = 0;
        currentLetterSelection = 0;
        GameObject input = GameObject.Find("ButtonManager");
        customController = input.GetComponent<CustomController>();
        RestartArrow.SetActive(true);
        MainMenuArrow.SetActive(false);

    }

    private void Update()
    {   

        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
        timerEnded();
        }

        void timerEnded()
        {
                //JOS ARROW OSOITTAA RESTART NAPPIA -->
            if (currentLetter == 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || customController.hallValue == true)
                {
                    SceneManager.LoadScene("StartScene");
                }
            }         
            //JOS ARROW OSOITTAA MAINMENU NAPPIA -->
            if (currentLetter == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space) || customController.hallValue == true)
                {
                    SceneManager.LoadScene("Menu");
                }
            }   
            //ALASPÄIN LIIKKUMINEN VALIKOSSA
            if (Input.GetKeyDown(KeyCode.DownArrow) && currentLetter != 1 || customController.buttonTwoPressed == true && currentLetter != 1)
            {
                currentLetterSelection++;
                currentLetter++;
                RestartArrow.SetActive(false);
                MainMenuArrow.SetActive(true);
                Debug.Log(currentLetter);
                Thread.Sleep(150);
            }

            //YLÖSPÄIN LIIKKUMINEN VALIKOSSA
            if (Input.GetKeyDown(KeyCode.UpArrow) && currentLetter != 0 || customController.buttonOnePressed == true && currentLetter != 0)
            {
                currentLetterSelection--;
                currentLetter--;
                RestartArrow.SetActive(true);
                MainMenuArrow.SetActive(false);
                Debug.Log(currentLetter);
                Thread.Sleep(150);
            }
        }
    }
}
