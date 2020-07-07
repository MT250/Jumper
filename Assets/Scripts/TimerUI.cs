using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private Text textUI;

    [SerializeField] private float seconds = 0;
    [SerializeField] private int minutes = 0;
    [SerializeField] private int hours = 0;

    private void Awake()
    {
        textUI = GetComponent<Text>();
    }

    void Update()
    {
        seconds += Time.deltaTime;

        if (seconds >= 60)
         {
            seconds = 0;
            minutes++;
         }

        if (minutes == 60)
        {
            minutes = 0;
            hours++;
        }

        SetValuesToTextComponent();
    }

    private void SetValuesToTextComponent()
    {
        //TODO: Make script display in "00:00:00" format, not "0:0:0"
        textUI.text = hours + ":" + minutes + ":" + seconds;
    }
}
