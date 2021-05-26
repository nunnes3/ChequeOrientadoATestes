using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePorExtenso.Controller
{
    public class ControladorCentena
    {
        List<string> listCentenas = new List<string> { "cem", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };


        private string retornaListaCentenas(char[] centena, int indice)
        {
            for (int i = 0; i < listCentenas.Count; i++)
            {

                if (centena[indice] == '1') { return listCentenas[0]; }
                if (centena[indice] == '2') { return listCentenas[1]; }
                if (centena[indice] == '3') { return listCentenas[2]; }
                if (centena[indice] == '4') { return listCentenas[3]; }
                if (centena[indice] == '5') { return listCentenas[4]; }
                if (centena[indice] == '6') { return listCentenas[5]; }
                if (centena[indice] == '7') { return listCentenas[6]; }
                if (centena[indice] == '8') { return listCentenas[7]; }
                if (centena[indice] == '9') { return listCentenas[8]; }
            }
            return "centenas";
        }

        public string verificaCentena(string valor)
        {
            string depoisDaVirgula = valor.Split(',')[1];

            if (depoisDaVirgula.Length > 2)
            {
                char[] separaDepoisVirgula = depoisDaVirgula.ToCharArray();

                return retornaListaCentenas(separaDepoisVirgula, 0);
            }


            char[] separa = valor.ToCharArray();
            string recebeValor = retornaListaCentenas(separa, 0);

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(recebeValor);
        }

    }
}
