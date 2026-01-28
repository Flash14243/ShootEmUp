using System;
using UnityEngine;

namespace ShootEmUp.Level
{
    public sealed class LevelBackground : MonoBehaviour
    {
        private float _startPositionY;

        private float _endPositionY;

        private float _movingSpeedY;

        private float _positionX;

        private float _positionZ;

        private Transform _myTransform;

        [SerializeField]
        private Params mParams;

        private void Awake()
        {
            _startPositionY = mParams.mStartPositionY;
            _endPositionY = mParams.mEndPositionY;
            _movingSpeedY = mParams.mMovingSpeedY;
            _myTransform = transform;
            var position = _myTransform.position;
            _positionX = position.x;
            _positionZ = position.z;
        }

        private void FixedUpdate()
        {
            if (_myTransform.position.y <= _endPositionY)
            {
                _myTransform.position = new Vector3(
                    _positionX,
                    _startPositionY,
                    _positionZ
                );
            }

            _myTransform.position -= new Vector3(
                0f,
                _movingSpeedY * Time.fixedDeltaTime,
                0f
            );
        }

        [Serializable]
        public sealed class Params
        {
            [SerializeField]
            public float mStartPositionY;

            [SerializeField]
            public float mEndPositionY;

            [SerializeField]
            public float mMovingSpeedY;
        }
    }
}