using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMusic : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        TitleMusic.instance.GetComponent<AudioSource>().Pause();
    }
}
