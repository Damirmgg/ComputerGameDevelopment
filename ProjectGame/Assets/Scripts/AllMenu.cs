using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllMenu : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("GameScene");// в кавычках название сцены на которую осуществляется переход
    }

    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }
}