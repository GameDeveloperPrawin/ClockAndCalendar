using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text HoursText;
    [SerializeField]
    private TMP_Text MinutesText;
    [SerializeField]
    private TMP_Text SecondsText;

    [SerializeField]
    private GameObject calendarContent;

    [SerializeField]
    private TMP_Text monthAndYear; 

    private enum Days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
        UpdateCalendar();
    }

    private void UpdateCalendar()
    {
        DateTime today = DateTime.Today;
        DateTime firstDateOfMonth = today.AddDays(-today.Day + 1);

        int index = 7 + (int)firstDateOfMonth.DayOfWeek;
        int date = 1;
        while ((index < calendarContent.transform.childCount) && (date <= DateTime.DaysInMonth(today.Year, today.Month)))
        {
            calendarContent.transform.GetChild(index).GetChild(0).GetComponent<TMP_Text>().text = date.ToString();
            if(date == today.Day)
            {
                calendarContent.transform.GetChild(index).GetComponent<Image>().color = Color.green;
            }
            index++;
            date++;
        }

        if((index == calendarContent.transform.childCount) && (date < DateTime.DaysInMonth(today.Year, today.Month)))
        {
            index = 7;
            while(date <= DateTime.DaysInMonth(today.Year, today.Month))
            {
                calendarContent.transform.GetChild(index).GetChild(0).GetComponent<TMP_Text>().text = date.ToString();
                if (date == today.Day)
                {
                    calendarContent.transform.GetChild(index).GetComponent<Image>().color = Color.green;
                }
                index++;
                date++;
            }
        }
        monthAndYear.text = today.ToString("Y");
    }

    private void UpdateTime()
    {
        DateTime time = DateTime.Now;

        if (time.Hour >= 10)
        {
            HoursText.text = (time.Hour).ToString();
        }
        else
        {
            HoursText.text = "0" + (time.Hour).ToString();
        }

        if(time.Minute >=10)
        {
            MinutesText.text = (time.Minute).ToString();
        }
        else
        {
            MinutesText.text = "0" + (time.Minute).ToString();
        }

        if (time.Second >= 10)
        {
            SecondsText.text = (time.Second).ToString();
        }
        else
        {
            SecondsText.text = "0" + (time.Second).ToString();
        }
    }
}
