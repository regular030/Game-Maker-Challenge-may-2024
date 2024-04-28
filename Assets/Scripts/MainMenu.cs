using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string NewGameScene1;
    public string NewGameScene2;
    public string NewGameScene3;
    public string NewGameScene4;
    public string NewGameScene5;
    public string NewGameScene6;
    public string NewGameScene7;
    public string NewGameScene8;
    public string NewGameScene9;
    public string NewGameScene10;
    public string NewGameSceneBackToMain;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Play1()
    {
        SceneManager.LoadScene(NewGameScene1);
    }

    public void Play2()
    {
        SceneManager.LoadScene(NewGameScene2);
    }

    public void Play3()
    {
        SceneManager.LoadScene(NewGameScene3);
    }

    public void Play4()
    {
        SceneManager.LoadScene(NewGameScene4);
    }

    public void Play5()
    {
        SceneManager.LoadScene(NewGameScene5);
    }

    public void Play6()
    {
        SceneManager.LoadScene(NewGameScene6);
    }

    public void Play7()
    {
        SceneManager.LoadScene(NewGameScene7);
    }

    public void Play8()
    {
        SceneManager.LoadScene(NewGameScene8);
    }

    public void Play9()
    {
        SceneManager.LoadScene(NewGameScene9);
    }

    public void Play10()
    {
        SceneManager.LoadScene(NewGameScene10);
    }

    public void PlayMain()
    {
        SceneManager.LoadScene(NewGameSceneBackToMain);
    }

    public void Exit()
    {
        UnityEngine.Application.Quit();
    }
}
