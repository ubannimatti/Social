using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [MaxLength(30)]
        [DisplayName("ಹೆಸರು")]
        public required string EmployeeName { get; set; }

        [MaxLength(20)]
        [DisplayName("ಐ. ಡಿ. ನಂಬರ್")]
        public required string IdentityNumber { get; set; }

        [MaxLength(100)]
        [DisplayName("ವಿಳಾಸ")]
        public required string Address { get; set; }

        [MaxLength(20)]
        [DisplayName("ಗ್ರಾಮ")]
        public required string Village { get; set; }

        [MaxLength(20)]
        [DisplayName("ಗ್ರಾಮ ಪಂಚಾಯತಿ")]
        public required string VillagePanchayat { get; set; }

        [MaxLength(20)]
        [DisplayName("ತಾಲ್ಲೂಕು")]
        public required string Taluk { get; set; }

        [DisplayName("ಸ್ವಂತ ಮನೆ ಹೊಂದಿದ್ದಾರೆಯೇ?")]
        public required bool HasAHouse { get; set; }

        [MaxLength(20)]
        [DisplayName("ಸ್ವಂತ ಮನೆ ವಿಸ್ತೀರ್ಣ")]
        public string? HouseArea { get; set; }

        [DisplayName("ವಸತಿಗಾಗಿ ಅರ್ಜಿ ಸಲ್ಲಿಸಿದ್ದಾರೆಯೇ?")]
        public required bool AppliedForHouse { get; set; }

        [MaxLength(20)]
        [DisplayName("ವಸತಿಗಾಗಿ ಅರ್ಜಿ ಯೋಜನೆಯ ಹೆಸರು")]
        public string? HouseApplicationScheme { get; set; }


        [DisplayName("ನಿವೇಶನ ಹೊಂದಿದ್ದಾರೆಯೇ?")]
        public required bool HasASite { get; set; }

        [MaxLength(20)]
        [DisplayName("ನಿವೇಶನ ವಿಸ್ತೀರ್ಣ")]
        public string? SiteArea { get; set; }
        [DisplayName("ನಿವೇಶನಕ್ಕಾಗಿ ಅರ್ಜಿ ಸಲ್ಲಿಸಿದ್ದಾರೆಯೇ?")]
        public required bool AppliedForSite { get; set; }

        [MaxLength(20)]
        [DisplayName("ನಿವೇಶನಕ್ಕಾಗಿ ಅರ್ಜಿ ಯೋಜನೆಯ ಹೆಸರು")]
        public string? SiteApplicationScheme { get; set; }

        [DisplayName("ಶೌಚಾಲಯ ವ್ಯವಸ್ಥೆ ಇದೆಯೇ?")]
        public required bool HasAToilet { get; set; }

        [DisplayName("ವಿದ್ಯುತ್ ಶಕ್ತಿ ಸಂಪರ್ಕ ಇದೆಯೇ?")]
        public required bool HasElectricityConnection { get; set; }

        [DisplayName("ನೀರಿನ ಸಂಪರ್ಕ ಇದೆಯೇ?")]
        public required bool HasWaterConnection { get; set; }
        [DisplayName("ಆಧಾರ್ ಕಾರ್ಡ್ ಹೊಂದಿದ್ದಾರೆಯೇ?")]
        public required bool HasAadharCard { get; set; }
        [DisplayName("ಆಯುಷ್ಮಾನ್ ಭಾರತ್ ಕಾರ್ಡ್ ಇದೆಯೇ?")]
        public required bool HasAyushmanBharatCard { get; set; }

        [MaxLength(20)]
        [DisplayName("ಆಯುಷ್ಮಾನ್ ಭಾರತ್ ಕಾರ್ಡ್ ನಂಬರ್")]
        public string? AyushmanBharatCardNumber { get; set; }
        [DisplayName("ವಿಮೆ ಹೊಂದಿದ್ದಾರೆಯೇ?")]
        public required bool HasHealthInsurance { get; set; }

        [MaxLength(20)]
        [DisplayName("ವಿಮೆ ಹೆಸರು")]
        public string? HealthInsuranceName { get; set; }
        [DisplayName("ಪಡಿತರ ಚೀಟಿ ಇದೆಯೇ?")]
        public required bool HasRationCard { get; set; }
        [DisplayName("ಪಡಿತರ ಚೀಟಿಗಾಗಿ ಅರ್ಜಿ ಸಲ್ಲಿಸಿದ್ದಾರೆಯೇ?")]
        public required bool HasAppliedForRationCard { get; set; }
        [DisplayName("ನರೇಗಾ ಜಾಬ್ ಕಾರ್ಡ್ ಇದೆಯೇ?")]
        public required bool HasNaregaJobCard { get; set; }
    }
}
