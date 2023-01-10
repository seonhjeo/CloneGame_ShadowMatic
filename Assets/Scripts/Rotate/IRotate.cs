using UnityEngine;

namespace Rotate
{
    public enum RotateTypes
    {
        Revoluter,
        Object
    }
    
    public interface IRotate
    {
        RotateTypes Type { get; }
        

        /// <summary> Initiate object's start rotation and set answer rotation </summary>
        void InitObj(Vector3 startRot, Vector3 answerRot);
        
        /// <summary> Rotate object by giving torque </summary>
        void RotateObj(float x, float y, float z);
    
        /// <summary> Set object's Rigidbody and Collider to activate/deactivate rotation </summary>
        void ActivateObject(bool active);

        /// <summary> Return progress about object rotation </summary>
        float ReturnProgress();
    }
}


