using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitorteste.Model
{
    class Nota
    {
        private int valor;
        private string observacao;
        private int peso;

        
        public Nota(int valor, string observacao)
        {
            this.Valor = valor;
            this.Observacao = observacao;
        }

        public Nota(int valor, string observacao, int peso)
        {
            this.Valor = valor;
            this.Observacao = observacao;
            this.Peso = peso;
        }

        public Nota(int valor, int peso)
        {
            this.Valor = valor;
            this.Peso = peso;
        }

        public Nota(int valor)
        {
            this.Valor = valor;
            this.Observacao = null;
        }

        public Nota()
        {
            this.Valor = 0;
            this.Observacao = null;
        }

        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public string Observacao
        {
            get { return observacao; }
            set { observacao = value; }
        }

        public int Peso
        {
            get { return peso; }
            set { peso = value; }
        }
    }
}
