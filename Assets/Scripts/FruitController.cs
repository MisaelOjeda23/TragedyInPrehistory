using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject[] fruits;
    [SerializeField] private float timeFruit;
    private float timeNextFruit;

    private void Start() 
    {
        maxX = float.MinValue;
        minX = float.MaxValue;
        maxY = float.MinValue;
        minY = float.MaxValue;

        foreach (Transform point in points)
        {
            float posX = point.position.x;
            float posY = point.position.y;

            if (posX > maxX) maxX = posX;
            if (posX < minX) minX = posX;
            if (posY > maxY) maxY = posY;
            if (posY < minY) minY = posY;
        }
    }

    private void Update() {
        timeNextFruit += Time.deltaTime;

        if (timeNextFruit >= timeFruit)
        {
            timeNextFruit = 0;
            //Crear enemigo
            CreateFruit();
        }
    }

    private void CreateFruit(){
        int fruitNumber = Random.Range(0, fruits.Length);
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(fruits[fruitNumber], randomPosition, Quaternion.identity);
    }

}