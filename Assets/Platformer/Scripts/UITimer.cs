using System.Threading;
using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeValue = 500;

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        // one to do the whole number for text
        //int wholeSecond = (int)Mathf.Floor(Time.realtimeSinceStartup);
        //timerText.text = $"Time \n{wholeSecond.ToString()}";
        
        // second way to do the whole number of text
        timerText.text = "Time \n" + timeValue.ToString("0");
    }
}
