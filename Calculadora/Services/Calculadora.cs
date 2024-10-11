using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculadoras.Services
{
    public class Calculadora
    {
        private List<string> historico;
        public Calculadora(){
            historico = new List<string>();
        }
         public int Somar(int valor1, int valor2){

            historico.Insert(0,"Soma");
            return valor1 + valor2;
        }

         public int Subtrair(int valor1, int valor2){
            historico.Insert(0,"Subtração");
            return valor1 - valor2;
        }

         public int Multiplicar(int valor1, int valor2){
            historico.Insert(0,"Mutiplicação");
            return valor1 * valor2;
        }

         public int Dividir(int valor1, int valor2){
            historico.Insert(0,"Divisão");
            return valor1 / valor2;
        }

        public double Exponencial(int valor1, int valor2){
            historico.Insert(0,"Exponencial");
            return Math.Pow(valor1,valor2);
        }

        public double RaizQuadrada(int valor1){
            historico.Insert(0,"Raiz Quadrada");
            return Math.Sqrt(valor1);
        }

        public List<double> Bhaskara(int a, int b, int c){
            List<double> raizes = new List<double>();
        double delta = Math.Sqrt(Math.Pow(b,2)-4*a*c);
        if(delta >0){
            double raiz1 = ((-b+delta)/(2*a));
            raizes.Add(raiz1);
            double raiz2 = ((-b-delta)/(2*a));
            raizes.Add(raiz2);
                
        } else if ( delta == 0 ){
            double raiz1 = -b/2*a;
            raizes.Add(raiz1);       
            }
            historico.Insert(0,"Bhaskara");
            return raizes;   
        }

        public List<string> Historico(){

            historico.RemoveRange(3,historico.Count-3);
            return historico;

        }
    }
    
}