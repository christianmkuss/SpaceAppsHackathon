using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class Window_Graph : MonoBehaviour {

    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;

    private void Awake() {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();

        List<double> valueList = new List<double>() {-0.1,0.2,0.3,0.2,0,-0.2,-0.3,-0.4,-0.5,-0.4,-0.3,-0.1,0,0,0,-0.1,0,0.1,0.3,0.7,1.2,1.6,1.9,2.1,2.2,2.1,2.1,2.3,2.5,2.8,3.1,3.4,3.4,3.3,3.3,3.3,3.4,3.7,4.0,4.3,4.5,4.8,5.0,5.2,5.5,5.8,6.0,6.1,6.1,6.1,6.2,6.2,6.2,6.3,6.7,7.1,7.7,8.3,8.9,9.5};
        List<double> tempList = Player.tempList;
        ShowGraph(valueList, tempList);
    }

    private GameObject CreateCircle(Vector2 anchoredPosition) {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private void ShowGraph(List<double> valueList,List<double> tempList) {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 20f;
        float xSize = 8f;

        GameObject lastCircleGameObject1 = null;
        for (int i = 0; i < valueList.Count; i++) {
            float xPosition = xSize + i * xSize;
            float yPosition = ((float)valueList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            if (lastCircleGameObject1 != null) {
                CreateDotConnection(lastCircleGameObject1.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject1 = circleGameObject;
        }

        GameObject lastCircleGameObject2 = null;
        for (int i = 0; i < tempList.Count; i++)
        {
            float xPosition = xSize + i * xSize;
            float yPosition = ((float)tempList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            if (lastCircleGameObject2 != null)
            {
                CreateDotConnection(lastCircleGameObject2.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject2 = circleGameObject;
        }
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB) {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1,1,1, .5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
    }

}
