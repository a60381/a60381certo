using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;

    // Start is called once before the first frame update
    void Start()
    {
        // Optional initialization
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the object has moved past the top boundary
        if (transform.position.z > topBound)
        {
            Destroy(gameObject); 
        }
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}