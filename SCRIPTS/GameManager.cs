using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText; // Ссылка на текстовое поле для отображения счета
    private int score = 0; // Счетчик очков
    private int remainingBalls; // Количество оставшихся шаров
    public GameObject Sphere;
    public string endGameSceneName;

    void Start()
    {
        // Находим все объекты с тегом "Ball" в начале игры
        remainingBalls = GameObject.FindGameObjectsWithTag("Block").Length;
        UpdateScoreText();
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        // Обработка столкновений с блоками
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject); // Уничтожение блока

            // Дополнительная логика обработки столкновения с блоком

            // Увеличение счета и обновление текстового поля
            score++;
            UpdateScoreText();
            BallDestroyed();
        }

        if (collision.gameObject.CompareTag("Dead")) { EndGame(); }


    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Dead")) { ReloadCurrentScene(); }
    }

    void UpdateScoreText()
    {
        // Обновление текстового поля с текущим счетом
        scoreText.text = "SCORE: " + score;
    }

    // Метод вызывается, когда шар исчезает
    public void BallDestroyed()
    {
        // Уменьшаем количество оставшихся шаров
        remainingBalls--;

        // Проверяем, если количество оставшихся шаров стало равным нулю
        if (remainingBalls == 0)
        {
            // Вызываем метод завершения игры
            EndGame();
        }
    }



    // Метод для перезагрузки текущего уровня
    void ReloadCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void EndGame()
    {
        // Отображаем панель с сообщением о конце игры
        SceneManager.LoadScene(endGameSceneName);
        // Здесь можно добавить другие действия при завершении игры, например, остановка времени или другие обработки.
    }

    // Метод для рестарта игры
    public void RestartGame()
    {
        // Перезагружаем текущую сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

