using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;

    // Start is called once before the first frame update
    void Start()
    {
        // Optional: Initialization code here
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object forward relative to its local forward direction
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}