using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    public float rotationSpeed = 100f; // D�nme h�z�

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
