using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = 5f;
    public float maxX = 5f;
    public float minX = -5f;

    void Update()
    {
        // Получаем ввод от клавиш
        float horizontalInput = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1f;
        }

        // Вычисляем новую позицию платформы
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;

        // Ограничиваем позицию платформы в пределах maxX и minX
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Применяем новую позицию к платформе
        transform.position = newPosition;
    }
}
