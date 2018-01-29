using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Runtime.Serialization;

namespace CarRental.Business.Entities
{
    [DataContract]
    public class Rental : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        [DataMember]
        public int RentalId { get; set; }
        [DataMember]
        public int CarId { get; set; }
        [DataMember]
        public int AccountId { get; set; }
        [DataMember]
        public DateTime DateRented { get; set; }
        [DataMember]
        public DateTime? DateReturned { get; set; }
        [DataMember]
        public DateTime DateDue { get; set; }
        public int EntityId
        {
            get => RentalId;
            set => RentalId = value;
        }

        int IAccountOwnedEntity.OwnerAccountId
        {
            get => AccountId;
        }
    }
}
