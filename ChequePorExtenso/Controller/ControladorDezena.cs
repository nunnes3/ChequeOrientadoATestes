using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePorExtenso.Controller
{
    public class ControladorDezena
    {
        List<string> listDezenas = new List<string> { "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };

        public string retornaListaDezenas(char[] dezena, int indice)
        {
            for (int i = 0; i < listDezenas.Count; i++)
            {

                if (dezena[indice] == '1') { return listDezenas[0]; }
                if (dezena[indice] == '2') { return listDezenas[1]; }
                if (dezena[indice] == '3') { return listDezenas[2]; }
                if (dezena[indice] == '4') { return listDezenas[3]; }
                if (dezena[indice] == '5') { return listDezenas[4]; }
                if (dezena[indice] == '6') { return listDezenas[5]; }
                if (dezena[indice] == '7') { return listDezenas[6]; }
                if (dezena[indice] == '8') { return listDezenas[7]; }
                if (dezena[indice] == '9') { return listDezenas[8]; }
            }
            return "dezenas";
        }


        public string verificaDezena(string valor)
        {
            string recebeValor = "";

            string antesDaVirgula = valor.Split(',')[0];

            string depoisDaVirgula = valor.Split(',')[1];

            char[] separa = valor.ToCharArray();

            if (antesDaVirgula.Length > 2)
            {
                char[] separaAntesVirgula = antesDaVirgula.ToCharArray();

                int indice = separaAntesVirgula.Length - 2;

                return retornaListaDezenas(separaAntesVirgula, indice);
            }

            if (depoisDaVirgula.Length > 2)
            {
                char[] separaAntesVirgula = depoisDaVirgula.ToCharArray();

                int indice = separaAntesVirgula.Length - 2;

                return retornaListaDezenas(separaAntesVirgula, indice);

            }


            recebeValor = retornaListaDezenas(separa, 0);

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(recebeValor);
        }
    }
}
