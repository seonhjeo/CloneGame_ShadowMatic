
namespace Rotate
{
    public enum RotateTypes
    {
        Revoluter,
        Object
    }
    
    public interface IRotate
    {
        public RotateTypes Type { get; }
        
        /// <summary> Rotate object by giving torque </summary>
        public void RotateObj(float x, float y, float z);
    
        /// <summary> Set object's Rigidbody to activate/deactivate rotation </summary>
        public void ActivateRigidBody(bool active);

        /// <summary> Return progress about object rotation </summary>
        public float ReturnProgress();
    }
}


