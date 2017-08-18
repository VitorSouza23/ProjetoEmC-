using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitorteste.Model;

namespace Vitorteste.Services
{
    class NotasService
    {
        private static NotasService INSTANCIA = null;
        private NotasService()
        {
            
        }

        public static NotasService GetInstance()
        {
            if (INSTANCIA == null)
            {
                return new NotasService();
            }

            return INSTANCIA;
        }

        public int CalcularMedia_Inteira(Aluno aluno)
        {
            int soma = 0;
            foreach (Nota nota in aluno.GetAllNotas())
            {
                soma += nota.Valor;
            }
            return soma / aluno.GetNumeroTotalDeNotas();
        }

        public double CalcularMedia_Decimal(Aluno aluno)
        {
            double soma = 0.0;
            foreach (Nota nota in aluno.GetAllNotas())
            {
                soma += nota.Valor;
            }
            return soma / (double)aluno.GetNumeroTotalDeNotas();
        }

        public int CalcularMediageralDaTurma_Inteira(Turma turma)
        {
            int soma = 0;
            foreach (Aluno aluno in turma.GetAllAlunos())
            {
                soma += this.CalcularMedia_Inteira(aluno);
            }
            return soma / turma.GetTotalDeAlunos();
        }

        public double CalcularMediageralDaTurma_Decimal(Turma turma)
        {
            double soma = 0.0;
            foreach (Aluno aluno in turma.GetAllAlunos())
            {
                soma += this.CalcularMedia_Decimal(aluno);
            }
            return soma / (double) turma.GetTotalDeAlunos();
        }

        public int CalcularMediaPonderada_Inteira(Aluno aluno)
        {
            int soma = 0;
            int somaPesos = 0;
            aluno.GetAllNotas().ForEach((nota) =>
            {
                soma += nota.Valor * nota.Peso;
                somaPesos += nota.Peso;
            });
            return soma / somaPesos;
        }

        public double CalcularMediaPonderada_Decimal(Aluno aluno)
        {
            double soma = 0;
            double somaPesos = 0;
            aluno.GetAllNotas().ForEach((nota) =>
            {
                soma += nota.Valor * nota.Peso;
                somaPesos += nota.Peso;
            });
            return soma / somaPesos;
        }
    }
}
