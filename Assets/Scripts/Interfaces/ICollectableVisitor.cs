public interface ICollectableVisitor
{
    void Visit(Coin coin);
    void Visit(Healer healer);
}