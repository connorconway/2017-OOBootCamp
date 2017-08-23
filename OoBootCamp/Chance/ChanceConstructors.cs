namespace OoBootCamp.Chance
{
  public static class ChanceConstructors
  {
    public static Chance Chance(this double fraction) => new Chance(fraction);

    public static Chance Chance(this int wholeNumber) => new Chance(wholeNumber);
  }
}