using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class SoundHandler : MonoBehaviour
{
    public float musicFadeSpeed;

    private EventInstance[] sounds = new FMOD.Studio.EventInstance[13];
    private EventInstance music;

    [EventRef]
    public string musicEvent;
    [EventRef]
    public string buttonHard;
    [EventRef]
    public string buttonSoft;
    [EventRef]
    public string menuClose;
    [EventRef]
    public string menuOpen;
    [EventRef]
    public string itemDropHard;
    [EventRef]
    public string itemDropSoft;
    [EventRef]
    public string itemGrab;
    [EventRef]
    public string itemSortCorrect;
    [EventRef]
    public string itemSortWrong;
    [EventRef]
    public string studentArrival;
    [EventRef]
    public string studentHappy;
    [EventRef]
    public string studentMad;
    [EventRef]
    public string itemArrival;

    


    [SerializeField]
    [Range(0f, 1f)]
    private float tempo;
    [SerializeField]
    [Range(0f, 1f)]
    private float intensity;

    public float newIntensity;

    private void Start()
    {
        music = RuntimeManager.CreateInstance(musicEvent);
        sounds[0] = RuntimeManager.CreateInstance(buttonHard);
        sounds[1] = RuntimeManager.CreateInstance(buttonSoft);
        sounds[2] = RuntimeManager.CreateInstance(menuClose);
        sounds[3] = RuntimeManager.CreateInstance(menuOpen);
        sounds[4] = RuntimeManager.CreateInstance(itemDropHard);
        sounds[5] = RuntimeManager.CreateInstance(itemDropSoft);
        sounds[6] = RuntimeManager.CreateInstance(itemGrab);
        sounds[7] = RuntimeManager.CreateInstance(itemSortCorrect);
        sounds[8] = RuntimeManager.CreateInstance(itemSortWrong);
        sounds[9] = RuntimeManager.CreateInstance(studentArrival);
        sounds[10] = RuntimeManager.CreateInstance(studentHappy);
        sounds[11] = RuntimeManager.CreateInstance(studentMad);
        sounds[12] = RuntimeManager.CreateInstance(itemArrival);

        music.start();
        SetMusicIntensity(1);
    }

    private void Update()
    {
        music.setParameterByName("intensity", intensity);
        music.setParameterByName("tempo", tempo);
        newIntensity -= Time.deltaTime * musicFadeSpeed;
        newIntensity = Mathf.Clamp01(newIntensity);
        if (newIntensity > intensity)
        {
            intensity = newIntensity;
        }
        else
        {
            intensity = Mathf.Lerp(intensity, newIntensity, Time.deltaTime /2);
        }


    }

    public void IntensifyMusic()
    {
        newIntensity = Mathf.Clamp01(intensity + 0.3f);
    }
    public void SetMusicIntensity(float _newIntensity)
    {
        intensity = _newIntensity;
    }

    public void PlaySound(int soundIndex)
    {
        sounds[soundIndex].start();
    }
    public void IncrimentTempo()
    {
        tempo += 0.02f;
        music.setParameterByName("tempo", tempo);
    }
}