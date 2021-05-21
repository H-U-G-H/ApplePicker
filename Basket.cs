using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dinamically")]
    public Text scoreGT;

    private void Start()
    {
        // �������� ������ �� ������� ������ ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // �������� ��������� Text ����� �������� �������
        scoreGT = scoreGO.GetComponent<Text>();
        // ���������� ��������� ����� ����� ������ 0
        scoreGT.text = "0";
    }

    private void Update()
    {
        // �������� ������� ���������� ��������� ���� �� ������ �� Input
        Vector3 mousePosition2D = Input.mousePosition;

        // ���������� Z ������ ����������, ��� ������ ��������� ��������� ����
        mousePosition2D.z = -Camera.main.transform.position.z;

        // ������������� ����� � ��������� ����������
        Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(mousePosition2D);

        // ����������� ������� ����� ��� X � ���������� X ��������� ����
        Vector3 position = this.transform.position;
        position.x = mousePosition3D.x;
        this.transform.position = position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �������� ������, �������� � ��� �������
        GameObject go = collision.gameObject;
        if (go.tag == "Apple") Destroy(go);

        // ������������� ����� � scoreGT � ����� �����
        int score = int.Parse(scoreGT.text);
        // �������� ���� �� ��������� ������
        score++;
        // ������������� ����� ������� � ������ � ������� �� �����
        scoreGT.text = score.ToString();

        // ��������� ������ ����������
        if (score > HighScore.score) HighScore.score = score;

        // ���������� ������ ���������
        GameObject tree = GameObject.FindGameObjectWithTag("AppleTree");
        AppleTree script = tree.GetComponent<AppleTree>();
        if(score >= 10)
        {
            script.speed = 25f;
            script.coolDown = 0.5f;
        }

        if (score >= 50)
        {
            script.speed = 50f;
            script.coolDown = 0.25f;
        }
        if (score >= 100)
        {
            script.speed = 100f;
            script.coolDown = 0.02f;
        }
    }
}
