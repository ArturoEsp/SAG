using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAdmGym.Configuracion
{
    class Validar
    {
        public static bool CheckFormatEmail(string EmailOrigin)
        {
            String sFormato;
            sFormato = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(EmailOrigin, sFormato))
            {
                if (Regex.Replace(EmailOrigin, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static void ValidateNumber(KeyPressEventArgs args)
        {
            if (char.IsDigit(args.KeyChar))
            {
                args.Handled = false;
            }
            else if (char.IsControl(args.KeyChar))
            {
                args.Handled = false;
            }
            else
            {
                args.Handled = true;
            }
        }

        public static void ValidateDoubles(KeyPressEventArgs e, string tb)
        {
            if (tb.Contains("."))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }

        public static void ValidateString(KeyPressEventArgs args)
        {
            if (char.IsLetter(args.KeyChar))
            {
                args.Handled = false;
            }
            else if (char.IsControl(args.KeyChar))
            {
                args.Handled = false;
            }
            else if (char.IsSeparator(args.KeyChar))
            {
                args.Handled = true;
            }
            else
            {
                args.Handled = true;
            }
        }

        public static bool TextBoxNotNull(Form Form)
        {
            bool Check = true;

            foreach (Control oControls in Form.Controls)
            {
                if (oControls is TextBox & oControls.Text == String.Empty)
                {
                    Check = false;
                }
            }

            return Check;
        }

        public static void CleanTextBox(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                if (c.Controls.Count > 0)
                {
                    CleanTextBox(c);
                }
            }
        }
    }
}
