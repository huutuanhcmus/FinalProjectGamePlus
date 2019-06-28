using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuSupport : MonoBehaviour
{
    // Start is called before the first frame update
    public void NextButton()
    {
        SceneManager.LoadScene("Test");
    }

    // Update is called once per frame

}
