using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Settings:")]

    // ������ ��� �������� �����
    public GameObject applePrefab;
    // �������� �������� ������
    public float speed = 10f;
    // ����������, �� ������� ������ ���������� ����������� �������� ������
    public float edges = 24f;
    // ����������� ���������� ��������� ����������� ��������
    public float randomness = 0.02f;
    // ������� �������� ����������� �����
    public float coolDown = 1f;

    private void Start()
    {
        // ���������� ������ ��� � �������
        Invoke("DropApple", coolDown);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", coolDown);
    }

    private void Update()
    {
        // ������� �����������
        Vector3 position = transform.position;
        position.x = position.x + speed * Time.deltaTime;
        transform.position = position;

        // ��������� �����������
        if (position.x > edges) speed = -Mathf.Abs(speed);
        else if (position.x < -edges) speed = Mathf.Abs(speed);
    }

    void FixedUpdate()
    {
        // ��������� ��������� �����������
        if (Random.value == randomness) speed = speed * -1;
    }
}
