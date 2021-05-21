using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottom = -20f;

    void Update()
    {
        if (transform.position.y < bottom)
        {
            Destroy(this.gameObject);

            // �������� ������ �� ��������� ApplePicker ������� ������
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            // ������� ������������� ����� AppleDestroyed() �� apScript
            apScript.AppleDestroyed();
        }
    }
}
