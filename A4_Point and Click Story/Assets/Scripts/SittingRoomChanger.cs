using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SittingRoomChanger : MonoBehaviour
{
    public Button sittingRoom;

    public void Start()
    {
        Button sR = sittingRoom.GetComponent<Button>();
        sR.onClick.AddListener(loadSittingRoom);
    }

    public void loadSittingRoom()
    {
        SceneManager.LoadScene(2);
    }
}
