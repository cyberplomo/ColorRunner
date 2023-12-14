using UnityEngine;

public class CharacterFollower : MonoBehaviour
{
    public Transform target;
    public LineRenderer followerLineRenderer;
    public float forwardSpeed = 5f;
    public float lateralSpeed = 5f;
   	
	private Transform followerTarget; 

    public void SetTarget(Transform newTarget)
    {
        followerTarget = newTarget;
    }


    void Start()
    {
        followerLineRenderer.positionCount = 0;
    }

    void FixedUpdate()
    {
        UpdateFollowerLineRenderer();

        if (target != null)
        {
            MoveTowardsTarget();
            HandleLateralMovement();
        }
    }

    void UpdateFollowerLineRenderer()
    {
        followerLineRenderer.positionCount = 1;
        followerLineRenderer.SetPosition(0, transform.position);
    }

    void MoveTowardsTarget()
    {
        float step = forwardSpeed * Time.deltaTime;
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }

    void HandleLateralMovement()
    {
        float horizontalStep = lateralSpeed * Time.deltaTime;
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * (horizontalInput * horizontalStep), Space.World);
    }
}
