using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUpController : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject[] powerUps;
    [SerializeField] private float timePowerUp;
    private float timeNextPowerUp;

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

    private void Update()
    {
        timeNextPowerUp += Time.deltaTime;

        if (timeNextPowerUp >= timePowerUp)
        {
            timeNextPowerUp = 0;
            
            CreatePowerUp();
        }

    }

    private void CreatePowerUp()
    {
        int powerUpNumber = Random.Range(0, powerUps.Length);
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(powerUps[powerUpNumber], randomPosition, Quaternion.identity);
    }

}
