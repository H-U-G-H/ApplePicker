using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Settings:")]

    // шаблон для создания яблок
    public GameObject applePrefab;
    // скорость движения яблони
    public float speed = 10f;
    // расстояние, на котором должно изменяться направление движения яблони
    public float edges = 24f;
    // вероятность случайного изменения направления движения
    public float randomness = 0.02f;
    // частота создания экземпляров яблок
    public float coolDown = 1f;

    private void Start()
    {
        // сбрасывать яблоки раз в секунду
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
        // простое перемещение
        Vector3 position = transform.position;
        position.x = position.x + speed * Time.deltaTime;
        transform.position = position;

        // изменение направления
        if (position.x > edges) speed = -Mathf.Abs(speed);
        else if (position.x < -edges) speed = Mathf.Abs(speed);
    }

    void FixedUpdate()
    {
        // случайное изменение напрваления
        if (Random.value == randomness) speed = speed * -1;
    }
}
