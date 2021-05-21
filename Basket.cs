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
        // получить ссылку на игровой объект ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // получить компонент Text этого игрового объекта
        scoreGT = scoreGO.GetComponent<Text>();
        // установить начальное число очков равным 0
        scoreGT.text = "0";
    }

    private void Update()
    {
        // получить текущие координаты указател€ мыши на экране из Input
        Vector3 mousePosition2D = Input.mousePosition;

        // координата Z камеры определ€ет, как далеко находитс€ указатель мыши
        mousePosition2D.z = -Camera.main.transform.position.z;

        // преобразовать точку в трЄхмерные координаты
        Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(mousePosition2D);

        // переместить корзину вдоль оси X в координату X указател€ мыши
        Vector3 position = this.transform.position;
        position.x = mousePosition3D.x;
        this.transform.position = position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // отыскать €блоко, попавшее в эту корзину
        GameObject go = collision.gameObject;
        if (go.tag == "Apple") Destroy(go);

        // преобразовать текст в scoreGT в целое число
        int score = int.Parse(scoreGT.text);
        // добавить очки за пойманное €блоко
        score++;
        // преобразовать число обратно в строку и вывести на экран
        scoreGT.text = score.ToString();

        // запомнить высшее достижение
        if (score > HighScore.score) HighScore.score = score;

        // увеличение уровн€ сложности
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
