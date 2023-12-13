using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MusicPlayer : MonoBehaviour
{
    public AudioClip backgroundMusic; // Аудиофайл для фоновой музыки
    private AudioSource audioSource;

    void Start()
    {
        // Создаем AudioSource на том же объекте, где находится скрипт
        audioSource = gameObject.AddComponent<AudioSource>();

        // Задаем аудиофайл для воспроизведения
        audioSource.clip = backgroundMusic;

        // Настройки воспроизведения
        audioSource.loop = true; // Повторять музыку
        audioSource.playOnAwake = true; // Воспроизводить при старте игры
        audioSource.volume = 0.2f;

        // Начинаем воспроизведение
        audioSource.Play();
    }
}
