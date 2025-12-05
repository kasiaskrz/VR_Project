using UnityEngine;
using UnityEngine.XR;

public class VRMovementWithRotation : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 60f; // Degrees per second
    public float deadzone = 0.15f; // Ignore small thumbstick movements
    public bool invertRotation = false; // Invert right/left if needed
    
    void Update()
    {
        HandleSmoothRotation();
    }
    
    void HandleSmoothRotation()
    {
        // Get right thumbstick input
        var rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (rightHand.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 rightStick))
        {
            // Apply deadzone
            if (Mathf.Abs(rightStick.x) < deadzone)
                return;
            
            // Calculate rotation amount
            float rotationInput = rightStick.x;
            if (invertRotation) rotationInput = -rotationInput;
            
            float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;
            
            // Apply smooth rotation to the player (not the camera)
            transform.Rotate(0, rotationAmount, 0);
        }
    }
    
    // Public method to adjust settings at runtime
    public void SetRotationSpeed(float newSpeed)
    {
        rotationSpeed = newSpeed;
    }
}