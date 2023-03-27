using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // the player object
    public GameObject player;

    // the maximum x-position for platforms
    public float maxX = 2;

    // the y-position of the last generated platform
    float lastPlatformY = 0;

    // the gap between platforms
    [SerializeField] public float gap = 4;

    // the number of platforms to generate at a time
    int numPlatforms = 10;

    // a counter to keep track of the number of platforms generated
    int platformCounter = 0;

    // a list of platform prefabs
    public List<GameObject> platformPrefabList;

    // a list to store the last generated platforms
    List<GameObject> generatedPlatforms = new List<GameObject>();

    void Start()
    {
        GeneratePlatform();
    }

    void Update()
    {
        // check if the player's y-position has surpassed the y-position of the last generated platform
        if (player.transform.position.y > (lastPlatformY - 100))
        {
            // generate new platforms
            for (int i = 0; i < numPlatforms; i++)
            {
                GeneratePlatform();
                platformCounter++;

                // check if the platform counter has reached 60
                if (platformCounter >= 5)
                {
                    // reset the platform counter
                    platformCounter = 0;

                    // destroy the platforms below the player
                    DestroyPlatformsBelowPlayer();
                }
            }
        }
    }
    // generate a new platform
    void GeneratePlatform()
    {
        // choose a random platform prefab from the platformPrefabList
        GameObject platformPrefab = platformPrefabList[Random.Range(0, platformPrefabList.Count)];

        // create an instance of the platform prefab
        GameObject platform = Instantiate(platformPrefab);

        // set the platform's position
        float x = Random.Range(-maxX, maxX);
        float y = lastPlatformY + gap;
        platform.transform.position = new Vector3(x, y, 0);

        // add the new platform to the list of generated platforms
        generatedPlatforms.Add(platform);

        // set the lastPlatformY variable to the y-position of the new platform
        lastPlatformY = y;
    }

    void DestroyPlatformsBelowPlayer()
    {
        // Create a temporary list to store the platforms that need to be deleted
        List<GameObject> platformsToDelete = new List<GameObject>();

        // loop through the generated platforms
        foreach (GameObject platform in generatedPlatforms)
        {
            // check if the platform is below the player
            if (platform.transform.position.y + 20 < player.transform.position.y)
            {
                // add the platform to the list of platforms to delete
                platformsToDelete.Add(platform);
            }
        }

        // loop through the platforms to delete and destroy them
        foreach (GameObject platform in platformsToDelete)
        {
            Destroy(platform);
            // remove the platform from the generated platforms list
            generatedPlatforms.Remove(platform);
        }
    }

}


   






























/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // the player object
    public GameObject player;

    // the maximum x-position for platforms
    public float maxX = 2;

    // the y-position of the last generated platform
    float lastPlatformY = 0;

    // the gap between platforms
    float gap = 4;

    // the number of platforms to generate at a time
    int numPlatforms = 50;

    // the current platform the player is on
    int currentPlatform = 1;

    // a list of platform prefabs
    public List<GameObject> platformPrefabList;

    void Start()
    {
        GeneratePlatform();
    }

    void Update()
    {
        // check if the player's y-position has surpassed the y-position of the last generated platform
        if (player.transform.position.y > (lastPlatformY - 20))
        {
            // generate new platforms
            for (int i = 0; i < numPlatforms; i++)
            {
                GeneratePlatform();
            }

            // increment the current platform
            currentPlatform++;

            // check if the current platform is 3
            if (currentPlatform == 3)
            {
                // reset the current platform
                currentPlatform = 1;
            }
        }
    }

    // generate a new platform
    void GeneratePlatform()
    {
        // choose a random platform prefab from the platformPrefabList
        GameObject platformPrefab = platformPrefabList[Random.Range(0, platformPrefabList.Count)];

        // create an instance of the platform prefab
        GameObject platform = Instantiate(platformPrefab);

        // set the platform's position
        float x = Random.Range(-maxX, maxX);
        float y = lastPlatformY + gap;
        platform.transform.position = new Vector3(x, y, 0);

        // set the lastPlatformY variable to the y-position of the new platform
        lastPlatformY = y;
    }
}*/










/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // the platform prefab
    public GameObject platformPrefab;

    // the player object
    public GameObject player;

    // the maximum x-position for platforms
    public float maxX = 2;

    // the y-position of the last generated platform
    public float lastPlatformY = 0;

    // the gap between platforms
    float gap = 4;

    // the number of platforms to generate at a time
    int numPlatforms = 50;

    // the current platform the player is on
    public int currentPlatform = 1;

    // a flag to track whether the initial platforms have been generated
    bool generatedInitialPlatforms = false;

    void Start()
    {
        // generate the initial platforms
        if (!generatedInitialPlatforms)
        {
            for (int i = 0; i < numPlatforms; i++)
            {
                GeneratePlatform();
                //lastPlatformY = platformList[0].transform.position.y;
            }

            generatedInitialPlatforms = true;
        }
    }

    void Update()
    {
        // check if the player's y-position has surpassed the y-position of the last generated platform
        if (player.transform.position.y > lastPlatformY)
        {
            // increment the current platform
            currentPlatform++;

            // check if the current platform is 25
            if (currentPlatform == 25)
            {
                // generate new platforms
                for (int i = 0; i < numPlatforms; i++)
                {
                    GeneratePlatform();
                }

                // reset the current platform
                currentPlatform = 1;
            }
        }
    }
    
    // a list to store the generated platforms
    List<GameObject> platformList = new List<GameObject>();

    // generate a new platform
    void GeneratePlatform()
    {
        // create an instance of the platform prefab
        GameObject platform = Instantiate(platformPrefab);

        // set the platform's position
        float x = Random.Range(-maxX, maxX);
        float y = lastPlatformY + gap;
        platform.transform.position = new Vector3(x, y, 0);

        // add the platform to the platformList
        platformList.Add(platform);

        // check if the platformList has at least 25 elements
        if (platformList.Count >= 25) 
        {
            // set the lastPlatformY variable to the y-position of the 25th platform in the platformList
            lastPlatformY = platformList[24].transform.position.y;
        }
    }

}*/















/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // the platform prefab
    public GameObject platformPrefab;

    // the player object
    public GameObject player;

    // the maximum x-position for platforms
    public float maxX = 2;

    // the y-position of the last generated platform
    float lastPlatformY = 0;

    // the gap between platforms
    float gap = 4;

    // the number of platforms to generate at a time
    int numPlatforms = 500;

    // the current platform the player is on
    int currentPlatform = 1;

    void Update()
    {
        // check if the player's y-position has surpassed the y-position of the last generated platform
        if (player.transform.position.y > lastPlatformY)
        {
            // generate new platforms
            for (int i = 0; i < numPlatforms; i++)
            {
                GeneratePlatform();
            }

            // increment the current platform
            currentPlatform++;

            // check if the current platform is 3
            if (currentPlatform == 3)
            {
                // reset the current platform
                currentPlatform = 1;
            }
        }
    }

    // generate a new platform
    void GeneratePlatform()
    {
        // create an instance of the platform prefab
        GameObject platform = Instantiate(platformPrefab);

        // set the platform's position
        float x = Random.Range(-maxX, maxX);
        float y = lastPlatformY + gap;
        platform.transform.position = new Vector3(x, y, 0);

        // set the lastPlatformY variable to the y-position of the new platform
        lastPlatformY = y;
    }
}*/




































/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // Prefab for the platform
    public GameObject platformPrefab;

    // Distance between platforms
    public float platformDistance = 3f;

    // Highest point that the player has reached
    public float highestPoint = 0f;

    // Number of platforms to generate ahead of the player
    public int platformsToGenerate = 5;

    // Number of platforms to keep in the game
    public int platformsToKeep = 5;

    // List of all platforms that have been generated
    private List<GameObject> platforms = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        // Check if the player has exceeded the highest point that has been generated so far
        if (transform.position.y > highestPoint)
        {
            // Generate the next 5 platforms
            for (int i = 0; i < platformsToGenerate; i++)
            {
                Vector3 platformPosition = new Vector3(0, highestPoint + platformDistance * (i + 1), 0);
                GameObject newPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
                platforms.Add(newPlatform);
            }

            // Update the highest point
            highestPoint = platforms[platforms.Count - 5].transform.position.y;

            // If there are more than 10 platforms in the list, delete the oldest 5 platforms
            if (platforms.Count > platformsToKeep)
            {
                for (int i = 0; i < platformsToGenerate - platformsToKeep; i++)
                {
                    Destroy(platforms[i]);
                    platforms.RemoveAt(i);
                }
            }
        }
    }
}*/












/*using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // Prefab for the platform
    public GameObject platformPrefab;

    // Distance between platforms
    public float platformDistance = 3f;

    // Highest point that the player has reached
    public float highestPoint = 0f;

    // Number of platforms to generate ahead of the player
    public int platformsToGenerate = 5;

    // Number of platforms to keep in the game
    public int platformsToKeep = 5;

    // List of all platforms that have been generated
    private List<GameObject> platforms = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        // Check if the player has exceeded the highest point that has been generated so far
        if (transform.position.y > highestPoint)
        {
            // Generate the next 5 platforms
            for (int i = 0; i < platformsToGenerate; i++)
            {
                Vector3 platformPosition = new Vector3(0, highestPoint + platformDistance * (i + 1), 0);
                GameObject newPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
                platforms.Add(newPlatform);
            }

            // Update the highest point
            highestPoint = platforms[platforms.Count - 5].transform.position.y;

            // If there are more than 10 platforms in the list, delete the oldest 5 platforms
            if (platforms.Count > platformsToKeep)
            {
                for (int i = 0; i < platformsToGenerate - platformsToKeep; i++)
                {
                    Destroy(platforms[i]);
                    platforms.RemoveAt(i);
                }
            }
        }
    }
}*/




























/*using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // Prefab for the platform
    public GameObject platformPrefab;

    // Distance between platforms
    public float platformDistance = 3f;

    // Highest point that the player has reached
    public float highestPoint = 3f;

    // Number of platforms to generate ahead of the player
    public int platformsToGenerate = 10;

    // Number of platforms to keep in the game
    public int platformsToKeep = 5;

    // List of all platforms that have been generated
    private List<GameObject> platforms = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        // Check if the player has exceeded the highest point that has been generated so far
        if (transform.position.y > highestPoint)
        {
            // Generate the next 10 platforms
            for (int i = 0; i < platformsToGenerate; i++)
            {
                Vector3 platformPosition = new Vector3(0, highestPoint + platformDistance * (i + 1), 0);
                GameObject newPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
                platforms.Add(newPlatform);
            }

            // Update the highest point
            highestPoint += platformDistance * platformsToGenerate;

            // If there are more than 10 platforms in the list, delete the oldest 5 platforms
            if (platforms.Count > platformsToKeep)
            {
                for (int i = 0; i < platformsToGenerate - platformsToKeep; i++)
                {
                    Destroy(platforms[i]);
                    platforms.RemoveAt(i);
                }
            }
        }
    }
}*/






























































/*using UnityEngine;  WORKS WELL BUT DOESNT DELETE OLD PLATFORMS

public class PlatformGenerator : MonoBehaviour
{
    // Prefab for the platform
    public GameObject platformPrefab;

    // Distance between platforms
    public float platformDistance = 3f;

    // Highest point that the player has reached
    private float highestPoint = -5f;

    // Number of platforms to generate ahead of the player
    public int platformsToGenerate = 5;

    // Reference to the newly generated platform game object
    private GameObject newPlatform;

    // List of the last 10 platforms generated
    private GameObject[] lastPlatforms = new GameObject[10];

    // Update is called once per frame
    void Update()
    {
        // Check if the player has exceeded the highest point that has been generated so far
        if (transform.position.y > highestPoint)
        {
            // Generate the next 5 platforms
            for (int i = 0; i < platformsToGenerate; i++)
            {
                Vector3 platformPosition = new Vector3(0, highestPoint + platformDistance * (i + 1), 0);
                Instantiate(platformPrefab, platformPosition, Quaternion.identity);
            }

            // Update the highest point
            highestPoint += platformDistance * platformsToGenerate;

            // Add the new platform to the list of the last 10 platforms
            for (int i = 0; i < lastPlatforms.Length - 1; i++)
            {
                lastPlatforms[i] = lastPlatforms[i + 1];
            }
            lastPlatforms[lastPlatforms.Length - 1] = newPlatform;

            // If there are more than 10 platforms in the list, delete the oldest 4 platforms
            if (lastPlatforms[0] != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    Destroy(lastPlatforms[i]);
                    lastPlatforms[i] = null;
                }
            }
        }
    }
}*/




















































/*using UnityEngine; THIS WORKS BEST

public class PlatformGenerator : MonoBehaviour
{
    // Prefab for the platform
    public GameObject platformPrefab;

    // Distance between platforms
    public float platformDistance = 3f;

    // Highest point that the player has reached
    private float highestPoint = -5f;

    // Reference to the newly generated platform game object
    private GameObject newPlatform;

    // List of the last 10 platforms generated
    private GameObject[] lastPlatforms = new GameObject[10];

    // Update is called once per frame
    void Update()
    {
        // Check if the player has exceeded the highest point that has been generated so far
        if (transform.position.y > highestPoint)
        {
            // Generate a new platform
            Vector3 platformPosition = new Vector3(0, highestPoint + platformDistance, 0);
            newPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);

            // Update the highest point
            highestPoint = newPlatform.transform.position.y;

            // Add the new platform to the list of the last 10 platforms
            for (int i = 0; i < lastPlatforms.Length - 1; i++)
            {
                lastPlatforms[i] = lastPlatforms[i + 1];
            }
            lastPlatforms[lastPlatforms.Length - 1] = newPlatform;

            // If there are more than 10 platforms in the list, delete the oldest 4 platforms
            if (lastPlatforms[0] != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    Destroy(lastPlatforms[i]);
                    lastPlatforms[i] = null;
                }
            }
        }
    }
}*/






















































/*using UnityEngine;     THIS WORKS PRETTY WELL

public class PlatformGenerator : MonoBehaviour
{
    // Prefab for the platform
    public GameObject platformPrefab;

    // Distance between platforms
    public float platformDistance = 3f;

    // Highest point that the player has reached
    private float highestPoint = -5f;

    // Reference to the newly generated platform game object
    private GameObject newPlatform;

    // Number of platforms that should be generated before destroying an old one
    public int platformsPerDestroy = 10;

    // Counter for the number of platforms generated since the last destroy
    private int platformsGenerated = 0;

    // List of the last 6 platforms generated
    private GameObject[] lastPlatforms = new GameObject[6];

    // Update is called once per frame
    void Update()
    {
        // Check if the player has exceeded the highest point that has been generated so far
        if (transform.position.y > highestPoint)
        {
            // Generate a new platform
            Vector3 platformPosition = new Vector3(0, highestPoint + platformDistance, 0);
            newPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);

            // Update the highest point
            highestPoint = newPlatform.transform.position.y;

            // Increment the platform generation counter
            platformsGenerated++;

            // Add the new platform to the list of the last 6 platforms
            for (int i = 0; i < lastPlatforms.Length - 1; i++)
            {
                lastPlatforms[i] = lastPlatforms[i + 1];
            }
            lastPlatforms[lastPlatforms.Length - 1] = newPlatform;
        }

        // If the counter has reached the threshold, reset it and destroy an old platform
        if (platformsGenerated >= platformsPerDestroy && lastPlatforms[0] != null)
        {
            platformsGenerated = 0;
            Destroy(lastPlatforms[0]);
            for (int i = 0; i < lastPlatforms.Length - 1; i++)
            {
                lastPlatforms[i] = lastPlatforms[i + 1];
            }
            lastPlatforms[lastPlatforms.Length - 1] = null;
        }
    }
}*/
















































/*using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // Prefab for the platform
    public GameObject platformPrefab;

    // Distance between platforms
    public float platformDistance = 3f;

    // Highest point that the player has reached
    private float highestPoint = -5f;

    // Reference to the newly generated platform game object
    private GameObject newPlatform;

    // Number of platforms that should be generated before destroying an old one
    public int platformsPerDestroy = 5;

    // Counter for the number of platforms generated since the last destroy
    private int platformsGenerated = 0;

    // Update is called once per frame
    void Update()
    {
        // Check if the player has exceeded the highest point that has been generated so far
        if (transform.position.y > highestPoint)
        {
            // Generate a new platform
            Vector3 platformPosition = new Vector3(0, highestPoint + platformDistance, 0);
            newPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);

            // Update the highest point
            highestPoint = newPlatform.transform.position.y;

            // Increment the platform generation counter
            platformsGenerated++;

            // If the counter has reached the threshold, reset it and destroy an old platform
            if (platformsGenerated >= platformsPerDestroy)
            {
                platformsGenerated = 0;
                Destroy(newPlatform);
            }
        }
    }
}*/






































/*using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // Prefab for the platform
    public GameObject platformPrefab;

    // Distance between platforms
    public float platformDistance = 3f;

    // Highest point that the player has reached
    private float highestPoint = -5f;

    // Reference to the newly generated platform game object
    private GameObject newPlatform;

    // Distance above the current platform at which the previous platform should be destroyed
    public float destroyDistance = 10f;

    // Update is called once per frame
    void Update()
    {
        // Check if the player has exceeded the highest point that has been generated so far
        if (transform.position.y > highestPoint)
        {
            // Generate a new platform
            Vector3 platformPosition = new Vector3(0, highestPoint + platformDistance, 0);
            newPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);

            // Update the highest point
            highestPoint = newPlatform.transform.position.y;

            // Destroy the previous platform if it is too far below the player
            if (highestPoint - transform.position.y > destroyDistance)
            {
                Destroy(newPlatform);
            }
        }
    }
}*/




























/*using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // Prefab for the platform
    public GameObject platformPrefab;

    // Distance between platforms
    public float platformDistance = 3f;

    // Highest point that the player has reached
    private float highestPoint = -4.3f;

    // Lowest point that the player has reached
    private float lowestPoint = 0f;

    // Reference to the newly generated platform game object
    private GameObject newPlatform;

    // Distance above the lowest point at which the platforms should be destroyed
    public float destroyDistance = 10f;

    // Update is called once per frame
    void Update()
    {
        // Check if the player has exceeded the highest point that has been generated so far
        if (transform.position.y > highestPoint)
        {
            // Generate a new platform
            Vector3 platformPosition = new Vector3(0, highestPoint + platformDistance, 0);
            newPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);

            // Update the highest point
            highestPoint = newPlatform.transform.position.y;
        }

        // Check if the player is a certain distance above the lowest point that has been generated so far
        if (transform.position.y - destroyDistance > lowestPoint)
        {
            // Destroy the platform that is no longer needed
            Destroy(newPlatform);

            // Update the lowest point
            lowestPoint = transform.position.y - destroyDistance;
        }
    }
}*/























/*using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // Prefab for the platform
    public GameObject platformPrefab;

    // Distance between platforms
    public float platformDistance = 3f;

    // Highest point that the player has reached
    private float highestPoint = -5f;

    // Lowest point that the player has reached
    private float lowestPoint = -10f;

    // Reference to the newly generated platform game object
    private GameObject newPlatform;

    // Update is called once per frame
    void Update()
    {
        // Check if the player has exceeded the highest point that has been generated so far
        if (transform.position.y > highestPoint)
        {
            // Generate a new platform
            Vector3 platformPosition = new Vector3(0, highestPoint + platformDistance, 0);
            newPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);

            // Update the highest point
            highestPoint = newPlatform.transform.position.y;
        }

        // Check if the player has fallen below the lowest point that has been generated so far
        if (transform.position.y < lowestPoint)
        {
            // Destroy the platform that is no longer needed
            Destroy(newPlatform);

            // Update the lowest point
            lowestPoint = transform.position.y;
        }
    }
}*/



