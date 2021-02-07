using System;
namespace API.Bank
{
    public class Conta
    {
        public string Nome {get; set;}

        private double Saldo {get; set;}

        private double Credito {get; set;}

        private TipoConta TipoConta {get; set;}

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            //Validacao de Saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            //this.saldo = this.saldo -this.Saque
            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo Atual da Conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar (double valorDeposito)
        {
            this.Saldo += valorDeposito; 
            
            Console.WriteLine("Saldo Atual da Conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir( double valorTransferir, Conta contaDestino)
        {
            if(this.Sacar(valorTransferir))
            {
                contaDestino.Depositar(valorTransferir);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += " Tipo Conta: " + this.TipoConta;
            retorno += " Nome: " + this.Nome;
            retorno += " Saldo: " + this.Saldo;
            retorno += " Crédito: " + this.Credito;

            return retorno;
        }

        

     }
}