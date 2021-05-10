using UnityEngine;

public class Bush : MonoBehaviour
{
    [SerializeField] float foliageCutTime;

    private float foliage;
    private bool isBeingCutted;

    private void Start()
    {
        foliage = foliageCutTime;
    }
    #region Collision detections region
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isBeingCutted = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (foliage > 0) foliage -= Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isBeingCutted = false;
    }
    #endregion
    private void Update()
    {
        if (foliage <= foliageCutTime && !isBeingCutted)
            foliage += Time.deltaTime / 3;
    }

}
