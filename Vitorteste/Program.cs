using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Vitorteste.Model;
using Vitorteste.Services;

namespace Vitorteste
{
    class Program
    {
        static void Main(string[] args)
        {

            int opc = -1;
            Turma turma = new Turma("Turma 1", "4534534", 3);
            Aluno aluno;
            MessageBox.Show("Olá, Bem-Vindo ao Controle de Notas", "Controle de Notas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            do
            {
                opc = int.Parse(Interaction.InputBox("Escolha uma opção: \n"
                     + "1 - Cadastrar aluno\n"
                     + "2 - Dar Nota\n"
                     + "3 - Calcular Média\n"
                     + "0 - Sair", "Escolha uma opção", "Digite o número da opção..."));

                switch (opc)
                {
                    case 1:
                        string nome = Interaction.InputBox("Digite o nome do Aluno:", "Nome do Aluno", "Digite o nome aqui...");
                        int idade;
                        bool teste = int.TryParse(Interaction.InputBox("Digite a idade do Aluno: ", "Idade do Aluno", "Digite a idade aqui..."), out idade);
                        if (!teste)
                        {
                            MessageBox.Show("Por favor, só utilize números!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        Random random = new Random();
                        string matricula = random.Next(100000, 999999).ToString();
                        turma.AddAluno(new Aluno(nome, idade, matricula));
                        MessageBox.Show("Aluno cadastrado!\n"
                            + "Nome: " + nome + "\n"
                            + "Idade: " + idade + "\n"
                            + "Matrícula: " + matricula, "Aluno Cadastrado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case 2:

                        aluno = GetAluno(turma);
                        if (aluno == null)
                        {
                            break;
                        }
                        int valorNota;
                        bool testeNota = int.TryParse(Interaction.InputBox("Digite o valor da nota:", "Nota do aluno", "Digite a nota do aluno aqui..."), out valorNota);
                        if (!testeNota)
                        {
                            MessageBox.Show("Por favor, só utilize números!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        if (valorNota > 10 || valorNota < 0)
                        {
                            MessageBox.Show("Por favor, só utilize valores de 0 a 10 para notas!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        aluno.AddNota(new Nota(valorNota));
                        MessageBox.Show("Nota adicinada ao Aluno: " + aluno.Nome + ".", "Nota Adicionada!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case 3:
                        aluno = GetAluno(turma);
                        if (aluno == null)
                        {
                            break;
                        }
                        if (aluno.GetNumeroTotalDeNotas() == 0)
                        {
                            MessageBox.Show("O aluno " + aluno.Nome  + " ainda não possui notas!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        string notas = "(";
                        for (int x = 0; x < aluno.GetNumeroTotalDeNotas(); x++)
                        {
                            if (x == aluno.GetNumeroTotalDeNotas() - 1)
                            {
                                notas += " " + aluno.GetNota(x).Valor + " ";
                            }
                            else
                            {
                                notas += " " + aluno.GetNota(x).Valor + " +";
                            }
                        }
                        notas += ")";
                        NotasService notaService = NotasService.GetInstance();
                        MessageBox.Show("Notas: " + notas + " / " + aluno.GetNumeroTotalDeNotas() + " = " + notaService.CalcularMedia_Inteira(aluno), "Média!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 0:
                        MessageBox.Show("Obrigado por utilizar o sistema!", "Fim!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    default:
                        MessageBox.Show("Opção inválida!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            } while (opc != 0);

        }

        private static Aluno GetAluno(Turma turma)
        {
            if (turma.GetTotalDeAlunos() == 0)
            {
                MessageBox.Show("Não há alunos cadastrados no sistema!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            string alunos = "";
            for (int x = 0; x < turma.GetTotalDeAlunos(); x++)
            {
                alunos += x + " - " + turma.GetAluno(x).Nome + "\n";
            }
            int indexAluno;
            bool testeIndex = int.TryParse(Interaction.InputBox("Digite o número do aluno:\n" + alunos, "Escolha um aluno", "Digite o número do aluno aqui..."), out indexAluno);
            if (!testeIndex)
            {
                MessageBox.Show("Por favor, só utilize números!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            if (indexAluno < 0 || indexAluno > turma.GetTotalDeAlunos())
            {
                MessageBox.Show("Por favor, escolha um valor existente!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return turma.GetAluno(indexAluno);
        }
    }
}
