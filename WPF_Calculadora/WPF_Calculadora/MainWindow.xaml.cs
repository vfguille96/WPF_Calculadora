using System;
using System.Windows;
using System.Windows.Input;
// ----
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.XPath;

namespace WPF_Calculadora
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			QuitarFocoBotones();
		}

		private void QuitarFocoBotones()
		{
			btn0.Focusable = false;
			btn1.Focusable = false;
			btn2.Focusable = false;
			btn3.Focusable = false;
			btn4.Focusable = false;
			btn5.Focusable = false;
			btn6.Focusable = false;
			btn7.Focusable = false;
			btn8.Focusable = false;
			btn9.Focusable = false;
			btn1.Focusable = false;
			btnSuma.Focusable = false;
			btnDiv.Focusable = false;
			btnMult.Focusable = false;
			btnC.Focusable = false;
			btnIgual.Focusable = false;
			btnCE.Focusable = false;
			btnRest.Focusable = false;
			btnComa.Focusable = false;
		}

		private static string escrito = string.Empty;
		private void btnIgual_Click(object sender, RoutedEventArgs e)
		{
			if (escrito != string.Empty || escrito == "0")
			{
				if (escrito[escrito.Length - 1] != '.' && escrito[escrito.Length - 1] != '*' && escrito[escrito.Length - 1] != '+' && escrito[escrito.Length - 1] != '-' && escrito[escrito.Length - 1] != '/')
				{
					try
					{
						txbPantalla.Text = Calcular(escrito).ToString();
					}
					catch (Exception)
					{
						txbPantalla.Text = "SYNTAX ERROR";
					}
				}

				if (escrito == "0")
					txbPantalla.Text = "0";
			}
		}

		private void btnDiv_Click(object sender, RoutedEventArgs e)
		{
			if (escrito != string.Empty)
			{
				if (escrito[escrito.Length - 1] != '.' && escrito[escrito.Length - 1] != '*' && escrito[escrito.Length - 1] != '-' && escrito[escrito.Length - 1] != '/' && escrito[escrito.Length - 1] != '+')
				{
					escrito += "/";
					txbPantalla.Text = escrito;
				}
			}
		}

		private void btnMult_Click(object sender, RoutedEventArgs e)
		{
			if (escrito != string.Empty)
			{
				if (escrito[escrito.Length - 1] != '.' && escrito[escrito.Length - 1] != '*' && escrito[escrito.Length - 1] != '-' && escrito[escrito.Length - 1] != '/' && escrito[escrito.Length - 1] != '+')
				{
					escrito += "*";
					txbPantalla.Text = escrito;
				}
			}		
		}

		private void btnRest_Click(object sender, RoutedEventArgs e)
		{
			if (escrito != string.Empty)
			{
				if (escrito[escrito.Length - 1] != '.' && escrito[escrito.Length - 1] != '*' && escrito[escrito.Length - 1] != '-' && escrito[escrito.Length - 1] != '/' && escrito[escrito.Length - 1] != '+')
				{
					escrito += "-";
					txbPantalla.Text = escrito;
				}
			}
		}

		private void btnSuma_Click(object sender, RoutedEventArgs e)
		{
			if (escrito != string.Empty)
			{
				if (escrito[escrito.Length - 1] != '.' && escrito[escrito.Length - 1] != '*' && escrito[escrito.Length - 1] != '-' && escrito[escrito.Length - 1] != '/' && escrito[escrito.Length - 1] != '+')
				{
					escrito += "+";
					txbPantalla.Text = escrito;
				}
			}
		}

		private void btnComa_Click(object sender, RoutedEventArgs e)
		{
			if (escrito != string.Empty)
			{
				if (escrito[escrito.Length - 1] != '.' && escrito[escrito.Length - 1] != '*' && escrito[escrito.Length - 1] != '+' && escrito[escrito.Length - 1] != '-' && escrito[escrito.Length - 1] != '/')
				{
					escrito += ".";
					txbPantalla.Text = escrito.Replace('.',',');
				}
			}
		}
		private void btn0_Click(object sender, RoutedEventArgs e)
		{
			escrito += 0;
			txbPantalla.Text = escrito;
		}

		private void btn1_Click(object sender, RoutedEventArgs e)
		{
			escrito += 1;
			txbPantalla.Text = escrito;
		}

		private void btnC_Click(object sender, RoutedEventArgs e)
		{
			escrito = string.Empty;
			txbPantalla.Text = "0";
		}

		private void btnCE_Click(object sender, RoutedEventArgs e)
		{
			if (txbPantalla.Text.Length != 0 && txbPantalla.Text != string.Empty && txbPantalla.Text != "0")
			{
				string tmp = "";
				tmp = escrito.Remove(txbPantalla.Text.Length - 1);
				escrito = tmp;
				txbPantalla.Text = escrito;
			}
			
			if (txbPantalla.Text == string.Empty)
				txbPantalla.Text = "0";
		}

		private void btn2_Click(object sender, RoutedEventArgs e)
		{
			escrito += 2;
			txbPantalla.Text = escrito;
		}

		private void btn3_Click(object sender, RoutedEventArgs e)
		{
			escrito += 3;
			txbPantalla.Text = escrito;
		}

		private void btn4_Click(object sender, RoutedEventArgs e)
		{
			escrito += 4;
			txbPantalla.Text = escrito;
		}

		private void btn5_Click(object sender, RoutedEventArgs e)
		{
			escrito += 5;
			txbPantalla.Text = escrito;
		}

		private void btn6_Click(object sender, RoutedEventArgs e)
		{
			escrito += 6;
			txbPantalla.Text = escrito;
		}

		private void btn7_Click(object sender, RoutedEventArgs e)
		{
			escrito += 7;
			txbPantalla.Text = escrito;
		}

		private void btn8_Click(object sender, RoutedEventArgs e)
		{
			escrito += 8;
			txbPantalla.Text = escrito;
		}

		private void btn9_Click(object sender, RoutedEventArgs e)
		{
			escrito += 9;
			txbPantalla.Text = escrito;
		}

		private void grdPrincipal_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter && escrito != string.Empty)
			{
				if (e.Key == Key.Enter && escrito[escrito.Length - 1] != '.' && escrito[escrito.Length - 1] != '*' && escrito[escrito.Length - 1] != '+' && escrito[escrito.Length - 1] != '-' && escrito[escrito.Length - 1] != '/')
				{
					try
					{
						txbPantalla.Text = Calcular(escrito).ToString();
					}
					catch (Exception)
					{
						txbPantalla.Text = "SYNTAX ERROR";
					}
				}
			}

			if (e.Key == Key.Multiply && escrito != string.Empty)
			{
				if (escrito[escrito.Length - 1] != '.' && escrito[escrito.Length - 1] != '*' && escrito[escrito.Length - 1] != '+' && escrito[escrito.Length - 1] != '-' && escrito[escrito.Length - 1] != '/')
				{
					escrito += "*";
					txbPantalla.Text = escrito;
				}
			}

			if (e.Key == Key.Divide && escrito != string.Empty)
			{
				if (escrito[escrito.Length - 1] != '.' && escrito[escrito.Length - 1] != '*' && escrito[escrito.Length - 1] != '+' && escrito[escrito.Length - 1] != '-' && escrito[escrito.Length - 1] != '/')
				{
					escrito += "/";
					txbPantalla.Text = escrito;
				}
			}

			if (e.Key == Key.Add && escrito != string.Empty || e.Key == Key.OemPlus && escrito != string.Empty)
			{
				if (escrito[escrito.Length - 1] != '.' && escrito[escrito.Length - 1] != '*' && escrito[escrito.Length - 1] != '+' && escrito[escrito.Length - 1] != '-' && escrito[escrito.Length - 1] != '/')
				{
					escrito += "+";
					txbPantalla.Text = escrito;
				}
			}

			if (e.Key == Key.Subtract && escrito != string.Empty || e.Key == Key.OemMinus && escrito != string.Empty)
			{
				if (escrito[escrito.Length - 1] != '.' && escrito[escrito.Length - 1] != '*' && escrito[escrito.Length - 1] != '+' && escrito[escrito.Length - 1] != '-' && escrito[escrito.Length - 1] != '/')
				{
					escrito += "-";
					txbPantalla.Text = escrito;
				}
			}

			if (e.Key == Key.Decimal && escrito != string.Empty || e.Key == Key.OemComma && escrito != string.Empty)
			{
				if (escrito[escrito.Length - 1] != '.' && escrito[escrito.Length - 1] != '*' && escrito[escrito.Length - 1] != '+' && escrito[escrito.Length - 1] != '-' && escrito[escrito.Length - 1] != '/')
				{
					escrito += ".";
					txbPantalla.Text = escrito.Replace('.', ',');
				}
			}

			if (e.Key == Key.Back)
			{
				try
				{
					if (txbPantalla.Text.Length != 0 && txbPantalla.Text != string.Empty && txbPantalla.Text != "0")
					{
						string tmp = "";
						tmp = escrito.Remove(txbPantalla.Text.Length - 1);
						escrito = tmp;
						txbPantalla.Text = escrito;

						if (txbPantalla.Text == string.Empty)
							txbPantalla.Text = "0";
					}

					if (txbPantalla.Text == string.Empty)
						txbPantalla.Text = "0";
				}
				catch (Exception)
				{
					txbPantalla.Text = "SYNTAX ERROR";
				}
			}

			if (e.Key == Key.Delete)
			{
				escrito = string.Empty;
				txbPantalla.Text = "0";
			}

			if (e.Key == Key.D0)
			{
				escrito += 0;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.NumPad0)
			{
				escrito += 0;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.D1)
			{
				escrito += 1;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.NumPad1)
			{
				escrito += 1;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.D2)
			{
				escrito += 2;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.NumPad2)
			{
				escrito += 2;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.D3)
			{
				escrito += 3;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.NumPad3)
			{
				escrito += 3;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.D4)
			{
				escrito += 4;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.NumPad4)
			{
				escrito += 4;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.D5)
			{
				escrito += 5;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.NumPad5)
			{
				escrito += 5;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.D6)
			{
				escrito += 6;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.NumPad6)
			{
				escrito += 6;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.D7)
			{
				escrito += 7;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.NumPad7)
			{
				escrito += 7;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.D8)
			{
				escrito += 8;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.NumPad8)
			{
				escrito += 8;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.D9)
			{
				escrito += 9;
				txbPantalla.Text = escrito;
			}

			if (e.Key == Key.NumPad9)
			{
				escrito += 9;
				txbPantalla.Text = escrito;
			}
		}

		public static double Calcular(string escrito)
		{
			var xsltExpression = string.Format("number({0})", new Regex(@"([\+\-\*])").Replace(escrito, " ${1} ").Replace("/", " div ").Replace("%", " mod "));

			return (double)new XPathDocument(new StringReader("<r/>")).CreateNavigator().Evaluate(xsltExpression);
		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Calculadora.\n\nCreador: \nGuillermo Vera\n\nContacto: \nguillermovera@vfguille.com\n@vfguille96\n\n\t\tv1.0 (beta)", "Acerca de...", MessageBoxButton.OK);
		}

		private void MenuItem_Click_1(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
