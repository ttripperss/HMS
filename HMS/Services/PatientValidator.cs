using System.Data;
using FluentValidation;
using HMS.Models;

namespace HMS.Validation
{
    internal sealed class PatientValidator : AbstractValidator<Patient>
    {


        public PatientValidator()
        {


            RuleFor(x => x.Age)
                .GreaterThanOrEqualTo(18)
                .WithMessage("Age should be greater than 18");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Name should be of max 20 characters");

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email is required");

            //RuleFor(p => p.Gender)
            //.IsInEnum()
            //.WithMessage("Invalid gender value. Please select 'Male', 'Female', or 'Other'.");

            RuleFor(p => p.ContactNumber)
         .NotEmpty()         
          .WithMessage("Invalid phone number. Must be 10-15 digits.");

           // RuleFor(p => p.DoctorId)
           //.NotEmpty().WithMessage("Doctor ID is required.")
           //.Must(id => Guid.TryParse(id.ToString(), out _))
           //.WithMessage("Invalid Doctor ID format.");










        }

        //private bool BeAValidPhoneNumber(int? contactNumber)
        //{
        //    if (!contactNumber.HasValue) return false;

        //    var contactNumberStr = contactNumber.Value.ToString();
        //    return contactNumberStr.Length >= 10 && contactNumberStr.Length <= 15;
        //}

    }
}







