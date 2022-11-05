using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class ButtonTimer : MonoBehaviour
{
    private static Timer timer1;

    private void CreateTimer()
    {        
        timer1 = new Timer();
        timer1.Interval = 1000;
        timer1.Elapsed += HandleTimerElapsed;
        timer1.Enabled = true;
        timer1.AutoReset = true;
    }

    public void HandleTimerElapsed(object sender, ElapsedEventArgs e)
    {

    }
}
