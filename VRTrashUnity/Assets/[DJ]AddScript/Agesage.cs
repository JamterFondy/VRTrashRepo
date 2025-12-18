using UnityEngine;

public class UpDownMotion : MonoBehaviour
{
    public float amplitude = 1.0f;   // è„â∫ÇÃïù
    public float speed = 1.0f;       // ìÆÇ≠ë¨Ç≥

    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        float newY = startY + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}