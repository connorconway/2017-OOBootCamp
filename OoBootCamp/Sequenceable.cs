namespace OoBootCamp
{
  public interface Sequenceable<in T>
  {
    bool IsBetterThan(T other);
  }
}