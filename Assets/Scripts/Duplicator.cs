using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Duplicator : MonoBehaviour
{
    public GameObject prefab;
    public int objCount;

    // Start is called before the first frame update
    void Start()
    {
        Duplicate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Duplicate()
    {
        for(int i = 0;i < objCount; i++)
        {
            var obj = Instantiate(prefab, transform);
            obj.GetComponent<Image>().color = new Color(0, 0, (float)i / (float)objCount);
        }
    }
}
