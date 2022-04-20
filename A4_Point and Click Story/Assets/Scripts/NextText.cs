using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextText : MonoBehaviour
{
    public Button nextText;

    public GameObject firstText;
    public GameObject secondText;

    public GameObject nextTextObject;

    public void Start()
    {
        Button nT = nextText.GetComponent<Button>();
        nT.onClick.AddListener(textLoader);
    }

    public void textLoader()
    {
        firstText.SetActive(false);
        secondText.SetActive(true);

        Destroy(nextTextObject);
    }
}
