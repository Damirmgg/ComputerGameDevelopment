using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllMenu : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("GameScene");// � �������� �������� ����� �� ������� �������������� �������
    }

    public void ExitGame()
    {
        Debug.Log("���� ���������");
        Application.Quit();
    }
}