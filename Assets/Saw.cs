using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float spinningSpeed;
    [Space(10)]
    [SerializeField] bool isSpinning;

    // Update is called once per frame
    void Update()
    {
        ReadInput();

        if (isSpinning) transform.Rotate(new Vector3(0, spinningSpeed, 0));
    }

    private void ReadInput()
    {
        //Mouse input
        if (Input.GetKey(KeyCode.Mouse0))
        {
            isSpinning = true;
            MoveToClickPosition();
        }
        else isSpinning = false;
    }

    private void MoveToClickPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit rayHit))
        {
            var hitPosition = rayHit.point;
            var destination = new Vector3(hitPosition.x, transform.position.y, hitPosition.z);
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
        }
    }
}
