using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRenderer : MonoBehaviour
{
    public GameObject lifePanel;
    public GameObject character;

    public GameObject hearth;
    public GameObject emptyHearth;
    // Use this for initialization
    void Start()
    {
       
        //lifePanel = GameObject.Find("LifePanel");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cambiarVida()
    {
        CharacterParameters characterInfo = character.GetComponent<CharacterParameters>();
        for (int i=0; i < lifePanel.transform.childCount; i++) {
            Destroy(lifePanel.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < characterInfo.maxLife; i++)
        {
            if (i < characterInfo.life)
            {
                GameObject aux = (GameObject)Instantiate(hearth, lifePanel.transform.position + new Vector3((i * 100) - 100, 0, -5), Quaternion.identity);
                aux.transform.parent = lifePanel.transform;
            }
            else
            {
                GameObject aux = (GameObject)Instantiate(emptyHearth, lifePanel.transform.position + new Vector3((i * 100) - 100, 0, -5), Quaternion.identity);
                aux.transform.parent = lifePanel.transform;
            }
        }
    }
}
