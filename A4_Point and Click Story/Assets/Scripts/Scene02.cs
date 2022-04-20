using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene02 : MonoBehaviour
{
    public static Scene02 scene02;

    public InkManager inkManager;
    private Text currentTextField;

    public void Awake()
    {
        if (scene02 != null)
        {
            scene02 = this;
            DontDestroyOnLoad(gameObject);
            currentTextField.text = Scene01.scene01.currentText;
        }
        else
        {
            Destroy(gameObject);
        }

        //currentTextField.text = Scene01.scene01.currentText;
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
