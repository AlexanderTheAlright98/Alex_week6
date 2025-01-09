using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class Volume : MonoBehaviour
{
    public Slider musicVol;

    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().volume = musicVol.value;
    }
}
