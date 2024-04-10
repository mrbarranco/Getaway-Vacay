using UnityEngine;

public class DrawLineBetweenCameras : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public float lineWidth = 0.2f; // Set the width of the line
    public Color lineColor = Color.red; // Set the color of the line
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // Set the number of vertices in the LineRenderer
        lineRenderer.startWidth = lineWidth; // Set the start width of the line
        lineRenderer.endWidth = lineWidth; // Set the end width of the line
        lineRenderer.startColor = lineColor; // Set the start color of the line
        lineRenderer.endColor = lineColor; // Set the end color of the line
    }

    void Update()
    {
        // Update the positions of the LineRenderer to match the positions of the cameras
        lineRenderer.SetPosition(0, camera1.transform.position);
        lineRenderer.SetPosition(1, camera2.transform.position);
    }
}
