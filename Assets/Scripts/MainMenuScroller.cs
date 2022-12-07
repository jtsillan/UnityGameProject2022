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
    [SerializeField] CustomController customController;
    private string[] letters = {"_","Play", "Options", "Tutorial","_"};
    // Start is called before the first frame update
    private void Start()
    {
        currentLetter = 1;
        currentLetterSelection = 1;
        selectionLetters[currentLetterSelection].color = Color.red;
        GameObject input = GameObject.Find("ButtonManager");
        customController = input.GetComponent<CustomController>();
    }

    private void Update()
    {   
            if (currentLetter == 4)
            {
                selectionLetters[currentLetter-1].color = Color.black;
                selectionLetters[currentLetter-3].color = Color.red;
                currentLetter -= 3;
            }

            if (currentLetter == 0)
            {
                selectionLetters[currentLetter+1].color = Color.black;
                selectionLetters[currentLetter+3].color = Color.red;
                currentLetter += 3;
            }
            
            if (currentLetter == 1)
            {
                Debug.Log("Asd11");
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("Asd");
                    SceneManager.LoadScene("GameOverScreen");
                }
            }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentLetterSelection++;
            currentLetter++;
            Thread.Sleep(100);
            selectionLetters[currentLetter-1].color = Color.black;
            selectionLetters[currentLetter].color = Color.red;

            if (currentLetter == 2)
            {
                if (Input.GetKeyDown("enter"))
                {
                    SceneManager.LoadScene("GameOverScreen");
                }
            }

            if (currentLetter == 3)
            {
                if (Input.GetKeyDown("enter"))
                {
                    SceneManager.LoadScene("GameOverScreen");
                }
            }
        }

        //ALKAA TOINEN OSA
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentLetterSelection--;
            currentLetter--;
            Thread.Sleep(100);
            selectionLetters[currentLetter+1].color = Color.black;
            selectionLetters[currentLetter].color = Color.red;
            if (currentLetter == 1)
            {
                if (Input.GetKeyDown("enter"))
                {
                    SceneManager.LoadScene("GameOverScreen");
                }
            }

            if (currentLetter == 2)
            {
                if (Input.GetKeyDown("enter"))
                {
                    SceneManager.LoadScene("GameOverScreen");
                }
            }

            if (currentLetter == 3)
            {
                if (Input.GetKeyDown("enter"))
                {
                    SceneManager.LoadScene("GameOverScreen");
                }
            }
        }
        //LOPPUU TOINEN OSA
    }
}
