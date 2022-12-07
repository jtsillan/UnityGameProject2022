using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;
public class MainMenuScroller : MonoBehaviour
{
    public TMP_Text[] selectionLetters;
    public int currentLetter;
    private int currentLetterSelection = 1;
    public GameObject OptionsMenu;
    public GameObject TutorialMenu;
    public GameObject TutorialBackButton;
    public GameObject OptionsBackButton;
    public GameObject ArrowPlay;
    public GameObject ArrowOptions;
    public GameObject ArrowTutorial;
    public GameObject BackArrowTutorial;
    [SerializeField] CustomController customController;
    private string[] letters = {"_","Play", "Options", "Tutorial","_","Back1"};
    // Start is called before the first frame update
    private void Start()
    {
        currentLetter = 1;
        currentLetterSelection = 1;
        selectionLetters[currentLetterSelection].color = Color.red;
        GameObject input = GameObject.Find("ButtonManager");
        customController = input.GetComponent<CustomController>();
        ArrowPlay.SetActive(true);
    }

    private void Update()
    {   
            if (currentLetter == 4)
            {

                currentLetter -= 3;
            }

            if (currentLetter == 0)
            {

                currentLetter += 3;
            }
            
            if (currentLetter == 1)
            {
                ArrowPlay.SetActive(true);
                ArrowOptions.SetActive(false);
                ArrowTutorial.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ArrowPlay.SetActive(false);
                    SceneManager.LoadScene("StartScene");
                }
            }

            if (GameObject.Find("Options") == true)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {

                    TutorialMenu.SetActive(false);
                    ArrowPlay.SetActive(false);
                    ArrowTutorial.SetActive(false);
                    ArrowOptions.SetActive(true);
                    Debug.Log(currentLetter);
                }
            }
            if (currentLetter == 2)
            {
            ArrowPlay.SetActive(false);
            ArrowOptions.SetActive(true);
            ArrowTutorial.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    OptionsMenu.SetActive(true);
                    if (GameObject.Find("Options") == true)
                    {
                        currentLetter += 4;
                        Debug.Log(currentLetter);
                    }
                }
            }

            if (GameObject.Find("Tutorial") == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentLetter -= 4;
                    TutorialMenu.SetActive(false);
                    ArrowPlay.SetActive(true);
                    ArrowTutorial.SetActive(false);
                    Debug.Log(currentLetter);
                }
            }


            if (currentLetter == 3)
            {
            ArrowPlay.SetActive(false);
            ArrowOptions.SetActive(false);
            ArrowTutorial.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    TutorialMenu.SetActive(true);
                    if (GameObject.Find("Tutorial") == true)
                    {
                        currentLetter += 2;
                        Debug.Log(currentLetter);
                    }
                }
            }



        
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentLetter != 5)
        {
            currentLetterSelection++;
            currentLetter++;
            Thread.Sleep(100);
            selectionLetters[currentLetter-1].color = Color.black;
            selectionLetters[currentLetter].color = Color.red;
        }
        //ALKAA TOINEN OSA
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentLetter != 5)
        {
            currentLetterSelection--;
            currentLetter--;
            Thread.Sleep(100);
            selectionLetters[currentLetter+1].color = Color.black;
            selectionLetters[currentLetter].color = Color.red;
        }
        //LOPPUU TOINEN OSA
    }
}
