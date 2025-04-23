//using PassKit;

//using PassKit;
using System.Globalization;

namespace KTIGSETS2.Views;

public partial class principal : ContentPage
{
    public principal(string user)
    {
        InitializeComponent();
        lblUsu.Text = "USUARIO CONECTADO: " + user;
    }

    private void txNotaS1_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void btnAceptar_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (pkEst.SelectedIndex == -1)
            {
                this.lblInfo.Text = "DEBE SELECCIONAR UN ESTUDIANTE";
                return;
            }

            if (string.IsNullOrWhiteSpace(txNotaS1.Text))
            {
                this.lblInfo.Text = "INGRESE LA NOTA DE SEGUIMIENTO 1";
                return;
            }

            if (string.IsNullOrWhiteSpace(txExaS1.Text))
            {
                this.lblInfo.Text = "INGRESE LA NOTA DEL EXAMEN DEL SEGUIMIENTO 1";
                return;
            }

            if (string.IsNullOrWhiteSpace(txNotaS2.Text))
            {
                this.lblInfo.Text = "INGRESE LA NOTA DE SEGUIMIENTO 2";
                return;
            }

            if (string.IsNullOrWhiteSpace(txExaS2.Text))
            {
                this.lblInfo.Text = "INGRESE LA NOTA DEL EXAMEN DEL SEGUIMIENTO 2";
                return;
            }


            string texto1 = txNotaS1.Text.Trim();
            texto1 = texto1.Replace(",", ".");

            string texto2 = txExaS1.Text.Trim();
            texto2 = texto2.Replace(",", ".");

            string texto3 = txNotaS2.Text.Trim();
            texto3 = texto3.Replace(",", ".");

            string texto4 = txExaS2.Text.Trim();
            texto4 = texto4.Replace(",", ".");

            if (decimal.TryParse(texto1, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal ns1))
            {
                if (decimal.TryParse(texto2, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal nes1))
                {
                    if (decimal.TryParse(texto3, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal ns2))
                    {
                        if (decimal.TryParse(texto4, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal nes2))
                        {
                            if (ns1 < 0 || ns1 > 10)
                            {
                                this.txNotaS1.BackgroundColor = Colors.Red;
                                this.lblInfo.Text = "DEBE INGRESAR LA NOTA EN RANGO DE 0 A 10";
                                return;
                            }

                            if (nes1 < 0 || nes1 > 10)
                            {
                                this.txExaS1.BackgroundColor = Colors.Red;
                                this.lblInfo.Text = "DEBE INGRESAR LA NOTA EN RANGO DE 0 A 10";
                                return;
                            }

                            if (ns2 < 0 || ns2 > 10)
                            {
                                this.txNotaS2.BackgroundColor = Colors.Red;
                                this.lblInfo.Text = "DEBE INGRESAR LA NOTA EN RANGO DE 0 A 10";
                                return;
                            }

                            if (nes2 < 0 || nes2 > 10)
                            {
                                this.txExaS2.BackgroundColor = Colors.Red;
                                this.lblInfo.Text = "DEBE INGRESAR LA NOTA EN RANGO DE 0 A 10";
                                return;
                            }

                            this.lblInfo.Text = "";
                            this.txNotaS1.BackgroundColor = Colors.White;
                            this.txExaS1.BackgroundColor = Colors.White;
                            this.txNotaS2.BackgroundColor = Colors.White;
                            this.txExaS2.BackgroundColor = Colors.White;

                            decimal notaS1 = ns1 * 0.3m;
                            decimal notaExamenS1 = nes1 * 0.2m;
                            decimal notaParcial1 = notaS1 + notaExamenS1;

                            decimal notaS2 = ns2 * 0.3m;
                            decimal notaExamenS2 = nes2 * 0.2m;
                            decimal notaParcial2 = notaS2 + notaExamenS2;

                            decimal notaFinal = notaParcial1 + notaParcial2;

                            string fec = dpFec.Date.ToString();

                            string estudiante = pkEst.Items[pkEst.SelectedIndex].ToString();

                            string estado = "";

                            if (notaFinal >= 7)
                            {
                                estado = "APROBADO";
                            }

                            if (notaFinal >= 5 && notaFinal <= 6.9m)
                            {
                                estado = "Complementario";
                            }

                            if (notaFinal < 5)
                            {
                                estado = "REPROBADO";
                            }


                            // Mostramos el resultado
                            DisplayAlert("MENSAJE", " NOMBRE: " + estudiante + "\n" + " FECHA: " + fec + "\n" + "NOTA PARCIAL 1: " + notaParcial1.ToString()
                               + "\n" + "NOTA PARCIAL 2: " + notaParcial2.ToString() + "\n" + "NOTA FINAL: " + notaFinal.ToString() + "\n" + "ESTADO: " + estado, "OK");
                        }
                        else
                        {
                            this.txExaS2.BackgroundColor = Colors.Red;
                            this.lblInfo.Text = "Ingrese un valor válido (ej: 7.50)";
                            return;
                        }
                    }
                    else
                    {
                        this.txNotaS2.BackgroundColor = Colors.Red;
                        this.lblInfo.Text = "Ingrese un valor válido (ej: 7.50)";
                        return;
                    }
                }
                else
                {
                    this.txExaS1.BackgroundColor = Colors.Red;
                    this.lblInfo.Text = "Ingrese un valor válido (ej: 7.50)";
                    return;
                }
            }
            else
            {
                this.txNotaS1.BackgroundColor = Colors.Red;
                this.lblInfo.Text = "Ingrese un valor válido (ej: 7.50)";
                return;
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    private void txExaS1_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void txNotaS2_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void txExaS2_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}