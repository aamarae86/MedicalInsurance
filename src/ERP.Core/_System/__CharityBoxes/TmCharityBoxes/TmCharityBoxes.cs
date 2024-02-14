using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._TmCharityBoxesType;
using ERP._System.__CharityBoxes._TmCharityBoxReceive;
using ERP._System.__CharityBoxes._TmLocations;
using ERP._System.__CharityBoxes._TmSupervisors;
using ERP._System._FndLookupValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__CharityBoxes._TmCharityBoxes
{
    public class TmCharityBoxes : AuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        [Required]
        [MaxLength(30)]
        public string CharityBoxNumber { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string CharityBoxName { get; protected set; }

        [Required]
        [MaxLength(30)]
        public string CharityBoxBarcode { get; protected set; }

        [Required]
        public long StatusLkpId { get; protected set; }
        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndLookupValues { get; protected set; }

        [Required]
        public long CharityTypeId { get; protected set; }
        [ForeignKey(nameof(CharityTypeId))]
        public TmCharityBoxesType CharityBoxesType { get; protected set; }

        public long? TmSupervisorId { get; protected set; }
        [ForeignKey(nameof(TmSupervisorId))]
        public TmSupervisors TmSupervisor { get; protected set; }

        public long? TmSubLocationId { get; protected set; }

        [ForeignKey(nameof(TmSubLocationId))]
        public TmLocationSub TmSubLocation { get; protected set; }


        public long? TmCharityBoxReceiveId { get; protected set; }


        [ForeignKey(nameof(TmCharityBoxReceiveId))]
        public TmCharityBoxReceive TmCharityBoxReceive { get; protected set; }

        public long? InternalCounterPerType { get; protected set; }

    }
    //class TmCharityBoxesComparer : IEqualityComparer<TmCharityBoxes>
    //{
    //    public bool Equals(TmCharityBoxes x, TmCharityBoxes y)
    //    {
    //        //Check whether the compared objects reference the same data.
    //        if (Object.ReferenceEquals(x, y)) return true;

    //        //Check whether any of the compared objects is null.
    //        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
    //            return false;

    //        //Check whether the products' properties are equal.
    //        return x.CharityBoxName == y.CharityBoxName && x.CharityBoxNumber == y.CharityBoxNumber;
    //    }

    //    public int GetHashCode(TmCharityBoxes obj)
    //    {
    //        //Check whether the object is null
    //        if (Object.ReferenceEquals(obj, null)) return 0;

    //        //Get hash code for the Name field if it is not null.
    //        int hashProductName = obj.CharityBoxName == null ? 0 : obj.CharityBoxName.GetHashCode();

    //        //Get hash code for the Code field.
    //        int hashProductCode = obj.CharityBoxNumber.GetHashCode();

    //        //Calculate the hash code for the product.
    //        return hashProductName ^ hashProductCode;
    //    }
    //}
}