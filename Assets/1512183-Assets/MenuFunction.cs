using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuFunction : MonoBehaviour
{
    public void PlayGameButton()
    {
        SceneManager.LoadScene(2);
     
    }
    public void OptionsButton()
    {
        SceneManager.LoadScene("Options");

    }
    public void SupportButton()
    {
        SceneManager.LoadScene("Support");

    }
    public void InformationButton()
    {
        SceneManager.LoadScene("Info-Team");

    }
    public void ExitsGameButton()
    {
        Application.Quit(); 
    }
}
