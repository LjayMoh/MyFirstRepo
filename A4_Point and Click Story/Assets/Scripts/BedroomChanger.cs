using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BedroomChanger : MonoBehaviour
{
    public Button bedroom;

    public void Start()
    {
        Button bR = bedroom.GetComponent<Button>();
        bR.onClick.AddListener(loadBedroom);
    }

    public void loadBedroom()
    {
        SceneManager.LoadScene(0);
    }
}
