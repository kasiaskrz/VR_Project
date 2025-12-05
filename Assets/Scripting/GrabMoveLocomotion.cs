using UnityEngine;


public class GrabMoveLocomotion : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor leftHand;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRDirectInteractor rightHand;

    private bool leftGrabbing;
    private bool rightGrabbing;

    private Vector3 lastLeftHandPos;
    private Vector3 lastRightHandPos;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        leftHand.selectEntered.AddListener(_ => { leftGrabbing = true; lastLeftHandPos = leftHand.transform.position; });
        leftHand.selectExited.AddListener(_ => leftGrabbing = false);

        rightHand.selectEntered.AddListener(_ => { rightGrabbing = true; lastRightHandPos = rightHand.transform.position; });
        rightHand.selectExited.AddListener(_ => rightGrabbing = false);
    }

    void FixedUpdate()
    {
        if (leftGrabbing)
        {
            Vector3 delta = leftHand.transform.position - lastLeftHandPos;
            rb.MovePosition(rb.position - delta);
            lastLeftHandPos = leftHand.transform.position;
        }

        if (rightGrabbing)
        {
            Vector3 delta = rightHand.transform.position - lastRightHandPos;
            rb.MovePosition(rb.position - delta);
            lastRightHandPos = rightHand.transform.position;
        }
    }
}
