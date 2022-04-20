using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToRoom : MonoBehaviour
{
    public Button leaveRoom;

    public void Start()
    {
        Button lR = leaveRoom.GetComponent<Button>();
        lR.onClick.AddListener(loadLevel);
    }

    public void loadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
