//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dealership_BD2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicles()
        {
            this.Orders = new HashSet<Orders>();
        }
    
        public int ID_Vehicle { get; set; }
        public int Brand_ID { get; set; }
        public int Model_ID { get; set; }
        public string Years { get; set; }
        public decimal Price { get; set; }
    
        public virtual Brands Brands { private get; set; }
        public virtual Models Models { private get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { private get; set; }
    }
}
