using Rastreabilidade.Entidades;
using System.Linq;
using System.Collections.Generic;

namespace Rastreabilidade.Models {
    /// <summary>
    /// Adiciona o tratamento de nomes de tabelas separadas por vírgulas
    /// </summary>
    public class ModuloModelView : Modulo {

        public ModuloModelView() { }

        public ModuloModelView(Modulo modulo) {
            this.Nome = modulo.Nome;
            this.Tabelas = modulo.Tabelas;
        }

        public string oldID { get; set; }

        /// <summary>
        /// Converte uma string separada por vírgula com os nomes das tabelas
        /// Na lista de tabelas do módulo
        /// </summary>
        public string TabelasComVirgulas {
            get {
                return string.Join(",", this.Tabelas);
            }
            set {
                if (value != null) {
                    string[] tableNames = value.Split(',');
                    foreach (string tableName in tableNames) {
                        if (!this.Tabelas.Any(t => t.Nome.Equals(tableName)) && tableName.Length != 0)
                            this.Tabelas.Add(
                                new Tabela { Nome = tableName });
                    }
                } else {
                    this.Tabelas = new List<Tabela>();
                }
            }
        }
    }
}