using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Transform player;
    [SerializeField] public GameObject TextContainer;
    public Vector3 offset;
    void Update()
    {   
        if (TextContainer.activeSelf == true) {
        transform.position = player.position + offset;
        }
        else
        transform.position = new Vector3(-100.0f,-100f,0);
    }
}