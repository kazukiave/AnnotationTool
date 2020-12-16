using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageUtility : MonoBehaviour
{
    public static void LoadImage(Image image, string imagePath)
    {
        //get images rect size
        var imgRect = image.GetComponent<RectTransform>();
        float widthMaxSize = imgRect.sizeDelta.x;
        float heightMaxSize = imgRect.sizeDelta.y;

        //Image texture
        byte[] imageByte = System.IO.File.ReadAllBytes(imagePath);
        Texture2D imageTexture = new Texture2D(2, 2);
        imageTexture.LoadImage(imageByte);

       // Debug.Log("texture dir " + imagePath + " width " + imageTexture.width + " height " + imageTexture.height);

        //resize imageSize;
        if (imageTexture.width > widthMaxSize)
        {
            Vector2 rectSize = ResizeImageWidth(widthMaxSize, imageTexture);
            if (rectSize.y > heightMaxSize)
            {
                image.rectTransform.sizeDelta = ResizeImageHeight(heightMaxSize, imageTexture);
            }
            else
            {
                image.rectTransform.sizeDelta = rectSize;
            }
        }
        if (imageTexture.height > heightMaxSize)
        {
            Vector2 rectSize = ResizeImageHeight(heightMaxSize, imageTexture);
            if (rectSize.x > widthMaxSize)
            {
                image.rectTransform.sizeDelta = ResizeImageWidth(widthMaxSize, imageTexture);
            }
            else
            {
                image.rectTransform.sizeDelta = rectSize;
            }
        }

        //Set a spit
        if (imageTexture.width <= widthMaxSize && imageTexture.height <= heightMaxSize)
        {
            image.rectTransform.sizeDelta = new Vector2(imageTexture.width, imageTexture.height);
        }
        Sprite imageSprit = Sprite.Create(imageTexture, new Rect(0f, 0f, imageTexture.width, imageTexture.height), new Vector2(0.5f, 0.5f));
        image.sprite = imageSprit;
    }

    /// <summary>
    /// 比率を変えずに幅を変えたRectを返す
    /// </summary>
    /// <returns></returns>
    private static Vector2 ResizeImageWidth(float widthMaxSize, Texture2D imageTexture)
    {
        float imageWidth = widthMaxSize;
        float imageHeight = (imageTexture.height * imageWidth) / imageTexture.width;
        return new Vector2(imageWidth, imageHeight);
    }

    /// <summary>
    /// 比率を変えずに高さ変えたRectを返す
    /// </summary>
    /// <returns></returns>
    private static Vector2 ResizeImageHeight(float heightMaxSize, Texture2D imageTexture)
    {
        float imageHeight = heightMaxSize;
        float imageWidth = (imageTexture.width * imageHeight) / imageTexture.height;
        return new Vector2(imageWidth, imageHeight);
    }
}
