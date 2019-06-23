using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneChange());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(1);
    }
}
