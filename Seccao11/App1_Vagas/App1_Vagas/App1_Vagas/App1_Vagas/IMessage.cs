using System;
using System.Collections.Generic;
using System.Text;

namespace App1_Vagas
{
    public interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
