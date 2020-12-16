using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JsonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var test = new Test()
        {
            test0 = 0,
            test1 = "nya"
        };
        string json = JsonUtility.ToJson(test);
        Debug.Log(json);
        var Test = JsonUtility.FromJson<Test>(json);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class Test
{
    public int test0;
    public string test1;
}