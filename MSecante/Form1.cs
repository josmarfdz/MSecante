using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSecante
{
    public partial class Form1 : Form
    {
        private float x0, x1, errorDeseado;
        private int iteraciones;
        private float raiz, errorFinal;
        private List<IteracionSecante> tablaIteraciones;

        public Form1()
        {
            InitializeComponent();
        }
        private class IteracionSecante
        {
            public int Iteracion { get; set; }
            public float X0 { get; set; }
            public float XI { get; set; }
            public float Fx0 { get; set; }
            public float FxI { get; set; }
            public float X2 { get; set; }
            public float Error { get; set; }
        }


        private void CalcularSecante()
        {
            tablaIteraciones = new List<IteracionSecante>();

            float xi0 = x0;
            float xi1 = x1;
            float errorActual = 1f;
            int iter = 0;

            float fx0 = EvaluarFuncion(xi0);
            float fx1 = EvaluarFuncion(xi1);
            float x2 = CalcularX2(xi0, xi1, fx0, fx1);

            tablaIteraciones.Add(new IteracionSecante
            {
                Iteracion = 1,
                X0 = xi0,
                XI = xi1,
                Fx0 = fx0,
                FxI = fx1,
                X2 = x2,
                Error = 1f
            });

            iter++;
            errorActual = Math.Abs((x2 - xi1) / x2);
            xi0 = xi1;
            xi1 = x2;

            while (errorActual > errorDeseado && iter < 100)
            {
                fx0 = EvaluarFuncion(xi0);
                fx1 = EvaluarFuncion(xi1);
                x2 = CalcularX2(xi0, xi1, fx0, fx1);

                if (float.IsNaN(x2) || float.IsInfinity(x2))
                    throw new Exception("El método divergió o se produjo una división por cero.");

                errorActual = Math.Abs((x2 - xi1) / x2);

                tablaIteraciones.Add(new IteracionSecante
                {
                    Iteracion = iter + 1,
                    X0 = xi0,
                    XI = xi1,
                    Fx0 = fx0,
                    FxI = fx1,
                    X2 = x2,
                    Error = errorActual
                });

                xi0 = xi1;
                xi1 = x2;
                iter++;
            }

            if (errorActual > errorDeseado)
                throw new Exception("No se encontró raíz en 100 iteraciones.");

            iteraciones = iter;
            raiz = x2;
            errorFinal = errorActual;
        }

        private float EvaluarFuncion(float x)
        {
            string funcion = txtFuncion.Text;
            if (string.IsNullOrWhiteSpace(funcion))
                throw new Exception("Debe ingresar una función válida.");

            // Reemplazar '^' por Math.Pow simple
            string expr = funcion.Replace("^", "**").Replace("x", x.ToString(System.Globalization.CultureInfo.InvariantCulture));

            while (expr.Contains("**"))
            {
                int idx = expr.IndexOf("**");
                int start = idx - 1;
                int end = idx + 2;

                string baseNum = expr[start].ToString();
                string exponente = expr[end].ToString();
                string powRepl = Math.Pow(double.Parse(baseNum), double.Parse(exponente)).ToString(System.Globalization.CultureInfo.InvariantCulture);

                expr = expr.Substring(0, start) + powRepl + expr.Substring(end + 1);
            }

            var dt = new DataTable();
            var result = dt.Compute(expr, "");
            return Convert.ToSingle(result);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtX0.Clear();
            txtX1.Clear();
            txtError.Clear();
            txtFuncion.Clear();
            dataIteracion.DataSource = null;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Confirmación antes de ejecutar el cálculo
            if (MessageBox.Show("Revise por última vez. ¿La función es correcta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return; // Si el usuario responde "No", salimos
            }

            try
            {
                // Validar campos
                if (string.IsNullOrWhiteSpace(txtX0.Text) || string.IsNullOrWhiteSpace(txtX1.Text) ||
                    string.IsNullOrWhiteSpace(txtError.Text) || string.IsNullOrWhiteSpace(txtFuncion.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!float.TryParse(txtX0.Text, out x0) ||
                    !float.TryParse(txtX1.Text, out x1) ||
                    !float.TryParse(txtError.Text, out errorDeseado))
                {
                    MessageBox.Show("Ingrese valores numéricos válidos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (errorDeseado <= 0)
                {
                    MessageBox.Show("El error debe ser positivo.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ejecutar cálculo
                CalcularSecante();
                MostrarResultados();  // Llamada a la función de mostrar resultados
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error de cálculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarResultados()
        {
            // Mostrar los resultados de las iteraciones en el DataGridView
            DataTable dt = new DataTable();
            dt.Columns.Add("Iteración");
            dt.Columns.Add("x0");
            dt.Columns.Add("x1");
            dt.Columns.Add("f(x0)");
            dt.Columns.Add("f(x1)");
            dt.Columns.Add("x2");
            dt.Columns.Add("ε");

            foreach (var iter in tablaIteraciones)
            {
                dt.Rows.Add(
                    iter.Iteracion,
                    iter.X0.ToString("F6"),
                    iter.XI.ToString("F6"),
                    iter.Fx0.ToString("F6"),
                    iter.FxI.ToString("F6"),
                    iter.X2.ToString("F6"),
                    iter.Error.ToString("F6")
                );
            }

            // Asignar el DataTable al DataGridView
            dataIteracion.DataSource = dt;

            // Mostrar el resumen en un MessageBox
            string resumen = $"Método de la Secante\n\n" +
                             $"Función: {txtFuncion.Text}\n" +
                             $"x0 = {x0},  x1 = {x1}\n" +
                             $"Error deseado = {errorDeseado}\n\n" +
                             $"Iteraciones realizadas: {iteraciones}\n" +
                             $"Raíz aproximada: {raiz:F6}\n" +
                             $"Error final: {errorFinal:F6}";

            MessageBox.Show(resumen, "Resumen del cálculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private float CalcularX2(float x0, float x1, float fx0, float fx1)
        {
            if (Math.Abs(fx1 - fx0) < 1e-6)
                throw new Exception("División por cero: f(x1) ≈ f(x0).");

            return x1 - (fx1 * (x1 - x0)) / (fx1 - fx0);
        }
    }
}
