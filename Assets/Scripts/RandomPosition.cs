using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    [SerializeField]
    public int numberOfCrates = 3;

    // Start is called before the first frame update
    void Start()
    {
        Transform crate = gameObject.transform.GetChild(0);
        Vector3 currentPos = crate.position;
        float LOW = 1.5f;
        float HIGH = 3f;
        float newX = GetRandomPosition(LOW, HIGH);
        float newZ = GetRandomPosition(LOW, HIGH);
        float distance = GetDistanceFromCenter(newX, newZ);
        crate.transform.position = new Vector3(newX, currentPos.y, newZ);

        for (int i = 0; i < numberOfCrates - 1; i++)
        {
            GameObject copy = Instantiate(crate.gameObject);
            newX = GetRandomPosition(LOW, HIGH);
            newZ = GetZFromX(newX, distance);
            copy.transform.position = new Vector3(newX, currentPos.y, newZ);
            copy.transform.parent = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
