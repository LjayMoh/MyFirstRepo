using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionDetector : MonoBehaviour
{
    public Rigidbody2D body;

    public GameObject item;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            loadLevel();
        }
    }

    public void loadLevel()
    {
        if (gameObject.name == "Ball")
        {
            SceneManager.LoadScene(1);
        }
        else if (gameObject.name == "Guitar")
        {
            SceneManager.LoadScene(3);
        }
        else if (gameObject.name == "JoyStick")
        {
            SceneManager.LoadScene(4);
        }
        else if (gameObject.name == "Photo Frame")
        {
            SceneManager.LoadScene(5);
        }
        else if (gameObject.name == "SkateBoard")
        {
            SceneManager.LoadScene(6);
        }
        else if (gameObject.name == "Toy Car")
        {
            SceneManager.LoadScene(7);
        }
        else if (gameObject.name == "Trophy")
        {
            SceneManager.LoadScene(8);
        }
    }
}
