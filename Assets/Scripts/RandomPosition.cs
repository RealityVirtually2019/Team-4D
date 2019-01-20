using UnityEngine;
using Academy.HoloToolkit.Unity;

public class RandomPosition : Singleton<RandomPosition>
{
    [SerializeField]
    public int numberOfCrates = 3;

    // Start is called before the first frame update
    void Start()
    {
        // Freeze everything
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateCopies()
    {
        Debug.Log("Fuck");
        // Un-Freeze everything
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }

        // Set the bamboo shit to be the right distance
        Transform bamboo = gameObject.transform.GetChild(1);
        MoveCrateToRandom(bamboo);
        float distance = GetDistanceFromCenter(bamboo.position.x, bamboo.position.z);

        // Set the first crate's details
        Transform crate = gameObject.transform.GetChild(0);
        Vector3 currentPos = crate.position;
        MoveCrateToRandom(crate, distance, bamboo);

        // Copy the create N times more
        for (int i = 0; i < numberOfCrates - 1; i++)
        {
            GameObject copy = Instantiate(crate.gameObject);
            MoveCrateToRandom(copy.transform, distance, bamboo);
            copy.transform.parent = gameObject.transform;
        }
    }

    void MoveCrateToRandom(Transform crate, float distance = -1, Transform checkForBamboozle = null)
    {
        float LOW = 1.5f;
        float HIGH = 3f;
        float newX = GetRandomPosition(LOW, HIGH);
        float newZ;
        if (distance == -1)
        {
            newZ = GetRandomPosition(LOW, HIGH);
        } else
        {
            newZ = GetZFromX(newX, distance);
        }
        if (checkForBamboozle != null)
        {
            while (crate.GetComponent<CrateCollider>().isColliding) {
                Debug.Log("Detected collision. Moving");
                newX = GetRandomPosition(LOW, HIGH);
                newZ = GetZFromX(newX, distance);
            }
        }
        crate.position = new Vector3(newX, crate.position.y, newZ);
    }

    float GetRandomPosition(float lower, float higher)
    {
        // https://www.desmos.com/calculator/tn54jy0k35
        float random = Random.Range(-0.5f, 0.5f);
        bool negative = random < 0;
        float higherArea = 2 * (higher - lower) * random;
        float lowerArea = lower;
        if (negative)
        {
            lowerArea = -lowerArea;
        }
        return higherArea + lowerArea;
    }

    float GetDistanceFromCenter(float x, float z)
    {
        return Mathf.Sqrt(Mathf.Pow(x, 2f) + Mathf.Pow(z, 2f));
    }

    float GetZFromX(float x, float distance)
    {
        return Mathf.Sqrt(Mathf.Pow(distance, 2f) - Mathf.Pow(x, 2f));
    }
}
