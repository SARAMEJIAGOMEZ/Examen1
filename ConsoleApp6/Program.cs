using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ConsoleApp6
{
  
    class Program
    {
        static void Main(string[] args)
        {

            List<Type> figuras = new List<Type>()
            {
                typeof(Estrella),
                typeof(Rayo),
                typeof(Corazon)
            };

            var Amarillo = Color.Yellow;
            var Rojo = Color.Red;
            var Negro = Color.Black;
            var Blanco = Color.White;

            var container = new Container(figuras);
            var container1 = new Container(null);


            List<IFiguras> figurasUser = new List<IFiguras>();
            var random = new Random(0);
            for (int i = 0; i < 100; i++)
            {
                var index = random.Next(3);
                var type = figuras[index];

                var figura = Activator.CreateInstance(type) as IFiguras;
                figurasUser.Add(figura);


            }
            foreach (var Figura in figurasUser)
            {
                Console.WriteLine(Figura.ToString());

            }

        }
    }

    public class Container
    {
        readonly IList<Type> _figuras;
        public Container(IList<Type> figuras)
        {
            if (null == figuras)
            {
                throw new ArgumentNullException("figuras");
            }
            _figuras = figuras;
        }
    }
    interface IFiguras
    {
        string ColorFondo { get; set; }
        string ColorBorde { get; set; }

    }

    public class Figura : IFiguras
    {
        string ColorFondo { get; set; }
        string IFiguras.ColorFondo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string ColorBorde { get; set; }
        string IFiguras.ColorBorde { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }


}


class Class2
{
    /// <summary>
    /// Principio de segregacion de la interfaz donde muchas interfaces cliente son mejores que una interfaz general
    /// </summary>
    /// 
    public interface ILienzo
    {
    }

    public interface IOutput
    {
    }

    public interface IToolbar
    {

    }

    public interface IContainer { }

    public class Output : IOutput
    {

        public Func<string> Read { get; set; }
        public Action<string> Write { get; set; }
        /*Constructor de los objetos tipo Output*/
        public Output(Func<string> leer, Action<string> escribir)
        {
            Write = escribir;
            Read = leer;
        }

    }

    public class Lienzo : ILienzo, IOutput

    {
        private static Lienzo instance;
        private Lienzo() { }
        public static Lienzo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Lienzo();
                }
                return instance;
            }
        }
    }


    public class Toolbar : IToolbar, IOutput
    {
        public Func<string> Read { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Action<string> Write { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }



    }


    public class Containerfiguras : IContainer
    {
        readonly IList<Type> _figuras;
        public Container(IList<Type> figuras)
        {
            if (null == figuras)
            {
                throw new ArgumentNullException("figuras");
            }
            _figuras = figuras;
        }


    }
}


class Class1
{

    /// <summary>
    /// Principio de Liskov donde los objetos deberian ser reemplazables por instancias de sus subtipos
    /// </summary>
    public interface IFiguras
    {
        string ColorFondo { get; set; }
        string ColorBorde { get; set; }

    }

    public class Figura : IFiguras
    {
        string ColorFondo { get; set; }
        string IFiguras.ColorFondo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string ColorBorde { get; set; }
        string IFiguras.ColorBorde { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    class Estrella : Figura
    {
        public override string ToString()
        {
            return "Soy una estrella";
        }
    }

    class Rayo : Figura
    {
        public override string ToString()
        {
            return "Soy un rayo";
        }
    }

    class Corazon : Figura
    {
        public override string ToString()
        {
            return "Soy un corazon";
        }
    }

}
    






        