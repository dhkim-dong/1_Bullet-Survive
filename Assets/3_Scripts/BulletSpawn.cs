using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    // �ʿ� �Ӽ� : ������ �Ѿ�. �Ѿ� ���� �ֱ�, �Ѿ��� ������ ���

    [SerializeField] private GameObject bulletPrefab;          // �߻��� �Ѿ� ������. �Ѿ��� ������ �پ��ϴٸ� �迭�� ����
    [SerializeField] private float spawnRateMin = 0.5f;        // �Ѿ� ���� �ֱ��� �ּ� �ð�
    [SerializeField] private float spawnRateMax = 3f;          // �Ѿ� ���� �ֱ��� �ִ� �ð�

    private Transform target;                                  // �Ѿ��� ������ ���
    private float spawnRate;                                   // ������ �Ѿ� ���� �ֱ��� ���� ���� spawnRate ����
    private float timeAfterSpawn;                              // �� ������ Time.deltaTime��ŭ �������� spawnRate�� ���� ����

    private void Start()
    {
        timeAfterSpawn = 0f;

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);         // spawnRate�� �ּ� ~ �ִ� ���� Random.Range�� �޾ƿ´�.

        target = FindObjectOfType<PlayerController>().transform;      // target�� ����ڴ� PlayerController�� ���� ��ü. �ش� ������ Player�� �ϳ��̹Ƿ�, �÷��̾� �ϳ��� �Ѵ´�.
    }

    private void Update()
    {
        timeAfterSpawn += Time.deltaTime;                             // �� ������ �ð��� ������Ų��.

        if (timeAfterSpawn >= spawnRate)                               // spawnRate�� �ð��� �ʰ��Ѵٸ�
        {
            timeAfterSpawn = 0;                                       // ���� �ݺ��� ���� 0���� �ʱ�ȭ

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);  // �Ѿ��� �����Ѵ�

            bullet.transform.LookAt(target);  // �Ѿ��� forward �������� �̵��ϱ� ������, ������ ���� target�������� �̵��Ѵ�.

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);     // ���ο� spawnRate ���� �����ϰ� �Է� �޴´�.
        }
    }
}
