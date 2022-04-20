using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipIntro : MonoBehaviour
{
    public Button skip;

    public GameObject introPanel;

    public GameObject mother;

    public void Start()
    {
        Button s = skip.GetComponent<Button>();
        s.onClick.AddListener(closePanel);
    }

    public void closePanel()
    {
        introPanel.SetActive(false);

        mother.SetActive(true);
    }
}
