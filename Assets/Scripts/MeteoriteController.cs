using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeteoriteController : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject[] meteorites;
    [SerializeField] private float timeMeteorite;
    [SerializeField] private float meteoriteLimite;
    private float fallenMateorites;
    private float timeNextMeteorite;

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
        timeNextMeteorite += Time.deltaTime;

        if (timeNextMeteorite >= timeMeteorite)
        {
            timeNextMeteorite = 0;
            //Crear enemigo
            CreateMeteorite();
            fallenMateorites++;
            Debug.Log(fallenMateorites);
        }

        LimitStop();
    }

    private void LimitStop()
    {
        if (fallenMateorites == meteoriteLimite)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void CreateMeteorite(){
        int meteoriteNumber = Random.Range(0, meteorites.Length);
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(meteorites[meteoriteNumber], randomPosition, Quaternion.identity);
    }

}
