using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PathUtility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static List<string> GetImgPaths(string srcPath, string extension, bool isShuffle = false)
    {
        var imagePaths = new List<string>();
        imagePaths.AddRange(Directory.GetFiles(srcPath, $"*.{extension}"));

        if (isShuffle)
            imagePaths.Shuffle();

        return imagePaths;
    }
}
