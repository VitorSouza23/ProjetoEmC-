using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitorteste.Abstract;

namespace Vitorteste.Model
{
    class Aluno : AbstractListController<Nota>
    {
        private string nome;
        private int idade;
        private string matricula;

        public Aluno(string nome, int idade, string matricula, List<Nota> listaNotas)
        {
            this.Matricula = matricula;
            this.Idade = idade;
            this.Nome = nome;
            this.Lista = listaNotas;
        }

        public Aluno(string nome, int idade, string matricula)
        {
            this.Matricula = matricula;
            this.Idade = idade;
            this.Nome = nome;
        }

        public Aluno()
        {
        }

        public int Idade
        {
            get { return idade; }
            set { idade = value; }
        }


        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        

        public void AddNota(Nota nota)
        {
            this.AddElement(nota);
        }

        public bool RemoveNota(int index)
        {
            return this.RemoveElement(index);
        }

        public bool UpdateNota(int index, Nota novaNota)
        {
            return this.UpdateElement(index, novaNota);
        }

        public Nota GetNota(int index)
        {
            return this.GetElement(index);
        }


        public List<Nota> GetAllNotas()
        {
            return this.Lista;
        }

        public int GetNumeroTotalDeNotas()
        {
            return this.ListSize();
        }


        public string ToString()
        {
            return "Nome: " + this.Nome + "\n"
                    + "idade: " + this.Idade + "\n"
                    + "Matrícula: " + this.Matricula;
        }

    }
}
