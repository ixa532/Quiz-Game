using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField]Button[] answersButtons;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] GameObject menuPanel;
    [SerializeField] Button startButton;
    [SerializeField] TMP_Dropdown dificultyDropDown, themeDropdown;

    private void Start()
    {
        startButton.onClick.AddListener(() => GameManager.instance.StartGame(dificultyDropDown.value, themeDropdown.value ));
    }
    public void UpdateQuestion(Quiz quizSelected)
    {
        questionText.text = quizSelected.Question;

        for(int i = 0; i < answersButtons.Length; i++)
        {
            answersButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = quizSelected.Answers[i]; // iterador é o controlador do for
        }
        
    }


    public void SetMenu(bool active)
    { 
        menuPanel.SetActive(active);
    }
}
