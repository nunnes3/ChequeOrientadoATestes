using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePorExtenso.Controller
{
    public class ControladorUnidade
    {

        string nomenclaturaReais = " reais";

        string nomenclaturaMil = " mil";

        List<string> listUnidades = new List<string> { "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };

        public string retornaListaUnidades(char[] unidade, int indice)
        {
            for (int i = 0; i < listUnidades.Count; i++)
            {
                if (unidade[indice] == '1') { return listUnidades[0]; }
                if (unidade[indice] == '2') { return listUnidades[1]; }
                if (unidade[indice] == '3') { return listUnidades[2]; }
                if (unidade[indice] == '4') { return listUnidades[3]; }
                if (unidade[indice] == '5') { return listUnidades[4]; }
                if (unidade[indice] == '6') { return listUnidades[5]; }
                if (unidade[indice] == '7') { return listUnidades[6]; }
                if (unidade[indice] == '8') { return listUnidades[7]; }
                if (unidade[indice] == '9') { return listUnidades[8]; }


            }
            return "unidades";
        }
        public string verificaUnidade(string valor)
        {
            string antesDaVirgula = valor.Split(',')[0];

            string depoisDaVirgula = valor.Split(',')[1];

            char[] separaAntesVirgula = antesDaVirgula.ToCharArray();

            char[] separaDepoisVirgula = depoisDaVirgula.ToCharArray();

            string recebeValor = "";


            if (antesDaVirgula.Length > 1)
            {

                int indice = separaAntesVirgula.Length - 1;

                return retornaListaUnidades(separaAntesVirgula, indice) + nomenclaturaReais;

            }


            if (depoisDaVirgula.Length > 2)
            {
                int indice = separaDepoisVirgula.Length - 1;

                return retornaListaUnidades(separaDepoisVirgula, indice) + nomenclaturaReais;
            }


            if (antesDaVirgula.Length == 1)
            {
                char[] separa = valor.ToCharArray();
                recebeValor = retornaListaUnidades(separa, 0);

                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(recebeValor) + nomenclaturaReais;

            }

            return "unidade";
        }

        public string verificaUnidadeMilhar(string valor)
        {
            string antesDaVirgula = valor.Split(',')[0];
            string depoisVirgula = valor.Split(',')[1];

            char[] separaAntesVirgula = antesDaVirgula.ToCharArray();

            string recebeValor = "";

            if (antesDaVirgula.Length > 1 && depoisVirgula.Length >2)
            {

                int indice = separaAntesVirgula.Length - 1;

                return retornaListaUnidades(separaAntesVirgula, indice) + nomenclaturaReais;

            }


            if (antesDaVirgula.Length == 1)
            {

                int indice = antesDaVirgula.Length - 1;

                recebeValor = retornaListaUnidades(separaAntesVirgula, indice);

                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(recebeValor) + nomenclaturaMil;

            }

            return "unidade milhar";
        }



    }
}
