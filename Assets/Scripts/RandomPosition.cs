using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 currentPos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(GetRandomPosition(1.5f, 3f), currentPos.y, GetRandomPosition(1.5f, 3f));
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
}
