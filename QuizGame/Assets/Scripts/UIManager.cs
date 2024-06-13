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

    [SerializeField] Button[] answersButtons;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] GameObject menuPanel;
    [SerializeField] Button startButton;
    [SerializeField] TMP_Dropdown dificultyDropDown, themeDropdown;
    [SerializeField] Button nextButton;

    private void Start()
    {
        startButton.onClick.AddListener(() => GameManager.instance.StartGame(dificultyDropDown.value, themeDropdown.value));
        nextButton.onClick.AddListener(() => QuizManager.instance.SelectQuiz(GameManager.instance.Theme, GameManager.instance.Dificulty));

        for (int i = 0; i < answersButtons.Length; i++)
        {
            int x = i;
            answersButtons[i].onClick.AddListener(() => QuizManager.instance.CheckAnswer(x));
            answersButtons[i].onClick.AddListener(() => nextButton.interactable = true);
        }
    }
        
    public void UpdateQuestion(Quiz quizSelected)
    {

        for(int i = 0; i < answersButtons.Length; i++)
        {
            answersButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = quizSelected.Answers[i]; // iterador � o controlador do for
            answersButtons[i].interactable = true;
            answersButtons[i].GetComponent<Image>().color = Color.white;
        }
        nextButton.interactable = false;
    }

    public void HighlightButton(int correctAnswer, int answerSelected)
    {
        answersButtons[correctAnswer].GetComponent<Image>().color = Color.green;

        if (answerSelected != correctAnswer)
        {
            answersButtons[answerSelected].GetComponent<Image>().color = Color.red;
        }

        for (int i = 0; i < answersButtons.Length; i++)       
        {
            answersButtons[i].interactable = false;
        }
    }

    public void SetMenu(bool active)
    { 
        menuPanel.SetActive(active);
    }
}
