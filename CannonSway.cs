//Created by Oliver Lykken

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSway : MonoBehaviour {

    //The farthest left point to rotate to
    public Transform leftEnd;

    //The farthest right point to rotate to
    public Transform rightEnd;

    //What is being rotated
    public GameObject moveHandle;

    //The speed that the object rotates at
    private float speed = 0.1f;

    void Start () {
        StartCoroutine(MoveCannonLeft(1f/speed));
	}
	
    private IEnumerator MoveCannonLeft(float duration)
    {
        if (duration > 0f)
         {
            float startTime = Time.time;
            float endTime = startTime + duration;
            moveHandle.transform.rotation = rightEnd.rotation;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / duration;
                moveHandle.transform.rotation = Quaternion.Slerp(rightEnd.rotation, leftEnd.rotation, progress);
                yield return null;
            }
        }
        moveHandle.transform.rotation = leftEnd.rotation;
        StartCoroutine(MoveCannonRight(1f / speed));
    }

    private IEnumerator MoveCannonRight(float duration)
    {
        if (duration > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + duration;
            moveHandle.transform.rotation = leftEnd.rotation;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / duration;
                moveHandle.transform.rotation = Quaternion.Slerp(leftEnd.rotation, rightEnd.rotation, progress);
                yield return null;
            }
        }
        moveHandle.transform.rotation = rightEnd.rotation;
        StartCoroutine(MoveCannonLeft(1f / speed));
    }
}
