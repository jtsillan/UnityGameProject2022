using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public Text TimerTxt;
    public GameObject CountdownTxt;
    Color32 color1 = new Color32(255, 168, 0, 255);

    void Start()
    {
        TimerOn = true;
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                if (DataManager.instance.check_Can_StoreNewHighScore())
                {
                    SceneManager.LoadScene("HighScore");
                    TimeLeft = 0;
                    TimerOn = false;
                }
                else
                {
                    SceneManager.LoadScene("GameOverScreen");
                    TimeLeft = 0;
                    TimerOn = false;
                }
            }

        //  if (TimeLeft < 7.02 && TimeLeft > 7)
        //  {
        //      CountdownTxt.SetActive(false);
        //  }

            if (TimeLeft < 10.02 && TimeLeft > 10)
            {
        //      CountdownTxt.SetActive(true);
                TimerTxt.color = Color.red;
            }

            if (TimeLeft < 30.02 && TimeLeft > 30)
            {
                TimerTxt.color = color1;
            }

            if (TimeLeft < 45.02 && TimeLeft > 45)
            {
                TimerTxt.color = Color.yellow;
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

}