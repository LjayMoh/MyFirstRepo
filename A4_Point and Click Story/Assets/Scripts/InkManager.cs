using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class InkManager : MonoBehaviour
{
    [SerializeField]
    public TextAsset _inkJsonAsset;
    public Story _story;

    [SerializeField]
    private GameObject _choiceButtonContainer;

    [SerializeField]
    private Button _choiceButtonPrefab;

    public GameObject joePanel, momPanel, friendPanel, narratorPanel, namePanel;
    public Text joeText, momText, friendText, narratorText, currentTextField, nameField;

   // public string activeObject = "";
    public bool activeConvo = false;

    void Start()
    {
        _story = new Story(_inkJsonAsset.text);
        RefreshChoiceView();
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        DisablePanel();

        if (_story.canContinue)
        {
            string text = _story.Continue(); // gets next line
            text = text?.Trim(); // removes white space from text

            //_textField.text = text; // displays new text

            List<string> tags = _story.currentTags;

            if (tags.Contains("Joe"))
            {
                nameField.text = "Joe";
                currentTextField = joeText;
                joePanel.SetActive(true);
                namePanel.SetActive(true);
            }
            else if (tags.Contains("mom"))
            {
                nameField.text = "mom";
                currentTextField = momText;
                momPanel.SetActive(true);
                namePanel.SetActive(true);

                SceneManager.LoadScene(2);
                if (!activeConvo)
                {
                    currentTextField.text = text;
                }
                else
                {
                    activeConvo = true;
                }
            }
            else if (tags.Contains("friend"))
            {
                nameField.text = "friend";
                currentTextField = friendText;
                friendPanel.SetActive(true);
                namePanel.SetActive(true);
            }
            else
            {
                nameField.text = "Narrator";
                currentTextField = narratorText;
                narratorPanel.SetActive(true);
                namePanel.SetActive(true);
            }

            currentTextField.text = text;
            //if (activeObject == "")
            //{
               // Debug.Log("Nothing to think about");
            //}
            //else
           // {
                //if (!activeConvo)
                //{
                    //_story.ChoosePathString(activeObject);
                    //activeConvo = true;
               // } 
           // }
        }
        else if (_story.currentChoices.Count > 0)
        {
            narratorPanel.SetActive(true);
            DisplayChoices();
        }
        else
        {
            activeConvo = false;
        }
    }

    private void DisablePanel()
    {
        joePanel.SetActive(false);
        momPanel.SetActive(false);
        friendPanel.SetActive(false);
        narratorPanel.SetActive(false);
    }

    private void DisplayChoices()
    {
        // checks if choices are already being displayed
        if (_choiceButtonContainer.GetComponentsInChildren<Button>().Length > 0) return;

        for (int i = 0; i < _story.currentChoices.Count; i++) // iterates through all choices
        {
            var choice = _story.currentChoices[i];
            var button = CreateChoiceButton(choice.text); // creates a choice button

            button.onClick.AddListener(() => OnClickChoiceButton(choice));
        }
    }

    Button CreateChoiceButton(string text)
    {
        // creates the button from a prefab
        var choiceButton = Instantiate(_choiceButtonPrefab);
        choiceButton.transform.SetParent(_choiceButtonContainer.transform, false);

        // sets text on the button
        var buttonText = choiceButton.GetComponentInChildren<Text>();
        buttonText.text = text;

        return choiceButton;
    }

    void OnClickChoiceButton(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index); // tells ink which choice was selected
        RefreshChoiceView(); // removes choices from the screen
        DisplayNextLine();
    }

    void RefreshChoiceView()
    {
        if (_choiceButtonContainer != null)
        {
            foreach (var button in _choiceButtonContainer.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }
}
