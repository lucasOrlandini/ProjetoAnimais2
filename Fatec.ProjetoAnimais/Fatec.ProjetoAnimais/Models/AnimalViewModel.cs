using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fatec.ProjetoAnimais.Models
{
    public class AnimalViewModel
    {
    
        public int id { get; set; }

        [Required]
        public string cidade_encontrado { get; set; }

        [Required]
        public string condicoes { get; set; }

        [Required]
        public string especie { get; set; }
        public string porte { get; set; }

        [Required]
        public string raca { get; set; }
        public int sexo { get; set; }
        public string descSexo
        {
            get
            {
                if (this.sexo == 1)
                {
                    return "Macho";
                }
                else
                {
                    return "Fêmea";
                }
            }

        }
        public int vacinas { get; set; }
        public string descVacinas
        {
            get
            {
                if (this.vacinas == 1)
                {
                    return "Sim";
                }
                else
                {
                    return "Não";
                }
            }

        }
        public int situacao { get; set; }
        public string descSituacao
        {
            get
            {
                if (this.situacao == 1)
                {
                    return "Disponível";
                }
                else
                {
                    return "Indisponível";
                }
            }

        }

    }
}
