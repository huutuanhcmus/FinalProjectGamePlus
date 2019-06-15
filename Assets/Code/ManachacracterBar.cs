using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManachacracterBar : MonoBehaviour
{
    public List<GameObject> gos;
    public GameObject mainChar;
    // Start is called before the first frame update


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
                    mainChar.GetComponent<Transform>().GetChild(6).GetComponent<Canvas>().enabled = false;
                    break;
                }
            }
        }
        else
        {
            transform.localScale = new Vector3(mainChar.GetComponent<Mancharacter>().currentMana / (mainChar.GetComponent<Mancharacter>().showMaxMana * 1.0f), 1, 1);
        }
    }
}
