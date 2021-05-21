using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Settings:")]
    public GameObject basketPrefab;
    public int quantity = 3;
    public float bottom = -14f;
    public float spacing = 1.25f;
    public List<GameObject> baskets;

    void Start()
    {
        baskets = new List<GameObject>();

        for (int i = 0; i < quantity; i++)
        {
            GameObject basket = Instantiate<GameObject>(basketPrefab);
            Vector3 position = Vector3.zero;
            position.y = bottom + (spacing * i);
            basket.transform.position = position;
            baskets.Add(basket);
        }
    }

   public void AppleDestroyed()
    {
        // ������� ��� ������� ������
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in apples) Destroy(apple);

        // �������� ������ ��������� �������
        int basketIDX = baskets.Count - 1;
        // �������� ������ �� ���� ������� ������
        GameObject basket = baskets[basketIDX];
        // ��������� ������� �� ������ � ������� ��� ������� ������
        baskets.RemoveAt(basketIDX);
        Destroy(basket);

        // ���� ������ �� ��������, ������������� ����
        if (baskets.Count == 0) SceneManager.LoadScene("Difficulty (Start)");
    }
}
