using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public static int score = 0;
    
    private void Awake()
    {
        // ���� �������� HighScore ��� ����������, ��������� ���
        if (PlayerPrefs.HasKey("HighScore")) score = PlayerPrefs.GetInt("HighScore");

        // ��������� ������ ���������� HighScore � ���������
        PlayerPrefs.SetInt("HighScore", score);
    }

    private void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;

        // �������� HighScore � PlayerPrefs, ���� ����������
        if(score > PlayerPrefs.GetInt("HighScore")) PlayerPrefs.SetInt("HighScore", score);
    }
}
