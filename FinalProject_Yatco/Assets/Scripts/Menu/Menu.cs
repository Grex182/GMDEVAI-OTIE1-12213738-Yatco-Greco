using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GameObject ButtonSoundObject;

    GameObject MenuMusic;

    AudioSource buttonSound;

    public float buttonSoundTimer = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        MenuMusic = GameObject.FindGameObjectWithTag("MenuMusic");
        ButtonSoundObject = GameObject.FindGameObjectWithTag("ButtonSound");
        buttonSound = ButtonSoundObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        DontDestroyOnLoad(ButtonSoundObject.gameObject);
        buttonSound.Play();
        DontDestroyOnLoad(MenuMusic.gameObject);
        SceneManager.LoadScene(0);
    }

    public void GameOverBack()
    {
        buttonSound.Play();
        SceneManager.LoadScene(0);
    }

    public void Controls()
    {
        DontDestroyOnLoad(ButtonSoundObject.gameObject);
        buttonSound.Play();
        DontDestroyOnLoad(MenuMusic.gameObject);
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        buttonSound.Play();
        Application.Quit();
    }

    public void Play()
    {
        DontDestroyOnLoad(ButtonSoundObject.gameObject);
        Destroy(MenuMusic);
        buttonSound.Play();
        SceneManager.LoadScene(2);
    }
}
