using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotherTalkScript : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;

    public GameObject talkPanel1;
    public GameObject talkPanel2;
    public GameObject talkPanel3;
    public GameObject talkPanel4;
    public GameObject talkPanel5;
    public GameObject talkPanel6;

    public GameObject mother;
    public GameObject joe;

    public void Start()
    {
        Button b1 = button1.GetComponent<Button>();
        b1.onClick.AddListener(talkPanel1Class);

        Button b2 = button2.GetComponent<Button>();
        b2.onClick.AddListener(talkPanel2Class);

        Button b3 = button3.GetComponent<Button>();
        b3.onClick.AddListener(talkPanel3Class);

        Button b4 = button4.GetComponent<Button>();
        b4.onClick.AddListener(talkPanel4Class);

        Button b5 = button5.GetComponent<Button>();
        b5.onClick.AddListener(talkPanel5Class);
    }

    public void talkPanel1Class()
    {
        talkPanel1.SetActive(false);
        talkPanel2.SetActive(true);
    }

    public void talkPanel2Class()
    {
        talkPanel2.SetActive(false);
        talkPanel3.SetActive(true);

        joe.SetActive(true);
        mother.SetActive(false);
    }

    public void talkPanel3Class()
    {
        talkPanel3.SetActive(false);
        talkPanel4.SetActive(true);

        joe.SetActive(false);
        mother.SetActive(true);
    }

    public void talkPanel4Class()
    {
        talkPanel4.SetActive(false);
        talkPanel5.SetActive(true);
    }

    public void talkPanel5Class()
    {
        talkPanel5.SetActive(false);
        talkPanel6.SetActive(true);
    }
}
