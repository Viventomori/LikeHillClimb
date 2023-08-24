using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController _spriteShapeController;
    [SerializeField, Range(1f, 400f)] private int distanceLevel = 10;
    [SerializeField, Range(1f, 50f)] private float xMultip = 2f;
    [SerializeField, Range(1f, 50f)] private float yMultip = 2f;
    [SerializeField, Range(0f, 1f)] private float curveSmooth = 0.5f;
    [SerializeField] private float noiseStep = 0.5f;
    [SerializeField] private float bottom = 10f;

    private void OnValidate()
    {
        // Clear existing points
        _spriteShapeController.spline.Clear();

        // Insert the initial point at the start position
        _spriteShapeController.spline.InsertPointAt(0, transform.position);

        // Calculate and insert additional points
        for (int i = 1; i < distanceLevel + 2; i++) // Adjusted loop condition
        {
            Vector3 newPosition = new Vector3(i * xMultip, Mathf.PerlinNoise(0, i * noiseStep) * yMultip);
            _spriteShapeController.spline.InsertPointAt(i, transform.position + newPosition);

            if (i != 1 && i != distanceLevel + 1) // Adjusted conditions
            {
                _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                _spriteShapeController.spline.SetRightTangent(i, Vector3.left * xMultip * curveSmooth);
                _spriteShapeController.spline.SetLeftTangent(i, Vector3.right * xMultip * curveSmooth);
            }
        }

        // Insert bottom points
        _spriteShapeController.spline.InsertPointAt(distanceLevel + 2,
            new Vector3(_spriteShapeController.spline.GetPosition(1).x, transform.position.y - bottom));
        _spriteShapeController.spline.InsertPointAt(distanceLevel + 3,
            new Vector3(transform.position.x, transform.position.y - bottom));
    }
}

