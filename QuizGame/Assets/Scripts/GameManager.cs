using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
   
    #endregion 

    Quiz.Dificulty dificulty;
    Quiz.Theme theme;

    QuizManager quizManager;
    private void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
    }
    //Inicia o jogo quando o botão iniciar do menu for precionado
    public void StartGame(int dificultySelected, int themeSelected)
    {
        //Fechar a janela do Menu
        UIManager.instance.SetMenu(false);
        
        //Atualizar a dificuldade e tema selecionado
        dificulty = (Quiz.Dificulty)dificultySelected;
        theme = (Quiz.Theme)themeSelected;
        
        //Solicitar um novo quiz
        quizManager.SelectQuiz(theme, dificulty);
        
    }
    public Quiz.Dificulty Dificulty { get => dificulty; }
    public Quiz.Theme Theme { get => theme;}

    public void GameOver()
    { 
    
    }
   
}

