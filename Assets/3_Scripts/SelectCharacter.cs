using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    public int playerNum;                 // ĳ���Ͱ� ���� ���� ������ : 1, ���� : 2

    void Start()                          // SceneLoad���Ŀ��� �ı����� �ʰ� ������ �ѱ� ����
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SelectBoy()               // ���� ĳ���� ����
    {
        playerNum = 1;
        SceneManager.LoadScene("01_Play");
    }

    public void SelectGirl()              // ���� ĳ���� ����
    {
        playerNum = 2;
        SceneManager.LoadScene("01_Play");
    }
}
