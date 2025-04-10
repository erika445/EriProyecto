using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace Nuevo_Proyecto.Model
{
    public class Store
    {
        [Key]
        [Required]
        public int BusinessEntityID { get; set; }


        [Required]
        public string Name { get; set; }


        public int SalesPersonalID { get; set; }


        public string Demographics { get; set; }

        [Required]
        public string rowguid { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }



    }
}
