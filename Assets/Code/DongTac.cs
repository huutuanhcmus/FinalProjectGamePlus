using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DongTac : MonoBehaviour
{
    public GameObject curIndex;
    public GameObject character;
    public float speed = 200.0f;
    bool flag;
    bool flag1;
    bool flag2;
    Vector4[] scale;
    // Start is called before the first frame update
    void Start()
    {
        flag = true;
        flag1 = false;
        flag2 = false;
        scale = new Vector4[11];
        scale[0] = new Vector4(0, 1, 1, 1);
        scale[1] = new Vector4(0, 0.7f, 0.7f, 0.7f);
        scale[2] = new Vector4(0, 0.4f, 0.4f, 0.4f);
        scale[3] = new Vector4(182, 2, 2, 2);
        scale[4] = new Vector4(0, 0.4f, 0.4f, 0.4f);
        scale[5] = new Vector4(0, 1, 1, 1);
        scale[6] = new Vector4(0, 0.5f, 0.5f, 0.5f);
        scale[7] = new Vector4(0, 1f, 1f, 1f);
        scale[8] = new Vector4(0, 0.5f, 0.5f, 0.5f);
        scale[9] = new Vector4(182, 1.7f, 1.7f, 1.7f);
        scale[10] = new Vector4(182, 0.7f, 0.7f, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time % 30);
        if ((Time.time)%30 >= 27 && Time.time % 30 <= 29)
            character.gameObject.transform.GetChild(4).GetComponent<Transform>().Rotate(Vector3.up * speed * Mathf.Sin(Time.time * 10));
        if ((Time.time) % 60 > 10 && (Time.time) % 60 < 11)
            flag1 = true;
        if (flag1)
        {
            character.gameObject.transform.GetChild(4).GetChild(0).GetComponent<Transform>().localScale = Vector3.MoveTowards(character.gameObject.transform.GetChild(4).GetChild(0).GetComponent<Transform>().transform.localScale, new Vector3(scale[curIndex.GetComponent<ChangeCharacter>().indexCur].y * 2, scale[curIndex.GetComponent<ChangeCharacter>().indexCur].z * 2, scale[curIndex.GetComponent<ChangeCharacter>().indexCur].w * 2), Time.deltaTime * 0.3f);
            if (character.gameObject.transform.GetChild(4).GetChild(0).GetComponent<Transform>().localScale.y == scale[curIndex.GetComponent<ChangeCharacter>().indexCur].y*2)
            {
                flag1 = false;
            }
        }
        else
        {
            character.gameObject.transform.GetChild(4).GetChild(0).GetComponent<Transform>().localScale = Vector3.MoveTowards(character.gameObject.transform.GetChild(4).GetChild(0).GetComponent<Transform>().transform.localScale, new Vector3(scale[curIndex.GetComponent<ChangeCharacter>().indexCur].y, scale[curIndex.GetComponent<ChangeCharacter>().indexCur].z, scale[curIndex.GetComponent<ChangeCharacter>().indexCur].w), Time.deltaTime * 0.3f);
            
        }
        if ((Time.time) % 120 > 45 && (Time.time) % 120 < 46){
            flag2 = true;
        }
        if (flag2)
        {
            character.gameObject.transform.GetChild(4).GetComponent<Transform>().localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            character.gameObject.transform.GetChild(4).GetChild(0).GetComponent<Transform>().localRotation = Quaternion.Euler(0.0f, 205.0f, 0.0f);
            character.gameObject.transform.GetChild(4).GetChild(0).GetComponent<Transform>().localPosition = Vector3.MoveTowards(character.gameObject.transform.GetChild(4).GetChild(0).GetComponent<Transform>().localPosition, new Vector3(-10f, -3f, -11f), Time.deltaTime*5);
            if (character.gameObject.transform.GetChild(4).GetChild(0).GetComponent<Transform>().localPosition == new Vector3(-10f, -3f, -11f))
            {
                flag2 = false;
                character.gameObject.transform.GetChild(4).GetChild(0).GetComponent<Transform>().localRotation = Quaternion.Euler(0.0f, 50.0f, 0.0f);
            }
        }
        else
        {
            if (character.gameObject.transform.GetChild(4).GetChild(0).GetComponent<Transform>().localPosition != new Vector3(0,0,0))
            {
                character.gameObject.transform.GetChild(4).GetChild(0).GetComponent<Transform>().localPosition = Vector3.MoveTowards(character.gameObject.transform.GetChild(4).GetChild(0).GetComponent<Transform>().localPosition, new Vector3(0, 0, 0), Time.deltaTime * 5);
                if (character.gameObject.transform.GetChild(4).GetChild(0).GetComponent<Transform>().localPosition == new Vector3(0, 0, 0))
                    character.gameObject.transform.GetChild(4).GetChild(0).GetComponent<Transform>().localRotation = Quaternion.Euler(0.0f, 80.0f, 0.0f); ;
            }
        }
        if (flag) {
            Debug.Log("aaaaaaa");
            character.gameObject.transform.GetChild(4).GetComponent<Transform>().transform.localPosition = Vector3.MoveTowards(character.gameObject.transform.GetChild(4).GetComponent<Transform>().transform.localPosition, new Vector3(0, 0.3f, 0), Time.deltaTime*0.3f); //(character.gameObject.transform.GetChild(4).GetComponent<Transform>().transform.localPosition.x, character.gameObject.transform.GetChild(4).GetComponent<Transform>().transform.localPosition.y + Mathf.Sin(Time.deltaTime), character.gameObject.transform.GetChild(4).GetComponent<Transform>().transform.localPosition.z);
            if (character.gameObject.transform.GetChild(4).GetComponent<Transform>().transform.localPosition.y >= 0.3)
                flag = false;
        }
        else{
            character.gameObject.transform.GetChild(4).GetComponent<Transform>().transform.localPosition = Vector3.MoveTowards(character.gameObject.transform.GetChild(4).GetComponent<Transform>().transform.localPosition, new Vector3(0, -0.3f, 0), Time.deltaTime*0.3f);
            if (character.gameObject.transform.GetChild(4).GetComponent<Transform>().transform.localPosition.y <= 0)
                flag = true;
        }
     }
}
