using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




// "AudioSource"コンポーネントがアタッチされていない場合アタッチ
[RequireComponent(typeof(AudioSource))]
public class ChangeSEVolume : MonoBehaviour
{

    public Slider slider2;
    AudioSource audioSource2;

    public AudioClip sound1;

    public void Start()
    {

        audioSource2 = gameObject.GetComponent<AudioSource>();
        audioSource2.volume = PlayerPrefs.GetFloat("Volume2");
        slider2.value = PlayerPrefs.GetFloat("Volume2");

    }

    void Update()
    {
        // マウス左
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioSource2.PlayOneShot(sound1);
        }
    }


    public void SoundSliderOnValueChange2(float newSliderValue2)
    {
        audioSource2.volume = newSliderValue2;
        PlayerPrefs.SetFloat("Volume2", newSliderValue2);
        PlayerPrefs.Save();
    }

}
