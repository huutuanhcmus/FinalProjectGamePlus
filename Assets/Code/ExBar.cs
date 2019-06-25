using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExBar : MonoBehaviour
{
    public Text exText;
    public Text lvText;
    public List<GameObject> gos;
    public GameObject mainChar;

    // Update is called once per frame
    void Update()
    {
        if (mainChar == null)
        {
            gos = new List<GameObject>();
            foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            {
                if (go.name == "MainChar")
                {
                    mainChar = go;
                    mainChar.GetComponent<Transform>().GetChild(2).GetComponent<Canvas>().enabled = false;
                    break;
                }
            }
        }
        else
        {
            lvText.text = mainChar.GetComponent<PlayerController>().lv.ToString();
            exText.text = mainChar.GetComponent<PlayerController>().ex.ToString() + "/" + ((int)(500 * Mathf.Pow(1.1f, mainChar.GetComponent<PlayerController>().lv))).ToString();
            transform.localScale = new Vector3(mainChar.GetComponent<PlayerController>().ex / (500 * Mathf.Pow(1.1f, mainChar.GetComponent<PlayerController>().lv)), 1, 1);
        }
    }
}
