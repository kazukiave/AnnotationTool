using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridMaker : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] int gridNum;
    private float canvasX;
    private float canvasY;
    // Start is called before the first frame update
    void Start()
    {
        var canvasScaler = canvas.GetComponent<CanvasScaler>();
        canvasX = canvasScaler.referenceResolution.x;
        canvasY = canvasScaler.referenceResolution.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<Vector2> GetGrid(int grdiNum)
    {
        var rtnList = new List<Vector2>();
        var width = Screen.width;
        var height = Screen.height;


        return rtnList;
    }

    private void GetGridPos()
    {
        var rtnList = new List<Vector2>();

        for(int i = 0; i < gridNum; i++)
        {

        }
    }
}
