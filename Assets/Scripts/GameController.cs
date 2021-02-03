using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Назначение цвета для спавна")]
    [SerializeField]
    Color[] colorSpawn;
    [Header("Спрайты и точки для спавна")]
    [SerializeField]
    Sprite[] objectsToSpawn;

    

    [SerializeField]
    GameObject[] pointsToSpawn;

    Dictionary<string, int> colors = new Dictionary<string, int>(4);

    int mistakes = 0;

    

    void Start()
    {
        colors.Add( "yellow", 0);
        colors.Add( "red", 0);
        colors.Add( "black", 0);
        colors.Add( "white", 0);

        SpawnSprites();
    }
    // Спавн объектов
    void SpawnSprites()
    {
        for (int i = 0; i < pointsToSpawn.Length; i++)
        {
            Sprite spawnObject = objectsToSpawn[Random.Range(0, 3)];
            pointsToSpawn[i].GetComponent<SpriteRenderer>().sprite = spawnObject;
            int randomNumber = Random.Range(0,3);
            int count = 0;
            
            pointsToSpawn[i].GetComponent<SpriteRenderer>().color = colorSpawn[randomNumber];
            switch (randomNumber)
            {
                case 0:
                    count = colors["yellow"];
                    colors["yellow"] = count + 1;
                    pointsToSpawn[i].tag = "yellow";
                    break;
                case 1:
                    count = colors["red"];
                    colors["red"] = count + 1;
                    pointsToSpawn[i].tag = "red";
                    break;
                case 2:
                    count = colors["black"];
                    colors["black"] = count + 1;
                    pointsToSpawn[i].tag = "black";
                    break;
                case 3:
                    count = colors["white"];
                    colors["white"] = count + 1;
                    pointsToSpawn[i].tag = "white";
                    break;
                default:
                    Debug.Log("no");
                    break;
            }
        }
        if (colors["yellow"] == colors["red"] | colors["yellow"] == colors["black"] | colors["yellow"] == colors["white"])
        {
            Debug.Log("1");
            SpawnSprites();
        }
        
    }

    void Update()
    {
        Debug.Log(colors["yellow"]);
        Debug.Log(colors["red"]);
        Debug.Log(colors["black"]);
        Debug.Log(colors["white"]);
        
        if (colors["yellow"] == 0 & colors["red"] == 0 & colors["black"] == 0 &  colors["white"] == 0)
        {
            Debug.Log("dsadasjhfdhslkj");
        }
        
        
    }
    // Уничтожение объектов
    public void DestroyObjects(string value)
    {
        GameObject[] allObjectDestroy;
        switch (value)
        {
            case "yellow":
                if (colors["yellow"] > colors["red"] & colors["yellow"] > colors["black"] & colors["yellow"] > colors["white"])
                {
                    allObjectDestroy = GameObject.FindGameObjectsWithTag("yellow");
                    for (int i = 0; i < allObjectDestroy.Length; i++)
                    {
                        Destroy(allObjectDestroy[i]);

                    }
                    colors["yellow"] = 0;
                }
                break;
            case "red":
                if (colors["red"] > colors["yellow"] & colors["red"] > colors["black"] & colors["red"] > colors["white"])
                {
                    allObjectDestroy = GameObject.FindGameObjectsWithTag("red");
                    for (int i = 0; i < allObjectDestroy.Length; i++)
                    {
                        Destroy(allObjectDestroy[i]);
                    }
                    colors["red"] = 0;
                }
                break;
            case "black":
                if (colors["black"] > colors["red"] & colors["black"] > colors["yellow"] & colors["black"] > colors["white"])
                {
                    allObjectDestroy = GameObject.FindGameObjectsWithTag("black");
                    for (int i = 0; i < allObjectDestroy.Length; i++)
                    {
                        Destroy(allObjectDestroy[i]);
                    }
                    colors["black"] = 0;
                }
                break;
            case "white":
                if (colors["white"] > colors["red"] & colors["white"] > colors["black"] & colors["white"] > colors["yellow"])
                {
                    allObjectDestroy = GameObject.FindGameObjectsWithTag("white");
                    for (int i = 0; i < allObjectDestroy.Length; i++)
                    {
                        Destroy(allObjectDestroy[i]);
                    }
                    colors["white"] = 0;
                }
                break;
            default:
                mistakes += 1;
                break;
        }

    }
    // Перезапуск игры
    void ReloadGame()
    {

    }
}
