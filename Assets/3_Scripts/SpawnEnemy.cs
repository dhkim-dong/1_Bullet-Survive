using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] enemyPos;       // Level ���� Enemy�� ������ ��ġ�� �ٸ��� �ϱ� ���ؼ� �迭�� ���� ��ġ�� ����
    public GameObject enemyPrefab;     // BulletSpawner�� �������� �ҷ��ɴϴ�.

    public int gameLevel;              // ���� Game�� Level�Դϴ�.
    private int maxLevel;              // Game�� �ִ� Level�Դϴ�. gameLevel�� maxLevel�� �ʰ��� �� �����ϴ�.
    public float levelUpTime;          // �������� �ϱ� ���� �ʿ� �ð��Դϴ�.
    public float timeDefault;          // levelUpTime�� üũ�ϴ� �ð��Դϴ�.

    public bool isLvUp;                // ���� ������ üũ�ϴ� Bool �����Դϴ�.
    public Text lvTxt;                 // Level UI ��� text�Դϴ�.

    public float speed = 8f;           // �Ѿ��� �ӵ� ���Դϴ�.

    void Start()
    {
        gameLevel = 1;
    }

    void Update()
    {
        lvTxt.text = "Level : " + gameLevel;                     // UI ���

        timeDefault += Time.deltaTime;                           // Time Check

        if(timeDefault >= levelUpTime)                           // ���� �ð��� ������ Level�� ����
        {
            timeDefault = 0f;

            gameLevel++;
            isLvUp = true;
        }

        if (isLvUp)                                              // ������ ���� �� ���
        {
            if(gameLevel % 2 == 0)                               // ¦�� �������� Enemy�� 1 �߰�
            {
                Instantiate(enemyPrefab, enemyPos[(gameLevel - 2)%4].position, Quaternion.identity);
                isLvUp = false;
            }
            else                                                 // Ȧ�� ���� ���� Bullet �ӵ� ����
            {
                speed += 1f;
                isLvUp = false;
            }
        }
    }
}
