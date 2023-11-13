using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using PIII_Proyecto1_CalculadoraWeb;

namespace PIII_Proyecto1_CalculadoraWeb
{
    public class Metodos
    {
        calculadora calculadora;
        /* public Boolean validarDatos()
         {
             if (calculadora.txtDatos.Text == null) { 
                 return false;
             }
             return true;
         }

         public void agregarDigitoAlTextBox(int digito)
         {
             if (calculadora.txtDatos.Text == null)
             {
                 calculadora.txtDatos.Text = Convert.ToString(digito);
             }
             else
             {
                 var textBox = calculadora.txtDatos.Text;
                 string valorActual = textBox;
                 calculadora.txtDatos.Text = valorActual + digito;
             }
         }*/

        public string EliminarUltimoDigito(string numero)
        {
            if (numero.Length >= 2)
            {
                numero = numero.Remove(numero.Length - 1);
            }
            else
            {
                numero = "";
            }
            return numero;
        }

    }
}