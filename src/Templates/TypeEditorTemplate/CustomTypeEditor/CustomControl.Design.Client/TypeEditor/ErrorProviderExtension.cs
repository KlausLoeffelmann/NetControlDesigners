using System;
using System.Windows.Forms;

namespace CustomControl.Designer.Client
{
    internal static class ErrorProviderExtension
    {
        public static bool SetErrorOrNull(this ErrorProvider errorProvider, Control control, Func<bool> errorCondition, string errorText)
        {
            if (errorCondition())
            {
                errorProvider.SetError(control, errorText);
                return true;
            }

            errorProvider.SetError(control, null);
            return false;
        }
    }
}
