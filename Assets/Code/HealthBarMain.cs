using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarMain : MonoBehaviour
{
    public Text healthText;
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
                    mainChar.GetComponent<Transform>().GetChild(2).GetComponent<Canvas>().enabled = false;
                    break;
                }
            }
        }
        else
        {
            healthText.text = mainChar.GetComponent<Health>().currentHealth.ToString() + "/" + mainChar.GetComponent<Health>().showMaxHealth.ToString();
            transform.localScale = new Vector3(mainChar.GetComponent<Health>().currentHealth / (mainChar.GetComponent<Health>().showMaxHealth * 1.0f), 1, 1);
        }
    }
}
