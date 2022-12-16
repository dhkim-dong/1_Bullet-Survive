using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 60f;   // ���� ȸ�� �ӵ�

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f); // y�� �������� ���� ȸ��
    }
}
