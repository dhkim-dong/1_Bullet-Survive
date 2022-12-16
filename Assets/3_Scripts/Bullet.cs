using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // �ʿ� �Ӽ� : �Ѿ��� �ӵ�
    private Rigidbody bulletRigid; 

    private SpawnEnemy bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = FindObjectOfType<SpawnEnemy>();                  // �ʿ� ������Ʈ ã��
        bulletRigid = GetComponent<Rigidbody>();                       // GameObject�� Rigidbody ã��
        bulletRigid.velocity = transform.forward * bulletSpeed.speed;  // ���� �� �Ѿ��� ���� �������� �̵�

        Destroy(gameObject, 3f);                                       // ���� �� 3�� �� �ı�
    }

    private void OnTriggerEnter(Collider other)                        // �浹 Ʈ����
    {
        if(other.tag == "Player")                                      // Tag�� �÷��̾� �ΰ���?
        {
            PlayerController player = other.GetComponent<PlayerController>();  // PlayerController Ŭ������ ���� ���� player

            if(player != null)    // PlayerController class�� ���ٸ� �������� �� �� (����ڵ�)
            {
                player.Die();     // ��� �޼��� ����
            }
        }
    }
}
