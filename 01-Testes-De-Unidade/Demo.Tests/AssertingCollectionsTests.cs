using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Tests
{
    public class AssertingCollectionsTests
    {
        [Fact]
        public void Funcionario_Habilidades_NaoDevePosssuirHabilidadesVazias()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Rafael", 10000);

            // Assert
            /*
             * Um Funcionario possui um IList<string> de habilidades.
             * No 1º parâmetro eu defino qual será a lista, e no 2º ocorre a iteração
             * (para cada item dessa lsta que chamaremos de 'habilidade', faça essa nova Assert),
             * Sendo a Assert uma negação do 'IsNullOrWhiteSpace'.
             */
            Assert.All(
                funcionario.Habilidades,
                habilidade => Assert.False(string.IsNullOrWhiteSpace(habilidade))
                );
        }

        [Fact]
        public void Funcionario_Habilidades_JuniorDevePossuirHabilidadeBasica()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Rafael", 1000);

            // Assert
            /*
             * Dentro do IList<string> um dos itens deve ser a string "OOP"
             */
            Assert.Contains("OOP", funcionario.Habilidades);
        }

        [Fact]
        public void Funcionario_Habilidades_JuniorNaoDevePossuirHabilidadeAvancada()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Rafael", 1000);

            // Assert
            /*
             * Dentro do IList<string> um dos itens deve ser a string "OOP"
             */
            Assert.DoesNotContain("Microservices", funcionario.Habilidades);
        }

        [Fact]
        public void Funcionario_Habilidades_SeniorDevePossuirTodasHabilidades()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Rafael", 15000);

            var habilidadesBasicas = new[]
            {
                "Lógica de Programação",
                "OOP",
                "Testes",
                "Microservices"
            };

            // Assert
            Assert.Equal(habilidadesBasicas, funcionario.Habilidades);
        }
    }
}
