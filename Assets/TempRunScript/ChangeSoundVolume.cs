using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// "AudioSource"コンポーネントがアタッチされていない場合アタッチ
[RequireComponent(typeof(AudioSource))]
public class ChangeSoundVolume : MonoBehaviour
{

    public Slider slider;
    AudioSource audioSource;

    public void Start()
    {

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("Volume1");
        slider.value = PlayerPrefs.GetFloat("Volume1");



    }
    public void SoundSliderOnValueChange(float newSliderValue)
    {
        audioSource.volume = newSliderValue;
        PlayerPrefs.SetFloat("Volume1", newSliderValue);
        PlayerPrefs.Save();
    }







}
