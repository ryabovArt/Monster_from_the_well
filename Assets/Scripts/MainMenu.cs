using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        AudioManager.instance.PlayMusic("menuMusic");
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Запуск уровня
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Выход из игры
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
