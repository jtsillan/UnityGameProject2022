using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;
public class NameChooser : MonoBehaviour
{
    public TMP_Text[] selectionLetters;
    public float timeRemaining = 5;
    public int currentLetter;
    private int currentLetterSelection = 1;
    public TMP_Text timeText;
    public string highScoreWithName;
    public string playerName;
    public int currentHighScore;
    [SerializeField] CustomController customController;
    private string[] letters = {"_","A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z","_"};
    // Start is called before the first frame update
    private void Start()
    {
        currentHighScore = DataManager.instance.currentScore;
        currentLetter = 1;
        currentLetterSelection = 1;
        selectionLetters[currentLetterSelection].color = Color.red;

        // Hae buttonmanager gameobject
        // ota sieltä customcontroller
        GameObject input = GameObject.Find("ButtonManager");

        customController = input.GetComponent<CustomController>();
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;

        if (customController.buttonTwoPressed == true)
        {
            if (currentLetterSelection ==26)
            {
                currentLetterSelection = 1;
            }
            else
            {
                currentLetterSelection++;
                Thread.Sleep(150);
            }
            timeRemaining = 5;

        }
        if (customController.buttonOnePressed == true)
        {
            if (currentLetterSelection==1)
            {
                currentLetterSelection = 26;
            }
            else
            {
                currentLetterSelection--;
                Thread.Sleep(150);
            }
            timeRemaining = 5;
        }

        if (timeRemaining <= 0 || Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            currentLetter++;
            selectionLetters[currentLetter-1].color = Color.black;
            selectionLetters[currentLetter].color = Color.red;
            if (currentLetter > 3)
            {
                playerName = selectionLetters[1].text + selectionLetters[2].text + selectionLetters[3].text;
                DataManager.instance.playername = playerName;
                DataManager.instance.savenewHighScore(DataManager.instance.currentScore);
                SceneManager.LoadScene("Menu");
            }
            currentLetterSelection = 1;
            timeRemaining = 5;

        }
        selectionLetters[currentLetter].text = letters[currentLetterSelection];
        timeText.text = (Mathf.RoundToInt(timeRemaining)).ToString();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            currentLetter--;
            selectionLetters[currentLetter+1].color = Color.black;
            selectionLetters[currentLetter].color = Color.red;
            if (currentLetter < 1)
            {
                currentLetter += 3;
                selectionLetters[currentLetter+1].color = Color.black;
                selectionLetters[currentLetter].color = Color.red;
            }
            currentLetterSelection = 1;
            timeRemaining = 5;

        }

    }
}
