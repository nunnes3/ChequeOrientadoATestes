using ChequePorExtenso.Controller;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePorExtenso.Model
{
    public class Conversor
    {
        public ControladorConversor controlaodor ;
        public ControladorCentavos controlaodorCentavos;
        public ControladorUnidade controladorUnidade;
        public ControladorCentena controladorCentena;
        public ControladorDezena controladorDezena;
        

        public Conversor(ControladorCentavos ctrlCentavos, ControladorCentena ctrlCentena, ControladorUnidade ctrlUnidade, ControladorDezena ctrlDezena)
        {
            controlaodorCentavos = ctrlCentavos;
            controladorCentena = ctrlCentena;
            controladorUnidade = ctrlUnidade;
            controladorDezena = ctrlDezena;
        }

        public Conversor()
        {

        }

        public string Validar(decimal valor)
        {

            string recebeValorDecimal = Convert.ToString(valor);


            string[] recebeSplit = RetornaArraySplit(recebeValorDecimal);
            
            if (recebeSplit[0] == "0" && recebeSplit.Length == 1)
            {
                return "Valor Invalido";
            }


            if (recebeSplit[0] == "0")
            {
                return (controlaodorCentavos.verificaCentavos(recebeValorDecimal));
            }

            if (recebeSplit[0] != "0" && recebeSplit[0].Length < 2 && recebeSplit[1].Length < 3)
            {
                if (recebeSplit[1] == "00")
                {
                    return (controladorUnidade.verificaUnidade(recebeValorDecimal));
                }

                return (controladorUnidade.verificaUnidade(recebeValorDecimal) + " e " + controlaodorCentavos.verificaCentavos(recebeValorDecimal));
            }

            if (recebeSplit[0] != "0" && recebeSplit[0].Length == 2)
            {
                return (controladorDezena.verificaDezena(recebeValorDecimal) + " e " + controladorUnidade.verificaUnidade(recebeValorDecimal));
            }

            if (recebeSplit[0] != "0" && recebeSplit[0].Length == 3 & recebeSplit[1] != "0")
            {
                return (controladorCentena.verificaCentena(recebeValorDecimal) + " e " + controladorDezena.verificaDezena(recebeValorDecimal) + " e " 
                + controladorUnidade.verificaUnidade(recebeValorDecimal));
            }

            if(recebeSplit[0].Length < 2 && recebeSplit[0] != "0" && recebeSplit[1].Length > 2)
            {
                return (controladorUnidade.verificaUnidadeMilhar(recebeValorDecimal)) + " " + (controladorCentena.verificaCentena(recebeValorDecimal)) + " e "
                + controladorDezena.verificaDezena(recebeValorDecimal) + " e " + controladorUnidade.verificaUnidade(recebeValorDecimal); 
            }

            return recebeValorDecimal;
        }


        public string[] RetornaArraySplit(string valor)
        {
            return valor.Split(',');
        }

    }

    

}

