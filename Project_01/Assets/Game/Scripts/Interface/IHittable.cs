public interface IHittable
{
    void Hit(HitType type, float value);
}
public enum HitType
{
    Push,Damage
}
