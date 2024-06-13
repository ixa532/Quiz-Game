using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
   
    [SerializeField] private Quiz[] quizList;
    [SerializeField] private Quiz currentQuiz;
    private int rightAnswers;
    [SerializeField] Quiz.Dificulty dificulty;
    [SerializeField] Quiz.Theme theme;



    public void SelectQuiz(Quiz.Theme themeSelected, Quiz.Dificulty dificultySelected)
    {
        Quiz quiz = quizList[Random.Range(0, quizList.Length)];
        if (quiz.GetDificulty == dificultySelected && quiz.GetTheme == themeSelected)
        {
            currentQuiz = quiz;
            UIManager.instance.UpdateQuestion(currentQuiz);
        }
        else
        {
            SelectQuiz(themeSelected, dificultySelected);
        }
    }
        #region Singleton
        public static QuizManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public void CheckAnswer (int answerSelected)
    {
        if (answerSelected == currentQuiz.CorrectAnswer)
        {
            rightAnswers++;
        }
        else
        {
            GameManager.instance.GameOver();
        }

        UIManager.instance.HighlightButton(currentQuiz.CorrectAnswer, answerSelected);
    }
}
