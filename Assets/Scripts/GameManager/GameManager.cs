using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject walls;
    private Transform wallsTransform;
    private GameObject playerObject;
    private Transform playerTransform;

    // Platform Generator Variables
    private float spaceBetweenPlatforms = 4.5f; // Hvor langt skal der være mellem platformene på Y aksen
    private float worldWidth = 7.5f; // Verdens bredde - halvdelen af platforms størrelse i X aksen.
    private float placePlatform = 4.0f; // Hvor i Y aksen, skal vi placere en platform
    public GameObject platformPrefab;

    // Use this for initialization
    void Start()
    {
        wallsTransform = walls.transform;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObject.transform;

        StartCoroutine(PlatformGenerator());
    }

    // Update is called once per frame
    void Update()
    {
        if (wallsTransform)
        {
            float playerYPosition = playerTransform.position.y;
            wallsTransform.position = Vector3.Lerp(wallsTransform.position, new Vector3(0, playerYPosition, 0), 0.2f);
        }
    }

    IEnumerator PlatformGenerator()
    {
        PlayerBehaviour pb = playerObject.GetComponent<PlayerBehaviour>();

        // meterCounter - bruges til at tælle på hvornår vi skal placere en ny platform.
        float meterCounter = placePlatform;


        do
        {
            yield return null;

            // Placere platforme

            if (meterCounter >= placePlatform)
            {
                GameObject newPlatform = Instantiate(platformPrefab) as GameObject;
                Transform platTransform = newPlatform.transform;
                platTransform.position = new Vector3(
                    Random.Range(-worldWidth, worldWidth),
                    placePlatform,
                    0);

                placePlatform += spaceBetweenPlatforms;
            }


            meterCounter = pb.transform.position.y + 5.0f;
        } while (pb.isPlayerDead == false);
    }
}
