using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static AudioSource _audioSource;
    public static bool isMuted;
    public void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("BackgroundMusic");
        if (objs.Length > 1)
        {
            for (int i = 0; i < objs.Length - 1; i++) Destroy(objs[i]);
        }
        DontDestroyOnLoad(this.gameObject);
        _audioSource = GetComponent<AudioSource>();
        if (isMuted) _audioSource.mute = true;
        //if (_audioSource == null)
        //{
        //    GameObject[] objs = GameObject.FindGameObjectsWithTag("BackgroundMusic");
        //    if (objs.Length > 1)
        //        Destroy(this.gameObject);

        //    DontDestroyOnLoad(this.gameObject);
        //    _audioSource = GetComponent<AudioSource>();
        //}
        //else return;

    }


}