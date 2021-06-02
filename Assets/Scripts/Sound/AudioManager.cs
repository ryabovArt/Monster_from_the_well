using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip sfx_jump, sfx_getStar, sfx_loose;
    public AudioClip level_1Music, menuMusic;

    public GameObject soundObject;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Проигрывание звуковых эффектов
    /// </summary>
    /// <param name="sfxName"> имя звукового эффекта </param>
    public void PlaySFX(string sfxName)
    {
        switch(sfxName)
        {
            case "jump":
                SoundObjectCreation(sfx_jump);
                break;
            case "getStar":
                SoundObjectCreation(sfx_getStar);
                break;
            case "loose":
                SoundObjectCreation(sfx_loose);
                break;
            default:
                break;
        }

    }

    /// <summary>
    /// Создание звукового эффекта на сцене
    /// </summary>
    /// <param name="clip"> имя звукового эффекта </param>
    private void SoundObjectCreation(AudioClip clip)
    {
        GameObject newSound = Instantiate(soundObject, transform);
        newSound.GetComponent<AudioSource>().clip = clip;
        newSound.GetComponent<AudioSource>().Play();
    }

    /// <summary>
    /// Проигрывание фоновой музыки
    /// </summary>
    /// <param name="sfxName"> имя музыкального клипа </param>
    public void PlayMusic(string musicName)
    {
        switch (musicName)
        {
            case "menuMusic":
                MusicObjectCreation(menuMusic);
                break;
            case "level_1Music":
                MusicObjectCreation(level_1Music);
                break;
            default:
                break;
        }

    }

    /// <summary>
    /// Создание музыкального клипа на сцене
    /// </summary>
    /// <param name="clip"> имя музыкального клипа </param>
    private void MusicObjectCreation(AudioClip clip)
    {
        GameObject newSound = Instantiate(soundObject, transform);
        newSound.GetComponent<AudioSource>().clip = clip;
        newSound.GetComponent<AudioSource>().loop = true;
        newSound.GetComponent<AudioSource>().Play();
    }
}
