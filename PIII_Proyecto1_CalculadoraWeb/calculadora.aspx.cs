using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PIII_Proyecto1_CalculadoraWeb
{
    public static class gVar
    {
        public static double numero1 = 0;
        public static double numero2 = 0;
        public static double resultado;
        public static string operador;
        public static bool nuevaOperacion = true;
        public static double numero3 = 0;
    }

    public partial class calculadora : System.Web.UI.Page
    {
        Metodos metodos = new Metodos();

        protected void btn0_Click(object sender, EventArgs e)
        {
            agregarDigitoAlTextBox(0);
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            agregarDigitoAlTextBox(1);
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            agregarDigitoAlTextBox(2);
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            agregarDigitoAlTextBox(3);
        }

        protected void btn4_Click(object sender, EventArgs e)
        {
            agregarDigitoAlTextBox(4);
        }
        protected void btn5_Click(object sender, EventArgs e)
        {
            agregarDigitoAlTextBox(5);
        }

        protected void btn6_Click(object sender, EventArgs e)
        {
            agregarDigitoAlTextBox(6);
        }

        protected void btn7_Click(object sender, EventArgs e)
        {
            agregarDigitoAlTextBox(7);
        }
        protected void btn8_Click(object sender, EventArgs e)
        {
            agregarDigitoAlTextBox(8);
        }

        protected void btn9_Click(object sender, EventArgs e)
        {
            agregarDigitoAlTextBox(9);
        }

        public void agregarDigitoAlTextBox(int digito)
        {
            if (string.IsNullOrEmpty(txtDatos.Text))
            {
                txtDatos.Text = digito.ToString();
            }
            else
            {
                var textBox = txtDatos.Text;
                string valorActual = textBox;
                txtDatos.Text = valorActual + digito;
            }
        }

        public void agregarComaAlTextBox(string num)
        {
            if (!num.Contains(","))
            {
                txtDatos.Text = num + ",";
            }
            txtDatos.Text = txtDatos.Text;
        }

        public Boolean validarDatos()
        {
            if (txtDatos.Text == null && gVar.numero1 == 0)
            {
                return false;
            }
            return true;
        }

        protected void btnComa_Click(object sender, EventArgs e)
        {
            if (validarDatos() == true && !string.IsNullOrEmpty(txtDatos.Text))
            {
                agregarComaAlTextBox(txtDatos.Text);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtDatos.Text = "";
            gVar.numero1 = 0;
            gVar.numero2 = 0;
            gVar.resultado = 0;
            gVar.operador = "";
            gVar.nuevaOperacion = true;
        }

        protected void btnBorrarDigito_Click(object sender, EventArgs e)
        {
            txtDatos.Text = metodos.EliminarUltimoDigito(txtDatos.Text);
        }

        protected void btnxy_Click(object sender, EventArgs e)
        {
            if (validarDatos() == true && !string.IsNullOrEmpty(txtDatos.Text))
            {
                gVar.numero1 = Convert.ToDouble(txtDatos.Text);
                txtDatos.Text = "";
                gVar.operador = "X^y";
                gVar.nuevaOperacion = true;
            }
        }

        protected void btn10x_Click(object sender, EventArgs e)
        {
            if (validarDatos() == true && !string.IsNullOrEmpty(txtDatos.Text))
            {
                gVar.numero1 = Convert.ToDouble(txtDatos.Text);
                gVar.resultado = gVar.numero1;
                txtDatos.Text = Math.Pow(10, gVar.numero1).ToString();
            }
        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            if (validarDatos() == true && !string.IsNullOrEmpty(txtDatos.Text))
            {
                gVar.numero1 = Convert.ToDouble(txtDatos.Text);
                gVar.resultado = gVar.numero1;
                txtDatos.Text = Math.Log10(gVar.numero1).ToString();
            }
        }

        protected void btnx2_Click(object sender, EventArgs e)
        {
            if (validarDatos() == true && !string.IsNullOrEmpty(txtDatos.Text))
            {
                gVar.numero1 = Convert.ToDouble(txtDatos.Text);
                gVar.resultado = gVar.numero1;
                txtDatos.Text = Math.Pow(gVar.numero1, 2).ToString();
            }
        }

        protected void btnSuma_Click(object sender, EventArgs e)
        {
            if (validarDatos() == true && !string.IsNullOrEmpty(txtDatos.Text))
            {
                if (gVar.numero1 == 0)
                {
                    gVar.operador = "+";
                    gVar.numero1 = Convert.ToDouble(txtDatos.Text);
                    txtDatos.Text = "";
                }
                else
                {
                    gVar.operador = "+";
                    gVar.numero1 = Convert.ToDouble(txtDatos.Text);
                    txtDatos.Text = "";
                    gVar.nuevaOperacion = true;
                }
            }

        }

        protected void btnIgual_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(gVar.operador) && txtDatos.Text != null)
            {
                gVar.numero2 = double.Parse(txtDatos.Text);

                if (gVar.nuevaOperacion == true)
                {
                    switch (gVar.operador)
                    {
                        case "+":
                            gVar.resultado = (gVar.numero1 + gVar.numero2);
                            gVar.numero3 = gVar.numero1;
                            break;
                        case "-":
                            gVar.resultado = (gVar.numero1 - gVar.numero2);
                            break;
                        case "*":
                            gVar.resultado = (gVar.numero1 * gVar.numero2);
                            break;
                        case "/":
                            gVar.resultado = (gVar.numero1 / gVar.numero2);
                            break;
                        case "X^y":
                            gVar.resultado = (Math.Pow(gVar.numero1, gVar.numero2));
                            break;
                        default:
                            break;
                    }
                    gVar.nuevaOperacion = false;
                }
                else
                {
                    switch (gVar.operador)
                    {
                        case "+":
                            gVar.resultado = (gVar.numero2 + gVar.numero3);
                            break;
                        case "-":
                            gVar.resultado = (gVar.numero2 - gVar.numero3);
                            break;
                        case "*":
                            gVar.resultado = (gVar.numero2 * gVar.numero3);
                            break;
                        case "/":
                            gVar.resultado = (gVar.numero2 / gVar.numero3);
                            break;
                        case "X^y":
                            gVar.resultado = (Math.Pow(gVar.numero1, gVar.numero2));
                            break;
                        default:
                            break;
                    }
                }
                txtDatos.Text = Convert.ToString(gVar.resultado);
            }

        }

        protected void btnRaiz_Click(object sender, EventArgs e)
        {
            if (validarDatos() == true && !string.IsNullOrEmpty(txtDatos.Text))
            {
                gVar.numero1 = Convert.ToDouble(txtDatos.Text);
                gVar.resultado = gVar.numero1;
                txtDatos.Text = Math.Sqrt(gVar.numero1).ToString();
            }
        }

        protected void btnResta_Click(object sender, EventArgs e)
        {
            if (validarDatos() == true && !string.IsNullOrEmpty(txtDatos.Text))
            {
                if (gVar.numero1 == 0)
                {
                    gVar.operador = "-";
                    gVar.numero1 = Convert.ToDouble(txtDatos.Text);
                    txtDatos.Text = "";
                }
                else
                {
                    gVar.operador = "-";
                    gVar.numero1 = Convert.ToDouble(txtDatos.Text);
                    txtDatos.Text = "";
                    gVar.nuevaOperacion = true;
                }
            }

        }

        protected void btnMultiplicacion_Click(object sender, EventArgs e)
        {
            if (validarDatos() == true && !string.IsNullOrEmpty(txtDatos.Text))
            {
                if (gVar.numero1 == 0)
                {
                    gVar.operador = "*";
                    gVar.numero1 = Convert.ToDouble(txtDatos.Text);
                    txtDatos.Text = "";
                }
                else
                {
                    gVar.operador = "*";
                    gVar.numero1 = Convert.ToDouble(txtDatos.Text);
                    txtDatos.Text = "";
                    gVar.nuevaOperacion = true;
                }
            }
        }

        protected void btnDivision_Click(object sender, EventArgs e)
        {
            if (validarDatos() == true && !string.IsNullOrEmpty(txtDatos.Text))
            {
                if (gVar.numero1 == 0)
                {
                    gVar.operador = "/";
                    gVar.numero1 = Convert.ToDouble(txtDatos.Text);
                    txtDatos.Text = "";
                }
                else
                {
                    gVar.operador = "/";
                    gVar.numero1 = Convert.ToDouble(txtDatos.Text);
                    txtDatos.Text = "";
                    gVar.nuevaOperacion = true;
                }
            }
        }

        protected void btnMasMenos_Click(object sender, EventArgs e)
        {
            if (validarDatos() == true && !string.IsNullOrEmpty(txtDatos.Text))
            {
                gVar.numero1 = Convert.ToDouble(txtDatos.Text);
                gVar.numero1 *= -1;
                txtDatos.Text = gVar.numero1.ToString();
            }
        }

        protected void btnN_Click(object sender, EventArgs e)
        {
            if (validarDatos() == true && !string.IsNullOrEmpty(txtDatos.Text))
            {
                double h = Convert.ToDouble(txtDatos.Text);
                double fact = 1;
                for (; h > 0.0; h--)
                {
                    fact = fact * h;
                }
                txtDatos.Text = fact.ToString();

            }
        }

        protected void txtDatos_TextChanged(object sender, EventArgs e)
        {

        }
    }
}