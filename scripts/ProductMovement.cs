using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductMovement : MonoBehaviour
{
    private Transform[] transforms;
    private int nextPositionIndex;
    private float speed = 2f;

    private bool move = false;


    void Update()
    {

        if (!move)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
                transform.position,
                transforms[nextPositionIndex].position,
                speed * Time.deltaTime
            );

        if (Vector3.Distance(transform.position , transforms[nextPositionIndex].position) < 0.2f)
        {
            if (nextPositionIndex < transforms.Length - 1)
            {
                nextPositionIndex++;
            }
        }
    }


    public void SetTrajectory(Transform[] transforms)
    {
        this.transforms = transforms;
        nextPositionIndex = 0;
        move = true;
    }

    public IEnumerator MoveToTarget(Transform target, float speed)
    {
        while (Vector3.Distance(transform.position, target.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                speed * Time.deltaTime
            );

            yield return null; // Wait for the next frame
        }

        // Snap to final position
        transform.position = target.position;
    }


    public void SetMove(bool value)
    {
        move = value;
    }

    public void SetNextPosIndex(int nextPositionIndex)
    {
        this.nextPositionIndex = nextPositionIndex;
    }
}
