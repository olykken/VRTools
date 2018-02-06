//Created by Oliver Lykken
//Makes the assigned object oscillate between two fixed sizes in "Real Time"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeRunner1 : MonoBehaviour {

    private float _currentScale = InitScale;

    //The larger scale end point
    private const float TargetScale = 1.04f;

    //The smaller scale end point
    private const float InitScale = .985f;

    //The number of frames the transition will happen over altering this alters the speed but this default is good for human breathing
    private const int FramesCount = 100;

    private const float AnimationTimeSeconds = 1;
    private float _deltaTime = AnimationTimeSeconds / FramesCount;
    private float _dx = (TargetScale - InitScale) / FramesCount;
    private bool _upScale = true;
    public Transform runner1;

    private IEnumerator Breath()
    {
        while (true)
        {
            while (_upScale)
            {
                _currentScale += _dx;
                if (_currentScale > TargetScale)
                {
                    _upScale = false;
                    _currentScale = TargetScale;
                }
                runner1.localScale = new Vector3(_currentScale, 0.985f, _currentScale);
                yield return new WaitForSeconds(_deltaTime);
            }

            while (!_upScale)
            {
                _currentScale -= _dx;
                if (_currentScale < InitScale)
                {
                    _upScale = true;
                    _currentScale = InitScale;
                }
                runner1.localScale = new Vector3(_currentScale, 0.985f, _currentScale);
                yield return new WaitForSeconds(_deltaTime);
            }
        }
    }
    private void Start()
    {
        StartCoroutine(Breath());
    }
}
