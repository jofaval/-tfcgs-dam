namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Horario")]
    public partial class Horario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Horario()
        {
            Impartimiento = new HashSet<Impartimiento>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string CursoCod { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string CursoNombre { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(9)]
        public string CodAsignatura { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime HoraInicio { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Dia { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Anyo { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "date")]
        public DateTime HoraFinal { get; set; }

        public virtual Asignatura Asignatura { get; set; }

        public virtual Curso Curso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Impartimiento> Impartimiento { get; set; }
    }
}
