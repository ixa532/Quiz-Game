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
    [SerializeField]TextMeshProUGUI questionText;

    public void UpdateQuestion(Quiz quizSelected)
    {
        questionText.text = quizSelected.Question;
        
        for(int i = 0; i < answersButtons.Length; i++) // i de iterador, deve começar aribuindo um valor ao i (i variavel)
        {
            answersButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = quizSelected.Answers[i];
        }
    }
}
