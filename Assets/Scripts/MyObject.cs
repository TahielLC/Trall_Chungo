namespace Code
{
    public class MyObject : RecyclableObject
    {
        internal override void Init()
        {
            Invoke(nameof(Recycle), 5);
        }

        internal override void Release()
        {
        }
    }
}
