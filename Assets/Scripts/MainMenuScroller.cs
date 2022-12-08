using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;
public class MainMenuScroller : MonoBehaviour
{
    public TMP_Text[] selectionLetters;
    public int currentLetter;
    private int currentLetterSelection = 1;
    public Slider mSlider;
    public GameObject OptionsMenu;
    public GameObject TutorialMenu;
    public GameObject OptionsVolumeButton;
    public GameObject OptionsBackButton;
    public GameObject ArrowPlay;
    public GameObject ArrowOptions;
    public GameObject ArrowTutorial;
    public GameObject BackArrowTutorial;
    [SerializeField] CustomController customController;
    private string[] letters = {"_","Play", "Options", "Tutorial","_","Back1","Slider","SliderBack"};
    // Start is called before the first frame update
    private void Start()
    {
        currentLetter = 1;
        currentLetterSelection = 1;
        selectionLetters[currentLetterSelection].color = Color.red;
        GameObject input = GameObject.Find("ButtonManager");
        customController = input.GetComponent<CustomController>();
        ArrowPlay.SetActive(true);
        mSlider.value = -15;
        mSlider.maxValue = 0;
    }

    private void Update()
    {   
            //JOS VALINTA MENEE TUTORIAALISTA ALAS, SE MENEE PLAY NAPPIIN
            if (currentLetter == 4)
            {
                currentLetter -= 3;
            }

            //JOS VALINTA MENEE PLAYSTA YLÖS, SE MENEE TUTORIAL NAPPIIN
            if (currentLetter == 0)
            {
                currentLetter += 3;
            }
            
            //JOS ARROW OSOITTAA PLAY NAPPIA -->
            if (currentLetter == 1)
            {
                ArrowPlay.SetActive(true);
                ArrowOptions.SetActive(false);
                ArrowTutorial.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Space) || customController.buttonOnePressed == true && customController.buttonTwoPressed == true)
                {
                    ArrowPlay.SetActive(false);
                    SceneManager.LoadScene("StartScene");
                }
            }

            if (currentLetter == 7)
            {
                if (Input.GetKeyDown(KeyCode.Space) || customController.buttonOnePressed == true && customController.buttonTwoPressed == true)
                {
                    OptionsVolumeButton.SetActive(true);
                    OptionsBackButton.SetActive(false);
                    OptionsMenu.SetActive(false);
                    currentLetter -= 6;
                }
                
            }

            //LIIKKUVUUS OPTIONS MENUSSA -->
            if (GameObject.Find("Options") == true)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || customController.buttonOnePressed == true)
                {
                    OptionsVolumeButton.SetActive(true);
                    OptionsBackButton.SetActive(false);
                    Debug.Log(currentLetter);
                }

                if (Input.GetKeyDown(KeyCode.DownArrow) || customController.buttonTwoPressed == true)
                {
                    OptionsVolumeButton.SetActive(false);
                    OptionsBackButton.SetActive(true);
                    Debug.Log(currentLetter);
                }
            }

            //JOS ARROW OSOITTAA OPTIONS NAPPIA -->
            if (currentLetter == 2)
            {
            ArrowPlay.SetActive(false);
            ArrowOptions.SetActive(true);
            ArrowTutorial.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Space) || customController.buttonOnePressed == true && customController.buttonTwoPressed == true)
                {
                    OptionsMenu.SetActive(true);
                    if (GameObject.Find("Options") == true)
                    {
                        currentLetter += 4;
                        Thread.Sleep(100);
                    }
                }
            }

            //PIILOTTAA TUTORIAL MENUN, JOS SEN SISÄLLÄ TEHDÄÄN VALINTA
            if (GameObject.Find("Tutorial") == true)
            {
                if (Input.GetKeyDown(KeyCode.Space) || customController.buttonOnePressed == true && customController.buttonTwoPressed == true)
                {
                    currentLetter -= 4;
                    TutorialMenu.SetActive(false);
                    ArrowPlay.SetActive(true);
                    ArrowTutorial.SetActive(false);
                    Debug.Log(currentLetter);
                }
            }

            //KUN ARROW OSOITTAA TUTORIAL NAPPIA -->
            if (currentLetter == 3)
            {
            ArrowPlay.SetActive(false);
            ArrowOptions.SetActive(false);
            ArrowTutorial.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space) || customController.buttonOnePressed == true && customController.buttonTwoPressed == true)
                {
                    TutorialMenu.SetActive(true);
                    if (GameObject.Find("Tutorial") == true)
                    {
                        currentLetter += 2;
                        Debug.Log(currentLetter);
                    }
                }
            }

            // KUN ARROW OSOITTAA VOLUMEA -->
            if (currentLetter == 6)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    mSlider.value -= 5;
                    Thread.Sleep(100);
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    mSlider.value += 5;
                    Thread.Sleep(100);
                }
            }



        //ALASPÄIN LIIKKUMINEN VALIKOSSA
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentLetter != 7 && currentLetter != 5)
        {
            currentLetterSelection++;
            currentLetter++;
            Thread.Sleep(100);
        }

        //YLÖSPÄIN LIIKKUMINEN VALIKOSSA
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentLetter != 6 && currentLetter != 5)
        {
            currentLetterSelection--;
            currentLetter--;
            Thread.Sleep(100);
        }

    }
}
