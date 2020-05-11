using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LaserTowerEffects : MonoBehaviour
{
    [SerializeField] private GameObject levelupEffect;
    
    private LineRenderer lineRenderer;
    
    private Color2 startLineRendColor;
    private Color2 endLineRendColor;
    private void Start()
    {
        if (gameObject.GetComponent<LineRenderer>() == null)
        {
            Debug.Log("Add Line Renderer");
        }
        else
        {
            lineRenderer = gameObject.GetComponent<LineRenderer>();
        }

        startLineRendColor = new Color2(lineRenderer.startColor, lineRenderer.endColor);
        endLineRendColor = new Color2(new Color(0,0,0,0), new Color(0,0,0,0));
    }

    public void LookAtTarget(Enemy target)
    {
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.parent.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);
    }
    
    public void DrawLaserLine(Enemy target)
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, target.gameObject.transform.position);

        lineRenderer.DOColor(startLineRendColor, endLineRendColor, 0.5f);
    }

    public void LevelupEffect()
    {
        Instantiate(levelupEffect, transform.position, Quaternion.identity);
    }
}
