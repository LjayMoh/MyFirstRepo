using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstTextPanel : MonoBehaviour
{
    public float time = 30;

    public GameObject introPanel;
    public GameObject firstTextPanel;
    public GameObject secondTextPanel;

    public GameObject nextTextObject;

    public GameObject mother;

    public Button nextText;

    public void Start()
    {
        Button nT = nextText.GetComponent<Button>();
        nT.onClick.AddListener(nextTextClass);
    }

    public void Update()
    {
        time -= Time.deltaTime;

        if (time < 15)
        {
            firstTextPanel.SetActive(false);
            secondTextPanel.SetActive(true);
        }

        if (time < 0)
        {
            introPanel.SetActive(false);

            mother.SetActive(true);
        }
    }

    //for those impatient people
    public void nextTextClass()
    {
        firstTextPanel.SetActive(false);
        secondTextPanel.SetActive(true);

        nextTextObject.SetActive(false);
    }
}
