using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f; 
    private GameObject removeObstaclesPoint;
    void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y,0);
        
        RemoveObstaclesOutOfBounds();
    }

    public void SetIntanceReference(GameObject point)
    {
        removeObstaclesPoint = point;
    }
    
    private void RemoveObstaclesOutOfBounds()
    {
        if (removeObstaclesPoint.transform.position.x > transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
