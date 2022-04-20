using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene01 : MonoBehaviour
{
    public static Scene01 scene01;
    public InkManager inkManager;

    public string currentText;

    private void Awake()
    {
        if (scene01 == null)
        {
            scene01 = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CurrentText()
    {
        currentText = inkManager._story.ToString();
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
