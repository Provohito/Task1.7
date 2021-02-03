using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject gameController;
    [SerializeField]
    GameObject startGamePanel;
    [SerializeField]
    GameObject mainGamePanel;
    [SerializeField]
    GameObject endGamePanel;
    [SerializeField]
    Text mistakesText;
    GameController gController;
    [SerializeField]
    Text resultText;
    void Start()
    {
        gController = gameController.GetComponent<GameController>();
    }
    void Update()
    {
        if (gController.roundsCount == 1)
        {
            EndGame();
        }
        mistakesText.text = "Ошибочные решения : " + gController.mistakes;
    }
    // функция старта игры
    public void StartGame()
    {
        startGamePanel.SetActive(false);
        mainGamePanel.SetActive(true);
    }
    //Функция конца игры
    void EndGame()
    {
        mainGamePanel.SetActive(false);
        resultText.text = "Ваши результаты таковы : " + gController.mistakes + " неправильных ответов.";
        endGamePanel.SetActive(true);
    }
    // Перезапуск игры
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }
}
