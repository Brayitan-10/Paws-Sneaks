using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
    public GameObject panelOpciones;
    public Slider sliderMusic, sliderSounds;
    public AudioMixer audioMixer;
    public Toggle toggle60FPS, toggle90FPS, toggle120FPS, togglePantallaCompleta, toggleVentana;
    public AudioSource audioSource;
    public AudioClip audioClip;
    
    private int fpsActual;
    private void Start()
    {
        toggle60FPS.isOn = PlayerPrefs.GetInt("FPS", 60) == 60;
        toggle90FPS.isOn = PlayerPrefs.GetInt("FPS", 60) == 90;
        toggle120FPS.isOn = PlayerPrefs.GetInt("FPS", 60) == 120;
        togglePantallaCompleta.isOn = Screen.fullScreen;
        toggleVentana.isOn = !Screen.fullScreen;

        CambiarFPS();
        CambiarModoPantalla();
    }
    private void Awake()
    {
        sliderMusic.onValueChanged.AddListener(SetVolumeMusic);
        sliderSounds.onValueChanged.AddListener(SetVolumeSound);
    }
    public void MostrarOpciones()
    { 
        panelOpciones.SetActive(true);
        ButtonSound();
    }
    public void OcultarOpciones()
    {
        panelOpciones.SetActive(false);
    }
    public void SetVolumeMusic(float sliderV)
    {
        audioMixer.SetFloat("VolMusic", sliderV);
    }
    public void SetVolumeSound(float sliderV)
    {
        audioMixer.SetFloat("VolSounds", sliderV);
    }
    public void CambiarFPS()
    {
        if (toggle60FPS.isOn)
        {
            Application.targetFrameRate = 60;
            fpsActual = 60;
        }
        else if (toggle90FPS.isOn)
        {
            Application.targetFrameRate = 90;
            fpsActual = 90;
        }
        else if (toggle120FPS.isOn)
        {
            Application.targetFrameRate = 120;
            fpsActual = 120;
        }
        PlayerPrefs.SetInt("FPS", fpsActual);
    }
    public void CambiarModoPantalla()
    {
        Screen.fullScreen = togglePantallaCompleta.isOn;
        PlayerPrefs.SetInt("PantallaCompleta", Screen.fullScreen ? 1 : 0);
    }
    public void ButtonSound()
    {
        audioSource.PlayOneShot(audioClip);
    }
}