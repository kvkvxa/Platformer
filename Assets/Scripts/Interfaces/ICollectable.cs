public interface ICollectable
{
    void Accept(ICollectableVisitor visitor);
}