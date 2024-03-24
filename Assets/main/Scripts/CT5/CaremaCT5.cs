using UnityEngine;

public class CaremaCT5 : MonoBehaviour
{
    static public CaremaCT5 instance;
    public void NextPallet()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += 38;
        transform.position = currentPosition;
    }
    private void Awake()
    {
        instance = this;
    }
}
