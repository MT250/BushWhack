using System.Collections;
using UnityEngine;

public class Bush : MonoBehaviour
{
    [SerializeField] float foliageCutTime;
    [SerializeField] int cutScore;

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
        {
            isBeingCutted = true;            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var saw = other.GetComponentInParent<Saw>();

            if (foliage > 0 && saw.isSpinning)
            {
                foliage -= Time.deltaTime;
                GameManager.instance.AddScore(Time.deltaTime);
            }
            else isBeingCutted = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isBeingCutted = false;
        }
    }
    #endregion
    private void Update()
    {
        if (foliage <= foliageCutTime && !isBeingCutted)
            foliage += Time.deltaTime / 3;
    }
}
