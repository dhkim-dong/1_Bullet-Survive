using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    public int playerNum;                 // 캐릭터가 가질 정보 유니토 : 1, 유니 : 2

    void Start()                          // SceneLoad이후에도 파괴되지 않고 정보를 넘기 위함
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SelectBoy()               // 남자 캐릭터 선택
    {
        playerNum = 1;
        SceneManager.LoadScene("01_Play");
    }

    public void SelectGirl()              // 여자 캐릭터 선택
    {
        playerNum = 2;
        SceneManager.LoadScene("01_Play");
    }
}
