using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Sound_SE : MonoBehaviour
{
    const int N = 100;
    public static AudioClip[] sound = new AudioClip[N];
    public AudioClip[] sound_se;

    public static AudioSource audioSource_tmp;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource_tmp = audioSource;
        for (int i = 0;i < sound_se.Length;i++)
        {
            sound[i] = sound_se[i];
        }
    }

    public static void AudioStop()
    {
        audioSource_tmp.Stop();
    }

    public static void Hidan()
    {
        audioSource_tmp.PlayOneShot(sound[0]);
    }
    public static void Omake()
    {
        audioSource_tmp.PlayOneShot(sound[1]);
    }
    public static void Jump()
    {
        audioSource_tmp.PlayOneShot(sound[2]);
    }
    public static void Slide()
    {
        audioSource_tmp.PlayOneShot(sound[3]);
    }
    public static void Clear()
    {
        audioSource_tmp.PlayOneShot(sound[4]);
    }
    public static void GameOver()
    {
        audioSource_tmp.PlayOneShot(sound[5]);
    }
    public static void Start_Alarm()
    {
        audioSource_tmp.PlayOneShot(sound[6]);
    }
    public static void Start_Gasagoso()
    {
        audioSource_tmp.PlayOneShot(sound[7]);
    }
    public static void Start_DoorOpen()
    {
        audioSource_tmp.PlayOneShot(sound[8]);
    }
    public static void Start_Clock()
    {
        audioSource_tmp.PlayOneShot(sound[9]);
    }
    public static void End_Run()
    {
        audioSource_tmp.PlayOneShot(sound[10]);
    }
    public static void End_Close()
    {
        audioSource_tmp.PlayOneShot(sound[11]);
    }
    public static void QTE_Slide()
    {
        audioSource_tmp.PlayOneShot(sound[12]);
    }
    public static void QTE_train()
    {
        audioSource_tmp.PlayOneShot(sound[13]);
    }
    public static void QTE_Brake()
    {
        audioSource_tmp.PlayOneShot(sound[14]);
    }
    public static void QTE_WomanScream1()
    {
        audioSource_tmp.PlayOneShot(sound[15]);
    }
    public static void QTE_WomanScream2()
    {
        audioSource_tmp.PlayOneShot(sound[16]);
    }
    public static void QTE_ManScream1()
    {
        audioSource_tmp.PlayOneShot(sound[17]);
    }
    public static void QTE_Shot1()
    {
        audioSource_tmp.PlayOneShot(sound[18]);
    }
    public static void QTE_shot2()
    {
        audioSource_tmp.PlayOneShot(sound[19]);
    }

}
