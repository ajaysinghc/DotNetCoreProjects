using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Runtime.Serialization;

namespace CarRental.Business.Entities
{
    [DataContract]
    public class Reservation : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        [DataMember]
        public int ReservationId { get; set; }
        [DataMember]
        public int AccountId { get; set; }
        [DataMember]
        public int CarId { get; set; }
        [DataMember]
        public DateTime RentalDate { get; set; }
        [DataMember]
        public DateTime ReturnDate { get; set; }
        int IIdentifiableEntity.EntityId
        {
            get => ReservationId;
            set => ReservationId = value;
        }

        int IAccountOwnedEntity.OwnerAccountId => AccountId;
    }
}
