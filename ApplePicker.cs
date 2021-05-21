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
        // удалить все упавшие €блоки
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in apples) Destroy(apple);

        // получить индекс последней корзины
        int basketIDX = baskets.Count - 1;
        // получить ссылку на этот игровой объект
        GameObject basket = baskets[basketIDX];
        // исключить корзину из списка и удалить сам игровой объект
        baskets.RemoveAt(basketIDX);
        Destroy(basket);

        // если корзин не осталось, перезапустить игру
        if (baskets.Count == 0) SceneManager.LoadScene("Difficulty (Start)");
    }
}
