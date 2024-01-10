using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




// "AudioSource"コンポーネントがアタッチされていない場合アタッチ
[RequireComponent(typeof(AudioSource))]
public class ChangeVoiceVolume : MonoBehaviour
{
    public Slider slider;
    AudioSource audioSource;

    public AudioClip sound;

    public void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("Voice_Volume");
        slider.value = PlayerPrefs.GetFloat("Voice_Volume");

    }

    public void SoundSliderOnValueChange3(float newSliderValue)
    {
        audioSource.volume = newSliderValue;
        PlayerPrefs.SetFloat("Voice_Volume", newSliderValue);
        PlayerPrefs.Save();
        audioSource.PlayOneShot(sound);
    }

}
