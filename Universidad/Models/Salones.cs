//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Universidad.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Salones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Salones()
        {
            this.Alunmos_Materias = new HashSet<Alunmos_Materias>();
        }
    
        public int Id { get; set; }
        public string NumeroSalon { get; set; }
        public int Piso { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alunmos_Materias> Alunmos_Materias { get; set; }
    }
}
