using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        
        
        public string Fname { get; set; }
        
       [Required]

        public string Lname { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }
        public string PhoneNo { get; set; }
    }
    public class SellerRegisterViewModel
    {
        public SellerInfo SellerInfo;
        [Required]

        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]


        public string Fname { get; set; }

        [Required]

        public string Lname { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "thisfield is required")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "NAtional ID Must be 14 characters")]
        public string NationalID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(256)]
        public string BusinessName { get; set; }

        public string FrontImage { get; set; }

        public string BackImage { get; set; }
        [DataType(DataType.Date)]
        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

        public DateTime? ExpiredDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Street should be minimum 3 characters")]
        [DataType(DataType.Text)]
        public string Street { get; set; }
        public string BuildingNum { get; set; }
        [ForeignKey("SellerInfo")]


        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string LandLineNum { get; set; }



        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }
        public string PhoneNo { get; set; }
    }
    public class SellerEditViewModel
    {
        public SellerInfo SellerInfo;
        [Required]

        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]


        public string Fname { get; set; }

        [Required]

        public string Lname { get; set; }


        
        [Required(ErrorMessage = "thisfield is required")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "NAtional ID Must be 14 characters")]
        public string NationalID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(256)]
        public string BusinessName { get; set; }

        public string FrontImage { get; set; }

        public string BackImage { get; set; }
        [DataType(DataType.Date)]
        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

        public DateTime? ExpiredDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Street should be minimum 3 characters")]
        [DataType(DataType.Text)]
        public string Street { get; set; }
        public string BuildingNum { get; set; }
        [ForeignKey("SellerInfo")]


        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string LandLineNum { get; set; }



        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }
        public string PhoneNo { get; set; }
    }
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
