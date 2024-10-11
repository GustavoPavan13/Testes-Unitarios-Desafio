using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Calculadoras.Services;

namespace CalculadoraTestes;
public class CalculadoraTestes
{
     [Theory]
    [InlineData(2,3,5)]
    [InlineData(4,30,34)]
    [InlineData(5,10,15)]
    public void Somar(int valor1, int valor2, int resultado)
    {
        Calculadora calc = new Calculadora();
        int resultadoCalculadora = calc.Somar(valor1, valor2);

        Assert.Equal(resultado,resultadoCalculadora);

    }
    [Theory]
    [InlineData(5,3,2)]
    [InlineData(4,1,3)]
    [InlineData(5,4,1)]
    public void Subtrair(int valor1, int valor2, int resultado)
    {
        Calculadora calc = new Calculadora();
        int resultadoCalculadora = calc.Subtrair(valor1, valor2);

        Assert.Equal(resultado,resultadoCalculadora);

    }
    [Theory]
    [InlineData(5,2,10)]
    [InlineData(4,1,4)]
    [InlineData(5,4,20)]
    public void Multiplicar(int valor1, int valor2, int resultado)
    {
        Calculadora calc = new Calculadora();
        int resultadoCalculadora = calc.Multiplicar(valor1, valor2);

        Assert.Equal(resultado,resultadoCalculadora);

    }
    [Theory]
    [InlineData(6,3,2)]
    [InlineData(4,1,4)]
    [InlineData(12,4,3)]
    public void Dividir(int valor1, int valor2, int resultado)
    {
        Calculadora calc = new Calculadora();
        int resultadoCalculadora = calc.Dividir(valor1, valor2);

        Assert.Equal(resultado,resultadoCalculadora);

    }
    [Fact]
    public void DividirPorZero(){
        Calculadora calc = new Calculadora();
        Assert.Throws<DivideByZeroException>(( )=> calc.Dividir(3,0));

    }
    [Theory]
    [InlineData(2,3,8)]
    [InlineData(4,2,16)]
    [InlineData(5,4,625)]
    public void Exponencial(int valor1, int valor2, int resultado)
    {
        Calculadora calc = new Calculadora();
        double resultadoCalculadora = calc.Exponencial(valor1, valor2);

        Assert.Equal(resultado,resultadoCalculadora);

    }
    [Theory]
    [InlineData(81,9)]
    [InlineData(25,5)]
    [InlineData(121,11)]
    public void RaizQuadrada(int valor1,  int resultado)
    {
        Calculadora calc = new Calculadora();
        double resultadoCalculadora = calc.RaizQuadrada(valor1);

        Assert.Equal(resultado,resultadoCalculadora);
    }

    [Theory]
    [InlineData(1,-3,2, new double[] { 2, 1 })]
    [InlineData(1,-2,1,new double []{1})]
    [InlineData(1,0,1, new double [] {})]
    public void Bhaskara(int valor1, int valor2, int valor3, double[] resultadoEsperado)
{
    Calculadora calc = new Calculadora();

    if (resultadoEsperado == null)
    {
        var exception = Assert.Throws<Exception>(() => calc.Bhaskara(valor1, valor2, valor3));
        Assert.Equal("Não existe raizes reais", exception.Message);
    }
    else
    {
        List<double> resultadoCalculadora = calc.Bhaskara(valor1, valor2, valor3);
        Assert.Equal(resultadoEsperado, resultadoCalculadora.ToArray());
    }

    }
    [Fact]
    public void TestarHistorico(){
        Calculadora calc  = new Calculadora();
        calc.Somar(4,4);
        calc.Somar(51,94);
        calc.Somar(4,0);
        calc.Somar(56,3);
        var lista = calc.Historico();
        Assert.NotEmpty(lista);
        Assert.Equal(3,lista.Count());
    }
}