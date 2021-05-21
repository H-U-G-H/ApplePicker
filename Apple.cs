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

            // получить ссылку на компонент ApplePicker главной камеры
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            // вызвать общедоступный метод AppleDestroyed() из apScript
            apScript.AppleDestroyed();
        }
    }
}
