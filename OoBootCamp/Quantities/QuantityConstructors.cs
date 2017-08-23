namespace OoBootCamp.Quantities
{
  public static class QuantityConstructors
  {
    public static RatioQuantity Teaspoons(this double amount) => Unit.Teaspoon.S(amount);
    public static RatioQuantity Teaspoons(this int amount) => Unit.Teaspoon.S(amount);
    public static RatioQuantity Tablespoons(this double amount) => Unit.Tablespoon.S(amount);
    public static RatioQuantity Tablespoons(this int amount) => Unit.Tablespoon.S(amount);
    public static RatioQuantity Ounces(this double amount) => Unit.Ounce.S(amount);
    public static RatioQuantity Ounces(this int amount) => Unit.Ounce.S(amount);
    public static RatioQuantity Cups(this double amount) => Unit.Cup.S(amount);
    public static RatioQuantity Cups(this int amount) => Unit.Cup.S(amount);
    public static RatioQuantity Pints(this double amount) => Unit.Pint.S(amount);
    public static RatioQuantity Pints(this int amount) => Unit.Pint.S(amount);
    public static RatioQuantity Quarts(this double amount) => Unit.Quart.S(amount);
    public static RatioQuantity Quarts(this int amount) => Unit.Quart.S(amount);
    public static RatioQuantity Gallons(this double amount) => Unit.Gallon.S(amount);
    public static RatioQuantity Gallons(this int amount) => Unit.Gallon.S(amount);
    public static RatioQuantity Inches(this double amount) => Unit.Inch.S(amount);
    public static RatioQuantity Inches(this int amount) => Unit.Inch.S(amount);
    public static RatioQuantity Feet(this double amount) => Unit.Foot.S(amount);
    public static RatioQuantity Feet(this int amount) => Unit.Foot.S(amount);
    public static RatioQuantity Yards(this double amount) => Unit.Yard.S(amount);
    public static RatioQuantity Yards(this int amount) => Unit.Yard.S(amount);
    public static RatioQuantity Furlongs(this double amount) => Unit.Furlong.S(amount);
    public static RatioQuantity Furlongs(this int amount) => Unit.Furlong.S(amount);
    public static RatioQuantity Miles(this double amount) => Unit.Mile.S(amount);
    public static RatioQuantity Miles(this int amount) => Unit.Mile.S(amount);
    public static IntervalQuantity Celsius(this double amount) => Unit.Celsius.Es(amount);
    public static IntervalQuantity Celsius(this int amount) => Unit.Celsius.Es(amount);
    public static IntervalQuantity Fahrenheit(this double amount) => Unit.Fahrenheit.S(amount);
    public static IntervalQuantity Fahrenheit(this int amount) => Unit.Fahrenheit.S(amount);
  }
}