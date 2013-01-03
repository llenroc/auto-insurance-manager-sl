
namespace AutoInsurance.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies AgencyMetadata as the class
    // that carries additional metadata for the Agency class.
    [MetadataTypeAttribute(typeof(Agency.AgencyMetadata))]
    public partial class Agency
    {

        // This class allows you to attach custom attributes to properties
        // of the Agency class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class AgencyMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private AgencyMetadata()
            {
            }

            [Display(Name = "Адрес",
                     Description = "Адрес на агенцията",
                     AutoGenerateField = true,
                     Order = 2)]
            [Required(ErrorMessage = "Полето 'Адрес' е задължително")]
            public string Address { get; set; }

            [Display(Name = "Агенция",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            public string AgencyId { get; set; }

            public EntityCollection<InsurancePolicy> InsurancePolicies { get; set; }

            [Display(Name = "Име",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 1)]
            [Required(ErrorMessage = "Полето 'Име' е задължително")]
            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies AutoMetadata as the class
    // that carries additional metadata for the Auto class.
    [MetadataTypeAttribute(typeof(Auto.AutoMetadata))]
    public partial class Auto
    {

        // This class allows you to attach custom attributes to properties
        // of the Auto class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class AutoMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private AutoMetadata()
            {
            }

            [Display(Name = "ID",
             Description = "",
             AutoGenerateField = true,
             Order = 0)]
            [Required(ErrorMessage = "Полето '' е задължително")]
            public int AutoId { get; set; }


            public AutoType AutoType { get; set; }

            [Display(Name = "Тип",
             Description = "Тип на ватомобила",
             AutoGenerateField = true,
             Order = 0)]
            [Required(ErrorMessage = "Полето 'Тип на автомобила' е задължително")]
            public Nullable<int> AutoTypeId { get; set; }

            [Display(Name = "Цвят",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 2)]
            [Required(ErrorMessage = "Полето 'Цвят' е задължително")]
            public string Color { get; set; }

            [Display(Name = "Описание",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            public string Description { get; set; }

            [Display(Name = "Брой врати",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'Брой врати' е задължително")]
            public Nullable<int> DoorsCount { get; set; }

            [Display(Name = "Обем на двигателя (мм 3)",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'Обем на двигателя' е задължително")]
            public Nullable<int> EngineDisplacement { get; set; }

            [Display(Name = "Начална дата на регистрация",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'Начална дата на регистрация' е задължително")]
            public Nullable<DateTime> FirstRegistrationDate { get; set; }

            [Display(Name = "Рама номер",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'Рама номер' е задължително")]
            public string FrameNumber { get; set; }


            public FuelType FuelType { get; set; }

            [Display(Name = "Гориво",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'Гориво' е задължително")]
            public Nullable<int> FuelTypeId { get; set; }

            public EntityCollection<InsurancePolicy> InsurancePolicies { get; set; }

            [Display(Name = "Товар (за тежкотоварни автомобили)",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            public Nullable<int> LoadingCapacity { get; set; }

            [Display(Name = "Производител",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'Производител' е задължително")]
            public string Make { get; set; }

            [Display(Name = "Година на производство",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'Година на производство' е задължително")]
            public Nullable<int> MakeYear { get; set; }

            [Display(Name = "Модел",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'Модел' е задължително")]
            public string Model { get; set; }

            [Display(Name = "Собственик",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'Собственик' е задължително")]
            public Nullable<int> OwnerPersonId { get; set; }

            public Person Person { get; set; }

            public Purpose Purpos { get; set; }

            [Display(Name = "Предназначение",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'Предназначение' е задължително")]
            public Nullable<int> PurposeId { get; set; }

            [Display(Name = "Регистрационен номер",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'Регистрационен номер' е задължително")]
            public string RegNumber { get; set; }

            [Display(Name = "Брой места",
                     Description = "Брой Места",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'Брой места' е задължително")]
            public Nullable<int> SeatsCount { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies AutoTypeMetadata as the class
    // that carries additional metadata for the AutoType class.
    [MetadataTypeAttribute(typeof(AutoType.AutoTypeMetadata))]
    public partial class AutoType
    {

        // This class allows you to attach custom attributes to properties
        // of the AutoType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class AutoTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private AutoTypeMetadata()
            {
            }

            public EntityCollection<Auto> Autos { get; set; }

            public int AutoTypeId { get; set; }

            [Display(Name = "Коефициент ",
                     Description = "Коефициент за изчисление крайната цена",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'Коефициент' е задължително")]
            public Nullable<decimal> Coeficient { get; set; }

            [Display(Name = "Товарен ли е",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'Товарен ли е' е задължително")]
            public Nullable<bool> HasLoadingCapacity { get; set; }

            [Display(Name = "Наименование",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'Наименование' е задължително")]
            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies CompanyMetadata as the class
    // that carries additional metadata for the Company class.
    [MetadataTypeAttribute(typeof(Company.CompanyMetadata))]
    public partial class Company
    {

        // This class allows you to attach custom attributes to properties
        // of the Company class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class CompanyMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private CompanyMetadata()
            {
            }

            [Display(Name = "Цена за тип на автомобила",
                     Description = "За изисление",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето '' е задължително")]
            public Nullable<decimal> AutoTypePrice { get; set; }

            public int CompanyId { get; set; }

            public Nullable<decimal> InsuranceBasePrice { get; set; }

            public EntityCollection<InsurancePolicy> InsurancePolicies { get; set; }

            public Nullable<decimal> LoadingCapacityPricePer1000kg { get; set; }

            public string Name { get; set; }

            public Nullable<decimal> OldDriverCoeficient { get; set; }

            public Nullable<decimal> PurposePrice { get; set; }

            public Nullable<decimal> VechicleDisplacementPrice { get; set; }

            public Nullable<decimal> YoungDriverCoeficient { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies FuelTypeMetadata as the class
    // that carries additional metadata for the FuelType class.
    [MetadataTypeAttribute(typeof(FuelType.FuelTypeMetadata))]
    public partial class FuelType
    {

        // This class allows you to attach custom attributes to properties
        // of the FuelType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class FuelTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private FuelTypeMetadata()
            {
            }

            public EntityCollection<Auto> Autos { get; set; }

            public int FuelTypeId { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies InsurancePolicyMetadata as the class
    // that carries additional metadata for the InsurancePolicy class.
    [MetadataTypeAttribute(typeof(InsurancePolicy.InsurancePolicyMetadata))]
    public partial class InsurancePolicy
    {

        // This class allows you to attach custom attributes to properties
        // of the InsurancePolicy class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class InsurancePolicyMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private InsurancePolicyMetadata()
            {
            }

            public Agency Agency { get; set; }

            [Display(Name = "Агенция",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 5 )]
            [Required(ErrorMessage = "Полето 'Агенция' е задължително")]
            public string AgencyName { get; set; }

            public Auto Auto { get; set; }

            [Display(Name = "Автомобил",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 2)]
            [Required(ErrorMessage = "Полето 'Автомобил' е задължително")]
            public Nullable<int> AutoId { get; set; }

            public Company Company { get; set; }

            [Display(Name = "Застрахователна компания",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 6)]
            [Required(ErrorMessage = "Полето 'Застрахователна компания' е задължително")]
            public Nullable<int> CompanyId { get; set; }

            [Display(Name = "Опит на водача (години)",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 4)]
            [Required(ErrorMessage = "Полето 'Опит на водача' е задължително")]
            public Nullable<int> DriverExperienceYears { get; set; }

            [Display(Name = "Крайна дата на застраховката",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 8)]
            [Required(ErrorMessage = "Полето 'Крайна дата' е задължително")]
            public Nullable<DateTime> EndDate { get; set; }

            [Display(Name = "Има ли предишни инциденти",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 3)]
            [Required(ErrorMessage = "Полето 'Има ли предишни инциденти' е задължително")]
            [DefaultValue(false)]
            public Nullable<bool> HasAccidents { get; set; }

            public int InsurancePolicyId { get; set; }

            [Display(Name = "Дата на издаване",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 1)]
            [Required(ErrorMessage = "Полето 'Дата на издаване' е задължително")]
            public Nullable<DateTime> IssueDate { get; set; }

            [Display(Name = "Номер на полицата",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            public string Number { get; set; }

            [Display(Name = "Сума за плащане",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 9)]
            public Nullable<decimal> Price { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PersonMetadata as the class
    // that carries additional metadata for the Person class.
    [MetadataTypeAttribute(typeof(Person.PersonMetadata))]
    public partial class Person
    {

        // This class allows you to attach custom attributes to properties
        // of the Person class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PersonMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PersonMetadata()
            {
            }

            [Display(Name = "Адрес",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            //[Required(ErrorMessage = "Полето 'Адрес' е задължително")]
            public string Address { get; set; }

            public EntityCollection<Auto> Autos { get; set; }

            [Display(Name = "Име",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'Име' е задължително")]
            public string Name { get; set; }

            [Display(Name = "ЕГН",
                     Description = "",
                     AutoGenerateField = true,
                     Order = 0)]
            [Required(ErrorMessage = "Полето 'ЕГН' е задължително")]
            public string Number { get; set; }

            public int PersonId { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PurposeMetadata as the class
    // that carries additional metadata for the Purpose class.
    [MetadataTypeAttribute(typeof(Purpose.PurposeMetadata))]
    public partial class Purpose
    {

        // This class allows you to attach custom attributes to properties
        // of the Purpose class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PurposeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PurposeMetadata()
            {
            }

            public EntityCollection<Auto> Autos { get; set; }

            public Nullable<decimal> Coeficient { get; set; }

            public string Name { get; set; }

            public int PurposeId { get; set; }
        }
    }
}
