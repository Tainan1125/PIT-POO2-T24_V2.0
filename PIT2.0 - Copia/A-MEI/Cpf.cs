using System;

namespace KomsertaPC_OS_s
{
    public class Cpf
    {
        private String cpf;

        private Cpf(String cpf)
        {
            this.cpf = cpf;
        }
        public String getCpf()
        {
            return cpf;
        }
        public void setCpf(String cpf)
        {
            this.cpf = cpf;
        }

        public static Cpf Create(String cpf)
        {
            if(!IsCpf(cpf))  throw new Exception("CPF Inválido!");
            return new Cpf(cpf);
        }

        public static bool IsCpf(String CPF)
        {
            // considera-se erro CPF's formados por uma sequencia de numeros iguais
            if (IsNumeroIgual(CPF)) return (false);
            // testando os digitos verificadores
            return IsDigitoVerificador(CPF);
        }

        private static bool IsDigitoVerificador(String cpf)
        {
            char digito10, digito11;

            // "try" - protege o codigo para eventuais erros de conversao de tipo (int)
            try
            {
                // Calculo do 1o. Digito Verificador
                digito10 = primeiroDigitoVerificador(cpf);
                // Calculo do 2o. Digito Verificador
                digito11 = segundoDigitoVerificador(cpf);

                // Verifica se os digitos calculados conferem com os digitos informados.
                return digito10 == cpf[9] && digito11 == cpf[10];
            }
            catch (Exception erro)
            {
                return false;
            }
        }

        private static char segundoDigitoVerificador(String cpf)
        {
            int soma = 0, peso = 11, num, r;
            char digito11;
            for (int i = 0; i < 10; i++)
            {
                // converte o i-esimo caractere do CPF em um numero
                num = cpf[i] - 48;
                soma = soma + (num * peso);
                peso = peso - 1;
            }

            r = 11 - (soma % 11);
            if ((r == 10) || (r == 11))
                digito11 = '0';
            else digito11 = (char)(r + 48);
            return digito11;
        }

        private static char primeiroDigitoVerificador(String cpf)
        {
            int soma = 0, peso = 10, num, r;
            char digito10;
            for (int i = 0; i < 9; i++)
            {
                // converte o i-esimo caractere do CPF em um numero
                num = cpf[i] - 48;
                soma = soma + (num * peso);
                peso = peso - 1;
            }

            r = 11 - (soma % 11);
            if ((r == 10) || (r == 11))
                digito10 = '0';
            else digito10 = (char)(r + 48); // converte no respectivo caractere numerico
            return digito10;
        }

        private static bool IsNumeroIgual(String cpf)
        {
            return cpf.Equals("00000000000") ||
                    cpf.Equals("11111111111") ||
                    cpf.Equals("22222222222") || cpf.Equals("33333333333") ||
                    cpf.Equals("44444444444") || cpf.Equals("55555555555") ||
                    cpf.Equals("66666666666") || cpf.Equals("77777777777") ||
                    cpf.Equals("88888888888") || cpf.Equals("99999999999") ||
                    cpf.Length != 11;
        }

    }

}

        