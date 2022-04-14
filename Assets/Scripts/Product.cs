using UnityEngine;
using UnityEngine.AI;

public class Product : MonoBehaviour
{
    public delegate void ProductAction();
    public static event ProductAction OnProductPicked;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NavMeshAgent>() != null && other.GetComponent<NavMeshAgent>().pathStatus == NavMeshPathStatus.PathComplete)
        {
            OnProductPicked?.Invoke();
        }
    }
}
