﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SeaManifestEntities : DbContext
    {
        public SeaManifestEntities()
            : base("name=SeaManifestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblAdditionalDetailsHouseCargoMap> tblAdditionalDetailsHouseCargoMaps { get; set; }
        public virtual DbSet<tblAdditionalDetailsMasterConsignmentMap> tblAdditionalDetailsMasterConsignmentMaps { get; set; }
        public virtual DbSet<tblAdditionalDetailsMessageImplementationMap> tblAdditionalDetailsMessageImplementationMaps { get; set; }
        public virtual DbSet<tblAmendmentDetailsMessageImlementationMap> tblAmendmentDetailsMessageImlementationMaps { get; set; }
        public virtual DbSet<tblCodeM> tblCodeMs { get; set; }
        public virtual DbSet<tblCodeTypeM> tblCodeTypeMs { get; set; }
        public virtual DbSet<tblCountryM> tblCountryMs { get; set; }
        public virtual DbSet<tblCurrencyCodesM> tblCurrencyCodesMs { get; set; }
        public virtual DbSet<tblErrorCode> tblErrorCodes { get; set; }
        public virtual DbSet<tblHouseCargoDescriptionMasterConsignmentMap> tblHouseCargoDescriptionMasterConsignmentMaps { get; set; }
        public virtual DbSet<tblItemDetailsHouseCargoMap> tblItemDetailsHouseCargoMaps { get; set; }
        public virtual DbSet<tblItemDetailsMasterConsignmentMap> tblItemDetailsMasterConsignmentMaps { get; set; }
        public virtual DbSet<tblItineraryHouseCargoMap> tblItineraryHouseCargoMaps { get; set; }
        public virtual DbSet<tblItineraryMasterConsignmentMap> tblItineraryMasterConsignmentMaps { get; set; }
        public virtual DbSet<tblMasterConsignmentMessageImplementationMap> tblMasterConsignmentMessageImplementationMaps { get; set; }
        public virtual DbSet<tblMessageTypeM> tblMessageTypeMs { get; set; }
        public virtual DbSet<tblPersonOnBoardMessageImplementationMap> tblPersonOnBoardMessageImplementationMaps { get; set; }
        public virtual DbSet<tblPortM> tblPortMs { get; set; }
        public virtual DbSet<tblSupportDocHouseCargoMap> tblSupportDocHouseCargoMaps { get; set; }
        public virtual DbSet<tblSupportDocMasterConsignmentMap> tblSupportDocMasterConsignmentMaps { get; set; }
        public virtual DbSet<tblSupportDocMessageImplementationMap> tblSupportDocMessageImplementationMaps { get; set; }
        public virtual DbSet<tblTransportEquipmentHouseCargoMap> tblTransportEquipmentHouseCargoMaps { get; set; }
        public virtual DbSet<tblTransportEquipmentMasterConsignmentMap> tblTransportEquipmentMasterConsignmentMaps { get; set; }
        public virtual DbSet<tblVoyageTransporterEquipmentMessageImplementationMap> tblVoyageTransporterEquipmentMessageImplementationMaps { get; set; }
        public virtual DbSet<tblRoleM> tblRoleMs { get; set; }
        public virtual DbSet<tblRolePermissionsM> tblRolePermissionsMs { get; set; }
        public virtual DbSet<tblUserM> tblUserMs { get; set; }
        public virtual DbSet<tblPermissionM> tblPermissionMs { get; set; }
        public virtual DbSet<tblMessageImplementation> tblMessageImplementations { get; set; }
    }
}
