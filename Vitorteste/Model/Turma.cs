using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitorteste.Abstract;

namespace Vitorteste.Model
{
    class Turma : AbstractListController<Aluno>
    {
        private string nome;
        private string codigo;
        private int ano;

        public Turma(string nome, string codigo, int ano, List<Aluno> listaAlunos)
        {
            this.Nome = nome;
            this.Codigo = codigo;
            this.Ano = ano;
            this.Lista = listaAlunos;
        }

        public Turma(string nome, string codigo, int ano)
        {
            this.Nome = nome;
            this.Codigo = codigo;
            this.Ano = ano;
        }

        public Turma()
        {
            
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
      

        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }
        

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public void AddAluno(Aluno aluno)
        {
            this.AddElement(aluno);
        }

        public bool RemoveAluno(int index)
        {
            return this.RemoveElement(index);
        }

        public bool UpdateAluno(int index, Aluno novoAluno)
        {
            return this.UpdateElement(index, novoAluno);
        }

        public Aluno GetAluno(int index)
        {
            return this.GetElement(index);
        }

        public List<Aluno> GetAllAlunos()
        {
            return this.Lista;
        }

        public int GetTotalDeAlunos()
        {
            return this.ListSize();
        }
    }
}
