using BAL.Models;
using BAL.Utilities;
using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{//PersonOnBoardMessageImplementation
    public class PersonOnBoardMessageImplementationService
    {
        private PersonOnBoardMessageImplementationService()
        {
        }

        private static PersonOnBoardMessageImplementationService _instance;

        public static PersonOnBoardMessageImplementationService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PersonOnBoardMessageImplementationService();
                return _instance;
            }
        }

        //save PersonOnBoardMessageImplementation 
        public object SavePersonOnBoardMessageImplementation(PersonOnBoardMessageImplementationModel model, int iUserId)
        {
            try
            {
                using (var db = new SeaManifestEntities())
                {
                    var data = db.tblPersonOnBoardMessageImplementationMaps.Where(z => z.iPersonOnBoardId == model.iPersonOnBoardId).SingleOrDefault();
                    if (data != null)
                    {
                        data.iMessageImplementationId = model.iMessageImplementationId;
                        data.dPersonOnBaordSeqNo = model.dPersonOnBaordSeqNo;
                        data.sPersonDetailsPersonTypeCdd = model.sPersonDetailsPersonTypeCdd;
                        data.sPersonDetailsPersonFamilyName = model.sPersonDetailsPersonFamilyName;
                        data.sPersonDetailsPersonGivenName = model.sPersonDetailsPersonGivenName;
                        data.sPersonDetailsPersonNationalityCdd = model.sPersonDetailsPersonNationalityCdd;
                        data.dPersonDetailsPassengersInTransitIndicator = model.dPersonDetailsPassengersInTransitIndicator;
                        data.sPersonDetailsCrewMemberRankOrRatingName = model.sPersonDetailsCrewMemberRankOrRatingName;
                        data.sPersonDetailsCrewMemberRankOrRatingCdd = model.sPersonDetailsCrewMemberRankOrRatingCdd;
                        data.sPersonDetailsPassangerPartOfEmbarkTnCdd = model.sPersonDetailsPassangerPartOfEmbarkTnCdd;
                        data.sPersonDetailsPassangerPartOfEmbarkTnName = model.sPersonDetailsPassangerPartOfEmbarkTnName;
                        data.sPersonDetailsPassangerPartOfDsmbarkTnCdd = model.sPersonDetailsPassangerPartOfDsmbarkTnCdd;
                        data.sPersonDetailsPassangerPartOfDsmbarkTnName = model.sPersonDetailsPassangerPartOfDsmbarkTnName;
                        data.sPersonDetailsPersonGenderCdd = model.sPersonDetailsPersonGenderCdd;
                        data.dtPersonDetailsPersonDateOfBirth = model.dtPersonDetailsPersonDateOfBirth.ToDate();
                        data.sPersonDetailsPersonPlaceOfBirthName = model.sPersonDetailsPersonPlaceOfBirthName;
                        data.sPersonDetailsPersonCountryOfBirthCdd = model.sPersonDetailsPersonCountryOfBirthCdd;
                        data.dtPersonIdDocExpiryDate = model.dtPersonIdDocExpiryDate.ToDate();
                        data.sPersonIdOrTravelDocIssuingNationCdd = model.sPersonIdOrTravelDocIssuingNationCdd;
                        data.sPersonIdOrTravelDocNo = model.sPersonIdOrTravelDocNo;
                        data.sPersonIdOrTravelDocTypeCdd = model.sPersonIdOrTravelDocTypeCdd;
                        data.sVisaDetailsPersonVisa = model.sVisaDetailsPersonVisa;
                        data.sVisaDetailsPNRNo = model.sVisaDetailsPNRNo;
                        data.iActionBy = iUserId;
                        data.dtActionDate = DateTime.Now;
                        db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        data = new tblPersonOnBoardMessageImplementationMap
                        {
                            iMessageImplementationId = model.iMessageImplementationId,
                            dPersonOnBaordSeqNo = model.dPersonOnBaordSeqNo,
                            sPersonDetailsPersonTypeCdd = model.sPersonDetailsPersonTypeCdd,
                            sPersonDetailsPersonFamilyName = model.sPersonDetailsPersonFamilyName,
                            sPersonDetailsPersonGivenName = model.sPersonDetailsPersonGivenName,
                            sPersonDetailsPersonNationalityCdd = model.sPersonDetailsPersonNationalityCdd,
                            dPersonDetailsPassengersInTransitIndicator = model.dPersonDetailsPassengersInTransitIndicator,
                            sPersonDetailsCrewMemberRankOrRatingName = model.sPersonDetailsCrewMemberRankOrRatingName,
                            sPersonDetailsCrewMemberRankOrRatingCdd = model.sPersonDetailsCrewMemberRankOrRatingCdd,
                            sPersonDetailsPassangerPartOfEmbarkTnCdd = model.sPersonDetailsPassangerPartOfEmbarkTnCdd,
                            sPersonDetailsPassangerPartOfEmbarkTnName = model.sPersonDetailsPassangerPartOfEmbarkTnName,
                            sPersonDetailsPassangerPartOfDsmbarkTnCdd = model.sPersonDetailsPassangerPartOfDsmbarkTnCdd,
                            sPersonDetailsPassangerPartOfDsmbarkTnName = model.sPersonDetailsPassangerPartOfDsmbarkTnName,
                            sPersonDetailsPersonGenderCdd = model.sPersonDetailsPersonGenderCdd,
                            dtPersonDetailsPersonDateOfBirth = model.dtPersonDetailsPersonDateOfBirth.ToDate(),
                            sPersonDetailsPersonPlaceOfBirthName = model.sPersonDetailsPersonPlaceOfBirthName,
                            sPersonDetailsPersonCountryOfBirthCdd = model.sPersonDetailsPersonCountryOfBirthCdd,
                            dtPersonIdDocExpiryDate = model.dtPersonIdDocExpiryDate.ToDate(),
                            sPersonIdOrTravelDocIssuingNationCdd = model.sPersonIdOrTravelDocIssuingNationCdd,
                            sPersonIdOrTravelDocNo = model.sPersonIdOrTravelDocNo,
                            sPersonIdOrTravelDocTypeCdd = model.sPersonIdOrTravelDocTypeCdd,
                            sVisaDetailsPersonVisa = model.sVisaDetailsPersonVisa,
                            sVisaDetailsPNRNo = model.sVisaDetailsPNRNo,
                            iActionBy = iUserId,
                            dtActionDate = DateTime.Now,
                        };
                        db.tblPersonOnBoardMessageImplementationMaps.Add(data);
                        db.SaveChanges();
                    }
                    return new { Status = true, Message = "Person On Board saved successfully!" };
                }

            }
            catch (Exception)
            {
                return new { Status = false, Message = "Something went wrong" };
            }
        }

        public object GetPersonOnBoardMessageImplementation(int iMessageImplementationId, string search, int start, int length, out int recordsTotal)
        {
            using (var db = new SeaManifestEntities())
            {
                var query = from t in db.tblPersonOnBoardMessageImplementationMaps
                            where (
                                   t.sPersonDetailsPersonTypeCdd.Contains(search)
                                || t.sPersonDetailsPersonFamilyName.Contains(search)
                                || t.sPersonDetailsPersonGivenName.Contains(search)
                                || t.sPersonDetailsPersonNationalityCdd.Contains(search)
                                || t.sPersonDetailsCrewMemberRankOrRatingName.Contains(search)
                                || t.sPersonDetailsCrewMemberRankOrRatingCdd.Contains(search)
                                || t.sPersonDetailsPassangerPartOfEmbarkTnCdd.Contains(search)
                                || t.sPersonDetailsPassangerPartOfEmbarkTnName.Contains(search)
                                || t.sPersonDetailsPassangerPartOfDsmbarkTnCdd.Contains(search)
                                || t.sPersonDetailsPassangerPartOfDsmbarkTnName.Contains(search)
                                || t.sPersonDetailsPersonGenderCdd.Contains(search)
                                || t.sPersonDetailsPersonPlaceOfBirthName.Contains(search)
                                || t.sPersonDetailsPersonCountryOfBirthCdd.Contains(search)
                                || t.sPersonIdOrTravelDocIssuingNationCdd.Contains(search)
                                || t.sPersonIdOrTravelDocNo.Contains(search)
                                || t.sPersonIdOrTravelDocTypeCdd.Contains(search)
                                || t.sVisaDetailsPersonVisa.Contains(search)
                                || t.sVisaDetailsPNRNo.Contains(search)
                            )
                            && t.iMessageImplementationId == iMessageImplementationId
                            select t;
                recordsTotal = query.Count();
                return query.OrderBy(z => z.sPersonDetailsPersonFamilyName).Take(length).Skip(start).ToList().Select(t => new
                {
                    t.iMessageImplementationId,
                    t.dPersonOnBaordSeqNo,
                    t.iPersonOnBoardId,
                    t.sPersonDetailsPersonTypeCdd,
                    t.sPersonDetailsPersonFamilyName,
                    t.sPersonDetailsPersonGivenName,
                    t.sPersonDetailsPersonNationalityCdd,
                    t.dPersonDetailsPassengersInTransitIndicator,
                    t.sPersonDetailsCrewMemberRankOrRatingName,
                    t.sPersonDetailsCrewMemberRankOrRatingCdd,
                    t.sPersonDetailsPassangerPartOfEmbarkTnCdd,
                    t.sPersonDetailsPassangerPartOfEmbarkTnName,
                    t.sPersonDetailsPassangerPartOfDsmbarkTnCdd,
                    t.sPersonDetailsPassangerPartOfDsmbarkTnName,
                    t.sPersonDetailsPersonGenderCdd,
                    dtPersonDetailsPersonDateOfBirth= t.dtPersonDetailsPersonDateOfBirth.ToDateString(),
                    t.sPersonDetailsPersonPlaceOfBirthName,
                    t.sPersonDetailsPersonCountryOfBirthCdd,
                    dtPersonIdDocExpiryDate=t.dtPersonIdDocExpiryDate.ToDateString(),
                    t.sPersonIdOrTravelDocIssuingNationCdd,
                    t.sPersonIdOrTravelDocNo,
                    t.sPersonIdOrTravelDocTypeCdd,
                    t.sVisaDetailsPersonVisa,
                    t.sVisaDetailsPNRNo
                }).ToList();
            }
        }

        public PersonOnBoardMessageImplementationModel GetPersonOnBoardMessageImplementationByPersonOnBoardId(int? iPersonOnBoardId)
        {
            using (var db = new SeaManifestEntities())
            {
                return db.tblPersonOnBoardMessageImplementationMaps.Where(z => z.iPersonOnBoardId == iPersonOnBoardId).ToList().Select(model => new PersonOnBoardMessageImplementationModel
                {

                    iMessageImplementationId = model.iMessageImplementationId,
                    iPersonOnBoardId=model.iPersonOnBoardId,
                    dPersonOnBaordSeqNo = model.dPersonOnBaordSeqNo,
                    sPersonDetailsPersonTypeCdd = model.sPersonDetailsPersonTypeCdd,
                    sPersonDetailsPersonFamilyName = model.sPersonDetailsPersonFamilyName,
                    sPersonDetailsPersonGivenName = model.sPersonDetailsPersonGivenName,
                    sPersonDetailsPersonNationalityCdd = model.sPersonDetailsPersonNationalityCdd,
                    dPersonDetailsPassengersInTransitIndicator = model.dPersonDetailsPassengersInTransitIndicator,
                    sPersonDetailsCrewMemberRankOrRatingName = model.sPersonDetailsCrewMemberRankOrRatingName,
                    sPersonDetailsCrewMemberRankOrRatingCdd = model.sPersonDetailsCrewMemberRankOrRatingCdd,
                    sPersonDetailsPassangerPartOfEmbarkTnCdd = model.sPersonDetailsPassangerPartOfEmbarkTnCdd,
                    sPersonDetailsPassangerPartOfEmbarkTnName = model.sPersonDetailsPassangerPartOfEmbarkTnName,
                    sPersonDetailsPassangerPartOfDsmbarkTnCdd = model.sPersonDetailsPassangerPartOfDsmbarkTnCdd,
                    sPersonDetailsPassangerPartOfDsmbarkTnName = model.sPersonDetailsPassangerPartOfDsmbarkTnName,
                    sPersonDetailsPersonGenderCdd = model.sPersonDetailsPersonGenderCdd,
                    dtPersonDetailsPersonDateOfBirth = model.dtPersonDetailsPersonDateOfBirth.ToDateString(),
                    sPersonDetailsPersonPlaceOfBirthName = model.sPersonDetailsPersonPlaceOfBirthName,
                    sPersonDetailsPersonCountryOfBirthCdd = model.sPersonDetailsPersonCountryOfBirthCdd,
                    dtPersonIdDocExpiryDate = model.dtPersonIdDocExpiryDate.ToDateString(),
                    sPersonIdOrTravelDocIssuingNationCdd = model.sPersonIdOrTravelDocIssuingNationCdd,
                    sPersonIdOrTravelDocNo = model.sPersonIdOrTravelDocNo,
                    sPersonIdOrTravelDocTypeCdd = model.sPersonIdOrTravelDocTypeCdd,
                    sVisaDetailsPersonVisa = model.sVisaDetailsPersonVisa,
                    sVisaDetailsPNRNo = model.sVisaDetailsPNRNo,
                }).SingleOrDefault();
            }
        }
    }
}
