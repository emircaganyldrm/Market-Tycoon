using UnityEngine;
using UnityEngine.AI;

public class Product : MonoBehaviour
{
    public delegate void ProductAction();
    public static event ProductAction OnProductPicked;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("collided");
        if (other.GetComponent<NavMeshAgent>() != null)
        {
            OnProductPicked?.Invoke();
        }
    }
}
