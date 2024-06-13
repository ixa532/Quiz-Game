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

        for (int i = 0; i < answersButtons.Lenght; i++) ;
        {
            int x = i;
            answersButtons[i].onClick.AddListener(() => QuizManager.instance.CheckAnswer(x));
            answersButtons[i].onClick.Listener(() => nestButton.interactable = true);
        }
    }
        
    public void UpdateQuestion(Quiz quizSelected)
    {

        for(int i = 0; i < answersButtons.Length; i++)
        {
            answersButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = quizSelected.Answers[i]; // iterador é o controlador do for
            answersButtons[i].GetComponent<Image>().color = Color.white;
        }
        
    }


    public void SetMenu(bool active)
    { 
        menuPanel.SetActive(active);
    }
}
