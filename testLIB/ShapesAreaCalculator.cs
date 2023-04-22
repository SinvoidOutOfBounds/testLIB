namespace TestLIB
{
    public class ShapesAreaCalculator
    {
    /// <summary>
    /// Вычисляет площадь фигуры (окружности по умолчанию), получая 1 числовое значение и, возможно, имя фигуры
    /// </summary>
    /// <param name="a"></param>
    /// <param name="shapeName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
        public static double Calculate(double a, string shapeName = "none") 
        {
            if (shapeName == "none" || shapeName == "circle")
            {
                var result = Math.PI * Math.Pow(a, 2);
                return result;
            }
            else return 0; 
            //Здесь можно продолжить ветвление для добавления новой фигуры (else if)
            //else throw new ArgumentException("Invalid name of the shape");
        }
    /// <summary>
    /// Вычисляет площадь фигуры (треугольника по умолчанию), получая 3 числовых значения и, возможно, имя фигуры
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <param name="shapeName"></param>
    /// <returns></returns>
        public static double Calculate(double a, double b, double c, string shapeName = "none")
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            c = Math.Abs(c);
            var triangleCheck = CheckTriangleExistenceAndSquareness(a, b, c);
            if (shapeName == "none" || shapeName == "triangle")
            {
                if (triangleCheck != "does not exist")
                {
                    var perimeter = a + b + c;
                    var halfPerimeter = perimeter / 2;
                    var result = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
                    result = Math.Round(result,1);
                    return result;
                }
                else return 0;
                //else throw new ArgumentException("Triangle with given sides does not exist");
            }
            else return 0;
            //else throw new ArgumentException("Invalid name of the shape");
        }
    /// <summary>
    /// Возвращает площадь треугольника и информацию о его прямоугольности
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <param name="shapeName"></param>
    /// <param name="checkSquareness"></param>
    /// <returns></returns>
        public static (double,string) Calculate(double a, double b, double c, string shapeName, string checkSquareness)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            c = Math.Abs(c);
            var triangleCheck = CheckTriangleExistenceAndSquareness(a, b, c);
            if (triangleCheck != "does not exist" && shapeName == "triangle" && checkSquareness == "yes")
            {
                var squareValue = Calculate(a, b, c);
                var result = (square:squareValue,check:triangleCheck);
                return result;
            }
            else return default;
            //else throw new ArgumentException("xd");
        }
    /// <summary>
    /// Возвращает информацию о прямоугольности, или о несуществовании треугольника
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns></returns>
        static string CheckTriangleExistenceAndSquareness(double a, double b, double c)
        {
            var list = new List<double> { a, b, c };
            list.Reverse();
            if (list[0] - list[1] - list[2] > 0 || a == 0 || b == 0 || c == 0)
                return "does not exist";
            else if (Math.Pow(list[0], 2) == (Math.Pow(list[1], 2) + Math.Pow(list[2], 2)))
                return "rectangular";
            else 
                return "not rectangular";
        }
    }
}