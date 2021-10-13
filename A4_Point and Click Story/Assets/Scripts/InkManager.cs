using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset _inkJsonAsset;
    private Story _story;

    [SerializeField]
    private Text _textField, _nameField;

    [SerializeField]
    private GameObject _choiceButtonContainer, _dialogueBG;

    [SerializeField]
    private Button _choiceButtonPrefab;

    public Image oldImage;
    public Sprite Joe, mom, friend, Narrator;

    void Start()
    {
        _story = new Story(_inkJsonAsset.text);
        RefreshChoiceView();
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        ///oldImage.sprite = Sprite;
        if (_story.canContinue)
        {
            string text = _story.Continue(); // gets next line

            text = text?.Trim(); // removes white space from text

            _textField.text = text; // displays new text

            List<string> tags = _story.currentTags;

            if (tags.Contains("Joe"))
            {
                _nameField.text = "Joe";
                oldImage.sprite = Joe;
            }
            else if (tags.Contains("mom"))
            {
                _nameField.text = "mom";
                oldImage.sprite = mom;
            }
            else if (tags.Contains("friend"))
            {
                _nameField.text = "friend";
                oldImage.sprite = friend;
            }
            else
            {
                _nameField.text = "Narrator";
                oldImage.sprite = Narrator;
            }
        }
        else if (_story.currentChoices.Count > 0)
        {
            oldImage.sprite = Narrator;
            _textField.text = "";
            DisplayChoices();
        }
        //_dialogueBG.GetComponent<Image>().SourceImage = sprite; 
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
