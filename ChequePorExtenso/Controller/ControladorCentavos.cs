using ChequePorExtenso.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePorExtenso.Controller
{
    public class ControladorCentavos
    {
        ControladorUnidade controladorUnidade;

        ControladorDezena controladorDezena;

        Conversor c;

        public ControladorCentavos(ControladorUnidade ctrlUnidade, ControladorDezena ctrlDezena, Conversor conversor)
        {
            controladorUnidade = ctrlUnidade;
            controladorDezena = ctrlDezena;
            c = conversor;
        }


        public string verificaCentavos(string valor)
        {
            string nomenclaturaCentavos = " centavos de real";

            string aposVirgula = valor.Split(',')[1];

            string[] recebeSplit = c.RetornaArraySplit(valor);

            string recebeValorUnidade = "";

            string recebeValorDezena = "";



            if (recebeSplit[1].Length > 1)
            {


                if (aposVirgula != null)
                {
                    char[] separaAposVirgula = aposVirgula.ToCharArray();

                    int indice = separaAposVirgula.Length - 1;

                    recebeValorUnidade = controladorUnidade.retornaListaUnidades(separaAposVirgula, indice);
                    recebeValorDezena = controladorDezena.retornaListaDezenas(separaAposVirgula, 0);
                }
                return (recebeValorDezena) + " " + (recebeValorUnidade) + nomenclaturaCentavos;


            }
            else
            {
                char[] separa = valor.ToCharArray();
                int indice = separa.Length - 1;
                string recebeValor = controladorUnidade.retornaListaUnidades(separa, indice);

                if (recebeValor == "um")
                {
                    return recebeValor + "centavo de real";
                }

                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(recebeValor) + nomenclaturaCentavos;

            }

        }

        

    }
}
