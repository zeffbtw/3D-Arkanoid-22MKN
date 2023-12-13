using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 direction;

    void Start()
    {
        // Задаем случайное направление при старте
        SetRandomDirection();
    }

    void Update()
    {
        // Двигаем шар в текущем направлении с постоянной скоростью
        transform.Translate(direction * speed * Time.deltaTime);

        // Запрещаем движение по оси Y
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }

    void SetRandomDirection()
    {
        // Генерируем случайное направление в горизонтальной плоскости
        float randomAngle = Random.Range(40f, 140f);
        direction = new Vector3(Mathf.Cos(randomAngle * Mathf.Deg2Rad), 0f, Mathf.Sin(randomAngle * Mathf.Deg2Rad)).normalized;
    }

    void OnCollisionEnter(Collision collision)
    {
        // При столкновении с другим объектом отражаем направление без изменения длины вектора
        Vector3 reflection = Vector3.Reflect(direction, collision.contacts[0].normal).normalized;
        direction = new Vector3(reflection.x, 0f, reflection.z);
    }
}
